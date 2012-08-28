/* Copyright (C) 2010, 2011  rafael1193
 * 
 * This file is part of Graficas2D.Control
 * 
 * Graficas2D.Control is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *  
 * Graficas2D.Control is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *  
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Graficas2D.Control
{
    public class OperacionesMatematicas
    {
        public static double Suma(double a, double b)
        {
            return a + b;
        }

        public static double Resta(double a, double b)
        {
            return a - b;
        }

        public static double Multiplicacion(double a, double b)
        {
            return a * b;
        }

        public static double Division(double a, double b)
        {
            return a / b;
        }

        public static double Potencia(double a, double b)
        {
            return Math.Pow(a, b);
        }

        public static double LogaritmoNeperiano(double a)
        {
            return Math.Log(a);
        }

        public static double Logaritmo10(double a)
        {
            return Math.Log10(a);
        }

        public static double Logaritmo(double bas, double exp)
        {
            return Math.Log(exp, bas);
        }

        public static double RaizCuadrada(double a)
        {
            return Math.Sqrt(a);
        }

        public static double RaizCubica(double a)
        {
            return Math.Pow(a, (1.0 / 3.0));
        }

        public static double Raiz(double radicando, double indice)
        {
            return Math.Pow(radicando, (1.0 / indice));
        }

        public static double Factorial(double a)
        {
            int resultado = 1;
            checked
            {
                for (int i = 1; i <= a; ++i)
                    resultado = resultado * i;
            }
            return resultado;
        }

        public static double CoeficienteBinomial(double a, double b)
        {
            return (Factorial(a) / (Factorial(b) * Factorial(a - b)));
        }

        public static double Floor(double a)
        {
            if (!double.IsNaN(a))
            {
                return Math.Floor(a);
            }
            else
            {
                return a;
            }
        }

        public static double Ceiling(double a)
        {
            if (!double.IsNaN(a))
            {
                return Math.Ceiling(a);
            }
            else
            {
                return a;
            }
        }

        public static double ParteEntera(double a)
        {
            if (!double.IsNaN(a))
            {
                return (int)a;
            }
            else
            {
                return a;
            }
        }

        public static double Modulo(double a, double b)
        {
            return a % b;
        }

        public static double Signo(double a)
        {
            if (!double.IsNaN(a))
            {
                return Math.Sign(a);
            }
            else
            {
                return a;
            }
        }

        public static double Abs(double a)
        {
            return Math.Abs(a);
        }
        
        public static double Neg(double a)
        {
        	return -a;
        }

        public static double Sin(double a)
        {
            return Math.Sin(a);
        }

        public static double Cos(double a)
        {
            return Math.Cos(a);
        }

        public static double Tan(double a)
        {
            return Math.Tan(a);
        }

        public static double Csc(double a)
        {
            return (1.0 / Math.Sin(a));
        }

        public static double Sec(double a)
        {
            return (1.0 / Math.Cos(a));
        }

        public static double Cot(double a)
        {
            return (1.0 / Math.Tan(a));
        }

        public static double Asin(double a)
        {
            return Math.Asin(a);
        }

        public static double Acos(double a)
        {
            return Math.Acos(a);
        }

        public static double Atan(double a)
        {
            return Math.Atan(a);
        }

        public static double Acsc(double a)
        {
            return Math.Asin(1 / a);
        }

        public static double Asec(double a)
        {
            return Math.Acos(1 / a);
        }

        public static double Acot(double a)
        {
            return Math.Atan(1 / a);
        }

        public static double LogicalAnd(double a, double b)
        {
            int res;

            if ((int)a != 0)
            {
                if ((int)b != 0)
                {
                    res = 1;
                }
                else
                {
                    res = 0;
                }
            }
            else
            {
                res = 0;
            }

            return res;
        }

        public static double LogicalOr(double a, double b)
        {
            int res;

            if ((int)a != 0)
            {
				res = 1;
            }
            else if ((int)b != 0)
            {
                res = 1;
            }
            else
            {
            	res = 0;
            }

            return res;
        }
        
        public static double LogicalNot(double a)
        {
            int res;

            if ((int)a != 0)
            {
				res = 0;
            }
            else
            {
            	res = 1;
            }

            return res;
        }
        
        public static double Max(double a, double b)
        {
        	return Math.Max(a,b);
        }
        
        public static double Min(double a, double b)
        {
        	return Math.Min(a,b);
        }
    }
}
