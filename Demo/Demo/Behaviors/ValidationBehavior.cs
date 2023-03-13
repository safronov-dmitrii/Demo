﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
        var context = new ValidationContext<TRequest>(request);

        ValidationResult[] validationResults = 
            await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken))); 
        
        IEnumerable<ValidationFailure> failures = validationResults
            .SelectMany(result => result.Errors)
            .Where(f => f is not null);

        if (failures.Any())
            throw new ValidationException(failures); 
        
        return await next();
    }
}