using System;

namespace FP.PostSharpSamples.Services
{
    public class ServiceCacheItem
    {
        public string MethodHash { get; set; }
        public string SerializedParameter { get; set; }
        public object Value { get; set; }
        public DateTime UseUntilTimestamp { get; set; }
    }
}
