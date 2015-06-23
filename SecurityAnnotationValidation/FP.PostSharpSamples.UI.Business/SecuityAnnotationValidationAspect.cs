using PostSharp.Constraints;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP.PostSharpSamples.UI.Business
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.Strict)]
    public class SecuityAnnotationValidationAspect : ScalarConstraint
    {
        public override bool ValidateConstraint(object target)
        {
            var type = (Type)target;
            return !type.IsAbstract && typeof(Controller).IsAssignableFrom(type);
        }

        public override void ValidateCode(object target)
        {
            var targetType = (Type)target;

            if (!targetType.GetCustomAttributes(typeof(SecurityLocatorTypeAttribute), true).Any() &&
                !targetType.GetCustomAttributes(typeof(IgnoreMissingSecurityLocatorTypeAttribute), true).Any())
            {
                Message.Write(targetType, SeverityType.Error,
                    "MissingSecurityAnnoation",
                    "Beim Controller {0} {1} wurde keine Sicherheit annotiert.",
                    targetType.DeclaringType,
                    targetType.Name);
            }


            base.ValidateCode(target);
        }
    }
}
