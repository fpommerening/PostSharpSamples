using System;
using System.ComponentModel;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;

namespace FP.PostSharpSamples.UI.Business
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    [IntroduceInterface(typeof(IPropertyChangeTracking))]
    public class ImplementPropertyChangeTrackingAspect : InstanceLevelAspect, IPropertyChangeTracking
    {
        [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore)]
        public event PropertyChangedEventHandler PropertyChanged;

        [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore)]
        public event PropertyChangingEventHandler PropertyChanging;

        [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore)]
        public void OnPropertyChanging(string property, object oldValue, object newValue)
        {
            var handler = PropertyChanging;
            if (handler != null)
            {
                handler(this, new PropertyChangingEventArgs(property));
            }
        }

        [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore)]
        public void OnPropertyChanged(string property, object oldValue, object newValue)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }


    }
}
