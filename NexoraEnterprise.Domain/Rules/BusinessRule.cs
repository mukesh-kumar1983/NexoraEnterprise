namespace NexoraEnterprise.Domain.Rules;

/// <summary>
/// Represents the base class for business rules.
/// </summary>
public abstract class BusinessRule : IBusinessRule
{
    /// <inheritdoc />
    public abstract bool IsBroken();

    /// <inheritdoc />
    public abstract string Message { get; }

    public abstract string ErrorCode { get; }

    // MAY BE USED IN THE FUTURE TO PROVIDE A UNIQUE ERROR CODE FOR EACH BUSINESS RULE
    //public virtual string ErrorCode => GetType().Name;

}