using System.Reflection;

namespace JSdotNet.Blog.Presentation.Endpoints;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}