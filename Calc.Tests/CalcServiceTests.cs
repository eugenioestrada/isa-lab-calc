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
        [InlineData(1.0, 1.0, 2.0)]
        [InlineData(1.5, -1.0, 0.5)]
        [InlineData(-4.0, -5.0, -9.0)]
        [InlineData(-3.0, 1.4, -1.6)]
        public void SumarDoubleTest(double operando1, double operando2, double resultadoEsperado)
        {
            double resultado = calcService.Sumar(operando1, operando2);
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
        [InlineData(1.0, 1.0, 0.0)]
        [InlineData(1.5, -1.0, 2.5)]
        [InlineData(-4.0, -5.0, 1.0)]
        [InlineData(-3.0, 1.4, -4.4)]
        public void RestarDoubleTest(double operando1, double operando2, double resultadoEsperado)
        {
            double resultado = calcService.Restar(operando1, operando2);
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

        [Theory]
        [InlineData(1.0, 1.0, 1.0)]
        [InlineData(3.0, -2.0, -1.5)]
        [InlineData(-4.0, -2.0, 2.0)]
        [InlineData(-6.0, 2.0, -3.0)]
        public void DividirDoubleTest(double dividendo, double divisor, double resultadoEsperado)
        {
            double resultado = calcService.Dividir(dividendo, divisor);
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void DivisionEntreCeroTest()
        {
            bool haFallado = false;
            try
            {
                calcService.Dividir(5, 0);
            }
            catch (DivideByZeroException)
            {
                haFallado = true;
            }
            Assert.True(haFallado);
        }

        [Fact]
        public void DivisionDoubleEntreCeroTest()
        {
            bool haFallado = false;
            try
            {
                calcService.Dividir(5.0, 0);
            }
            catch (DivideByZeroException)
            {
                haFallado = true;
            }
            Assert.True(haFallado);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(5, 2, 10)]
        [InlineData(9, 3, 27)]
        [InlineData(-9, 3, -27)]
        [InlineData(-4, -2, 8)]
        [InlineData(25, -5, -125)]
        [InlineData(5, 0, 0)]
        [InlineData(-2, 0, 0)]
        public void MultiplicarTest(int multiplicando, int multiplicador, int resultadoEsperado)
        {
            int resultado = calcService.Multiplicar(multiplicando, multiplicador);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(1.0, 1.0, 1.0)]
        [InlineData(3.0, -2.0, -6.0)]
        [InlineData(-4.0, -2.0, 8.0)]
        [InlineData(-6.0, 2.0, -12.0)]
        [InlineData(5.0, 0.0, 0.0)]
        [InlineData(-2.0, 0.0, 0.0)]
        public void MultiplicarDoubleTest(double multiplicando, double multiplicador, double resultadoEsperado)
        {
            double resultado = calcService.Multiplicar(multiplicando, multiplicador);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(5)]
        [InlineData(1000)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public void RaizCuadrada(int numero)
        {
            double resultadoEsperado = Math.Sqrt(numero);
            double resultado = calcService.RaizCuadrada(numero);
            double error = resultadoEsperado > resultado ?
                            resultadoEsperado - resultado :
                            resultado - resultadoEsperado;

            Assert.True(error <= 1e-5);;
        }

        [Fact]
        public void RaizCuadradaDeNegativo()
        {
            bool haFallado = false;
            try
            {
                calcService.RaizCuadrada(-1);
            }
            catch (Exception)
            {
                haFallado = true;
            }
            Assert.True(haFallado);
        }
    }
}
