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
	[Serializable]
	public class CalculadoraInfija : Graficas2D.Control.ICalculadora
	{
		private enum TipoToken
		{
			Ninguno = 0,
			Separador,
			ParentesisIzquierdo,
			ParentesisDerecho,
			Variable,
			Constante,
			Funcion1,
			Funcion2,
			Funcion3,
			Operador,
			OperadorPostfijo,
			Numero
		}

		private enum TipoChar
		{
			Ninguno,
			Numero,
			PuntoDecimal,
			SeparadorFun,
			ParentesisIzquierdo,
			ParentesisDerecho,
			Letra,
			Operador,
			OperadorPostfijo

		}

		private struct Token
		{
			string cadena;
			TipoToken tipoToken;

			public String Cadena
			{
				get { return cadena; }
				set { cadena = value; }
			}

			public TipoToken Tipo
			{
				get { return tipoToken; }
				set { tipoToken = value; }
			}

			public Token(string cadena, TipoToken tipoToken)
			{
				this.cadena = cadena;
				this.tipoToken = tipoToken;
			}
		}

		string separador = ",";
		string parentesisIzquierdo = "(";
		string parentesisDerecho = ")";
		string separadorDecimal = ".";

		const double DELTAH = 1e-7;

		CalculadoraRPN calc;

		SortedList<string, double> variables;
		SortedList<string, double> constantes;
		SortedList<string, Operacion1Delegate> fun1;
		SortedList<string, Operacion2Delegate> fun2;
		SortedList<string, Operacion3Delegate> fun3;
		SortedList<string, OperadorInfijoDelegate> oper;
		SortedList<string, int> preced;
		SortedList<string, Asociatividad> asoc;
		SortedList<string, OperadorPostfijoDelegate> post;

		string expresionAnt;
		string rpnAnt;

		public SortedList<string, double> Variables
		{
			get { return variables; }
			set { variables = value; }
		}

		public CalculadoraInfija()
		{
			calc = new CalculadoraRPN();

			variables = new SortedList<string, double>();
			constantes = new SortedList<string, double>();
			fun1 = new SortedList<string, Operacion1Delegate>();
			fun2 = new SortedList<string, Operacion2Delegate>();
			fun3 = new SortedList<string, Operacion3Delegate>();
			oper = new SortedList<string, OperadorInfijoDelegate>();
			post = new SortedList<string, OperadorPostfijoDelegate>();
			preced = new SortedList<string, int>();
			asoc = new SortedList<string, Asociatividad>();

			calc.Variables = variables;
			calc.Funciones1 = fun1;
			calc.Funciones2 = fun2;
			calc.Funciones3 = fun3;
			calc.Constantes = constantes;
			calc.OperadoresInfijos = oper;
			calc.OperadoresPostfijos = post;

			fun1.Add("sqrt", new Operacion1Delegate(OperacionesMatematicas.RaizCuadrada));
			fun1.Add("cbrt", new Operacion1Delegate(OperacionesMatematicas.RaizCubica));
			fun1.Add("ln", new Operacion1Delegate(OperacionesMatematicas.LogaritmoNeperiano));
			fun1.Add("log10", new Operacion1Delegate(OperacionesMatematicas.Logaritmo10));
			fun1.Add("log2", new Operacion1Delegate(OperacionesMatematicas.Logaritmo10));
			fun1.Add("sin", new Operacion1Delegate(OperacionesMatematicas.Sin));
			//fun1.Add("sen", new Operacion1Delegate(OperacionesMatematicas.Sin));
			fun1.Add("cos", new Operacion1Delegate(OperacionesMatematicas.Cos));
			fun1.Add("tan", new Operacion1Delegate(OperacionesMatematicas.Tan));
			//fun1.Add("tg", new Operacion1Delegate(OperacionesMatematicas.Tan));
			fun1.Add("asin", new Operacion1Delegate(OperacionesMatematicas.Asin));
			//fun1.Add("asen", new Operacion1Delegate(OperacionesMatematicas.Asin));
			fun1.Add("acos", new Operacion1Delegate(OperacionesMatematicas.Acos));
			fun1.Add("atan", new Operacion1Delegate(OperacionesMatematicas.Atan));
			fun1.Add("arcsin", new Operacion1Delegate(OperacionesMatematicas.Asin));
			//fun1.Add("arcsen", new Operacion1Delegate(OperacionesMatematicas.Asin));
			fun1.Add("arccos", new Operacion1Delegate(OperacionesMatematicas.Acos));
			fun1.Add("arctan", new Operacion1Delegate(OperacionesMatematicas.Atan));
			fun1.Add("csc", new Operacion1Delegate(OperacionesMatematicas.Csc));
			//fun1.Add("cosec", new Operacion1Delegate(OperacionesMatematicas.Csc));
			fun1.Add("sec", new Operacion1Delegate(OperacionesMatematicas.Sec));
			fun1.Add("cot", new Operacion1Delegate(OperacionesMatematicas.Cot));
			//fun1.Add("cotg", new Operacion1Delegate(OperacionesMatematicas.Cot));
			fun1.Add("acsc", new Operacion1Delegate(OperacionesMatematicas.Acsc));
			//fun1.Add("acosec", new Operacion1Delegate(OperacionesMatematicas.Acsc));
			fun1.Add("asec", new Operacion1Delegate(OperacionesMatematicas.Asec));
			fun1.Add("acot", new Operacion1Delegate(OperacionesMatematicas.Acot));
			//fun1.Add("acotg", new Operacion1Delegate(OperacionesMatematicas.Acot));
			//fun1.Add("arccsc", new Operacion1Delegate(OperacionesMatematicas.Acsc));
			//fun1.Add("arccosec", new Operacion1Delegate(OperacionesMatematicas.Acsc));
			//fun1.Add("arcsec", new Operacion1Delegate(OperacionesMatematicas.Asec));
			//fun1.Add("arccot", new Operacion1Delegate(OperacionesMatematicas.Acot));
			//fun1.Add("arccotg", new Operacion1Delegate(OperacionesMatematicas.Acot));
			fun1.Add("sgn", new Operacion1Delegate(OperacionesMatematicas.Signo));
			fun1.Add("int", new Operacion1Delegate(OperacionesMatematicas.ParteEntera));
			fun1.Add("floor", new Operacion1Delegate(OperacionesMatematicas.Floor));
			fun1.Add("ceil", new Operacion1Delegate(OperacionesMatematicas.Ceiling));
			fun1.Add("abs", new Operacion1Delegate(OperacionesMatematicas.Abs));
			fun1.Add("neg", new Operacion1Delegate(OperacionesMatematicas.Neg));
			fun1.Add("not", new Operacion1Delegate(OperacionesMatematicas.LogicalNot));
			

			fun2.Add("add", new Operacion2Delegate(OperacionesMatematicas.Suma));
			fun2.Add("sub", new Operacion2Delegate(OperacionesMatematicas.Resta));
			fun2.Add("mul", new Operacion2Delegate(OperacionesMatematicas.Multiplicacion));
			fun2.Add("div", new Operacion2Delegate(OperacionesMatematicas.Division));
			fun2.Add("pow", new Operacion2Delegate(OperacionesMatematicas.Potencia));
			fun2.Add("mod", new Operacion2Delegate(OperacionesMatematicas.Modulo));
			fun2.Add("log", new Operacion2Delegate(OperacionesMatematicas.Logaritmo));
			fun2.Add("root", new Operacion2Delegate(OperacionesMatematicas.Raiz));
			//fun2.Add("raiz", new Operacion2Delegate(OperacionesMatematicas.Raiz));
			fun2.Add("max", new Operacion2Delegate(OperacionesMatematicas.Max));
			fun2.Add("min", new Operacion2Delegate(OperacionesMatematicas.Min));
			fun2.Add("and", new Operacion2Delegate(OperacionesMatematicas.LogicalAnd));
			fun2.Add("or", new Operacion2Delegate(OperacionesMatematicas.LogicalOr));

			DefinirOperacion("+", OperacionesMatematicas.Suma, 3, Asociatividad.Izquierda);
			DefinirOperacion("-", OperacionesMatematicas.Resta, 3, Asociatividad.Izquierda);
			DefinirOperacion("*", OperacionesMatematicas.Multiplicacion, 4, Asociatividad.Izquierda);
			DefinirOperacion("/", OperacionesMatematicas.Division, 4, Asociatividad.Izquierda);
			DefinirOperacion("%", OperacionesMatematicas.Modulo, 4, Asociatividad.Izquierda);
			DefinirOperacion("^", OperacionesMatematicas.Potencia, 5, Asociatividad.Izquierda);
			DefinirOperacion("C", OperacionesMatematicas.Potencia, 6, Asociatividad.Izquierda);
			DefinirOperacion("|", OperacionesMatematicas.LogicalOr, 7, Asociatividad.Izquierda);			
			DefinirOperacion("&", OperacionesMatematicas.LogicalAnd, 8, Asociatividad.Izquierda);
			
			post.Add("!", new OperadorPostfijoDelegate(OperacionesMatematicas.Factorial));

			//Ans
			DefinirVariable("ans", 0);

			//Constantes matemáticas
			DefinirConstante("pi", Math.PI);
			DefinirConstante("e", Math.E);
			DefinirConstante("phi", 1.618033988749894848);

			//Constants Fisico-Quimicas
			DefinirConstante("c", 299792458);
			DefinirConstante("G", 6.6743e-11);
			DefinirConstante("g", 9.80665);
			DefinirConstante("h", 6.62606896e-34);
			DefinirConstante("R", 8.314472);
			DefinirConstante("Na", 6.0221415e23);
			DefinirConstante("mu0", Math.PI * 4E-7);
			DefinirConstante("epsilon0", 8.854187817620E-12);

		}

		private Token[] Tokenizar(string operaciones)
		{
			List<string> lista = new List<string>();
			StringBuilder buffer = new StringBuilder();
			int conteoParentesis = 0;

			if (operaciones.Length == 0)
			{
				throw new ArgumentException("No se han introducido operaciones");
			}

			for (int i = 0; i < operaciones.Length; i++)
			{
				if (char.IsLetterOrDigit(operaciones[i]) || operaciones[i].ToString() == separadorDecimal)
				{
					buffer.Append(operaciones[i]);
				}
				else
				{
					if (buffer.Length > 0)
						lista.Add(buffer.ToString());
					lista.Add(operaciones[i].ToString());
					buffer = new StringBuilder();
					if (operaciones[i].ToString() == parentesisIzquierdo)
					{ conteoParentesis++; }
					else if (operaciones[i].ToString() == parentesisDerecho)
					{ conteoParentesis--; }
				}
			}

			if (buffer.Length != 0) lista.Add(buffer.ToString());

			//Se cuenta el balance de parentesis abiertos y cerrados para ver si la expresion es correcta. Si el conteo es != 0 es que faltan o sobran parentesis
			if (conteoParentesis != 0)
			{
				if (conteoParentesis > 0)
					throw new FormatException("Hay más parentesis abiertos que cerrados. Comprueba la expresion.");
				if (conteoParentesis < 0)
					throw new FormatException("Hay más parentesis cerrados que abiertos. Comprueba la expresion.");
			}

			//            /*Se comprueban los signos '-' para analizar si son operador y el signo negativo de un numero*/
			//            int j = 0;
			//            if (lista.Count > 1 && lista[0] == "-")
			//            {
			//                //si el primer elemento es un "-", ponemos un 0 delante para que haya los dos operadores que requiere el "-"
			//                lista[0] = "-";
			//                lista.Insert(0, "0");
			//            }
			//            for (j = 1; j < lista.Count; j++)
			//            {
			//                if (lista[j] == "-")
			//                {
			//                    TipoToken tokenAnt = ObtenerTipoToken(lista[j - 1]);
			//                    TipoToken tokenPost = ObtenerTipoToken(lista[j + 1]);
			//                    if (!(tokenAnt == TipoToken.Variable || tokenAnt == TipoToken.Numero || tokenAnt == TipoToken.Constante)) //si el elemento anterior no es un numero/variable/constante...
			//                    {
			//                        if (tokenPost == TipoToken.Variable || tokenPost == TipoToken.Numero || tokenPost == TipoToken.Constante) //y el siguiente si lo es, quiere decir que es un "-" unario
			//                        {
			//                            //ponemos un 0 delante para que haya los dos operadores que requiere el "-" y unos parentesis para mantener el orden de operaciones
			//                            lista.Insert(j, "0");
			//                            lista.Insert(j, parentesisIzquierdo);
			//                            lista.Insert(j + 4, parentesisDerecho);
			//                            j = j + 4;
			//                        }
			//                    }
			//                }
			//            }
			
			/*Handler for '-' meaning negation instead of substraction*/
			//For the first element
			int j = 0;
			if (lista.Count > 1 && lista[j] == "-")
			{
				TipoToken tokenPost = ObtenerTipoToken(lista[j + 1]);
				
				if (tokenPost != TipoToken.ParentesisIzquierdo)
				{
					if(tokenPost != TipoToken.Funcion1 && tokenPost != TipoToken.Funcion2 && tokenPost != TipoToken.Funcion3)
					{
						lista[j] = "neg";
						lista.Insert(j + 1, parentesisIzquierdo);
						lista.Insert(j + 3, parentesisDerecho);
					}
					else
					{
						lista[j] = "neg";
						lista.Insert(j + 1, parentesisIzquierdo);
						//for functions, it's necessary to search it's beginning and end
						int jprov = j + 3;
						int balanceParentesis = 0;
						
						do
						{
							if (lista[jprov] == parentesisIzquierdo)
							{
								balanceParentesis++;
							}
							else if(lista[jprov] == parentesisDerecho)
							{
								balanceParentesis--;
							}
							
							jprov++;
						} while (balanceParentesis != 0);
						
						lista.Insert(jprov - 1,parentesisDerecho);
					}
				}
				else
				{
					lista[0]="neg";
				}
			}
			
			for (j = 1; j < lista.Count-1; j++)
			{
				if (lista[j] == "-")
				{
					TipoToken tokenAnt = ObtenerTipoToken(lista[j - 1]);
					TipoToken tokenPost = ObtenerTipoToken(lista[j + 1]);
					
					if (tokenAnt == TipoToken.ParentesisIzquierdo || tokenAnt == TipoToken.Separador) //si el elemento anterior no es un numero/variable/constante...
					{
						if(tokenPost != TipoToken.Funcion1 && tokenPost != TipoToken.Funcion2 && tokenPost != TipoToken.Funcion3)
						{
							lista[j]="neg";
							lista.Insert(j + 1, parentesisIzquierdo);
							lista.Insert(j + 3, parentesisDerecho);
							j = j + 3;
						}
						else
						{
							lista[j] = "neg";
						lista.Insert(j + 1, parentesisIzquierdo);
						//for functions, it's necessary to search it's beginning and end
						int jprov = j + 3;
						int balanceParentesis = 0;
						
						do
						{
							if (lista[jprov] == parentesisIzquierdo)
							{
								balanceParentesis++;
							}
							else if(lista[jprov] == parentesisDerecho)
							{
								balanceParentesis--;
							}
							
							jprov++;
						} while (balanceParentesis != 0);
						
						lista.Insert(jprov - 1,parentesisDerecho);
						}
					}
					else if (tokenPost == TipoToken.ParentesisIzquierdo && tokenAnt != TipoToken.ParentesisDerecho)
					{
						lista[j]="neg";
					}
				}

			}

			/*Se convierten los items de la lista en los Token correspondientes*/
			Token[] tokens = new Token[lista.Count];
			TipoToken tipo;

			for (int i = 0; i < lista.Count; i++)
			{
				if (lista[i] != " " && lista[i] != "" && lista[i] != null) //se descartan los vacios y los nulos que a veces se generan para evitar que salte la excepcion de "elemento desconocido"
				{
					tipo = ObtenerTipoToken(lista[i]);
					if (tipo == TipoToken.Ninguno) throw new KeyNotFoundException("Se ha introducido un elemento desconocido");
					tokens[i] = new Token(lista[i], tipo);
				}
			}

			return tokens;
		}

		private string ShuntingYard(Token[] tokens)
		{
			StringBuilder output = new StringBuilder();
			Stack<Token> stack = new Stack<Token>();
			int tokensLeidos = 0;

			for (tokensLeidos = 0; tokensLeidos < tokens.Length; tokensLeidos++)
			{
				Token tok = tokens[tokensLeidos];
				if (tok.Tipo != TipoToken.Ninguno)
				{
					if (tok.Tipo == TipoToken.Numero)
						output.Append(tok.Cadena + " ");

					if (tok.Tipo == TipoToken.Variable)
						output.Append(tok.Cadena + " ");

					if (tok.Tipo == TipoToken.Constante)
						output.Append(tok.Cadena + " ");

					if (tok.Tipo == TipoToken.Funcion1 || tok.Tipo == TipoToken.Funcion2 || tok.Tipo == TipoToken.Funcion3)
						stack.Push(tok);

					if (tok.Tipo == TipoToken.OperadorPostfijo)
						output.Append(tok.Cadena + " ");

					if (tok.Tipo == TipoToken.Separador)
					{
						while (stack.Peek().Tipo != TipoToken.ParentesisIzquierdo)
						{
							output.Append(stack.Pop().Cadena + " ");
						}
					}

					if (tok.Tipo == TipoToken.Operador)
					{
						if (stack.Count > 0)
						{
							while (stack.Peek().Tipo == TipoToken.Operador && ((asoc[tok.Cadena] == Asociatividad.Izquierda && preced[tok.Cadena] < preced[stack.Peek().Cadena]) || (asoc[tok.Cadena] == Asociatividad.Derecha && preced[tok.Cadena] < preced[stack.Peek().Cadena])))
							{
								output.Append(stack.Pop().Cadena + " ");
								if (stack.Count <= 0) break;
							}
						}
						stack.Push(tok);
					}

					if (tok.Tipo == TipoToken.ParentesisIzquierdo)
						stack.Push(tok);

					if (tok.Tipo == TipoToken.ParentesisDerecho)
					{
						while (stack.Peek().Tipo != TipoToken.ParentesisIzquierdo)
						{
							output.Append(stack.Pop().Cadena + " ");

						}
						stack.Pop();

						if (stack.Count > 0 && stack.Peek().Tipo == TipoToken.Funcion1)
						{
							output.Append(stack.Pop().Cadena + " ");
						}
						else if (stack.Count > 0 && stack.Peek().Tipo == TipoToken.Funcion2)
						{
							output.Append(stack.Pop().Cadena + " ");

						}
						else if (stack.Count > 0 && stack.Peek().Tipo == TipoToken.Funcion3)
						{
							output.Append(stack.Pop().Cadena + " ");
						}
					}
				}
			}
			while (stack.Count != 0)
			{
				output.Append(stack.Pop().Cadena + " ");
			}


			return output.ToString();
		}

		private TipoChar ObtenerTipoChar(char op)
		{
			if (oper.ContainsKey(op.ToString()))
			{ return TipoChar.Operador; }

			if (char.IsDigit(op))
			{ return TipoChar.Numero; }

			if (op == '.')
			{ return TipoChar.PuntoDecimal; }

			if (op == parentesisIzquierdo[0])
			{ return TipoChar.ParentesisIzquierdo; }

			if (op == parentesisDerecho[0])
			{ return TipoChar.ParentesisDerecho; }

			if (op == separador[0])
			{ return TipoChar.SeparadorFun; }

			if (char.IsLetter(op))
			{ return TipoChar.Letra; }

			return TipoChar.Ninguno;
		}

		private TipoToken ObtenerTipoToken(string op)
		{
			double o;

			if (op == separador)
			{ return TipoToken.Separador; }

			if (op == parentesisIzquierdo)
			{ return TipoToken.ParentesisIzquierdo; }

			if (op == parentesisDerecho)
			{ return TipoToken.ParentesisDerecho; }

			if (Double.TryParse(op, out o))
			{ return TipoToken.Numero; }

			if (variables.ContainsKey(op))
			{ return TipoToken.Variable; }

			if (constantes.ContainsKey(op))
			{ return TipoToken.Constante; }

			if (oper.ContainsKey(op))
			{ return TipoToken.Operador; }

			if (fun1.ContainsKey(op))
			{ return TipoToken.Funcion1; }

			if (fun2.ContainsKey(op))
			{ return TipoToken.Funcion2; }

			if (fun3.ContainsKey(op))
			{ return TipoToken.Funcion3; }

			if (post.ContainsKey(op))
			{ return TipoToken.OperadorPostfijo; }

			return TipoToken.Ninguno;
		}

		public void DefinirOperacion(string token, Operacion1Delegate operacion)
		{
			if (!fun1.ContainsKey(token))
			{
				fun1.Add(token, operacion);
			}
			else
			{
				fun1[token] = operacion;
			}
		}

		public void DefinirOperacion(string token, Operacion2Delegate operacion)
		{
			if (!fun2.ContainsKey(token))
			{
				fun2.Add(token, operacion);
			}
			else
			{
				fun2[token] = operacion;
			}
		}

		public void DefinirOperacion(string token, Operacion3Delegate operacion)
		{
			if (!fun3.ContainsKey(token))
			{
				fun3.Add(token, operacion);
			}
			else
			{
				fun3[token] = operacion;
			}
		}

		public void DefinirOperacion(string token, OperadorInfijoDelegate operacion, int precedencia, Asociatividad asociatividad)
		{
			if (!oper.ContainsKey(token))
			{
				oper.Add(token, operacion);
				preced.Add(token, precedencia);
				asoc.Add(token, asociatividad);
			}
			else
			{
				oper[token] = operacion;
				preced[token] = precedencia;
				asoc[token] = asociatividad;
			}
		}

		public void DefinirOperacion(string token, OperadorPostfijoDelegate operacion)
		{
			if (!post.ContainsKey(token))
			{
				post.Add(token, operacion);
			}
			else
			{
				post[token] = operacion;
			}
		}

		public void DefinirConstante(string token, double num)
		{
			if (!constantes.ContainsKey(token))
			{
				constantes.Add(token, num);
			}
			else
			{
				constantes[token] = num;
			}
		}
		/// <summary>
		/// Elimina una constante definida
		/// </summary>
		/// <param name="token"></param>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException">Se lanza cuando se intenta eliminar una constante que no existe</param>
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
			if (variables.ContainsKey(token))
			{
				variables[token] = nuevoNum;
			}
			else
			{
				variables.Add(token, nuevoNum);
			}
		}
		/// <summary>
		/// Elimina una variable definida
		/// </summary>
		/// <param name="token"></param>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException">Se lanza cuando se intenta eliminar una variable que no existe</param>
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

		public double EvaluarDerivada1(string variableADerivar)
		{
			return EvaluarDerivada1(expresionAnt, variableADerivar);
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

		public double EvaluarExpresion()
		{
			return calc.EvaluarExpresion(rpnAnt);
		}

		public double EvaluarExpresion(string operaciones)
		{
			if (expresionAnt != operaciones)
			{
				expresionAnt = operaciones;
				rpnAnt = ShuntingYard(Tokenizar(operaciones));
				rpnAnt.Trim(new char[] { '\0', ' ' });
			}

			return (calc.EvaluarExpresion(rpnAnt));
		}

		public bool ComprobarValidez(string operaciones)
		{
			bool valido = false;
			try
			{
				rpnAnt = ShuntingYard(Tokenizar(operaciones));
				valido = true;
			}
			catch (Exception e)
			{

			}
			return valido;
		}

		public string Expresion
		{
			get { return expresionAnt; }
			set { expresionAnt = value; }
		}

		public int NumeroVariables
		{
			get { return variables.Count; }
		}

		object ICloneable.Clone()
		{
			Object copy = Clone();
			return copy;
		}

		public CalculadoraInfija Clone()
		{
			CalculadoraInfija calcCopy = new CalculadoraInfija();

			System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			System.IO.Stream stream = new System.IO.MemoryStream();

			using (stream)
			{
				formatter.Serialize(stream, this);
				stream.Seek(0, System.IO.SeekOrigin.Begin);
				return (CalculadoraInfija)formatter.Deserialize(stream);
			}
		}
	}
}
