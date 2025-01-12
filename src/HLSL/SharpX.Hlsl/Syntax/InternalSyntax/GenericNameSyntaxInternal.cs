﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Core;

namespace SharpX.Hlsl.Syntax.InternalSyntax;

internal class GenericNameSyntaxInternal : SimpleNameSyntaxInternal
{
    public TypeArgumentListSyntaxInternal TypeArgumentList { get; }

    public override SyntaxTokenInternal Identifier { get; }

    public GenericNameSyntaxInternal(SyntaxKind kind, SyntaxTokenInternal identifier, TypeArgumentListSyntaxInternal typeArgumentList) : base(kind)
    {
        SlotCount = 2;

        AdjustWidth(identifier);
        Identifier = identifier;

        AdjustWidth(typeArgumentList);
        TypeArgumentList = typeArgumentList;
    }

    public GenericNameSyntaxInternal(SyntaxKind kind, SyntaxTokenInternal identifier, TypeArgumentListSyntaxInternal typeArgumentList, DiagnosticInfo[]? diagnostics) : base(kind, diagnostics)
    {
        SlotCount = 2;

        AdjustWidth(identifier);
        Identifier = identifier;

        AdjustWidth(typeArgumentList);
        TypeArgumentList = typeArgumentList;
    }

    public override GreenNode SetDiagnostics(DiagnosticInfo[]? diagnostics)
    {
        return new GenericNameSyntaxInternal(Kind, Identifier, TypeArgumentList, diagnostics);
    }

    public override GreenNode? GetSlot(int index)
    {
        return index switch
        {
            0 => Identifier,
            1 => TypeArgumentList,
            _ => null
        };
    }

    public override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        return new GenericNameSyntax(this, parent, position);
    }

    public override TResult? Accept<TResult>(HlslSyntaxVisitorInternal<TResult> visitor) where TResult : default
    {
        return visitor.VisitGenericName(this);
    }
}