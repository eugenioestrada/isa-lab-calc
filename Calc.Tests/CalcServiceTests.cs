using System;
using Xunit;
using Calc;

namespace Calc.Tests
{
    public class CalcServiceTests
    {
        private readonly CalcService calcService = new CalcService(); 

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, -2, 0)]
        [InlineData(-10, 2, -8)]
        [InlineData(-8, -4, -12)]
        public void SumarTest(int operando1, int operando2, int resultadoEsperado)
        {
            int resultado = calcService.Sumar(operando1, operando2);
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(2, -2, 4)]
        [InlineData(-10, 2, -12)]
        [InlineData(-8, -4, -4)]
        public void RestarTest(int operando1, int operando2, int resultadoEsperado)
        {
            int resultado = calcService.Restar(operando1, operando2);
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(5, 2, 2)]
        [InlineData(9, 3, 3)]
        [InlineData(-9, 3, -3)]
        [InlineData(-4, -2, 2)]
        [InlineData(25, -5, -5)]
        public void DividirTest(int dividendo, int divisor, int resultadoEsperado)
        {
            int resultado = calcService.Dividir(dividendo, divisor);
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
