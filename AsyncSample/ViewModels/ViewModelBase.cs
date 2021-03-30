using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AsyncSample.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティ変更通知イベントハンドラ
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // CallerMemberNameで呼び出し元プロパティは省略可
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void RaisePropertyChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                this.RaisePropertyChanged(propertyName);
            }
        }
    }
}
