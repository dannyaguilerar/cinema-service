using Cinema.Core.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Core.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(
    ILogger<ValidationBehavior<TRequest, TResponse>> _logger, 
    IEnumerable<IValidator<TRequest>> _validators) : 
    IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
    private const string ExecutionMessage = "Validation for {@Request} started.";
    private const string SuccessMessage = "Validation for {@Request} passed.";
    private const string FailedMessage = "Validation for {@Request} failed with {@Errors} errors.";

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }
        _logger.LogInformation(ExecutionMessage, request.GetType().Name);
        var context = new ValidationContext<TRequest>(request);
        var errorsDictionary = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);
        if (errorsDictionary.Count > 0)
        {
            _logger.LogInformation(FailedMessage, request.GetType().Name, errorsDictionary.Count);
            throw new InvalidRequestException(request.GetType().Name, errorsDictionary);
        }
        _logger.LogInformation(SuccessMessage, request.GetType().Name);
        return await next();
    }
}
