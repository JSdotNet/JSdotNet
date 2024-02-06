namespace JSdotNet.Domain.Abstractions.Test;

internal static class AssertionExtensions
{
    internal static ErrorAssertions Should(this Error? instance) => new(instance);
}