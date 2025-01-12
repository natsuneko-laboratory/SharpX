﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Core;

namespace SharpX.ShaderLab;

public enum SyntaxKind
{
    None = 0,

    List = GreenNode.ListKind,

    #region punctuation

    /// <summary>Represents <c>(</c> token.</summary>
    OpenParenToken,

    /// <summary>Represents <c>)</c> token.</summary>
    CloseParenToken,

    /// <summary>Represents <c>+</c> token.</summary>
    PlusToken,

    /// <summary>Represents <c>-</c> token.</summary>
    MinusToken,

    /// <summary>Represents <c>=</c> token.</summary>
    EqualsToken,

    /// <summary>Represents <c>{</c> token.</summary>
    OpenBraceToken,

    /// <summary>Represents <c>}</c> token.</summary>
    CloseBraceToken,

    /// <summary>Represents <c>[</c> token.</summary>
    OpenBracketToken,

    /// <summary>Represents <c>]</c> token.</summary>
    CloseBracketToken,

    /// <summary>Represents <c>"</c> token.</summary>
    DoubleQuoteToken,

    /// <summary>Represents <c>,</c> token.</summary>
    CommaToken,

    /// <summary>Represents <c>.</c> token.</summary>
    DotToken,

    #endregion

    #region keywords

    CgIncludeKeyword,

    CgProgramKeyword,

    ColorKeyword,

    CustomEditorKeyword,

    EndCgKeyword,

    FallbackKeyword,

    FloatKeyword,

    GrabPassKeyword,

    IntKeyword,

    NameKeyword,

    OffKeyword,

    PassKeyword,

    PropertiesKeyword,

    ShaderKeyword,

    StencilKeyword,

    SubShaderKeyword,

    TagsKeyword,

    Texture2DKeyword,

    Texture3DKeyword,

    TextureCubeKeyword,

    UsePassKeyword,

    RangeKeyword,

    VectorKeyword,

    #endregion

    #region tokens

    EndOfFileToken,

    IdentifierToken,

    NumericLiteralToken,

    StringLiteralToken,

    #endregion

    #region trivia

    EndOfLineTrivia,

    WhitespaceTrivia,

    #endregion

    #region name & type-names

    IdentifierName,

    QualifiedName,

    #endregion

    #region expressions

    EqualsValueClause,

    ArgumentList,

    Argument,

    CommandArgumentList,

    ParenthesizedExpression,

    #endregion

    #region literal expressions

    TextureLiteralExpression,

    NumericLiteralExpression,

    StringLiteralExpression,

    #endregion

    #region declarations

    CgIncludeDeclaration,

    CgProgramDeclaration,

    CommandDeclaration,

    CompilationUnit,

    CustomEditorDeclaration,

    FallbackDeclaration,

    GrabPassDeclaration,

    HlslSourceUnit,

    NameDeclaration,

    PropertiesDeclaration,

    PropertyDeclaration,

    PassDeclaration,

    ShaderDeclaration,

    StencilDeclaration,

    SubShaderDeclaration,

    TagsDeclaration,

    TagDeclaration,

    UsePassDeclaration,

    #endregion

    #region attributes

    AttributeList,

    Attribute,

    #endregion
}