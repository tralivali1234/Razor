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

            var @namespace = RazorIRAssert.SingleChild<NamespaceDeclarationIR>(irDocument);
            var @class = RazorIRAssert.SingleChild<ClassDeclarationIR>(@namespace);
            var method = RazorIRAssert.SingleChild<MethodDeclarationIR>(@class);
            RazorIRAssert.NoChildren(method);
        }

        [Fact]
        public void Lower_HelloWorld()
        {
            var codeDocument = TestRazorCodeDocument.Create("Hello, World!");

            var irDocument = Lower(codeDocument);

            var @namespace = RazorIRAssert.SingleChild<NamespaceDeclarationIR>(irDocument);
            var @class = RazorIRAssert.SingleChild<ClassDeclarationIR>(@namespace);
            var method = RazorIRAssert.SingleChild<MethodDeclarationIR>(@class);
            var html = RazorIRAssert.SingleChild<HtmlIR>(method);

            Assert.Equal("Hello, World!", html.Content);
        }

        private DocumentIR Lower(RazorCodeDocument codeDocument)
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
