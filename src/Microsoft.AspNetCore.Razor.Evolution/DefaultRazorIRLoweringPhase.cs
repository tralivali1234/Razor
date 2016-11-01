// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Razor.Evolution.Intermediate;
using Microsoft.AspNetCore.Razor.Evolution.Legacy;

namespace Microsoft.AspNetCore.Razor.Evolution
{
    internal class DefaultRazorIRLoweringPhase : RazorEnginePhaseBase, IRazorIRLoweringPhase
    {
        protected override void ExecuteCore(RazorCodeDocument codeDocument)
        {
            var syntaxTree = codeDocument.GetSyntaxTree();
            ThrowForMissingDependency<RazorSyntaxTree>(syntaxTree);

            var visitor = new Visitor();

            visitor.VisitBlock(syntaxTree.Root);

            var irDocument = visitor.Builder.Build();
            codeDocument.SetIRDocument(irDocument);
        }

        private class Visitor : ParserVisitor
        {
            public Visitor()
            {
                Builder = RazorIRBuilder.Document();
                Template = new IRTemplate();

                Builder.Push(Template);
            }

            public RazorIRBuilder Builder { get; }

            public IRTemplate Template { get; }

            public override void VisitBlock(Block block)
            {
                base.VisitBlock(block);
            }

            public override void VisitSpan(Span span)
            {
                base.VisitSpan(span);
            }
        }
    }
}
