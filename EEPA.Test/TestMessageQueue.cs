using System.Runtime.CompilerServices;
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
            var rpcClient = new RpcClient();

            var fibonacci = new Fibonacci(30);
            var fibAnswer = rpcClient.Call<Fibonacci,MathAnswer>(fibonacci);

            new Client().Call<Fibonacci, MathAnswer>(fibonacci);

            rpcClient.Close();

            Assert.AreEqual(832040, fibAnswer.Answer);
        }
    }
}
