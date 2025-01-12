﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Composition.Attributes;
using SharpX.Composition.Interfaces;

namespace SharpX.Hlsl.CSharp.Enum;

[Backend]
public class PluginEntryPoint : IBackend
{
    public void EntryPoint(IBackendRegistry registry)
    {
        registry.RegisterBackendVisitor("HLSL", typeof(HlslNodeVisitor), typeof(HlslSyntaxNode), 1);
    }
}