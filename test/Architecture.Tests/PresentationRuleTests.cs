using System.Reflection;
using JSdotNet.Architecture.Tests.Rules;

namespace JSdotNet.Architecture.Tests;

// ReSharper disable once UnusedMember.Global
public sealed class PresentationRuleTests : PresentationRules
{
    protected override Assembly PresentationAssembly => Component.PresentationAssembly;

    protected override string[] Infrastructure => Component.InfrastructureNamespaces;
    protected override string[] Application => Component.ApplicationNamespaces;
}