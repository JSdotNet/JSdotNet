using System.Reflection;
using JSdotNet.Architecture.Tests.Rules;

namespace JSdotNet.Architecture.Tests;

// ReSharper disable once UnusedMember.Global
public sealed class DomainRuleTests : DomainRules
{
    protected override Assembly DomainAssembly => Component.DomainAssembly;

    protected override string[]? DomainAbstractionAssemblies => null;
    protected override string[] Application => Component.ApplicationNamespaces;
    protected override string[] Presentation => Component.PresentationNamespaces;
    protected override string[] Infrastructure => Component.InfrastructureNamespaces;
}