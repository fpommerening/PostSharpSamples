using System;
using System.Text;
using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;


namespace FP.PostSharpSamples.DAL
{
    [Serializable]
    public class EventHandlerLoggingAspect : EventInterceptionAspect
    {
        public override void OnAddHandler(EventInterceptionArgs args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Event {0} was hooked up by\n", args.Event.Name);
            sb.AppendFormat("\tclass: {0} \n", args.Handler.Target.GetType().FullName);
            sb.AppendFormat("\tassembly: {0}", args.Handler.Target.GetType().Module);
            
            Console.WriteLine(sb);

            base.OnAddHandler(args);
        }

        public override void OnRemoveHandler(EventInterceptionArgs args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Event {0} was removed from\n", args.Event.Name);
            sb.AppendFormat("\tclass: {0} \n", args.Handler.Target.GetType().FullName);
            sb.AppendFormat("\tassembly: {0}", args.Handler.Target.GetType().Module);
            Console.WriteLine(sb);
            base.OnRemoveHandler(args);
        }
    }
}
