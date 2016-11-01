// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.AspNetCore.Razor.Evolution.Intermediate
{
    public class LoweringIntegrationTest
    {
        [Fact]
        public void Lower_EmptyDocument()
        {
            var codeDocument = TestRazorCodeDocument.CreateEmpty();

            var irDocument = Lower(codeDocument);

            var template = RazorIRAssert.SingleChild<IRTemplate>(irDocument);
            RazorIRAssert.NoChildren(template);
        }

        [Fact]
        public void Lower_HelloWorld()
        {
            var codeDocument = TestRazorCodeDocument.Create("Hello, World!");

            var irDocument = Lower(codeDocument);

            var template = RazorIRAssert.SingleChild<IRTemplate>(irDocument);
            var markup = RazorIRAssert.SingleChild<IRMarkup>(template);
            Assert.Equal("Hello, World!", markup.Content);
        }

        private RazorIRDocument Lower(RazorCodeDocument codeDocument)
        {
            var engine = RazorEngine.Create();

            for (var i = 0; i < engine.Phases.Count; i++)
            {
                var phase = engine.Phases[i];
                phase.Execute(codeDocument);

                if (phase is IRazorIRLoweringPhase)
                {
                    break;
                }
            }

            var irDocument = codeDocument.GetIRDocument();
            Assert.NotNull(irDocument);
            return irDocument;
        }
    }
}
