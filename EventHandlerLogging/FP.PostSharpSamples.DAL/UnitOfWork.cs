using System;
using System.Collections.Generic;

namespace FP.PostSharpSamples.DAL
{
    public class UnitOfWork
    {
        [EventHandlerLoggingAspect]
        public event Action DataLoaded;

        public List<TestModel> GetTestModels()
        {
            var list = new List<TestModel>();
            list.Add(new TestModel()
            {
                Name = "Mustermann",
                FirstName = "Max",
                City = "Musterstadt",
                Street = "Hauptstraße 17",
                ZipCode = "12345"
            });
            list.Add(new TestModel()
            {
                Name = "Meier",
                FirstName = "Sabine",
                City = "Musterdorf",
                Street = "Berlinstraße 42",
                ZipCode = "98765"
            });
            RaiseDataLoaded();
            return list;
        }

        private void RaiseDataLoaded()
        {
            var handler = DataLoaded;
            if (handler != null)
            {
                handler();
            }
        }
    }
}
