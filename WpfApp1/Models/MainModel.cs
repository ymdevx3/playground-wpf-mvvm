
namespace WpfApp1.Models
{
    class MainModel
    {
        public int Value { get; set; } = 0;

        public int? ValueX { get; set; }

        public int? ValueY { get; set; }

        public string CalcResult => this.ValueX.HasValue && this.ValueY.HasValue ? (this.ValueX + this.ValueY).ToString() : "***";
    }
}
