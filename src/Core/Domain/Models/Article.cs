using System.Diagnostics;
using JSdotNet.Domain.Abstractions;
using JSdotNet.Domain.Abstractions.Model;

namespace JSdotNet.Domain.Models;

[DebuggerDisplay("{Id}: {Title}")]
public sealed class Article : AggregateRoot
{
    private Article() : base(default!) { }

    private Article(Guid id) : base(id) { }


    public DateTime CreatedAt { get; private init; } = DateTime.UtcNow;
    public DateTime LastUpdated { get; private set; } = DateTime.UtcNow;

    public string Title { get; private init; } = default!;
    public string Summary { get; private set; } = default!;

    public string Route { get; private init; } = default!;



    private readonly List<string> _tags = [];
    public IReadOnlyList<string> Tags => _tags.AsReadOnly();
}



[DebuggerDisplay("{Id}: {Title}")]
public abstract class Tag : AggregateRoot<string>
{
    protected Tag() : base(default!) { }

    protected Tag(string value) : base(value) { }

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
    Project
}

[DebuggerDisplay("{Id}")]
public sealed class Tool : Tag
{
    private Tool() : base(default!) { }

    private Tool(string value) : base(value) { }

}


[DebuggerDisplay("{Id}")]
public sealed class Skill : Tag
{
    private Skill() : base(default!) { }

    private Skill(string value) : base(value) { }

}



[DebuggerDisplay("{Id}")]
public sealed class DesignPattern : Tag
{
    private DesignPattern() : base(default!) { }

    private DesignPattern(string value) : base(value) { }

}


[DebuggerDisplay("{Id}")]
public sealed class Practice : Tag
{
    private Practice() : base(default!) { }

    private Practice(string value) : base(value) { }

}



[DebuggerDisplay("{Id}")]
public sealed class Principle : Tag
{
    private Principle() : base(default!) { }

    private Principle(string value) : base(value) { }

}



[DebuggerDisplay("{Id}")]
public sealed class Package : Tag
{
    private Package() : base(default!) { }

    private Package(string value) : base(value) { }

    public string? Url { get; private init; }
}


[DebuggerDisplay("{Id}")]
public sealed class Technology : Tag
{
    private Technology() : base(default!) { }

    private Technology(string value) : base(value) { }

}


[DebuggerDisplay("{Id}")]
public sealed class KnowledgeEvent : Tag
{
    private KnowledgeEvent() : base(default!) { }

    private KnowledgeEvent(string value) : base(value) { }

    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }

}



[DebuggerDisplay("{Id}")]
public sealed class Project : Tag
{
    private Project() : base(default!) { }

    private Project(string value) : base(value) { }

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