using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using FP.PostSharpSamples.BL;

namespace FP.PostSharpSamples.UI.Controls
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [Serializable]
    public class IncludeAdditionalControlAspect : InstanceLevelAspect
    {
        public override bool CompileTimeValidate(Type type)
        {
            return !type.IsAbstract && typeof(Form).IsAssignableFrom(type);
        }

        [OnMethodExitAdvice, MulticastPointcut(MemberName = ".ctor")]
        public void OnExit(MethodExecutionArgs args)
        {
            var tabControlMember = Instance.GetType()
                                                    .GetFields(BindingFlags.NonPublic | BindingFlags.Public |
                                                               BindingFlags.Instance)
                                                    .FirstOrDefault(x => x.FieldType == typeof(TabControl));
            if (tabControlMember == null)
                return;

            var tabControl = tabControlMember.GetValue(Instance) as TabControl;
            if (tabControl == null)
                return;

            var formControllerMember = Instance.GetType()
                                         .GetFields(BindingFlags.NonPublic | BindingFlags.Public |
                                                    BindingFlags.Instance)
                                         .FirstOrDefault(x => x.FieldType.IsSubclassOf(typeof(BaseController)));

            if (formControllerMember == null)
                return;

            var formController = formControllerMember.GetValue(Instance) as BaseController;
            if (formController == null)
                return;

            var tabPage = new TabPage { Text = "Documents" };
            DocumentControl documentControl = new DocumentControl();
            tabPage.Controls.Add(documentControl);
            documentControl.Dock = DockStyle.Fill;
            tabControl.TabPages.Add(tabPage);
            formController.DataSourceInitialized += (sender, eventArgs) => documentControl.Controller.InitDataSource();
        }
    }
}
