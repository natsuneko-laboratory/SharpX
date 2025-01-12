﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

namespace SharpX.Core;

/// <summary>
///     represents <see cref="Microsoft.CodeAnalysis.SyntaxToken" />
/// </summary>
public readonly struct SyntaxToken : IEquatable<SyntaxToken>
{
    public static readonly Func<SyntaxToken, bool> NonZeroWidth = t => t.Width > 0;
    public static readonly Func<SyntaxToken, bool> Any = t => true;

    public SyntaxToken(SyntaxNode? parent, GreenNode? token, int position, int index)
    {
        Parent = parent;
        Node = token;
        Index = index;
        Position = position;
    }

    public SyntaxToken(GreenNode? token) : this()
    {
        Node = token;
    }

    public int RawKind => Node?.RawKind ?? 0;

    public string Language => Node?.Language ?? string.Empty;

    public SyntaxNode? Parent { get; }

    public GreenNode? Node { get; }

    public GreenNode RequiredNode
    {
        get
        {
            var node = Node;
            Contract.AssertNotNull(node);

            return node;
        }
    }

    public int Index { get; }

    public int Position { get; }

    public int Width => Node?.Width ?? 0;

    public int FullWidth => Node?.FullWidth ?? 0;

    public TextSpan Span => Node != null ? new TextSpan(Position + Node.GetLeadingTriviaWidth(), Node.Width) : default;

    public TextSpan FullSpan => new(Position, FullWidth);

    #region Trivia

    public SyntaxTriviaList LeadingTrivia => Node != null ? new SyntaxTriviaList(this, Node.GetLeadingTrivia(), Position) : default;

    public int LeadingWidth => Node?.GetLeadingTriviaWidth() ?? 0;

    public SyntaxTriviaList TrailingTrivia
    {
        get
        {
            if (Node == null)
                return default;

            var leading = Node.GetLeadingTrivia();
            var index = 0;
            if (leading != null)
                index = leading.IsList ? leading.SlotCount : 1;

            var trailing = Node.GetTrailingTrivia();
            var trailingPosition = Position + FullWidth;
            if (trailing != null)
                trailingPosition -= trailing.FullWidth;

            return new SyntaxTriviaList(this, trailing, trailingPosition, index);
        }
    }

    public int TrailingWidth => Node?.GetTrailingTriviaWidth() ?? 0;

    public string Text => ToString();

    public SyntaxToken WithLeadingTrivia(SyntaxTriviaList trivia)
    {
        return WithLeadingTrivia((IEnumerable<SyntaxTrivia>)trivia);
    }

    public SyntaxToken WithLeadingTrivia(params SyntaxTrivia[] trivia)
    {
        return WithLeadingTrivia((IEnumerable<SyntaxTrivia>)trivia);
    }

    public SyntaxToken WithLeadingTrivia(IEnumerable<SyntaxTrivia> trivia)
    {
        if (Node == null)
            return default;

        return new SyntaxToken(null, Node.WithLeadingTrivia(GreenNode.CreateList(trivia, static w => w.RequiredUnderlyingNode)), 0, 0);
    }

    public SyntaxToken WithTrailingTrivia(SyntaxTriviaList trivia)
    {
        return WithTrailingTrivia((IEnumerable<SyntaxTrivia>)trivia);
    }

    public SyntaxToken WithTrailingTrivia(params SyntaxTrivia[] trivia)
    {
        return WithTrailingTrivia((IEnumerable<SyntaxTrivia>)trivia);
    }

    public SyntaxToken WithTrailingTrivia(IEnumerable<SyntaxTrivia> trivia)
    {
        if (Node == null)
            return default;

        return new SyntaxToken(null, Node.WithTrailingTrivia(GreenNode.CreateList(trivia, static w => w.RequiredUnderlyingNode)), 0, 0);
    }

    #endregion

    public override string ToString()
    {
        return Node != null ? Node.ToString() : string.Empty;
    }

    public static bool operator ==(SyntaxToken left, SyntaxToken right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(SyntaxToken left, SyntaxToken right)
    {
        return !left.Equals(right);
    }

    public bool Equals(SyntaxToken other)
    {
        return Parent == other.Parent && Node == other.Node && Position == other.Position && Index == other.Index;
    }

    public override bool Equals(object? obj)
    {
        return obj is SyntaxToken other && Equals(other);
    }

    public SyntaxToken GetNextToken(Func<SyntaxToken, bool> predicate, Func<SyntaxTrivia, bool>? stepInto = null)
    {
        if (Node == null)
            return default;
        return SyntaxNavigator.Instance.GetNextToken(this, predicate, stepInto);
    }

    public override int GetHashCode()
    {
#if NET5_0_OR_GREATER
        return HashCode.Combine(Parent, Node, Index, Position);
#else
        unchecked
        {
            var hashCode = Parent != null ? Parent.GetHashCode() : 0;
            hashCode = (hashCode * 397) ^ (Node != null ? Node.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ Index;
            hashCode = (hashCode * 397) ^ Position;
            return hashCode;
        }
#endif
    }
}