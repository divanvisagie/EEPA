using EEPA.Library.Consumer;

namespace EEPA.Consumer
{
    public class FibonacciConsumer
    { 
        private static int Fib(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return Fib(n - 1) + Fib(n - 2);
        }

        public static void Main()
        {
            new Listener().Listen<Fibonacci>("fibonacci", inMessage => new MathAnswer(Fib(inMessage.Number)));
        }
    }
}