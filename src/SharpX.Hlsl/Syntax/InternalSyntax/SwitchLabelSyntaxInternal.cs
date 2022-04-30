﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using Microsoft.CodeAnalysis;

using SharpX.Core;

namespace SharpX.Hlsl.Syntax.InternalSyntax;

internal abstract class SwitchLabelSyntaxInternal : HlslSyntaxNodeInternal
{
    protected SwitchLabelSyntaxInternal(SyntaxKind kind) : base(kind) { }
    protected SwitchLabelSyntaxInternal(SyntaxKind kind, DiagnosticInfo[]? diagnostics, SyntaxAnnotation[]? annotations) : base(kind, diagnostics, annotations) { }
}