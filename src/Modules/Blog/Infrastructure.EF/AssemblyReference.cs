using System.Reflection;

namespace JSdotNet.Blog.Infrastructure.EF;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}