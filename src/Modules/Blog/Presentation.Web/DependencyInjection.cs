namespace JSdotNet.Blog.Presentation.Web;

public static class DependencyInjection
{
    public static RazorComponentsEndpointConventionBuilder AddBlog(this RazorComponentsEndpointConventionBuilder builder, IConfiguration _)
    {
        return builder.AddAdditionalAssemblies(AssemblyReference.Assemblies);
    }
}