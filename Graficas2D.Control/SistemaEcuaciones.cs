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

namespace Graficas2D.Control
{
    public class SistemaEcuaciones
    {
        public static bool ResolverGauss(double[,] matrizValores, out double[] resultados)
        {
            double t, s;
            int i, l, j, k, m, n;

            resultados = new double[matrizValores.GetLength(0)];

            try
            {
                n = resultados.Length - 1;
                m = n + 1;
                for (l = 0; l <= n - 1; l++)
                {
                    j = l;
                    for (k = l + 1; k <= n; k++)
                    {
                        if (!(Math.Abs(matrizValores[j, l]) >= Math.Abs(matrizValores[k, l]))) j = k;
                    }

                    if (!(j == l))
                    {
                        for (i = 0; i <= m; i++)
                        {
                            t = matrizValores[l, i];
                            matrizValores[l, i] = matrizValores[j, i];
                            matrizValores[j, i] = t;
                        }
                    }

                    for (j = l + 1; j <= n; j++)
                    {
                        t = (matrizValores[j, l] / matrizValores[l, l]);
                        for (i = 0; i <= m; i++) matrizValores[j, i] -= t * matrizValores[l, i];
                    }
                }

                resultados[n] = matrizValores[n, m] / matrizValores[n, n];
                for (i = 0; i <= n - 1; i++)
                {
                    j = n - i - 1;
                    s = 0;

                    for (l = 0; l <= i; l++)
                    {
                        k = j + l + 1;
                        s += matrizValores[j, k] * resultados[k];
                    }
                    resultados[j] = ((matrizValores[j, m] - s) / matrizValores[j, j]);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ResolverGauss(ICalculadora calc, string[,] matrizExpresiones, out double[] resultados)
        {
            int filas = matrizExpresiones.GetLength(0);

            int columnas = matrizExpresiones.GetLength(1);

            double[,] valores = new double[filas, columnas];

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    valores[i, j] = calc.EvaluarExpresion(matrizExpresiones[i, j]);
                }
            }

            return ResolverGauss(valores, out resultados);
  
        }
    }
}
