using System.Reflection;

namespace JSdotNet.Blog.Presentation.Web;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;

    public static readonly Assembly[] Assemblies =
    [
        Assembly,
        Client.AssemblyReference.Assembly,
    ];
}