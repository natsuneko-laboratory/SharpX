﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

namespace SharpX.ShaderLab.Syntax;

internal static class SyntaxFacts
{
    public static string GetText(SyntaxKind kind)
    {
        return kind switch
        {
            SyntaxKind.OpenParenToken => "(",
            SyntaxKind.CloseParenToken => ")",
            SyntaxKind.PlusToken => "+",
            SyntaxKind.MinusToken => "-",
            SyntaxKind.EqualsToken => "=",
            SyntaxKind.OpenBraceToken => "{",
            SyntaxKind.CloseBraceToken => "}",
            SyntaxKind.OpenBracketToken => "[",
            SyntaxKind.CloseBracketToken => "]",
            SyntaxKind.CommaToken => ",",
            SyntaxKind.DoubleQuoteToken => "\"",
            SyntaxKind.DotToken => ".",
            SyntaxKind.CgIncludeKeyword => "CGINCLUDE",
            SyntaxKind.CgProgramKeyword => "CGPROGRAM",
            SyntaxKind.ColorKeyword => "Color",
            SyntaxKind.CustomEditorKeyword => "CustomEditor",
            SyntaxKind.EndCgKeyword => "ENDCG",
            SyntaxKind.FallbackKeyword => "Fallback",
            SyntaxKind.FloatKeyword => "Float",
            SyntaxKind.IntKeyword => "Int",
            SyntaxKind.NameKeyword => "Name",
            SyntaxKind.OffKeyword => "Off",
            SyntaxKind.PassKeyword => "Pass",
            SyntaxKind.PropertiesKeyword => "Properties",
            SyntaxKind.ShaderKeyword => "Shader",
            SyntaxKind.SubShaderKeyword => "SubShader",
            SyntaxKind.TagsKeyword => "Tags",
            SyntaxKind.Texture2DKeyword => "2D",
            SyntaxKind.Texture3DKeyword => "3D",
            SyntaxKind.TextureCubeKeyword => "Cube",
            SyntaxKind.RangeKeyword => "Range",
            SyntaxKind.VectorKeyword => "Vector"
        };
    }
}