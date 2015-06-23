using System;

namespace FP.PostSharpSamples.BL
{
    public class UserController : BaseController
    {
        public UserController()
        {
            ObjectId = Guid.NewGuid();
        }
    }
}
