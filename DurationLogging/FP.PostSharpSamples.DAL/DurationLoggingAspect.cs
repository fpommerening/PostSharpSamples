using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;
using System;
using System.Diagnostics;
using System.Reflection;

namespace FP.PostSharpSamples.DAL
{
    [Serializable]
    [ProvideAspectRole(StandardRoles.PerformanceInstrumentation)]
    public class DurationLoggingAspect : OnMethodBoundaryAspect
    {
        private static readonly Stopwatch Stopwatch = new Stopwatch();
        private string _fullMethodName = string.Empty;

        static DurationLoggingAspect()
        {
            Stopwatch.Start();
        }

        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            base.CompileTimeInitialize(method, aspectInfo);
            _fullMethodName = string.Format("{0}.{1}", method.DeclaringType.FullName, method.Name);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = Stopwatch.ElapsedMilliseconds;
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var durationInMilliseconds = Stopwatch.ElapsedMilliseconds - (long)args.MethodExecutionTag;
            var span = TimeSpan.FromMilliseconds(durationInMilliseconds);
            var logMessage = string.Format("Die Ausführung der Methode {0}  dauerte {1} ms", _fullMethodName, span.TotalMilliseconds);
            Console.WriteLine(logMessage);
        }
    }
}
