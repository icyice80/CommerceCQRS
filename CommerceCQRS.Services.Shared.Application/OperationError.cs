namespace CommerceCQRS.Services.Shared.Application
{
    public class OperationError
    {
        public OperationError(int errorCode, string title, string message)
        {
            this.ErrorCode = errorCode;
            this.Title = title;
            this.Message = message;
        }

        public int ErrorCode { get; }
        public string Title { get; }
        public string Message { get; }

    }
}
