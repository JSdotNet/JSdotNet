﻿using JSdotNet.Common.Domain;

namespace JSdotNet.Application.@_.Behaviors;

public interface IValidationResult
{
    public static Error ValidationError => new("ValidationError", "A validation problem occurred");

    Error[] Errors { get; }
}


public record ValidationResult : Result, IValidationResult
{
    private ValidationResult(Error[] errors) : base(false, IValidationResult.ValidationError)
    {
        Errors = errors;
    }

    public Error[] Errors { get; }

    public static ValidationResult WithErrors(Error[] errors) => new(errors);
}


public record ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    private ValidationResult(Error[] errors) : base(default, false, IValidationResult.ValidationError)
    {
        Errors = errors;
    }

    public Error[] Errors { get; }


#pragma warning disable CA1000 // TODO Review coding rule
    public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);
#pragma warning restore CA1000
}