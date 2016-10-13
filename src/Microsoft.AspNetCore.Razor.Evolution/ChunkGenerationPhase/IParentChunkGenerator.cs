// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Razor.Evolution.SyntaxTreePhase;

namespace Microsoft.AspNetCore.Razor.Evolution.ChunkGenerationPhase
{
    public interface IParentChunkGenerator
    {
        void GenerateStartParentChunk(Block target, ChunkGeneratorContext context);
        void GenerateEndParentChunk(Block target, ChunkGeneratorContext context);
    }
}
