namespace CommerceCQRS.Services.Shared.Application
{
    public class ErrorResult : IOperationResult
    {
        public ErrorResult(IList<OperationError> errors)
        {
            this.Errors = errors;
        }
        public bool Succeed()
        {
            return false;
        }

        public IList<OperationError> Errors { get; set; }
    }
}
