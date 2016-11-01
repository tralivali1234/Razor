// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Razor.Evolution.Intermediate
{
    public class IRMarkup : RazorIRNode
    {
        public override IList<RazorIRNode> Children { get; } = EmptyArray;

        public string Content { get; set; }

        public override RazorIRNode Parent { get; set; }

        public override void Accept(RazorIRNodeVisitor visitor)
        {
            visitor.VisitMarkup(this);
        }

        public override TResult Accept<TResult>(RazorIRNodeVisitor<TResult> visitor)
        {
            return visitor.VisitMarkup(this);
        }
    }
}
