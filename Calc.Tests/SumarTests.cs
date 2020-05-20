using System;
using Xunit;

namespace Calc.Tests
{
    public class SumarTests
    {
        [Fact]
        public void SumarTest()
        {
            int operando1 = 1;
            int operando2 = 1;
            int resultadoEsperado = 2;

            var calc = new Calc.CalcService();
            int resultado = calc.Sumar(operando1, operando2);
            Assert.Equal(resultado, resultadoEsperado);
        }
    }
}
