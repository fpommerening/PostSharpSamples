using System;

namespace FP.PostSharpSamples.BL
{
    public class DocumentController : BaseController
    {
        public override void InitDataSource()
        {
            this.ObjectId = Guid.NewGuid();
            base.InitDataSource();
        }
    }
}
