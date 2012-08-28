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

namespace Graficas2D.Control
{
    class CodigoEjemplo
    {
        private CodigoEjemplo()
        {
            Funcion2D func = new Funcion2D();
            CalculadoraInfija calc = new CalculadoraInfija();
            calc.DefinirVariable("x", 0);

            func.Puntos = new System.Drawing.PointF[200];

            for (int i = 0; i < 200; i++)
            {
                func.Puntos[i].X = i;
                func.Puntos[i].Y = (float)calc.EvaluarExpresion("3*x");
                calc.ModificarVariable("x", i);
            }

            func.Grosor = 3f;
            func.ColorLinea = System.Drawing.Color.AliceBlue;
            func.Dibujar = true;

            System.Console.Beep(440, 1);

            Papel2 papel = new Papel2();
            papel.Funciones.Add(func);
        }
    }
}
