using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp1.Commands;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public MainModel Model { get; set; }

        public CountUpCommand CountUpCommand { get; private set; }

        // CallerMemberNameで呼び出し元プロパティは省略可
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public MainViewModel()
        {
            this.Model = new MainModel();
            this.CountUpCommand = new CountUpCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Value
        {
            get
            {
                //カウンタークラスが保持するカウント値を返す
                return Model.Value;
            }
            set
            {
                //カウンタークラスが保持するカウント値を設定する
                Model.Value = value;

                //中身が変更されたことを View Modelに通知するためのイベントハンドラ呼び出し
                //引数として、プロパティ名を文字列として渡すことでVIEWからバインドされる
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }

        public int? ValueX
        {
            get => Model.ValueX;
            set
            {
                Model.ValueX = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(CalcResult));
            }
            //set
            //{
            //    Model.ValueX = value;
            //    this.CalcResult = Model.CalcResult;
            //    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ValueX)));
            //    RaisePropertyChanged();
            //}
        }

        public int? ValueY
        {
            get => Model.ValueY;
            set
            {
                Model.ValueY = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(CalcResult));
            }
            //set
            //{
            //    Model.ValueY = value;
            //    this.CalcResult = Model.CalcResult;
            //    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ValueY)));
            //    RaisePropertyChanged();
            //}
        }

        public string CalcResult
        {
            get => Model.CalcResult;
            //set => RaisePropertyChanged();
        }
    }
}
