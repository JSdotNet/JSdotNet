using System.Reflection;

namespace JSdotNet.Blog.Domain;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}