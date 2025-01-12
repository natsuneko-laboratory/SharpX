﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Core;
using SharpX.Core.Syntax.InternalSyntax;

namespace SharpX.Hlsl.Syntax.InternalSyntax;

internal class BracketedArgumentListSyntaxInternal : BaseArgumentListSyntaxInternal
{
    private readonly GreenNode? _arguments;

    public SyntaxTokenInternal OpenBracketToken { get; }

    public SyntaxTokenInternal CloseBracketToken { get; }

    public override SeparatedSyntaxListInternal<ArgumentSyntaxInternal> Arguments => new(new SyntaxListInternal<HlslSyntaxNodeInternal>(_arguments));


    public BracketedArgumentListSyntaxInternal(SyntaxKind kind, SyntaxTokenInternal openBracketToken, GreenNode? arguments, SyntaxTokenInternal closeBracketToken) : base(kind)
    {
        SlotCount = 3;

        AdjustWidth(openBracketToken);
        OpenBracketToken = openBracketToken;

        if (arguments != null)
        {
            AdjustWidth(arguments);
            _arguments = arguments;
        }

        AdjustWidth(closeBracketToken);
        CloseBracketToken = closeBracketToken;
    }

    public BracketedArgumentListSyntaxInternal(SyntaxKind kind, SyntaxTokenInternal openBracketToken, GreenNode? arguments, SyntaxTokenInternal closeBracketToken, DiagnosticInfo[]? diagnostics) : base(kind, diagnostics)
    {
        SlotCount = 3;

        AdjustWidth(openBracketToken);
        OpenBracketToken = openBracketToken;

        if (arguments != null)
        {
            AdjustWidth(arguments);
            _arguments = arguments;
        }

        AdjustWidth(closeBracketToken);
        CloseBracketToken = closeBracketToken;
    }

    public override GreenNode SetDiagnostics(DiagnosticInfo[]? diagnostics)
    {
        return new BracketedArgumentListSyntaxInternal(Kind, OpenBracketToken, _arguments, CloseBracketToken, diagnostics);
    }

    public override GreenNode? GetSlot(int index)
    {
        return index switch
        {
            0 => OpenBracketToken,
            1 => _arguments,
            2 => CloseBracketToken,
            _ => null
        };
    }

    public override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        return new BracketedArgumentListSyntax(this, parent, position);
    }

    public override TResult? Accept<TResult>(HlslSyntaxVisitorInternal<TResult> visitor) where TResult : default
    {
        return visitor.VisitBracketedArgumentList(this);
    }
}