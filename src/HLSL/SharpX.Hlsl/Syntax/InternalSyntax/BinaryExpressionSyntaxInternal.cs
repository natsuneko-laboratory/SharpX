﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Core;

namespace SharpX.Hlsl.Syntax.InternalSyntax;

internal class BinaryExpressionSyntaxInternal : ExpressionSyntaxInternal
{
    public ExpressionSyntaxInternal Left { get; }

    public SyntaxTokenInternal OperatorToken { get; }

    public ExpressionSyntaxInternal Right { get; }

    public BinaryExpressionSyntaxInternal(SyntaxKind kind, ExpressionSyntaxInternal left, SyntaxTokenInternal operatorToken, ExpressionSyntaxInternal right) : base(kind)
    {
        SlotCount = 3;

        AdjustWidth(left);
        Left = left;

        AdjustWidth(operatorToken);
        OperatorToken = operatorToken;

        AdjustWidth(right);
        Right = right;
    }

    public BinaryExpressionSyntaxInternal(SyntaxKind kind, ExpressionSyntaxInternal left, SyntaxTokenInternal operatorToken, ExpressionSyntaxInternal right, DiagnosticInfo[]? diagnostics) : base(kind, diagnostics)
    {
        SlotCount = 3;

        AdjustWidth(left);
        Left = left;

        AdjustWidth(operatorToken);
        OperatorToken = operatorToken;

        AdjustWidth(right);
        Right = right;
    }

    public override GreenNode SetDiagnostics(DiagnosticInfo[]? diagnostics)
    {
        return new BinaryExpressionSyntaxInternal(Kind, Left, OperatorToken, Right, diagnostics);
    }

    public override GreenNode? GetSlot(int index)
    {
        return index switch
        {
            0 => Left,
            1 => OperatorToken,
            2 => Right,
            _ => null
        };
    }

    public override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        return new BinaryExpressionSyntax(this, parent, position);
    }

    public override TResult? Accept<TResult>(HlslSyntaxVisitorInternal<TResult> visitor) where TResult : default
    {
        return visitor.VisitBinaryExpression(this);
    }
}