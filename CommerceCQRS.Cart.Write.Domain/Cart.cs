using CommerceCQRS.Cart.Write.Domain.Dtos;
using CommerceCQRS.Cart.Write.Domain.Events;
using CommerceCQRS.Cart.Write.Domain.Exception;
using CommerceCQRS.Services.Shared.Domain;

namespace CommerceCQRS.Cart.Write.Domain
{
    public class Cart : AggregateRoot<Guid>
    {
        public Cart(Guid id, Guid userId) : base(id)
        {

            this.UserId = userId;
        }

        public Guid Id { get; }
        public Guid UserId { get; private set; }

        public List<CartItem> Items { get; } = new();
        public CartStatus Status { get; private set; } = CartStatus.Pending;

        public void AddItem(Guid productId, int quantity)
        {
            this.CheckForEditable();

            var existing = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existing != null)
            {
                existing.UpdateQuantity(quantity);
            }
            else
            {
                Items.Add(new CartItem(productId, quantity));
            }

            //raise domain events
            this.AddDomainEvent(new CartItemAddedDomainEvent(this.Id, productId, quantity));
        }

        public void RemoveItem(Guid productId)
        {
            this.CheckForEditable();

            var existing = Items.FirstOrDefault(i => i.ProductId == productId);

            if (existing == null)
                throw new DomainException((int)ErrorCode.NotFound, "Item not found in the cart");

            this.Items.Remove(existing);

            //raise domain events
            this.AddDomainEvent(new CartItemRemovedDomainEvent(Id, productId));
        }

        public void AssignToUser(Guid userId)
        {
            this.UserId = userId;
        }

        public void MergeWith(Cart sourceCart)
        {
            foreach (var item in sourceCart.Items)
            {
                var existing = Items.FirstOrDefault(i => i.ProductId == item.ProductId);
                if (existing != null)
                {
                    existing.UpdateQuantity(item.Quantity);
                }
                else
                {
                    Items.Add(new CartItem(item.ProductId, item.Quantity));
                }
            }
        }

        public void Checkout()
        {
            this.CheckForEditable();

            if (!this.Items.Any())
                throw new DomainException((int)ErrorCode.EmptyCart, "Cannot checkout empty cart");

            this.Status = CartStatus.CheckedOut;
            this.AddDomainEvent(new CartCheckedOutDomainEvent(this.Id,this.UserId, CartItemMapper.ToDtoList(this.Items)));
        }

        private void CheckForEditable()
        {
            if (this.Status != CartStatus.Pending)
            {
                throw new DomainException((int)ErrorCode.InvalidCartStatus,
                    "Cannot modify a cart that is not pending.");
            }

        }
    }

}
