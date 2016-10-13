// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Razor.Evolution
{
    public class ItemCollection
    {
        private readonly Dictionary<object, object> _items;

        public ItemCollection()
        {
            _items = new Dictionary<object, object>();
        }

        public object this[object key]
        {
            get
            {
                object value;
                _items.TryGetValue(key, out value);
                return value;
            }
            set
            {
                _items[key] = value;
            }
        }
    }
}
