// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNetCore.Razor.Evolution.SyntaxTreePhase.Tokenizer
{
    public class HtmlSymbol : SymbolBase<HtmlSymbolType>
    {
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
