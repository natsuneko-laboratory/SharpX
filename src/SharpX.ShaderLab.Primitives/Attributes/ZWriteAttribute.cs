﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.ShaderLab.Primitives.Enum;

namespace SharpX.ShaderLab.Primitives.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ZWriteAttribute : Attribute
{
    public ZWriteAttribute(ZWrite a) { }

    public ZWriteAttribute(string a) { }
}