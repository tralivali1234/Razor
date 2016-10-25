// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNetCore.Razor.Evolution.Legacy
{
    public class HtmlSymbol : SymbolBase<HtmlSymbolType>
    {
        public HtmlSymbol(int absoluteIndex, int lineIndex, int characterIndex, string content, HtmlSymbolType type)
            : base(new SourceLocation(absoluteIndex, lineIndex, characterIndex), content, type)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }
        }

        public HtmlSymbol(SourceLocation start, string content, HtmlSymbolType type)
            : base(start, content, type)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }
        }
    }
}
