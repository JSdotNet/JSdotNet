using System.Reflection;
using JSdotNet.Api;

namespace JSdotNet.Architecture.Tests;

internal static class Component
{
    private const string Namespace = "Solution_Template";

    internal static string[] DomainNamespaces =>
    [
        $"{Namespace}.Domain"
    ];

    internal static string[] ApplicationNamespaces =>
    [
        $"{Namespace}.Application"
    ];

    internal static string[] PresentationNamespaces =>
    [
        $"{Namespace}.Presentation"
    ];

    internal static string[] InfrastructureNamespaces =>
    [
        $"{Namespace}.Infrastructure.EF"
    ];


    internal static Assembly DomainAssembly => Domain.AssemblyReference.Assembly;

    //internal static string[]? DomainAbstractionAssemblies => null;
    ////{
    ////    //typeof(Shared.Business.Abstractions.Constants.ClaimConstants).Assembly.FullName!,
    ////    //typeof(Infrastructure.Business.Entity).Assembly.FullName!,
    ////    //typeof(Infrastructure.Utils.ClaimModel).Assembly.FullName!,
    ////};

    internal static Assembly ApplicationAssembly => Application.AssemblyReference.Assembly;
    internal static Assembly[] InfrastructureAssembly => []; // TODO Infrastructure.EF.AssemblyReference.Assembly
    internal static Assembly PresentationAssembly => AssemblyReference.Assembly;
}
