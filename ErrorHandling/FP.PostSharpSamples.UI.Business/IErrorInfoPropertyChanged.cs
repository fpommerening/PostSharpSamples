using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FP.PostSharpSamples.UI.Business
{
    public interface IErrorInfoPropertyChanged : INotifyPropertyChanged, IDataErrorInfo
    {
        void SetError(string property, string error);

        void OnPropertyChanged([CallerMemberName] string propertyName = "");
    }
}
