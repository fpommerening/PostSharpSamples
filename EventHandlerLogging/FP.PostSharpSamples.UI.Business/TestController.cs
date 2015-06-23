using FP.PostSharpSamples.DAL;
using System;

namespace FP.PostSharpSamples.UI.Business
{
    public class TestController
    {
        private readonly UnitOfWork _unitOfWork;

        public Boolean DataLoaded { get; set; }

        public TestController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void LoadData()
        {
            _unitOfWork.DataLoaded += UnitOfWorkOnDataLoaded;
            _unitOfWork.GetTestModels();
        }

        private void UnitOfWorkOnDataLoaded()
        {
           _unitOfWork.DataLoaded -= UnitOfWorkOnDataLoaded;
        }
    }
}
