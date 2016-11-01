// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNetCore.Razor.Evolution.Intermediate
{
    public abstract class RazorIRNodeVisitor 
    {
        public virtual void Visit(RazorIRNode node)
        {
            node.Accept(this);
        }

        internal void VisitDirectiveToken(DirectiveTokenIR directiveTokenIR)
        {
            throw new NotImplementedException();
        }

        internal void VisitTemplate(TemplateIR templateIR)
        {
            throw new NotImplementedException();
        }

        internal void VisitSection(SectionIR sectionIR)
        {
            throw new NotImplementedException();
        }

        internal void VisitCSharpStatement(CSharpStatementIR cSharpStatementIR)
        {
            throw new NotImplementedException();
        }

        internal void VisitCSharpExpression(CSharpExpressionIR cSharpExpressionIR)
        {
            throw new NotImplementedException();
        }

        internal void VisitHtmlAttributeValue(HtmlAttributeValueIR htmlAttributeValueIR)
        {
            throw new NotImplementedException();
        }

        internal void VisitCSharpAttributeValue(CSharpAttributeValueIR cSharpAttributeValueIR)
        {
            throw new NotImplementedException();
        }

        internal void VisitHtmlAttribute(HtmlAttributeIR htmlAttributeIR)
        {
            throw new NotImplementedException();
        }

        public virtual void VisitDefault(RazorIRNode node)
        {
        }

        internal void VisitSingleLineDirective(SingleLineDirectiveIR singleLineDirectiveIR)
        {
            throw new NotImplementedException();
        }

        internal void VisitBlockDirective(BlockDirectiveIR blockDirectiveIR)
        {
            throw new NotImplementedException();
        }

        public virtual void VisitClass(ClassDeclarationIR node)
        {
            VisitDefault(node);
        }

        public virtual void VisitCSharp(CSharpSource node)
        {
            VisitDefault(node);
        }

        internal void VisitMethodDeclaration(MethodDeclarationIR methodDeclarationIR)
        {
            throw new NotImplementedException();
        }

        public virtual void VisitDocument(DocumentIR node)
        {
            VisitDefault(node);
        }

        public virtual void VisitHtml(HtmlIR node)
        {
            VisitDefault(node);
        }

        public virtual void VisitNamespace(NamespaceDeclarationIR node)
        {
            VisitDefault(node);
        }

        public virtual void VisitUsingStatement(UsingStatementIR node)
        {
            VisitDefault(node);
        }
    }
}
