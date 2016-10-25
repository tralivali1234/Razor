// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNetCore.Razor.Evolution.Legacy
{
    public class CSharpSymbol : SymbolBase<CSharpSymbolType>
    {
        public CSharpSymbol(int absoluteIndex, int lineIndex, int characterIndex, string content, CSharpSymbolType type)
            : base(new SourceLocation(absoluteIndex, lineIndex, characterIndex), content, type)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }
        }

        public CSharpSymbol(SourceLocation start, string content, CSharpSymbolType type)
            : base(start, content, type)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }
        }

        public CSharpKeyword? Keyword { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as CSharpSymbol;
            return base.Equals(other) &&
                other.Keyword == Keyword;
        }

        public override int GetHashCode()
        {
            // Hash code should include only immutable properties.
            return base.GetHashCode();
        }
    }
}
