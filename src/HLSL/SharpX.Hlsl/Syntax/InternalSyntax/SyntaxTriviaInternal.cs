﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Core;

namespace SharpX.Hlsl.Syntax.InternalSyntax;

internal class SyntaxTriviaInternal : HlslSyntaxNodeInternal
{
    private readonly string _text;

    public override bool IsTrivia => true;

    public SyntaxTriviaInternal(SyntaxKind kind, string text, DiagnosticInfo[]? diagnostics = null) : base(kind, text.Length, diagnostics)
    {
        _text = text;
    }

    public override GreenNode SetDiagnostics(DiagnosticInfo[]? diagnostics)
    {
        return new SyntaxTriviaInternal(Kind, _text, diagnostics);
    }

    public override GreenNode? GetSlot(int index)
    {
        throw Exceptions.Unreachable;
    }

    public override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        throw Exceptions.Unreachable;
    }

    public override string ToFullString()
    {
        return _text;
    }

    public override string ToString()
    {
        return _text;
    }

    protected override void WriteTriviaTo(TextWriter writer)
    {
        writer.Write(_text);
    }

    public static implicit operator SyntaxTrivia(SyntaxTriviaInternal trivia)
    {
        return new SyntaxTrivia(default, trivia, 0, 0);
    }

    public override TResult? Accept<TResult>(HlslSyntaxVisitorInternal<TResult> visitor) where TResult : default
    {
        return visitor.VisitTrivia(this);
    }
}