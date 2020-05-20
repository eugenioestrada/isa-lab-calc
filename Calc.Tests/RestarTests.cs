using System;
using Xunit;

namespace Calc.Tests
{
    public class RestarTests
    {
        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(2, -2, 4)]
        [InlineData(-10, 2, -12)]
        [InlineData(-8, -4, -4)]
        public void RestarTest(int operando1, int operando2, int resultadoEsperado)
        {
            var calc = new Calc.CalcService();
            int resultado = calc.Restar(operando1, operando2);
            Assert.Equal(resultado, resultadoEsperado);
        }
    }
}
