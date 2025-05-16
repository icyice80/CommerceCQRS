using System.Text.Json.Serialization;

namespace CommerceCQRS.Services.Shared.Application
{
    public class OperationResultBase : IOperationResult
    {
        [JsonIgnore] 
        public IList<OperationError> Errors { get; } = new List<OperationError>();

        /// <inheritdoc />
        public virtual bool Succeed()
        {
            return this.Errors.Any() == false;
        }
    }
}
