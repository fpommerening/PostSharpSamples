using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FP.PostSharpSamples.UI.Business;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using System.Reflection;

namespace FP.PostSharpSamples.UI.Controls
{
    [Serializable]
    public class IncludeErrorProviderAspect : InstanceLevelAspect
    {
        [NonSerialized]
        private ErrorProvider _currentErrorProvider;

        [NonSerialized]
        private Form _currentForm;

        [NonSerialized]
        private List<ControlledBinding> _controlledBindings;

        public override bool CompileTimeValidate(Type type)
        {
            return typeof (Form).IsAssignableFrom(type);
        }

        [OnInstanceConstructedAdvice]
        public void OnInstanceConstructed()
        {
            _currentForm = (Form) Instance;
            _controlledBindings = new List<ControlledBinding>();

            var errorProvider = Instance.GetType()
                                         .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                                         .FirstOrDefault(x => x.FieldType == typeof(ErrorProvider));

            if (errorProvider != null)
            {
                _currentErrorProvider = (ErrorProvider)errorProvider.GetValue(Instance);
            }
            else
            {
                _currentErrorProvider = new ErrorProvider(_currentForm);
            }

            var bindingSources = Instance.GetType()
                                         .GetFields(BindingFlags.NonPublic | BindingFlags.Public |BindingFlags.Instance)
                                         .Where(x => x.FieldType == typeof(BindingSource));

           
            foreach (var bindingSource in bindingSources)
            {
               ((BindingSource)bindingSource.GetValue(Instance)).CurrentChanged += OnCurrentChanged;
            }
        }

        private void OnCurrentChanged(object sender, EventArgs eventArgs)
        {
            FillBindings();
        }

        private void FillBindings()
        {
            foreach (Control c in GetControls(_currentForm).Where(x => x.DataBindings.Count > 0))
            {
                var binding = c.DataBindings[0];
                var bindingDataSource = binding.DataSource as BindingSource;
                if (bindingDataSource != null)
                {
                    var errorProperty = bindingDataSource.DataSource as IErrorInfoPropertyChanged;
                    if (errorProperty != null)
                    {
                        errorProperty.PropertyChanged -= errorPropy_PropertyChanged;
                        errorProperty.PropertyChanged += errorPropy_PropertyChanged;

                        var exBindConf = _controlledBindings.FirstOrDefault(x => x.TargetControl == c);
                        if (exBindConf == null)
                        {
                            exBindConf = new ControlledBinding {TargetControl = c};
                            _controlledBindings.Add(exBindConf);
                        }
                        exBindConf.BindingSource = bindingDataSource;
                        exBindConf.DataSource = errorProperty;
                        exBindConf.Property = binding.BindingMemberInfo.BindingMember;
                    }
                }
            }
        }

        void errorPropy_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var exBindConf = _controlledBindings.FirstOrDefault(x => x.DataSource == sender && x.Property == e.PropertyName);
            if (exBindConf != null)
            {
                _currentErrorProvider.SetError(exBindConf.TargetControl, exBindConf.DataSource[exBindConf.Property]);
            }
        }

        private IEnumerable<Control> GetControls(Control control)
        {
            if (!control.HasChildren)
            {
                yield return control;
            }
            else
            {
                foreach (Control childControl in control.Controls)
                {
                    yield return childControl;
                    foreach (var c in GetControls(childControl))
                    {
                        yield return c;
                    }
                }
            }
           
                
        }
    }
}
