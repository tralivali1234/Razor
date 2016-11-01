// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
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

                Namespace = new NamespaceDeclarationIR();
                Builder.Push(Namespace);

                Class = new ClassDeclarationIR();
                Builder.Push(Class);

                Method = new MethodDeclarationIR();
                Builder.Push(Method);
            }

            public RazorIRBuilder Builder { get; }

            public NamespaceDeclarationIR Namespace { get; }

            public ClassDeclarationIR Class { get; }

            public MethodDeclarationIR Method { get; }

            public override void VisitStartAttributeBlock(AttributeBlockChunkGenerator chunk, Block block)
            {
            }

            public override void VisitEndAttributeBlock(AttributeBlockChunkGenerator chunk, Block block)
            {
            }

            public override void VisitStartDynamicAttributeBlock(DynamicAttributeBlockChunkGenerator chunk, Block block)
            {
            }

            public override void VisitEndDynamicAttributeBlock(DynamicAttributeBlockChunkGenerator chunk, Block block)
            {
            }

            public override void VisitStartTemplateBlock(TemplateBlockChunkGenerator chunk, Block block)
            {
                Builder.Push(new TemplateIR());
            }

            public override void VisitEndTemplateBlock(TemplateBlockChunkGenerator chunk, Block block)
            {
                Builder.Pop();
            }

            public override void VisitStartExpressionBlock(ExpressionChunkGenerator chunk, Block block)
            {
                Builder.Push(new CSharpExpressionIR()
                {
                    SourceLocation = block.Start,
                });
            }

            public override void VisitEndExpressionBlock(ExpressionChunkGenerator chunk, Block block)
            {
                Builder.Pop();
            }

            public override void VisitStartSectionBlock(SectionChunkGenerator chunk, Block block)
            {
                Builder.Push(new SectionIR()
                {
                    Name = chunk.SectionName,
                });
            }

            public override void VisitEndSectionBlock(SectionChunkGenerator chunk, Block block)
            {
                Builder.Pop();
            }

            public override void VisitTypeMemberSpan(TypeMemberChunkGenerator chunk, Span span)
            {
                Class.BaseType = span.Content;
            }

            public override void VisitAddTagHelperSpan(AddTagHelperChunkGenerator chunk, Span span)
            {
                // Empty for now
            }

            public override void VisitRemoveTagHelperSpan(RemoveTagHelperChunkGenerator chunk, Span span)
            {
                // Empty for now
            }

            public override void VisitTagHelperPrefixSpan(TagHelperPrefixDirectiveChunkGenerator chunk, Span span)
            {
                // Empty for now
            }

            public override void VisitStatementSpan(StatementChunkGenerator chunk, Span span)
            {
            }

            public override void VisitSetBaseTypeSpan(SetBaseTypeChunkGenerator chunk, Span span)
            {
            }

            public override void VisitMarkupSpan(MarkupChunkGenerator chunk, Span span)
            {
                Builder.Add(new HtmlIR()
                {
                    Content = span.Content,
                    SourceLocation = span.Start,
                });
            }

            public override void VisitLiteralAttributeSpan(LiteralAttributeChunkGenerator chunk, Span span)
            {
            }

            public override void VisitImportSpan(AddImportChunkGenerator chunk, Span span)
            {
            }

            public override void VisitExpressionSpan(ExpressionChunkGenerator chunk, Span span)
            {
            }
        }
    }
}
