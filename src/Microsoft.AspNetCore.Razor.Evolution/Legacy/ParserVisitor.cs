// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Razor.Evolution.Legacy
{
    internal abstract class ParserVisitor
    {
        public virtual void VisitBlock(Block block)
        {
            VisitStartBlock(block);

            for (var i = 0; i < block.Children.Count; i++)
            {
                block.Children[i].Accept(this);
            }

            VisitEndBlock(block);
        }

        public virtual void VisitStartBlock(Block block)
        {
            if (block.ChunkGenerator != null)
            {
                block.ChunkGenerator.AcceptStart(this, block);
            }
        }

        public virtual void VisitEndBlock(Block block)
        {
            if (block.ChunkGenerator != null)
            {
                block.ChunkGenerator.AcceptEnd(this, block);
            }
        }

        public virtual void VisitSpan(Span span)
        {
            if (span.ChunkGenerator != null)
            {
                span.ChunkGenerator.Accept(this, span);
            }
        }

        public virtual void VisitStartDynamicAttributeBlock(DynamicAttributeBlockChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitEndDynamicAttributeBlock(DynamicAttributeBlockChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitStartExpressionBlock(ExpressionChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitEndExpressionBlock(ExpressionChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitStartAttributeBlock(AttributeBlockChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitEndAttributeBlock(AttributeBlockChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitExpressionSpan(ExpressionChunkGenerator chunkGenerator, Span span)
        {
        }

        public virtual void VisitMarkupSpan(MarkupChunkGenerator chunkGenerator, Span span)
        {
        }

        public virtual void VisitImportSpan(AddImportChunkGenerator chunkGenerator, Span span)
        {
        }

        public virtual void VisitStatementSpan(StatementChunkGenerator chunkGenerator, Span span)
        {
        }

        public virtual void VisitLiteralAttributeSpan(LiteralAttributeChunkGenerator chunkGenerator, Span span)
        {
        }

        public virtual void VisitDirectiveToken(DirectiveTokenChunkGenerator chunkGenerator, Span block)
        {
        }

        public virtual void VisitEndTemplateBlock(TemplateBlockChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitStartDirectiveBlock(DirectiveChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitEndDirectiveBlock(DirectiveChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitStartTemplateBlock(TemplateBlockChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitEndCommentBlock(RazorCommentChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitStartCommentBlock(RazorCommentChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitStartTagHelperBlock(TagHelperChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitEndTagHelperBlock(TagHelperChunkGenerator chunkGenerator, Block block)
        {
        }

        public virtual void VisitAddTagHelperSpan(AddTagHelperChunkGenerator chunkGenerator, Span span)
        {
        }

        public virtual void VisitRemoveTagHelperSpan(RemoveTagHelperChunkGenerator chunkGenerator, Span span)
        {
        }

        public virtual void VisitTagHelperPrefixDirectiveSpan(TagHelperPrefixDirectiveChunkGenerator chunkGenerator, Span span)
        {
        }
    }
}
