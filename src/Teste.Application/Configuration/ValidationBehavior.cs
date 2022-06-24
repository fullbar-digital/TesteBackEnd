using FluentValidation;
using MediatR;

namespace Teste.Application.Configuration
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context,cancellationToken)))
                                              .ConfigureAwait(false);

                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                {
                    var errors = new List<ValidationError>();

                    failures.ForEach(fail => errors.Add(new ValidationError(fail.PropertyName, fail.ErrorMessage)));
                    throw new ValidationException()
                }
            }            
            
            return next();
        }
    }
}
