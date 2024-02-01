using System;
using System.Collections.Generic;

namespace Pragmatic.Server.TradingCentral.ZMQ
{
    public interface IBridge : IDisposable
    {
        public string Name { get; }

        public void Configure(Dictionary<string, string> config);
        public void Start();
        public void Stop();
    }
}
