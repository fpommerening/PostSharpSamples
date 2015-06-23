using System;
using System.Collections.Generic;
using System.Linq;

namespace FP.PostSharpSamples.Services
{
    public class TestService
    {
        [ServiceCacheAspect(300)]
        public List<DTOTest> GetDataByGroup(string group)
        {
            return GetData().Where(x => x.Group == group).ToList();
        }

        #region 

        private List<DTOTest> GetData()
        {
            var random = new Random();
            var data = new List<DTOTest>();
            data.Add(new DTOTest { Id = 1, Name = "Mustermann", FirstName = "Max", Group = "GroupA", LastActivety = DateTime.Now });
            System.Threading.Thread.Sleep(random.Next(500, 2000));
            data.Add(new DTOTest { Id = 1, Name = "Lehmann", FirstName = "Tim", Group = "GroupB", LastActivety = DateTime.Now });
            System.Threading.Thread.Sleep(random.Next(500, 2000));
            data.Add(new DTOTest { Id = 1, Name = "Müller", FirstName = "Anna", Group = "GroupC", LastActivety = DateTime.Now });
            System.Threading.Thread.Sleep(random.Next(500, 2000));
            data.Add(new DTOTest { Id = 1, Name = "Meier", FirstName = "Ella", Group = "GroupA", LastActivety = DateTime.Now });
            System.Threading.Thread.Sleep(random.Next(200, 500));
            return data;
        }


        #endregion

    }
}
