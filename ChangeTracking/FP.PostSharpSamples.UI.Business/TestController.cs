using FP.PostSharpSamples.DAL;
using System.ComponentModel;
using System.Windows.Forms;

namespace FP.PostSharpSamples.UI.Business
{
    public class TestController
    {
        private readonly UnitOfWork _unitOfWork;
        public BindingSource BindingSource { get; set; }

        public TestController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void LoadData()
        {
            var list = new BindingList<TestModelView>();
            BindingSource.DataSource = list;

            foreach(var model in _unitOfWork.GetTestModels())
            {
                var vm = new TestModelView
                {
                    City = model.City,
                    FirstName = model.FirstName,
                    Name = model.Name,
                    Street = model.Street,
                    ZipCode = model.ZipCode
                };
                list.Add(vm);
            }
        }

        public void UpdateData()
        {
            var list = BindingSource.DataSource as BindingList<TestModelView>;
            if(list != null)
            {
                list[1].Name = "Müller";
            }
        }
       
    }
}
