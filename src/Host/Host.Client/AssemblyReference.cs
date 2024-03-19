using System.Reflection;

namespace JSdotNet.Host.Client;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}