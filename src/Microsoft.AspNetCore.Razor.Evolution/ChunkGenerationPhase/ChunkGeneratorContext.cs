// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Razor.Evolution.ChunkGenerationPhase
{
    public class ChunkGeneratorContext
    {
        public ChunkGeneratorContext(
            string className,
            string rootNamespace,
            string sourceFile,
            bool shouldGenerateLinePragmas)
        {
            //ChunkTreeBuilder = new ChunkTreeBuilder();
            SourceFile = shouldGenerateLinePragmas ? sourceFile : null;
            RootNamespace = rootNamespace;
            ClassName = className;
        }

        public string SourceFile { get; internal set; }

        public string RootNamespace { get; }

        public string ClassName { get; }

        //public ChunkTreeBuilder ChunkTreeBuilder { get; set; }
    }
}
