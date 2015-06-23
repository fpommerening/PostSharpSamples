using System;

namespace FP.PostSharpSamples.UI.Business
{
    public class SecurityLocatorTypeAttribute : Attribute
    {
        public Type SecurityLocatorType { get; private set; }
        public SecurityLocatorTypeAttribute(Type securityLocatorType)
        {
            SecurityLocatorType = securityLocatorType;
        }
    }
}
