using EEPA.Producer;
using EEPA.Library.Client;

namespace EEPA.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class TestMessageQueue
    {
     
        [Test]
        public void CallingFib30_ShouldReturn_832040()
        {

            var fibonacci = new Fibonacci(30);
            var fibAnswer = new Client().Call<Fibonacci,MathAnswer>(fibonacci);

            Assert.AreEqual(832040, fibAnswer.Answer);
        }
    }
}
