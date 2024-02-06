using FluentAssertions.Primitives;

namespace JSdotNet.Domain.Abstractions.Test;

internal sealed class ErrorAssertions(Error? instance) : ReferenceTypeAssertions<Error?, ErrorAssertions>(instance)
{
    protected override string Identifier => "error";


    public AndConstraint<ErrorAssertions> Be(string code, string because = "", params object[] becauseArgs)
    {
        Subject.Should().NotBeNull();
        Subject!.Value.Code.Should().Be(code);

        return new AndConstraint<ErrorAssertions>(this);
    }
}
