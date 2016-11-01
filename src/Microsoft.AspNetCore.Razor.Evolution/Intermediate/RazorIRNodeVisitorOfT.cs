// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNetCore.Razor.Evolution.Intermediate
{
    public abstract class RazorIRNodeVisitor<TResult>
    {
        public virtual TResult Visit(RazorIRNode node)
        {
            return node.Accept(this);
        }

        public virtual TResult VisitDefault(RazorIRNode node)
        {
            return default(TResult);
        }

        internal TResult VisitDirectiveToken(DirectiveTokenIR directiveTokenIR)
        {
            throw new NotImplementedException();
        }

        internal TResult VisitTemplate(TemplateIR templateIR)
        {
            throw new NotImplementedException();
        }

        internal TResult VisitSection(SectionIR sectionIR)
        {
            throw new NotImplementedException();
        }

        internal TResult VisitCSharpStatement(CSharpStatementIR cSharpStatementIR)
        {
            throw new NotImplementedException();
        }

        internal TResult VisitCSharpExpression(CSharpExpressionIR cSharpExpressionIR)
        {
            throw new NotImplementedException();
        }

        internal TResult VisitHtmlAttributeValue(HtmlAttributeValueIR htmlAttributeValueIR)
        {
            throw new NotImplementedException();
        }

        internal TResult VisitCSharpAttributeValue(CSharpAttributeValueIR cSharpAttributeValueIR)
        {
            throw new NotImplementedException();
        }

        internal TResult VisitHtmlAttribute(HtmlAttributeIR htmlAttributeIR)
        {
            throw new NotImplementedException();
        }

        public virtual TResult VisitClass(ClassDeclarationIR node)
        {
            return VisitDefault(node);
        }

        internal TResult VisitSingleLineDirective(SingleLineDirectiveIR singleLineDirectiveIR)
        {
            throw new NotImplementedException();
        }

        internal TResult VisitBlockDirective(BlockDirectiveIR blockDirectiveIR)
        {
            throw new NotImplementedException();
        }

        public virtual TResult VisitCSharp(CSharpSource node)
        {
            return VisitDefault(node);
        }

        internal TResult VisitMethodDeclaration(MethodDeclarationIR methodDeclarationIR)
        {
            throw new NotImplementedException();
        }

        public virtual TResult VisitDocument(DocumentIR node)
        {
            return VisitDefault(node);
        }

        public virtual TResult VisitHtml(HtmlIR node)
        {
            return VisitDefault(node);
        }

        public virtual TResult VisitNamespace(NamespaceDeclarationIR node)
        {
            return VisitDefault(node);
        }

        public virtual TResult VisitUsingStatement(UsingStatementIR node)
        {
            return VisitDefault(node);
        }
    }
}
