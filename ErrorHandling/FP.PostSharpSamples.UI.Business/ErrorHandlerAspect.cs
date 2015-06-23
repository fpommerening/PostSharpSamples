using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace FP.PostSharpSamples.UI.Business
{
    [Serializable]
    public class ErrorHandlerAspect : InstanceLevelAspect
    {
        public override bool CompileTimeValidate(Type type)
        {
            return !type.IsAbstract && typeof(BaseErrorViewModel).IsAssignableFrom(type);
        }

        [OnLocationSetValueAdvice, MulticastPointcut(Targets = MulticastTargets.Property, Attributes = MulticastAttributes.Instance)]
        public void OnPropertySet(LocationInterceptionArgs args)
        {
            var baseErrorViewModel = Instance as BaseErrorViewModel;
            if (baseErrorViewModel == null)
            {
                return;
            }

            args.ProceedSetValue();

            // clear old errors
            baseErrorViewModel.SetError(args.Location.Name, "");

            foreach (var att in args.Location.PropertyInfo.GetCustomAttributes(typeof(ValidationAttribute), false))
            {
                if (!((ValidationAttribute)att).IsValid(args.Value))
                {
                    baseErrorViewModel.SetError(args.Location.Name, ((ValidationAttribute)att).FormatErrorMessage(GetDisplayName(args.Location)));
                    break;
                }
            }
            baseErrorViewModel.OnPropertyChanged(args.Location.Name);
        }

        private static string GetDisplayName(LocationInfo location)
        {
            var displayAttribute = location.PropertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault();
            if (displayAttribute != null)
            {
                return ((DisplayNameAttribute)displayAttribute).DisplayName;
            }
            return location.Name;
        }
    }
}
