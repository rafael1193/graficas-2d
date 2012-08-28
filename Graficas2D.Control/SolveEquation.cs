/* Copyright (C) 2010, 2011 rafael1193
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
    class SolveEquation
    {
        /*Secant method made by pleonex and adapted to Graficas2D.Control by rafael1193*/
        static double Secant(ICalculadora calculator, string function, double a, double b, double precision)
        {
            string funcN = function.Replace("x", "xn");
            string funcN_1 = function.Replace("x", "xn1");

            double xn_1 = a;   // Xn-1
            double xn = b;     // Xn
            double x = 0;       // Xn+1

            calculator.DefinirVariable("xn", xn);
            calculator.DefinirVariable("xn1", xn_1);

            for (int i = 0; Math.Abs(xn - xn_1) > precision; i++)
            {

                x = xn - calculator.EvaluarExpresion(funcN) * ((xn - xn_1) / (calculator.EvaluarExpresion(funcN) - calculator.EvaluarExpresion(funcN_1)));

                xn_1 = xn;
                xn = x;

                calculator.ModificarVariable("xn", xn);
                calculator.ModificarVariable("xn1", xn_1);

                //Console.WriteLine("Iteración " + i.ToString() + ": x = " + x.ToString());
            }

            return x;
        }
    }
}
