using JSdotNet.Blog.Domain.Models;

namespace JSdotNet.Blog.Presentation.Web.Data;

internal static class TestData
{
    internal static IList<Article> GetArticles()
    {
        var articles = new List<Article>
        {
            Article.Create(new DateOnly(2024, 01, 05), "Article 1", Lorem, "Article1", new TagKey(TagType.Tool, "VS")),
            Article.Create(new DateOnly(2024, 01, 07), "Article 2", Lorem, "article2", new TagKey(TagType.Tool, "VS")),
            Article.Create(new DateOnly(2024, 01, 08), "Article 3", Lorem, "article3"),
            Article.Create(new DateOnly(2024, 01, 10), "Article 4", Lorem, "article4"),
            Article.Create(new DateOnly(2024, 01, 15), "Article 5", Lorem, "article5"),
            Article.Create(new DateOnly(2024, 01, 16), "Article 6", Lorem, "article6"),
            Article.Create(new DateOnly(2024, 01, 17), "Article 7", Lorem, "article7"),
            Article.Create(new DateOnly(2024, 01, 18), "Article 8", Lorem, "article8"),
            Article.Create(new DateOnly(2024, 01, 19), "Article 9", Lorem, "article9"),
            Article.Create(new DateOnly(2024, 01, 20), "Article 10", Lorem, "article10")
        };

        return articles.AsReadOnly();
    }



    private const string Lorem = "<b>Lorem ipsum dolor sit amet</b>, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
}
