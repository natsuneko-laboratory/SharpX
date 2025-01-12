﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

namespace SharpX.ShaderLab.Primitives.Attributes.Compiler;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
public class ShaderPragmaAttribute : Attribute
{
    public ShaderPragmaAttribute(string key, params string[] args) { }
}