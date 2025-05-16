namespace CommerceCQRS.Services.Shared.Domain
{
    public class DomainException:System.Exception
    {
        public int ErrorCode { get; }

        public DomainException(int errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}
