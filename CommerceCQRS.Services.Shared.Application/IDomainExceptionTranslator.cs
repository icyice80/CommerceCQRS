using CommerceCQRS.Services.Shared.Domain;

namespace CommerceCQRS.Services.Shared.Application
{
    public interface IDomainExceptionTranslator
    {
        OperationError Translate(DomainException exception);
    }
}
