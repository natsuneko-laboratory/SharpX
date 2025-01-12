﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace SharpX.CLI.Models;

public class SharpXConfig
{
    [JsonPropertyName("compilerOptions")]
    public CompilerOptions CompilerOptions { get; set; }

    [JsonPropertyName("files")]
    public List<string> Files { get; set; }

    [JsonPropertyName("includes")]
    public List<string> Includes { get; set; }

    [JsonPropertyName("excludes")]
    public List<string> Excludes { get; set; }

    [JsonPropertyName("languages")]
    public List<string> Languages { get; set; }

    [JsonPropertyName("plugins")]
    public List<string> Plugins { get; set; }

    public static SharpXConfig Default => new()
    {
        CompilerOptions = new CompilerOptions
        {
            Libraries = new List<string>(),
            OutDir = "./out/",
            BaseUrl = "./src/",
            Target = "none"
        },
        Files = new List<string>(),
        Includes = new List<string> { "./src/" },
        Excludes = new List<string>(),
        Languages = new List<string>(),
        Plugins = new List<string>()
    };
}