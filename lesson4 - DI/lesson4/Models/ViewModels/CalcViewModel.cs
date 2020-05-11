
namespace lesson4.Models.ViewModels
{
    public class CalcViewModel
    {
        public int A { get; set; }
        public int B { get; set; }
        public double Result { get; set; }

        public CalcViewModel(int a, int b, double res)
        {
            A = a; B = b; Result = res;
        }
        public CalcViewModel()
        {

        }
    }
}
