﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Hlsl.Primitives.Attributes.Compiler;
#if INCLUDE_MATRIX_INTELLISENSE
using SharpX.Hlsl.SourceGenerator.Attributes;
#endif

namespace SharpX.Hlsl.Primitives.Types;

[Component("&T2x4")]
[ExternalComponent]
#if INCLUDE_MATRIX_INTELLISENSE
[Swizzle("_00", "_01", "_02", "_03", "_10", "_11", "_12", "_13")]
#endif
// ReSharper disable once InconsistentNaming
public
#if INCLUDE_MATRIX_INTELLISENSE
    partial
#endif
    class Matrix2x4<T>
{
    public Matrix2x4(Vector1<T> _) { }

    public Matrix2x4(Vector1<T> _00, Vector1<T> _01, Vector1<T> _02, Vector1<T> _03, Vector1<T> _10, Vector1<T> _11, Vector1<T> _12, Vector1<T> _13) { }

    public Matrix2x4(Vector2<T> _0, Vector2<T> _1, Vector2<T> _2, Vector2<T> _3) { }
}