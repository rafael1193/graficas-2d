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
using System.Drawing;
using Graficas2D.Control;

namespace Graficas2D.Control
{
    public delegate double Operacion1Delegate(double val1);
    public delegate double Operacion2Delegate(double val1, double val2);
    public delegate double Operacion3Delegate(double val1, double val2, double val3);
    public delegate double OperadorInfijoDelegate(double valLeft, double valRight);
    public delegate double OperadorPostfijoDelegate(double val);

    [Serializable]
    public class CalculadoraRPN : ICalculadora
    {
        const double DELTAH = 1e-7;

        string expresion;

        SortedList<string, Operacion1Delegate> operaciones1;
        SortedList<string, Operacion2Delegate> operaciones2;
        SortedList<string, Operacion3Delegate> operaciones3;
        SortedList<string, OperadorInfijoDelegate> operadoresInfijos;
        SortedList<string, OperadorPostfijoDelegate> operadoresPostfijos;
        SortedList<string, double> variables;
        SortedList<string, double> constantes;

        #region Propiedades
        public SortedList<string, double> Variables
        {
            get { return variables; }
            set { variables = value; }
        }

        public SortedList<string, double> Constantes
        {
            get { return constantes; }
            set { constantes = value; }
        }

        public SortedList<string, Operacion1Delegate> Funciones1
        {
            get { return operaciones1; }
            set { operaciones1 = value; }
        }

        public SortedList<string, Operacion2Delegate> Funciones2
        {
            get { return operaciones2; }
            set { operaciones2 = value; }
        }

        public SortedList<string, Operacion3Delegate> Funciones3
        {
            get { return operaciones3; }
            set { operaciones3 = value; }
        }

        public SortedList<string, OperadorInfijoDelegate> OperadoresInfijos
        {
            get { return operadoresInfijos; }
            set { operadoresInfijos = value; }
        }

        public SortedList<string, OperadorPostfijoDelegate> OperadoresPostfijos
        {
            get { return operadoresPostfijos; }
            set { operadoresPostfijos = value; }
        }

        public int NumeroVariables
        {
            get { return Variables.Count; }
        }

        public string Expresion
        {
            get { return expresion; }
            set { expresion = value; }
        }
        #endregion

        public CalculadoraRPN()
        {
            operaciones1 = new SortedList<string, Operacion1Delegate>();
            operaciones2 = new SortedList<string, Operacion2Delegate>();
            operaciones3 = new SortedList<string, Operacion3Delegate>();
            operadoresInfijos = new SortedList<string, OperadorInfijoDelegate>();
            operadoresPostfijos = new SortedList<string, OperadorPostfijoDelegate>();
            variables = new SortedList<string, double>();
            constantes = new SortedList<string, double>();

            expresion = "";

            ////Ans
            //DefinirVariable("ans", 0);

            ////Otras
            //DefinirOperacion("sqrt", new Operacion1Delegate(Sqrt));
            //DefinirOperacion("cbrt", new Operacion1Delegate(Cbrt));
            //DefinirOperacion("!", new Operacion1Delegate(Factorial));
            //DefinirOperacion("C", new Operacion2Delegate(CoeficienteBinomial));
            //DefinirOperacion("sgn", new Operacion1Delegate(OperacionesMatematicas.Signo));
            //DefinirOperacion("floor", new Operacion1Delegate(OperacionesMatematicas.Floor));
            //DefinirOperacion("ceil", new Operacion1Delegate(OperacionesMatematicas.Ceiling));
            //DefinirOperacion("int", new Operacion1Delegate(OperacionesMatematicas.ParteEntera));
            //DefinirOperacion("mod", new Operacion2Delegate(OperacionesMatematicas.Modulo));

            ////Funciones Trigonometricas
            //DefinirOperacion("sin", new Operacion1Delegate(Sin));
            //DefinirOperacion("cos", new Operacion1Delegate(Cos));
            //DefinirOperacion("tan", new Operacion1Delegate(Tan));
            //DefinirOperacion("csc", new Operacion1Delegate(Csc));
            //DefinirOperacion("sec", new Operacion1Delegate(Sec));
            //DefinirOperacion("cot", new Operacion1Delegate(Cot));
            //DefinirOperacion("asin", new Operacion1Delegate(Asin));
            //DefinirOperacion("acos", new Operacion1Delegate(Acos));
            //DefinirOperacion("atan", new Operacion1Delegate(Atan));
            //DefinirOperacion("acsc", new Operacion1Delegate(Asin));
            //DefinirOperacion("asec", new Operacion1Delegate(Acos));
            //DefinirOperacion("acot", new Operacion1Delegate(Atan));

            ////Funciones Básicas
            //DefinirOperacion("+", new Operacion2Delegate(Addition));
            //DefinirOperacion("-", new Operacion2Delegate(Substraction));
            //DefinirOperacion("*", new Operacion2Delegate(Multiplication));
            //DefinirOperacion("/", new Operacion2Delegate(Division));
            //DefinirOperacion("^", new Operacion2Delegate(Power));
            //DefinirOperacion("ln", new Operacion1Delegate(OperacionesMatematicas.LogaritmoNeperiano));
            //DefinirOperacion("log10", new Operacion1Delegate(OperacionesMatematicas.Logaritmo10));
            //DefinirOperacion("log", new Operacion2Delegate(OperacionesMatematicas.Logaritmo));

            ////Constantes matemáticas
            //DefinirConstante("pi", Math.PI);
            //DefinirConstante("e", Math.E);
            //DefinirConstante("phi", 1.618033988749894848);

            ////Constants Fisico-Quimicas
            //DefinirConstante("c", 299792458);
            //DefinirConstante("G", 6.6743e-11);
            //DefinirConstante("g", 9.80665);
            //DefinirConstante("h", 6.62606896e-34);
            //DefinirConstante("R", 8.314472);
            //DefinirConstante("Na", 6.0221415e23);
        }

        #region Definir y modificar operaciones
        public void DefinirOperacion(string token, Operacion1Delegate operacion)
        {
            operaciones1.Add(token, operacion);
        }

        public void DefinirOperacion(string token, Operacion2Delegate operacion)
        {
            operaciones2.Add(token, operacion);
        }

        public void DefinirOperacion(string token, Operacion3Delegate operacion)
        {
            operaciones3.Add(token, operacion);
        }

        public void DefinirOperacion(string token, OperadorInfijoDelegate operacion, int orden, Graficas2D.Control.Asociatividad asociatividad)
        {
            operadoresInfijos.Add(token, operacion);
        }

        public void DefinirOperacion(string token, OperadorPostfijoDelegate operacion)
        {
            operadoresPostfijos.Add(token, operacion);
        }

        public void DefinirConstante(string token, double num)
        {
            constantes.Add(token, num);
        }

        public void EliminarConstante(string token)
        {
            if (!constantes.Remove(token))
            {
                throw new KeyNotFoundException();
            }
        }

        public void EliminarTodasConstantes()
        {
            constantes.Clear();
        }

        public void DefinirVariable(string token, double num)
        {
            variables.Add(token, num);
        }

        public void ModificarVariable(string token, double nuevoNum)
        {
            variables[token] = nuevoNum;
        }

        public void EliminarVariable(string token)
        {
            if (!variables.Remove(token))
            {
                throw new KeyNotFoundException();
            }
        }

        public void EliminarTodasVariables()
        {
            variables.Clear();
        }

        #endregion

        #region Operaciones
        private double Addition(double a, double b)
        {
            return a + b;
        }

        private double Substraction(double a, double b)
        {
            return a - b;
        }

        private double Multiplication(double a, double b)
        {
            return a * b;
        }

        private double Division(double a, double b)
        {
            return a / b;
        }

        private double Power(double a, double b)
        {
            return Math.Pow(a, b);
        }

        private double Sqrt(double a)
        {
            return Math.Sqrt(a);
        }

        private double Cbrt(double a)
        {
            return Math.Pow(a, (1.0 / 3.0));
        }

        private double Factorial(double a)
        {
            int resultado = 1;
            checked
            {
                for (int i = 1; i <= a; ++i)
                    resultado = resultado * i;
            }
            return resultado;
        }

        private double CoeficienteBinomial(double a, double b)
        {
            return (Factorial(a) / (Factorial(b) * Factorial(a - b)));
        }

        private double Sin(double a)
        {
            return Math.Sin(a);
        }

        private double Cos(double a)
        {
            return Math.Cos(a);
        }

        private double Tan(double a)
        {
            return Math.Tan(a);
        }

        private double Csc(double a)
        {
            return (1.0 / Math.Sin(a));
        }

        private double Sec(double a)
        {
            return (1.0 / Math.Cos(a));
        }

        private double Cot(double a)
        {
            return (1.0 / Math.Tan(a));
        }

        private double Asin(double a)
        {
            return Math.Asin(a);
        }

        private double Acos(double a)
        {
            return Math.Acos(a);
        }

        private double Atan(double a)
        {
            return Math.Atan(a);
        }

        private double Acsc(double a)
        {
            return Math.Asin(1 / a);
        }

        private double Asec(double a)
        {
            return Math.Acos(1 / a);
        }

        private double Acot(double a)
        {
            return Math.Atan(1 / a);
        }
        #endregion

        #region Evaluar
        public bool ComprobarValidez(string operaciones)
        {
            bool valido = false;
            try
            {
                EvaluarExpresion(operaciones);
                valido = true;
            }
            catch (Exception e)
            { }
            return valido;
        }

        public double EvaluarExpresion(string operaciones)
        {
            Stack<double> pila = new Stack<double>();

            StringBuilder cadena = new StringBuilder(operaciones);
            StringBuilder operando = new StringBuilder(4);

            int c = 0;
            int pos = 0;

            if (operaciones.Length == 0)
            {
                throw new ArgumentException("No se han introducido operaciones");
            }

            cadena.Append(' ');

            while (pos < operaciones.Length)
            {
                c = 1;
                operando = new StringBuilder(4);

                while (cadena[pos] != ' ')
                {
                    operando.Append(cadena[pos]);
                    c++;
                    pos++;
                }

                double num;

                if (double.TryParse(operando.ToString(), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out num))
                {
                    pila.Push(num);
                }
                else
                {
                    double x1;
                    double x2;
                    double x3;

                    bool operado = false;

                    Operacion1Delegate op1;
                    Operacion2Delegate op2;
                    Operacion3Delegate op3;
                    OperadorInfijoDelegate opIn;
                    OperadorPostfijoDelegate opPost;

                    if (pila.Count >= 0)
                    {
                        if (constantes.TryGetValue(operando.ToString().ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat), out x1))
                        {
                            pila.Push(x1);
                            operado = true;
                        }
                        else
                        {
                            if (variables.TryGetValue(operando.ToString().ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat), out x1))
                            {
                                pila.Push(x1);
                                operado = true;
                            }
                            if (/*pila.Count >= 1 &&*/ operado == false)
                            {
                                if (operaciones1.TryGetValue(operando.ToString(), out op1))
                                {
                                    x1 = pila.Pop();
                                    pila.Push(op1(x1));
                                    operado = true;
                                }

                                if (operado == false && OperadoresPostfijos.TryGetValue(operando.ToString(), out opPost))
                                {
                                    
                                    x1 = pila.Pop();
                                    pila.Push(opPost(x1));
                                    operado = true;
                                }

                                if (/*pila.Count >= 2 &&*/ operado == false)
                                {
                                    if (operaciones2.TryGetValue(operando.ToString(), out op2))
                                    {
                                        x1 = pila.Pop();
                                        x2 = pila.Pop();
                                        pila.Push(op2(x2, x1));
                                        operado = true;
                                    }

                                    if (operado == false && operadoresInfijos.TryGetValue(operando.ToString(), out opIn))
                                    {  
                                        x1 = pila.Pop();
                                        x2 = pila.Pop();
                                        pila.Push(opIn(x2, x1));
                                        operado = true;
                                    }

                                    if (/*pila.Count >= 3 &&*/ operado == false)
                                    {
                                        if (operaciones3.TryGetValue(operando.ToString(), out op3))
                                        {
                                            x1 = pila.Pop();
                                            x2 = pila.Pop();
                                            x3 = pila.Pop();
                                            pila.Push(op3(x3, x2, x1));
                                            operado = true;
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("Se ha introducido una operación que no existe");
                                        }
                                    }
                                }
                            }

                        }
                    }
                }

                pos++;
            }
            if (pila.Count == 1)
            {
                variables["ans"] = pila.Peek();
                //ans = pila.Peek();
                return pila.Pop();
            }
            else
            {
                throw new ArgumentException("Sobran valores en la expresión");
            }
        }

        public double EvaluarDerivada1(string expresion, string variableADerivar)
        {
            if (variables.ContainsKey(variableADerivar))
            {
                double punto = variables[variableADerivar];

                variables[variableADerivar] = punto + 2 * DELTAH;
                double f1 = -EvaluarExpresion(expresion);

                variables[variableADerivar] = punto + DELTAH;
                double f2 = 8 * EvaluarExpresion(expresion);

                variables[variableADerivar] = punto - DELTAH;
                double f3 = -8 * EvaluarExpresion(expresion);

                variables[variableADerivar] = punto - 2 * DELTAH;
                double f4 = EvaluarExpresion(expresion);

                return (f1 + f2 + f3 + f4) / (12 * DELTAH);

                //double punto = variables[variableADerivar];

                //variables[variableADerivar] = punto + DELTAH;
                //double f1 = EvaluarExpresion(expresion);

                //variables[variableADerivar] = punto;
                //double f2 = EvaluarExpresion(expresion);

                //return ((f1 - f2) / DELTAH);
            }
            else
            {
                throw new ArgumentException("La variable a derivar no está definida");
            }
        }

        public double EvaluarExpresion()
        {
            return EvaluarExpresion(expresion);
        }

        public double EvaluarDerivada1(string variableADerivar)
        {
            return EvaluarDerivada1(expresion, variableADerivar);
        }

        public double EvaluarDerivada2(string expresion, string variableADerivar)
        {
            throw new NotImplementedException();
        }

        public double EvaluarDerivada2(string variableADerivar)
        {
            throw new NotImplementedException();
        }

        public double EvaluarDerivada3(string expresion, string variableADerivar)
        {
            throw new NotImplementedException();
        }

        public double EvaluarDerivada3(string variableADerivar)
        {
            throw new NotImplementedException();
        }

        public double EvaluarDerivada4(string expresion, string variableADerivar)
        {
            throw new NotImplementedException();
        }

        public double EvaluarDerivada4(string variableADerivar)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Test
        public static bool Test()
        {
            string expresion = "G x * raizcuarta sin";

            try
            {
                CalculadoraRPN calc = new CalculadoraRPN();

                calc.EvaluarExpresion(expresion).ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Test(string expresion, string[] variables)
        {
            try
            {
                CalculadoraRPN calc = new CalculadoraRPN();
                Random ran = new Random();

                for (int i = 0; i < variables.Length; i++)
                {
                    calc.DefinirVariable(variables[i], ran.Next());
                }

                calc.EvaluarExpresion(expresion).ToString();

                return true;
            }
            catch
            {
                return false;
            }


        }
        #endregion

        #region ICloneable
        public object Clone()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
