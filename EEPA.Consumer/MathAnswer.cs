using EEPA.Producer;

namespace EEPA.Consumer
{
    internal class MathAnswer : IDomainMessage
    {
        public int Answer { get; set; }
        public MathAnswer(int i)
        {
            Answer = i;
        }
    }
}