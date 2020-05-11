
namespace lesson4.Services
{
    public class CalculateService
    {
        public int Sum(int a, int b) => a + b;
        public int Substract(int a, int b) => a - b;
        public int Mult(int a, int b) => a * b;
        public double Div(int a, int b) => (double)a / b;
    }
}
