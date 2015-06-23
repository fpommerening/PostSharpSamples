using System;
using PostSharp.Aspects;

namespace FP.PostSharpSamples.UI.Business
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class PropertyChangeEventAspect : LocationInterceptionAspect
    {
        public override void OnSetValue(LocationInterceptionArgs args)
        {
            var oldValue = args.GetCurrentValue();
            var newValue = args.Value;
            var classWithPropertyChangeTracking = args.Instance as IPropertyChangeTracking;
            if (classWithPropertyChangeTracking != null)
            {
                classWithPropertyChangeTracking.OnPropertyChanging(args.LocationName, oldValue, newValue);
            }

            base.OnSetValue(args);

            if (classWithPropertyChangeTracking != null &&
                ((oldValue == null && newValue != null) ||
                 (oldValue != null && newValue == null) ||
                 !oldValue.Equals(newValue)))
            {
                classWithPropertyChangeTracking.OnPropertyChanged(args.LocationName, oldValue, newValue);
            }

        }
    }
}
