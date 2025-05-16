namespace CommerceCQRS.Services.Shared.Application
{
    public interface IOperationResult
    {
        bool Succeed();

        public IList<OperationError> Errors { get; }
    }
}
