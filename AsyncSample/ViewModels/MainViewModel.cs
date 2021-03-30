using System.ComponentModel;
using System.Runtime.CompilerServices;

using AsyncSample.Commands;
using AsyncSample.Models;

namespace AsyncSample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// モデル
        /// </summary>
        public MainModel Model { get; set; }

        /// <summary>
        /// 処理時間
        /// </summary>
        public int Time
        {
            get => this.Model.Time;
            set => this.Model.Time = value;
        }

        /// <summary>
        /// 状態文言
        /// </summary>
        public string Status => this.Model.Status;

        /// <summary>
        /// 進捗率
        /// </summary>
        public string Rate => this.Model.Rate;

        /// <summary>
        /// 進捗バーの値
        /// </summary>
        public double Value => this.Model.Value;

        /// <summary>
        /// 実行中かどうか
        /// </summary>
        public bool IsRunning => this.Model.IsRunning;

        /// <summary>
        /// Startボタンコマンド
        /// </summary>
        public DelegateCommand StartCommand { get; private set; }

        /// <summary>
        /// ストップボタンコマンド
        /// </summary>
        public DelegateCommand StopCommand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainViewModel()
        {
            this.Model = new MainModel() { PropertyChanged = this.RaisePropertyChanged, RaiseCanExecuteChanged = this.RaiseCanExecuteChanged };
            this.StartCommand = new DelegateCommand(
                _ => this.Model.WorkAsync(),
                _ => !this.IsRunning
            );
            this.StopCommand = new DelegateCommand(
                _ => this.Model.Cancel(),
                _ => this.IsRunning
            );
        }

        private void RaiseCanExecuteChanged()
        {
            this.StartCommand.RaiseCanExecuteChanged();
            this.StopCommand.RaiseCanExecuteChanged();
        }
    }
}
