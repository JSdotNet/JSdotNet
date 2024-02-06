using System.Diagnostics;
using JSdotNet.Domain.Abstractions;

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
public sealed class Pattern : Tag
{
    private Pattern() : base(default!) { }

    private Pattern(string value) : base(value) { }

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

}