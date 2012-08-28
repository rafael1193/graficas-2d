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
using System.Drawing;

namespace Graficas2D.Control
{
    public delegate PointF[] MetodoCalculoDelegate(ICalculadora calc, string expresionX, string expresionY, Intervalo intervalo, uint puntosPorUnidad);

    [Serializable]
    public class Funcion2D:SetOfPoints
    {
        //PointF[] puntos;
        //Color colorLinea;
        //float grosor;
        //bool dib;
        //string nom;
        string ecuX;
        string ecuY;
        Intervalo interv;
        uint prof;
        ICalculadora calc;
        MetodoCalculoDelegate metodo;


        #region Constructores
        public Funcion2D():base() { }
        public Funcion2D(string expresionX, string expresionY, Intervalo intervalo, uint puntosPorUnidad, Color color, float grosor, string nombre, bool dibujar, bool autoCalcularPuntos, ICalculadora calculadora, MetodoCalculoDelegate metodoCalculo):base()
        {
            base.puntos = null;
            base.colorLinea = color;
            base.grosor = grosor;
            base.dib = dibujar;
            base.nom = nombre;
            ecuX = expresionX;
            ecuY = expresionY;
            interv = intervalo;
            this.prof = puntosPorUnidad;
            calc = calculadora;
            metodo = metodoCalculo;
            if (autoCalcularPuntos) CalcularPuntos(metodo);
        }

        public Funcion2D(string expresionY, Intervalo intervalo, uint puntosPorUnidad, Color color, float grosor, string nombre, bool dibujar, bool autoCalcularPuntos, ICalculadora calculadora, MetodoCalculoDelegate metodoCalculo):base()
        {
            base.puntos = null;
            base.colorLinea = color;
            base.grosor = grosor;
            base.dib = dibujar;
            base.nom = nombre;
            ecuX = "x";
            ecuY = expresionY;
            interv = intervalo;
            this.prof = puntosPorUnidad;
            calc = calculadora;
            metodo = metodoCalculo;
            if (autoCalcularPuntos) CalcularPuntos(metodo);
        }
        #endregion

        #region CalcularPuntos
        private void CalcularPuntos(MetodoCalculoDelegate metodoCalc)
        {
            puntos = metodoCalc(calc, ecuX, ecuY, interv, prof);
        }

        public void CalcularPuntos()
        {
            CalcularPuntos(metodo);
        }
        #endregion

        #region Propiedades
        public string ExpresionX
        {
            get { return ecuX; }
            set { ecuX = value; }
        }
        public string ExpresionY
        {
            get { return ecuY; }
            set { ecuY = value; }
        }
        public Intervalo Intervalo
        {
            get { return interv; }
            set { interv = value; }
        }
        public uint Profundidad
        {
            get { return prof; }
            set { prof = value; }
        }
        public ICalculadora Calculadora
        {
            get { return calc; }
            set { calc = value; }
        }
        public MetodoCalculoDelegate MetodoCalculo
        {
            get { return metodo; }
            set { metodo = value; }
        }
        #endregion

        #region Override Object

        public override string ToString()
        {
            return nom;
        }

        #endregion

        public class ObtenerPuntos
        {
            public static PointF[] Normal(ICalculadora calc, string expresionX, string expresionY, Intervalo intervalo, uint puntosPorUnidad)
            {
                PointF[] puntos;
                int numtotal = ((int)Math.Round((Math.Abs(intervalo.Fin - intervalo.Inicio) * puntosPorUnidad),0, MidpointRounding.AwayFromZero) + 1);

                try
                {
                    puntos = new PointF[numtotal];

                    for (int k = 0; k < calc.Variables.Count; k++)
                    {
                        calc.Variables[calc.Variables.Keys[k]] = intervalo.Inicio;
                    }

                    for (int i = 0; i < puntos.Length; i++)
                    {
                        puntos[i].X = (float)calc.EvaluarExpresion(expresionX);
                        puntos[i].Y = (float)calc.EvaluarExpresion(expresionY);

                        float a = 1f / (float)(puntosPorUnidad);

                        for (int j = 0; j < calc.Variables.Count; j++)
                        {
                            calc.Variables[calc.Variables.Keys[j]] += a;
                        }
                    }

                    return puntos;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //PointF[] po = new PointF[]{PointF.Empty};
                    //return po;
                }
            }
            public static PointF[] DerivadaX(ICalculadora calc, string expresionX, string expresionY, Intervalo intervalo, uint puntosPorUnidad)
            {
                PointF[] puntos;

                try
                {
                    puntos = new PointF[((int)Math.Round((Math.Abs(intervalo.Fin - intervalo.Inicio) * puntosPorUnidad),0, MidpointRounding.AwayFromZero) + 1)];

                    for (int k = 0; k < calc.Variables.Count; k++)
                    {
                        calc.Variables[calc.Variables.Keys[k]] = intervalo.Inicio;
                    }

                    for (int i = 0; i < puntos.Length; i++)
                    {
                        puntos[i].X = (float)calc.EvaluarExpresion(expresionX);
                        puntos[i].Y = (float)calc.EvaluarDerivada1(expresionY, "x");

                        float a = 1f / (float)(puntosPorUnidad);

                        for (int j = 0; j < calc.Variables.Count; j++)
                        {
                            calc.Variables[calc.Variables.Keys[j]] += a;
                        }
                    }

                    return puntos;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //PointF[] po = new PointF[]{PointF.Empty};
                    //return po;
                }
            }
            public static PointF[] DerivadaY(ICalculadora calc, string expresionX, string expresionY, Intervalo intervalo, uint puntosPorUnidad)
            {
                PointF[] puntos;

                try
                {
                    puntos = new PointF[((int)Math.Round((Math.Abs(intervalo.Fin - intervalo.Inicio) * puntosPorUnidad),0, MidpointRounding.AwayFromZero) + 1)];

                    for (int k = 0; k < calc.Variables.Count; k++)
                    {
                        calc.Variables[calc.Variables.Keys[k]] = intervalo.Inicio;
                    }

                    for (int i = 0; i < puntos.Length; i++)
                    {
                        puntos[i].X = (float)calc.EvaluarExpresion(expresionX);
                        puntos[i].Y = (float)calc.EvaluarDerivada1(expresionY, "y");

                        float a = 1f / (float)(puntosPorUnidad);

                        for (int j = 0; j < calc.Variables.Count; j++)
                        {
                            calc.Variables[calc.Variables.Keys[j]] += a;
                        }
                    }

                    return puntos;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //PointF[] po = new PointF[]{PointF.Empty};
                    //return po;
                }
            }
            public static PointF[] DerivadaT(ICalculadora calc, string expresionX, string expresionY, Intervalo intervalo, uint puntosPorUnidad)
            {
                PointF[] puntos;

                try
                {
                    puntos = new PointF[((int)Math.Round((Math.Abs(intervalo.Fin - intervalo.Inicio) * puntosPorUnidad),0, MidpointRounding.AwayFromZero) + 1)];

                    for (int k = 0; k < calc.Variables.Count; k++)
                    {
                        calc.Variables[calc.Variables.Keys[k]] = intervalo.Inicio;
                    }

                    for (int i = 0; i < puntos.Length; i++)
                    {
                        puntos[i].X = (float)calc.EvaluarExpresion(expresionX);
                        puntos[i].Y = (float)calc.EvaluarDerivada1(expresionY, "t");

                        float a = 1f / (float)(puntosPorUnidad);

                        for (int j = 0; j < calc.Variables.Count; j++)
                        {
                            calc.Variables[calc.Variables.Keys[j]] += a;
                        }
                    }

                    return puntos;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //PointF[] po = new PointF[]{PointF.Empty};
                    //return po;
                }
            }
            /// <summary>
            /// Genera un MetodoCalculoDelegate que hace derivadas de la variable deseada. El delegado encapsula un método anónimo por lo que el rendimiento se puede ver deteriorado. Es preferible crear un método propio en vez de usar este.
            /// </summary>
            /// <param name="calc">Calculadora que se va a utilizar</param>
            /// <param name="expresionX">Expresion para PointF.X</param>
            /// <param name="expresionY">Expresion para PointF.Y</param>
            /// <param name="variableADerivar">Identificador de la variable a Derivar (Debe estar ya definida en la Calculadora)</param>
            /// <param name="intervalo">Intervalo de Cálculo</param>
            /// <param name="puntosPorUnidad">Puntos a calcular por unidad</param>
            /// <returns>MetodoCalculoDelegate</returns>
            public static MetodoCalculoDelegate GenerarMetodoDerivada(ICalculadora calc, string expresionX, string expresionY, string variableADerivar, Intervalo intervalo, uint puntosPorUnidad)
            {
                return delegate(ICalculadora calcu, string expresX, string expresY, Intervalo interv, uint PPU)
                {
                    PointF[] puntos;

                    try
                    {
                        puntos = new PointF[(int)Math.Round((Math.Abs(intervalo.Fin - intervalo.Inicio) * puntosPorUnidad), 0, MidpointRounding.AwayFromZero)];

                        for (int k = 0; k < calc.Variables.Count; k++)
                        {
                            calc.Variables[calc.Variables.Keys[k]] = intervalo.Inicio;
                        }

                        for (int i = 0; i < puntos.Length; i++)
                        {
                            puntos[i].X = (float)calc.EvaluarExpresion(expresionX);
                            puntos[i].Y = (float)calc.EvaluarDerivada1(expresionY, variableADerivar);

                            float a = 1f / (float)(puntosPorUnidad);

                            for (int j = 0; j < calc.Variables.Count; j++)
                            {
                                calc.Variables[calc.Variables.Keys[j]] += a;
                            }
                        }

                        return puntos;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        //PointF[] po = new PointF[]{PointF.Empty};
                        //return po;
                    }
                };
            }
        }
    }
}
