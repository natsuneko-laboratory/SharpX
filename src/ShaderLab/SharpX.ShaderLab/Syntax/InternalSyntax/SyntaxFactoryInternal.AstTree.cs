﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using SharpX.Core;
using SharpX.Core.Syntax.InternalSyntax;

namespace SharpX.ShaderLab.Syntax.InternalSyntax;

internal partial class SyntaxFactoryInternal
{
    public static IdentifierNameSyntaxInternal IdentifierName(SyntaxTokenInternal identifier)
    {
        if (identifier.Kind != SyntaxKind.IdentifierToken)
            throw new ArgumentException(nameof(identifier));

        return new IdentifierNameSyntaxInternal(SyntaxKind.IdentifierName, identifier);
    }

    public static QualifiedNameSyntaxInternal QualifiedName(NameSyntaxInternal left, SyntaxTokenInternal dotToken, SimpleNameSyntaxInternal right)
    {
        if (dotToken.Kind != SyntaxKind.DotToken)
            throw new ArgumentException(nameof(dotToken));

        return new QualifiedNameSyntaxInternal(SyntaxKind.QualifiedName, left, dotToken, right);
    }

    public static EqualsValueClauseSyntaxInternal EqualsValueClause(SyntaxTokenInternal equalsToken, ExpressionSyntaxInternal value)
    {
        if (equalsToken.Kind != SyntaxKind.EqualsToken)
            throw new ArgumentException(nameof(equalsToken));

        return new EqualsValueClauseSyntaxInternal(SyntaxKind.EqualsValueClause, equalsToken, value);
    }

    public static ArgumentListSyntaxInternal ArgumentList(SyntaxTokenInternal openParenToken, SeparatedSyntaxListInternal<ArgumentSyntaxInternal> arguments, SyntaxTokenInternal closeParenToken)
    {
        if (openParenToken.Kind != SyntaxKind.OpenParenToken)
            throw new ArgumentException(nameof(openParenToken));
        if (closeParenToken.Kind != SyntaxKind.CloseParenToken)
            throw new ArgumentException(nameof(closeParenToken));

        return new ArgumentListSyntaxInternal(SyntaxKind.ArgumentList, openParenToken, arguments.Node!, closeParenToken);
    }

    public static ArgumentSyntaxInternal Argument(ExpressionSyntaxInternal expression)
    {
        return new ArgumentSyntaxInternal(SyntaxKind.Argument, expression);
    }

    public static AttributeListSyntaxInternal AttributeList(SyntaxTokenInternal openBracketToken, SeparatedSyntaxListInternal<AttributeSyntaxInternal> attributes, SyntaxTokenInternal closeBracketToken)
    {
        if (openBracketToken.Kind != SyntaxKind.OpenBracketToken)
            throw new ArgumentException(nameof(openBracketToken));
        if (closeBracketToken.Kind != SyntaxKind.CloseBracketToken)
            throw new ArgumentException(nameof(closeBracketToken));

        return new AttributeListSyntaxInternal(SyntaxKind.AttributeList, openBracketToken, attributes.Node!, closeBracketToken);
    }

    public static AttributeSyntaxInternal Attribute(NameSyntaxInternal name, ArgumentListSyntaxInternal? argumentList)
    {
        return new AttributeSyntaxInternal(SyntaxKind.Attribute, name, argumentList);
    }

    public static LiteralExpressionSyntaxInternal LiteralExpression(SyntaxKind kind, SyntaxTokenInternal value)
    {
        switch (kind)
        {
            case SyntaxKind.NumericLiteralExpression:
            case SyntaxKind.StringLiteralExpression:
                break;

            default:
                throw new ArgumentException(nameof(kind));
        }

        switch (value.Kind)
        {
            case SyntaxKind.NumericLiteralToken:
            case SyntaxKind.StringLiteralToken:
                break;

            default:
                throw new ArgumentException(nameof(value));
        }

        return new LiteralExpressionSyntaxInternal(kind, value);
    }

    public static TextureLiteralExpressionSyntaxInternal TextureLiteralExpression(LiteralExpressionSyntaxInternal value, SyntaxTokenInternal openBraceToken, SyntaxTokenInternal closeBraceToken)
    {
        if (openBraceToken.Kind != SyntaxKind.OpenBraceToken)
            throw new ArgumentException(nameof(openBraceToken));
        if (closeBraceToken.Kind != SyntaxKind.CloseBraceToken)
            throw new ArgumentException(nameof(closeBraceToken));

        return new TextureLiteralExpressionSyntaxInternal(SyntaxKind.TextureLiteralExpression, value, openBraceToken, closeBraceToken);
    }

    public static CompilationUnitSyntaxInternal CompilationUnit(ShaderDeclarationSyntaxInternal shader, SyntaxTokenInternal endOfFileToken)
    {
        if (endOfFileToken.Kind != SyntaxKind.EndOfFileToken)
            throw new ArgumentException(nameof(endOfFileToken));

        return new CompilationUnitSyntaxInternal(SyntaxKind.CompilationUnit, shader, endOfFileToken);
    }

    public static ShaderDeclarationSyntaxInternal ShaderDeclaration(SyntaxTokenInternal shaderKeyword, SyntaxTokenInternal identifier, SyntaxTokenInternal openBraceToken, PropertiesDeclarationSyntaxInternal? properties, CgIncludeDeclarationSyntaxInternal? cgInclude,
                                                                    SyntaxListInternal<SubShaderDeclarationSyntaxInternal> subShaders, FallbackDeclarationSyntaxInternal? fallback, CustomEditorDeclarationSyntaxInternal? customEditor, SyntaxTokenInternal closeBraceToken)
    {
        if (shaderKeyword.Kind != SyntaxKind.ShaderKeyword)
            throw new ArgumentException(nameof(shaderKeyword));
        if (identifier.Kind != SyntaxKind.StringLiteralToken)
            throw new ArgumentException(nameof(identifier));
        if (openBraceToken.Kind != SyntaxKind.OpenBraceToken)
            throw new ArgumentException(nameof(openBraceToken));
        if (closeBraceToken.Kind != SyntaxKind.CloseBraceToken)
            throw new ArgumentException(nameof(closeBraceToken));

        return new ShaderDeclarationSyntaxInternal(
            SyntaxKind.ShaderDeclaration,
            shaderKeyword,
            identifier,
            openBraceToken,
            properties,
            cgInclude,
            subShaders.Node!,
            fallback,
            customEditor,
            closeBraceToken
        );
    }

    public static PropertiesDeclarationSyntaxInternal PropertiesDeclaration(SyntaxTokenInternal propertiesKeyword, SyntaxTokenInternal openBraceToken, SyntaxListInternal<PropertyDeclarationSyntaxInternal> properties, SyntaxTokenInternal closeBraceToken)
    {
        if (propertiesKeyword.Kind != SyntaxKind.PropertiesKeyword)
            throw new ArgumentException(nameof(propertiesKeyword));
        if (openBraceToken.Kind != SyntaxKind.OpenBraceToken)
            throw new ArgumentException(nameof(openBraceToken));
        if (closeBraceToken.Kind != SyntaxKind.CloseBraceToken)
            throw new ArgumentException(nameof(closeBraceToken));

        return new PropertiesDeclarationSyntaxInternal(SyntaxKind.PropertiesDeclaration, propertiesKeyword, openBraceToken, properties.Node!, closeBraceToken);
    }

    public static PropertyDeclarationSyntaxInternal PropertyDeclaration(AttributeListSyntaxInternal? attributeList, SyntaxTokenInternal identifier, SyntaxTokenInternal openParenToken, SyntaxTokenInternal displayName, SyntaxTokenInternal commaToken, SimpleNameSyntaxInternal type,
                                                                        ArgumentListSyntaxInternal? argumentList,
                                                                        SyntaxTokenInternal closeParenToken, EqualsValueClauseSyntaxInternal @default)
    {
        if (identifier.Kind != SyntaxKind.IdentifierToken)
            throw new ArgumentException(nameof(identifier));
        if (openParenToken.Kind != SyntaxKind.OpenParenToken)
            throw new ArgumentException(nameof(openParenToken));
        if (displayName.Kind != SyntaxKind.StringLiteralToken)
            throw new ArgumentException(nameof(displayName));
        if (commaToken.Kind != SyntaxKind.CommaToken)
            throw new ArgumentException(nameof(commaToken));
        if (closeParenToken.Kind != SyntaxKind.CloseParenToken)
            throw new ArgumentException(nameof(closeParenToken));

        return new PropertyDeclarationSyntaxInternal(SyntaxKind.PropertyDeclaration, attributeList, identifier, openParenToken, displayName, commaToken, type, argumentList, closeParenToken, @default);
    }

    public static SubShaderDeclarationSyntaxInternal SubShaderDeclaration(SyntaxTokenInternal subShaderKeyword, SyntaxTokenInternal openBraceToken, TagsDeclarationSyntaxInternal? tags, SyntaxListInternal<CommandDeclarationSyntaxInternal> commands, CgIncludeDeclarationSyntaxInternal? cgInclude,
                                                                          SyntaxListInternal<BasePassDeclarationSyntaxInternal> passes, SyntaxTokenInternal closeBraceToken)
    {
        if (subShaderKeyword.Kind != SyntaxKind.SubShaderKeyword)
            throw new ArgumentException(nameof(subShaderKeyword));
        if (openBraceToken.Kind != SyntaxKind.OpenBraceToken)
            throw new ArgumentException(nameof(openBraceToken));
        if (closeBraceToken.Kind != SyntaxKind.CloseBraceToken)
            throw new ArgumentException(nameof(closeBraceToken));

        return new SubShaderDeclarationSyntaxInternal(SyntaxKind.SubShaderDeclaration, subShaderKeyword, openBraceToken, tags, commands.Node!, cgInclude, passes.Node!, closeBraceToken);
    }

    public static CgIncludeDeclarationSyntaxInternal CgIncludeDeclaration(SyntaxTokenInternal cgIncludeKeyword, GreenNode source, SyntaxTokenInternal endCgKeyword)
    {
        if (cgIncludeKeyword.Kind != SyntaxKind.CgIncludeKeyword)
            throw new ArgumentException(nameof(cgIncludeKeyword));
        if (endCgKeyword.Kind != SyntaxKind.EndCgKeyword)
            throw new ArgumentException(nameof(endCgKeyword));

        return new CgIncludeDeclarationSyntaxInternal(SyntaxKind.CgIncludeDeclaration, cgIncludeKeyword, source, endCgKeyword);
    }

    public static CgProgramDeclarationSyntaxInternal CgProgramDeclaration(SyntaxTokenInternal cgProgramKeyword, GreenNode source, SyntaxTokenInternal endCgKeyword)
    {
        if (cgProgramKeyword.Kind != SyntaxKind.CgProgramKeyword)
            throw new ArgumentException(nameof(cgProgramKeyword));
        if (endCgKeyword.Kind != SyntaxKind.EndCgKeyword)
            throw new ArgumentException(nameof(endCgKeyword));

        return new CgProgramDeclarationSyntaxInternal(SyntaxKind.CgProgramDeclaration, cgProgramKeyword, source, endCgKeyword);
    }

    public static PassDeclarationSyntaxInternal PassDeclaration(SyntaxTokenInternal keyword, SyntaxTokenInternal openBraceToken, TagsDeclarationSyntaxInternal? tags, SyntaxListInternal<BaseCommandDeclarationSyntaxInternal> commands, CgProgramDeclarationSyntaxInternal cgProgram,
                                                                SyntaxTokenInternal closeBraceToken)
    {
        if (keyword.Kind != SyntaxKind.PassKeyword)
            throw new ArgumentException(nameof(keyword));
        if (openBraceToken.Kind != SyntaxKind.OpenBraceToken)
            throw new ArgumentException(nameof(openBraceToken));
        if (closeBraceToken.Kind != SyntaxKind.CloseBraceToken)
            throw new ArgumentException(nameof(closeBraceToken));
        return new PassDeclarationSyntaxInternal(SyntaxKind.PassDeclaration, keyword, openBraceToken, tags, commands.Node!, cgProgram, closeBraceToken);
    }

    public static GrabPassDeclarationSyntaxInternal GrabPassDeclaration(SyntaxTokenInternal keyword, SyntaxTokenInternal openBraceToken, SyntaxTokenInternal? identifier, TagsDeclarationSyntaxInternal? tags, NameDeclarationSyntaxInternal? name, SyntaxTokenInternal closeBraceToken)
    {
        if (keyword.Kind != SyntaxKind.GrabPassKeyword)
            throw new ArgumentException(nameof(keyword));
        if (openBraceToken.Kind != SyntaxKind.OpenBraceToken)
            throw new ArgumentException(nameof(openBraceToken));
        if (identifier != null && identifier.Kind != SyntaxKind.IdentifierToken)
            throw new ArgumentException(nameof(identifier));
        if (closeBraceToken.Kind != SyntaxKind.CloseBraceToken)
            throw new ArgumentException(nameof(closeBraceToken));

        return new GrabPassDeclarationSyntaxInternal(SyntaxKind.GrabPassDeclaration, keyword, openBraceToken, identifier, tags, name, closeBraceToken);
    }

    public static UsePassDeclarationSyntaxInternal UsePassDeclaration(SyntaxTokenInternal keyword, SyntaxTokenInternal passReference)
    {
        if (keyword.Kind != SyntaxKind.UsePassKeyword)
            throw new ArgumentException(nameof(keyword));
        if (passReference.Kind != SyntaxKind.StringLiteralToken)
            throw new ArgumentException(nameof(passReference));

        return new UsePassDeclarationSyntaxInternal(SyntaxKind.UsePassDeclaration, keyword, passReference);
    }

    public static CommandDeclarationSyntaxInternal CommandDeclaration(SyntaxTokenInternal keyword, SeparatedSyntaxListInternal<IdentifierNameSyntaxInternal> arguments)
    {
        if (keyword.Kind != SyntaxKind.IdentifierToken)
            throw new ArgumentException(nameof(keyword));

        return new CommandDeclarationSyntaxInternal(SyntaxKind.CommandDeclaration, keyword, arguments.Node!);
    }

    public static StencilDeclarationSyntaxInternal StencilDeclaration(SyntaxTokenInternal keyword, SyntaxTokenInternal openBraceToken, SyntaxListInternal<CommandDeclarationSyntaxInternal> commands, SyntaxTokenInternal closeBraceToken)
    {
        if (keyword.Kind != SyntaxKind.StencilKeyword)
            throw new ArgumentException(nameof(keyword));
        if (openBraceToken.Kind != SyntaxKind.OpenBraceToken)
            throw new ArgumentException(nameof(openBraceToken));
        if (closeBraceToken.Kind != SyntaxKind.CloseBraceToken)
            throw new ArgumentException(nameof(closeBraceToken));

        return new StencilDeclarationSyntaxInternal(SyntaxKind.StencilDeclaration, keyword, openBraceToken, commands.Node!, closeBraceToken);
    }

    public static NameDeclarationSyntaxInternal NameDeclaration(SyntaxTokenInternal keyword, SyntaxTokenInternal name)
    {
        if (keyword.Kind != SyntaxKind.NameKeyword)
            throw new ArgumentException(nameof(keyword));
        if (name.Kind != SyntaxKind.StringLiteralToken)
            throw new ArgumentException(nameof(name));

        return new NameDeclarationSyntaxInternal(SyntaxKind.NameDeclaration, keyword, name);
    }

    public static TagsDeclarationSyntaxInternal TagsDeclaration(SyntaxTokenInternal tagsKeyword, SyntaxTokenInternal openBraceToken, SyntaxListInternal<TagDeclarationSyntaxInternal> tags, SyntaxTokenInternal closeBraceToken)
    {
        if (tagsKeyword.Kind != SyntaxKind.TagsKeyword)
            throw new ArgumentException(nameof(tagsKeyword));
        if (openBraceToken.Kind != SyntaxKind.OpenBraceToken)
            throw new ArgumentException(nameof(openBraceToken));
        if (closeBraceToken.Kind != SyntaxKind.CloseBraceToken)
            throw new ArgumentException(nameof(closeBraceToken));

        return new TagsDeclarationSyntaxInternal(SyntaxKind.TagsDeclaration, tagsKeyword, openBraceToken, tags.Node!, closeBraceToken);
    }

    public static TagDeclarationSyntaxInternal TagDeclaration(SyntaxTokenInternal key, SyntaxTokenInternal equalsToken, SyntaxTokenInternal value)
    {
        if (key.Kind != SyntaxKind.StringLiteralToken)
            throw new ArgumentException(nameof(key));
        if (equalsToken.Kind != SyntaxKind.EqualsToken)
            throw new ArgumentException(nameof(equalsToken));
        if (value.Kind != SyntaxKind.StringLiteralToken)
            throw new ArgumentException(nameof(value));

        return new TagDeclarationSyntaxInternal(SyntaxKind.TagDeclaration, key, equalsToken, value);
    }

    public static FallbackDeclarationSyntaxInternal FallbackDeclaration(SyntaxTokenInternal fallbackKeyword, SyntaxTokenInternal shaderNameOrOffKeyword)
    {
        if (fallbackKeyword.Kind != SyntaxKind.FallbackKeyword)
            throw new ArgumentException(nameof(fallbackKeyword));

        switch (shaderNameOrOffKeyword.Kind)
        {
            case SyntaxKind.StringLiteralToken:
            case SyntaxKind.OffKeyword:
                break;

            default:
                throw new ArgumentException(nameof(shaderNameOrOffKeyword));
        }

        return new FallbackDeclarationSyntaxInternal(SyntaxKind.FallbackDeclaration, fallbackKeyword, shaderNameOrOffKeyword);
    }

    public static CustomEditorDeclarationSyntaxInternal CustomEditorDeclaration(SyntaxTokenInternal customEditorKeyword, SyntaxTokenInternal fullyQualifiedInspectorName)
    {
        if (customEditorKeyword.Kind != SyntaxKind.CustomEditorKeyword)
            throw new ArgumentException(nameof(customEditorKeyword));
        if (fullyQualifiedInspectorName.Kind != SyntaxKind.StringLiteralToken)
            throw new ArgumentException(nameof(fullyQualifiedInspectorName));

        return new CustomEditorDeclarationSyntaxInternal(SyntaxKind.CustomEditorDeclaration, customEditorKeyword, fullyQualifiedInspectorName);
    }

    public static HlslSourceSyntaxInternal HlslSource(GreenNode sources)
    {
        return new HlslSourceSyntaxInternal(SyntaxKind.HlslSourceUnit, sources);
    }
}