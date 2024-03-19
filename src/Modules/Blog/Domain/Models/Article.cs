using System.Diagnostics;

using JSdotNet.Common.Domain.Model;

namespace JSdotNet.Blog.Domain.Models;

[DebuggerDisplay("{Id}: {Title}")]
public sealed class Article : AggregateRoot
{
    private Article() : base(default!) { }

    private Article(Guid id) : base(id) { }


    public DateOnly CreatedAt { get; private init; }
    public DateOnly LastUpdated { get; private set; }

    public string Title { get; private set; } = default!;
    public string Summary { get; private set; } = default!;

    public string Route { get; private set; } = default!;
    


    private readonly List<TagKey> _tags = [];
    public IReadOnlyList<TagKey> Tags => _tags.AsReadOnly();

    // TODO Image?

    public static Article Create(DateOnly createdAt, string title, string summary, string route, params TagKey[] tags)
    {
        var article = new Article(Guid.NewGuid())
        {
            CreatedAt = createdAt,
            Title = title,
            Summary = summary,
            Route = route
        };

        article._tags.AddRange(tags);

        return article;
    }


    public void Update(string title, string summary, string route, IEnumerable<TagKey> tags)
    {
        Title = title;
        Summary = summary;
        Route = route;

        _tags.Clear();
        _tags.AddRange(tags);

        LastUpdated = DateOnly.FromDateTime(DateTime.Now);
    }
}

public sealed record TagKey(TagType Type, string Value);

[DebuggerDisplay("{Id}: {Title}")]
public abstract class Tag : AggregateRoot<TagKey>
{
    protected Tag() : base(default!) { }

    protected Tag(TagKey value) : base(value) { }

    public TagType Type { get; private set; }
}


public enum TagType
{
    Tool,
    Skill,
    Technology,
    Package,
    DesignPattern,
    Principle,
    Practice,
}

[DebuggerDisplay("{Id}")]
public sealed class Tool : Tag
{
    private Tool() : base(default!) { }

    private Tool(string value) : base(new TagKey(TagType.Tool, value)) { }

    public string Name { get; private init; } = default!;
    public string? Description { get; private init; } = default!;

    private readonly List<TagKey> _tags = [];
    public IReadOnlyList<TagKey> Tags => _tags.AsReadOnly();

    public static Tool Create(string id, string name, string? description = null, params TagKey[] tags)
    {
        var result = new Tool(id)
        {
            Name = name,
            Description = description
        };

        result._tags.AddRange(tags);

        return result;
    }

}


[DebuggerDisplay("{Id}")]
public sealed class Skill : Tag
{
    private Skill() : base(default!) { }

    private Skill(string value) : base(new TagKey(TagType.Skill, value)) { }

}



[DebuggerDisplay("{Id}")]
public sealed class DesignPattern : Tag
{
    private DesignPattern() : base(default!) { }

    private DesignPattern(string value) : base(new TagKey(TagType.DesignPattern, value)) { }

}


[DebuggerDisplay("{Id}")]
public sealed class Practice : Tag
{
    private Practice() : base(default!) { }

    private Practice(string value) : base(new TagKey(TagType.Practice, value)) { }

}



[DebuggerDisplay("{Id}")]
public sealed class Principle : Tag
{
    private Principle() : base(default!) { }

    private Principle(string value) : base(new TagKey(TagType.Principle, value)) { }

}



[DebuggerDisplay("{Id}")]
public sealed class Package : Tag
{
    private Package() : base(default!) { }

    private Package(string value) : base(new TagKey(TagType.Package, value)) { }

    public string? Url { get; private init; }
}


[DebuggerDisplay("{Id}")]
public sealed class Technology : Tag
{
    private Technology() : base(default!) { }

    private Technology(string value) : base(new TagKey(TagType.Technology, value)) { }

}


//[DebuggerDisplay("{Id}")]
//public sealed class KnowledgeEvent : Tag
//{
//    private KnowledgeEvent() : base(default!) { }

//    private KnowledgeEvent(string value) : base(new TagKey(TagType.KnowledgeEvent, value)) { }

//    public DateOnly Start { get; set; }
//    public DateOnly End { get; set; }

//}



[DebuggerDisplay("{Id}")]
public sealed class Project : AggregateRoot
{
    private Project() : base(default!) { }

    private Project(Guid value) : base(value) { }

    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }

    public Employer? Employer { get; set; }
    public Customer? Customer { get; set; }
}


public sealed record Employer(string Name, string Url); // TODO Entity?
public sealed record Customer(string Name, string Url); // TODO Entity?



//[DebuggerDisplay("{Id}")]
//public sealed class Product : Tag
//{
//    private Product() : base(default!) { }

//    private Product(string value) : base(value) { }

//    public string? Version { get; set; }


//}