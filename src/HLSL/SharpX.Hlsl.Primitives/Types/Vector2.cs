﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Hlsl.Primitives.Attributes.Compiler;
using SharpX.Hlsl.SourceGenerator.Attributes;

#pragma warning disable CS0626, CS0660, CS0661

namespace SharpX.Hlsl.Primitives.Types;

[Component("&T2")]
[ExternalComponent]
[Swizzle("X", "Y")]
[Swizzle("R", "G")]
public sealed partial class Vector2<T>
{
    public Vector2(Vector1<T> _1, Vector1<T> _2) { }

    [ImplicitCastInCompiler]
    public static extern explicit operator Vector2<T>(T _);

    [ImplicitCastInCompiler]
    public static extern explicit operator Vector2<T>(Vector1<T> _);

    [ImplicitCastInCompiler]
    public static extern explicit operator Vector2<T>(Vector3<T> _);

    [ImplicitCastInCompiler]
    public static extern explicit operator Vector2<T>(Vector4<T> _);

    public static extern bool operator >(Vector2<T> a, Vector2<T> b);

    public static extern bool operator >=(Vector2<T> a, Vector2<T> b);

    public static extern bool operator <(Vector2<T> a, Vector2<T> b);

    public static extern bool operator <=(Vector2<T> a, Vector2<T> b);

    public static extern bool operator !=(Vector2<T> a, Vector2<T> b);

    public static extern bool operator ==(Vector2<T> a, Vector2<T> b);

    public static extern Vector2<T> operator +(Vector2<T> a, Vector2<T> b);

    public static extern Vector2<T> operator -(Vector2<T> a, Vector2<T> b);

    public static extern Vector2<T> operator *(Vector2<T> a, Vector2<T> b);

    public static extern Vector2<T> operator /(Vector2<T> a, Vector2<T> b);

    public static extern Vector2<T> operator %(Vector2<T> a, Vector2<T> b);

    public static extern Vector2<T> operator +(Vector2<T> a, T b);

    public static extern Vector2<T> operator -(Vector2<T> a, T b);

    public static extern Vector2<T> operator *(Vector2<T> a, T b);

    public static extern Vector2<T> operator /(Vector2<T> a, T b);

    public static extern Vector2<T> operator %(Vector2<T> a, T b);

    public static extern Vector2<T> operator +(T a, Vector2<T> b);

    public static extern Vector2<T> operator -(T a, Vector2<T> b);

    public static extern Vector2<T> operator *(T a, Vector2<T> b);

    public static extern Vector2<T> operator /(T a, Vector2<T> b);

    public static extern Vector2<T> operator %(T a, Vector2<T> b);

    public static extern Vector2<T> operator +(Vector2<T> a, Vector1<T> b);

    public static extern Vector2<T> operator -(Vector2<T> a, Vector1<T> b);

    public static extern Vector2<T> operator *(Vector2<T> a, Vector1<T> b);

    public static extern Vector2<T> operator /(Vector2<T> a, Vector1<T> b);

    public static extern Vector2<T> operator %(Vector2<T> a, Vector1<T> b);

    public static extern Vector2<T> operator +(Vector2<T> a, Vector3<T> b);

    public static extern Vector2<T> operator -(Vector2<T> a, Vector3<T> b);

    public static extern Vector2<T> operator *(Vector2<T> a, Vector3<T> b);

    public static extern Vector2<T> operator /(Vector2<T> a, Vector3<T> b);

    public static extern Vector2<T> operator %(Vector2<T> a, Vector3<T> b);

    public static extern Vector2<T> operator +(Vector2<T> a, Vector4<T> b);

    public static extern Vector2<T> operator -(Vector2<T> a, Vector4<T> b);

    public static extern Vector2<T> operator *(Vector2<T> a, Vector4<T> b);

    public static extern Vector2<T> operator /(Vector2<T> a, Vector4<T> b);

    public static extern Vector2<T> operator %(Vector2<T> a, Vector4<T> b);
}

