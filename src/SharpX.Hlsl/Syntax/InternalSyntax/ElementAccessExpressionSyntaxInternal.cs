﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using Microsoft.CodeAnalysis;

using SharpX.Core;

using SyntaxNode = SharpX.Core.SyntaxNode;

namespace SharpX.Hlsl.Syntax.InternalSyntax;

internal class ElementAccessExpressionSyntaxInternal : ExpressionSyntaxInternal
{
    public ExpressionSyntaxInternal Expression { get; }

    public BracketedArgumentListSyntaxInternal ArgumentList { get; }

    public ElementAccessExpressionSyntaxInternal(SyntaxKind kind, ExpressionSyntaxInternal expression, BracketedArgumentListSyntaxInternal argumentList) : base(kind)
    {
        SlotCount = 2;

        AdjustWidth(expression);
        Expression = expression;

        AdjustWidth(argumentList);
        ArgumentList = argumentList;
    }

    public ElementAccessExpressionSyntaxInternal(SyntaxKind kind, ExpressionSyntaxInternal expression, BracketedArgumentListSyntaxInternal argumentList, DiagnosticInfo[]? diagnostics, SyntaxAnnotation[]? annotations) : base(kind, diagnostics, annotations)
    {
        SlotCount = 2;

        AdjustWidth(expression);
        Expression = expression;

        AdjustWidth(argumentList);
        ArgumentList = argumentList;
    }

    public override GreenNode SetAnnotations(SyntaxAnnotation[]? annotations)
    {
        return new ElementAccessExpressionSyntaxInternal(Kind, Expression, ArgumentList, GetDiagnostics(), annotations);
    }

    public override GreenNode SetDiagnostics(DiagnosticInfo[]? diagnostics)
    {
        return new ElementAccessExpressionSyntaxInternal(Kind, Expression, ArgumentList, diagnostics, GetAnnotations());
    }

    public override GreenNode? GetSlot(int index)
    {
        return index switch
        {
            0 => Expression,
            1 => ArgumentList,
            _ => null
        };
    }

    public override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        return new ElementAccessExpressionSyntax(this, parent, position);
    }
}