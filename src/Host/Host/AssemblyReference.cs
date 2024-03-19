using System.Reflection;

namespace JSdotNet.Host;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;


    public static readonly Assembly[] AdditionalAssemblies =
    [
        Client.AssemblyReference.Assembly,
        ..Blog.Presentation.Web.AssemblyReference.Assemblies,
    ];
}