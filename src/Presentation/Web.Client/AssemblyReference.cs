using System.Reflection;

namespace JSdotNet.Web.Client;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}