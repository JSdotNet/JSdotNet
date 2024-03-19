using JSdotNet.Common.Domain;

namespace JSdotNet.Domain.Tests;

internal static class AssertionExtensions
{
    internal static ErrorAssertions Should(this Error? instance) => new(instance);
}