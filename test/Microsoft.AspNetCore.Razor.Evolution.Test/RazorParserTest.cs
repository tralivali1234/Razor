// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.IO;
using Microsoft.AspNetCore.Razor.Evolution.SyntaxTreePhase.Parser;
using Xunit;

namespace Microsoft.AspNetCore.Razor.Evolution
{
    public class RazorParserTest
    {
        [Fact]
        public void CanParseStuff()
        {
            var parser = new RazorParser();
            var filePath = "TestFiles/Source/BasicMarkup.cshtml";
            var fileStream = File.OpenRead(filePath);
            var sourceDocument = RazorSourceDocument.ReadFrom(fileStream, filePath);
            var documentReader = sourceDocument.CreateReader();
            var output = parser.Parse(documentReader);

            Assert.NotNull(output);
        }
    }
}
