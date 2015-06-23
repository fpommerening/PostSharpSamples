using System;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;

namespace BuildinAspects
{
    [Log(AttributeTargetMemberAttributes = MulticastAttributes.Internal | MulticastAttributes.Public)]
    public class TestProcessor
    {
        public void Method1(string param1, Int32 param2)
        {
            MethodA(param1);
            MethodB(param2);
        }

        internal void MethodA(string param)
        {
            System.Threading.Thread.Sleep(1000);
        }

        internal void MethodB(Int32 param)
        {
            System.Threading.Thread.Sleep(2000);
        }

    }
}
