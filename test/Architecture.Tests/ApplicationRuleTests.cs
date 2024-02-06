using System.Reflection;
using JSdotNet.Architecture.Tests.Rules;

namespace JSdotNet.Architecture.Tests;

public sealed class ApplicationRuleTests : ApplicationRules
{
    protected override Assembly ApplicationAssembly => Component.ApplicationAssembly;

    protected override string[] PresentationProjects => Component.PresentationNamespaces;
    protected override string[] Domain => Component.DomainNamespaces;
    protected override string[] Infrastructure => Component.InfrastructureNamespaces;
}
