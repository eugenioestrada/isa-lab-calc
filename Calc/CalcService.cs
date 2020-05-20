using System;

namespace Calc
{
    public class CalcService
    {
        public int Sumar(int operando1, int operando2) => operando1 + operando2;
        public double Sumar(double operando1, double operando2) => operando1 + operando2;
        public int Restar(int operando1, int operando2) => operando1 - operando2;
        public double Restar(double operando1, double operando2) => operando1 - operando2;
        public int Multiplicar(int multiplicando, int multiplicador) => multiplicando * multiplicador;
        public double Multiplicar(double multiplicando, double multiplicador) => multiplicando * multiplicador;
        public int Dividir(int dividendo, int divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }

            return dividendo / divisor;
        }
        public double Dividir(double dividendo, double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }

            return dividendo / divisor;
        }
        public double RaizCuadrada(int numero)
        {
            if (numero < 0)
            {
                throw new Exception("No existe la raíz cuadrada de números negativos");
            }
            else if (numero == 0 || numero == 1)
            {
                return numero;
            }
            else
            {
                double valorMaximo = numero;
                double valorMinimo = 0;
                double candidato, resultado, error;
                do
                {
                    candidato = this.Sumar(this.Dividir(this.Restar(valorMaximo, valorMinimo), 2), valorMinimo);
                    resultado = this.Multiplicar(candidato, candidato);
                    error = resultado > numero ? this.Restar(resultado, numero) : this.Restar(numero, resultado);

                    if (resultado > numero)
                    {
                        valorMaximo = candidato;
                    }
                    else
                    {
                        valorMinimo = candidato;
                    }
                }
                while (error >= 1e-5);

                return candidato;
            }
        }
    }
}
