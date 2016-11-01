// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace Microsoft.AspNetCore.Razor.Evolution.Intermediate
{
    public static class RazorIRAssert
    {
        public static TNode SingleChild<TNode>(RazorIRNode node)
        {
            if (node.Children.Count == 0)
            {
                throw new IRAssertException(node, "The node has no children.");
            }
            else if (node.Children.Count > 1)
            {
                throw new IRAssertException(node, node.Children, "The node has multiple children");
            }

            var child = node.Children[0];
            return Assert.IsType<TNode>(child);
        }

        public static void NoChildren(RazorIRNode node)
        {
            if (node.Children.Count > 0)
            {
                throw new IRAssertException(node, node.Children, "The node has children.");
            }
        }

        private class IRAssertException : XunitException
        {
            public IRAssertException(RazorIRNode node, string userMessage) 
                : base(Format(node, null, userMessage))
            {
                Node = node;
            }

            public IRAssertException(RazorIRNode node, IEnumerable<RazorIRNode> nodes, string userMessage)
                : base(Format(node, nodes, userMessage))
            {
                Node = node;
                Nodes = nodes;
            } 

            public RazorIRNode Node { get; }

            public IEnumerable<RazorIRNode> Nodes { get; }

            private static string Format(RazorIRNode node, IEnumerable<RazorIRNode> nodes, string userMessage)
            {
                var builder = new StringBuilder();
                builder.AppendLine(userMessage);
                builder.AppendLine();

                if (nodes != null)
                {
                    builder.AppendLine("Nodes:");

                    foreach (var n in nodes)
                    {
                        builder.AppendLine(n.ToString());
                    }

                    builder.AppendLine();
                }


                builder.AppendLine("Path:");

                var current = node;
                do
                {
                    builder.AppendLine(current.ToString());
                }
                while ((current = current.Parent) != null);

                return builder.ToString();
            }
        }
    }
}
