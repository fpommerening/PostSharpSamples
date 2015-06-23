using System;
using System.Collections.Generic;

namespace FP.PostSharpSamples.DAL
{
    [DurationLoggingAspect]
    public class UnitOfWork
    {
        public List<TestModel> GetTestModels()
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));

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
            return list;
        }
    }
}
