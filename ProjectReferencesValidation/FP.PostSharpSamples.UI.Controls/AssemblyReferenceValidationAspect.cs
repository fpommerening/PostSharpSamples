
using System;

using System.Linq;

using PostSharp.Aspects;
using System.Reflection;
using PostSharp.Extensibility;
using PostSharp;

namespace FP.PostSharpSamples.UI.Controls
{
    [Serializable]
    public class AssemblyReferenceValidationAspect : AssemblyLevelAspect
    {
        private static string[] whiteList = new string[]
           {
               "FP.PostSharpSamples.UI.Business",

                "PostSharp",

                "mscorlib",
                "System",
                "System.Core",
                "System.Drawing",
                "System.Windows.Forms"
           };

        public override bool CompileTimeValidate(Assembly assembly)
        {
            bool violated = false;
            foreach (var asm in assembly.GetReferencedAssemblies())
                if (!whiteList.Contains(asm.Name))
                {
                    violated = true;
                    var location = MessageLocation.Of(assembly);
                    Message msg = new Message(
                        SeverityType.Error,
                        "AssemblyReferenceViolation",
                        String.Format("Das Projekt darf nicht auf {0} verweisen", asm.Name),
                        string.Empty,
                        assembly.FullName,
                        location.File,
                        0, 0,
                        null
                        );
                    MessageSource.MessageSink.Write(msg);
                }
            return violated;
        }
    }
}
