using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncSample.Models
{
    public class MainModel
    {
        public int Time { get; set; } = 10;

        public string Status { get; set; } = "Not running...";

        public string Rate => $"{(int)Math.Truncate(this.Value)} %";

        public double Value { get; set; }

        public bool IsRunning { get; set; }

        public Action<string[]> PropertyChanged { get; set; }

        public Action RaiseCanExecuteChanged { get; set; }

        /// <summary>
        /// タスク
        /// </summary>
        private Task workingTask;

        /// <summary>
        /// キャンセルトークンソース
        /// </summary>
        private CancellationTokenSource cancelSource = new CancellationTokenSource();

        public async void WorkAsync()
        {
            try
            {
                this.IsRunning = true;
                this.Status = "Running...";
                this.Value = 0;
                this.PropertyChanged?.Invoke(new[] { nameof(this.Status), nameof(this.Value) });
                this.RaiseCanExecuteChanged?.Invoke();

                this.cancelSource = new CancellationTokenSource();

                this.workingTask = this.Work();
                await this.workingTask;

                this.Status = "Not running...";
            }
            catch (Exception)
            {
                this.Status = "Stopped...";
            }
            finally
            {
                this.cancelSource.Dispose();

                this.IsRunning = false;
                this.PropertyChanged?.Invoke(new[] { nameof(this.Status) });
                this.RaiseCanExecuteChanged?.Invoke();
            }
        }

        private Task Work()
        {
            return Task.Run(() =>
            {
                this.WorkCore();
            });
        }

        private void WorkCore()
        {
            for (int i = 1; i <= this.Time; i++)
            {
                this.cancelSource?.Token.ThrowIfCancellationRequested();

                Thread.Sleep(1000);

                this.Value = (double)i / this.Time * 100;
                this.PropertyChanged?.Invoke(new[] { nameof(this.Value), nameof(this.Rate) });
            }
        }

        public void Cancel()
        {
            this.cancelSource?.Cancel();
        }
    }
}
