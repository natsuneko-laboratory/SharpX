﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Core;
using SharpX.Core.Syntax.InternalSyntax;

namespace SharpX.Hlsl.Syntax.InternalSyntax;

internal class WarningSpecifierListSyntaxInternal : HlslSyntaxNodeInternal
{
    private readonly GreenNode? _specifiers;

    public SeparatedSyntaxListInternal<WarningSpecifierSyntaxInternal> Specifiers => new(new SyntaxListInternal<HlslSyntaxNodeInternal>(_specifiers));

    public WarningSpecifierListSyntaxInternal(SyntaxKind kind, GreenNode? specifiers) : base(kind)
    {
        SlotCount = 1;

        if (specifiers != null)
        {
            AdjustWidth(specifiers);
            _specifiers = specifiers;
        }
    }

    public WarningSpecifierListSyntaxInternal(SyntaxKind kind, GreenNode? specifiers, DiagnosticInfo[]? diagnostics) : base(kind, diagnostics)
    {
        SlotCount = 1;

        if (specifiers != null)
        {
            AdjustWidth(specifiers);
            _specifiers = specifiers;
        }
    }

    public override GreenNode SetDiagnostics(DiagnosticInfo[]? diagnostics)
    {
        return new WarningSpecifierListSyntaxInternal(Kind, _specifiers, diagnostics);
    }

    public override GreenNode? GetSlot(int index)
    {
        return index switch
        {
            0 => _specifiers,
            _ => null
        };
    }

    public override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        throw new NotImplementedException();
    }

    public override TResult? Accept<TResult>(HlslSyntaxVisitorInternal<TResult> visitor) where TResult : default
    {
        throw new NotImplementedException();
    }
}