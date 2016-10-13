// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Razor.Evolution
{
    public class DefaultRazorEngine : RazorEngine
    {
        public DefaultRazorEngine(IRazorEngineFeature[] features, IRazorEnginePhase[] phases)
        {
            Features = features;
            Phases = phases;

            for (var i = 0; i < features.Length; i++)
            {
                features[i].Engine = this;
            }

            for (var i = 0; i < phases.Length; i++)
            {
                phases[i].Engine = this;
            }
        }

        public override IReadOnlyList<IRazorEngineFeature> Features { get; }

        public override IReadOnlyList<IRazorEnginePhase> Phases { get; }

        public override RazorCodeDocument CreateCodeDocument(RazorSourceDocument source) => new DefaultRazorCodeDocument(source);

        public override void ExecutePhase(IRazorEnginePhase phase, RazorCodeDocument document) => phase.Execute(document);

        public override void Process(RazorCodeDocument document)
        {
            for (var i = 0; i < Phases.Count; i++)
            {
                var phase = Phases[i];
                ExecutePhase(phase, document);
            }
        }

        private class DefaultRazorCodeDocument : RazorCodeDocument
        {
            public DefaultRazorCodeDocument(RazorSourceDocument source)
            {
                Source = source;

                ErrorSink = new ErrorSink();
                Items = new ItemCollection();
            }

            public override ErrorSink ErrorSink { get; }

            public override ItemCollection Items { get; }

            public override RazorSourceDocument Source { get; }
        }
    }
}
