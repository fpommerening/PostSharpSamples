using PostSharp.Aspects;
using System;
using System.Windows.Forms;

namespace FP.PostSharpSamples.UI.Controls
{
    [Serializable]
    public class DispatchToUiThreadAspect : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs eventArgs)
        {
            var targetControl = eventArgs.Instance as Control;
            if (targetControl == null)
            {
                return;
            }
            if (targetControl.InvokeRequired)
            {
                targetControl.Invoke(new Action(eventArgs.Proceed));
            }
            else
            {
                eventArgs.Proceed();
            }
        }
    }
}
