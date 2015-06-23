using System;

namespace FP.PostSharpSamples.UI.Business
{
    [ImplementPropertyChangeTrackingAspect]
    public class TestModelView
    {
        [PropertyChangeEventAspect]
        public String Name { get; set; }

        [PropertyChangeEventAspect]
        public String FirstName { get; set; }

        [PropertyChangeEventAspect]
        public String Street { get; set; }

        [PropertyChangeEventAspect]
        public String ZipCode { get; set; }

        [PropertyChangeEventAspect]
        public string City { get; set; }
    }
}
