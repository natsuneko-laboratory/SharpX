﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Core;
using SharpX.Core.Syntax.InternalSyntax;

namespace SharpX.ShaderLab.Syntax.InternalSyntax;

internal class CommandDeclarationSyntaxInternal : BaseCommandDeclarationSyntaxInternal
{
    private readonly GreenNode _arguments;

    public override SyntaxTokenInternal Keyword { get; }

    public SeparatedSyntaxListInternal<IdentifierNameSyntaxInternal> Arguments => new(_arguments);

    public CommandDeclarationSyntaxInternal(SyntaxKind kind, SyntaxTokenInternal keyword, GreenNode arguments) : base(kind)
    {
        SlotCount = 2;

        AdjustWidth(keyword);
        Keyword = keyword;

        AdjustWidth(arguments);
        _arguments = arguments;
    }

    public CommandDeclarationSyntaxInternal(SyntaxKind kind, SyntaxTokenInternal keyword, GreenNode arguments, DiagnosticInfo[]? diagnostics) : base(kind, diagnostics)
    {
        SlotCount = 2;

        AdjustWidth(keyword);
        Keyword = keyword;

        AdjustWidth(arguments);
        _arguments = arguments;
    }

    public override GreenNode SetDiagnostics(DiagnosticInfo[]? diagnostics)
    {
        return new CommandDeclarationSyntaxInternal(Kind, Keyword, _arguments, diagnostics);
    }

    public override GreenNode? GetSlot(int index)
    {
        return index switch
        {
            0 => Keyword,
            1 => _arguments,
            _ => null
        };
    }

    public override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        return new CommandDeclarationSyntax(this, parent, position);
    }
}