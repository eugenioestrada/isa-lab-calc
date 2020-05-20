using System;

namespace Calc
{
    public class CalcService
    {
        public int Sumar(int operando1, int operando2)
        {
            return operando1 + operando2;
        }

        public int Restar(int operando1, int operando2)
        {
            return operando1 - operando2;
        }

        public int Dividir(int dividendo, int divisor)
        {
            return dividendo / divisor;
        }

        public int Multiplicar(int multiplicando, int multiplicador)
        {
            return multiplicando * multiplicador;
        }
    }
}
