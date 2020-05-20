using System;
using Xunit;

namespace Calc.Tests
{
    public class SumarTests
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, -2, 0)]
        [InlineData(-10, 2, -8)]
        [InlineData(-8, -4, -12)]
        public void SumarTest(int operando1, int operando2, int resultadoEsperado)
        {
            var calc = new Calc.CalcService();
            int resultado = calc.Sumar(operando1, operando2);
            Assert.Equal(resultado, resultadoEsperado);
        }
    }
}
