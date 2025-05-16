namespace CommerceCQRS.Cart.Write.Application
{
    public class ErrorCode
    {

        public const int SystemInternalError = 1;

        public const int Unknown = 100;
        public const int NotFound = 101;
        public const int InvalidCartStatus = 102;
        public const int InvalidQuantity = 103;
        public const int EmptyCart = 104;
        public const int MissingUserIdOrAnonymousId = 105;
    }
}
