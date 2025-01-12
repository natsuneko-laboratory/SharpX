﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Core;
using SharpX.Core.Syntax.InternalSyntax;

namespace SharpX.ShaderLab.Syntax.InternalSyntax;

internal class TagsDeclarationSyntaxInternal : ShaderLabSyntaxNodeInternal
{
    private readonly GreenNode _tags;

    public SyntaxTokenInternal TagsKeyword { get; }

    public SyntaxTokenInternal OpenBraceToken { get; }

    public SyntaxListInternal<TagDeclarationSyntaxInternal> Tags => new(_tags);

    public SyntaxTokenInternal CloseBraceToken { get; }

    public TagsDeclarationSyntaxInternal(SyntaxKind kind, SyntaxTokenInternal tagsKeyword, SyntaxTokenInternal openBraceToken, GreenNode tags, SyntaxTokenInternal closeBraceToken) : base(kind)
    {
        SlotCount = 4;

        AdjustWidth(tagsKeyword);
        TagsKeyword = tagsKeyword;

        AdjustWidth(openBraceToken);
        OpenBraceToken = openBraceToken;

        AdjustWidth(tags);
        _tags = tags;

        AdjustWidth(closeBraceToken);
        CloseBraceToken = closeBraceToken;
    }

    public TagsDeclarationSyntaxInternal(SyntaxKind kind, SyntaxTokenInternal tagsKeyword, SyntaxTokenInternal openBraceToken, GreenNode tags, SyntaxTokenInternal closeBraceToken, DiagnosticInfo[]? diagnostics) : base(kind, diagnostics)
    {
        SlotCount = 4;

        AdjustWidth(tagsKeyword);
        TagsKeyword = tagsKeyword;

        AdjustWidth(openBraceToken);
        OpenBraceToken = openBraceToken;

        AdjustWidth(tags);
        _tags = tags;

        AdjustWidth(closeBraceToken);
        CloseBraceToken = closeBraceToken;
    }

    public override GreenNode SetDiagnostics(DiagnosticInfo[]? diagnostics)
    {
        return new TagsDeclarationSyntaxInternal(Kind, TagsKeyword, OpenBraceToken, _tags, CloseBraceToken, diagnostics);
    }

    public override GreenNode? GetSlot(int index)
    {
        return index switch
        {
            0 => TagsKeyword,
            1 => OpenBraceToken,
            2 => _tags,
            3 => CloseBraceToken,
            _ => null
        };
    }

    public override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        return new TagsDeclarationSyntax(this, parent, position);
    }
}