using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP.PostSharpSamples.UI.Business
{
    public class TestController
    {

        public event Action<String> MessageSended;

        public void StartLongProcess()
        {
            var handler = MessageSended;
            if (handler != null)
            {
                handler(DateTime.Now.ToString(CultureInfo.InvariantCulture));
            }

        }
    }
}
