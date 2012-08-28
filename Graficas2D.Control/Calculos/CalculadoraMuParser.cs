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
    //public class CalculadoraMuParser : ICalculadora
    //{
    //    const double DELTAH = 1e-7;

    //    //muParser.Parser parser;
    //    string expresionAnt;
    //    string derivAnt;

    //    Dictionary<string, double> dic;

    //    public CalculadoraMuParser()
    //    {
    //        //parser = new muParser.Parser();

    //        dic = new Dictionary<string, double>();

    //        DefinirOperacion("cbrt",new Operacion1Delegate(OperacionesMatematicas.RaizCubica));
    //        DefinirOperacion("!", new OperadorPostfijoDelegate(OperacionesMatematicas.Factorial));
    //        DefinirOperacion("C", new OperadorInfijoDelegate(OperacionesMatematicas.CoeficienteBinomial),100);

    //        //Constantes matemáticas
    //        DefinirConstante("pi", Math.PI);
    //        DefinirConstante("e", Math.E);
    //        DefinirConstante("phi", 1.618033988749894848);

    //        //Constants Fisico-Quimicas
    //        DefinirConstante("c", 299792458);
    //        DefinirConstante("G", 6.6743e-11);
    //        DefinirConstante("g", 9.80665);
    //        DefinirConstante("h", 6.62606896e-34);
    //        DefinirConstante("R", 8.314472);
    //        DefinirConstante("Na", 6.0221415e23);
    //    }

    //    public int NumeroVariables
    //    {
    //        get { return parser.GetVar().Count; }
    //    }

    //    public string Expresion
    //    {
    //        get { return expresionAnt; }
    //        set { expresionAnt = value; }
    //    }

    //    public void DefinirOperacion(string token, Operacion1Delegate operacion)
    //    {
    //        parser.DefineFun(token, new muParser.Parser.Fun1Delegate(operacion));
    //    }

    //    public void DefinirOperacion(string token, Operacion2Delegate operacion)
    //    {
    //        parser.DefineFun(token, new muParser.Parser.Fun2Delegate(operacion));
    //    }

    //    public void DefinirOperacion(string token, Operacion3Delegate operacion)
    //    {
    //        parser.DefineFun(token, new muParser.Parser.Fun3Delegate(operacion));
    //    }

    //    public void DefinirOperacion(string token, OperadorInfijoDelegate operacion, int orden)
    //    {
    //        parser.DefineOprt(token, new muParser.Parser.Fun2Delegate(operacion), orden);
    //    }

    //    public void DefinirOperacion(string token, OperadorPostfijoDelegate operacion)
    //    {
    //        parser.DefinePostfixOprt(token, new muParser.Parser.Fun1Delegate(operacion));
    //    }

    //    public void DefinirVariable(string token, double num)
    //    {
    //        if (!parser.GetVar().ContainsKey(token))
    //        {
    //            parser.DefineVar(token, new muParser.ParserVariable(num));
    //            dic.Add(token, num);
    //        }
    //        else 
    //        {
    //            throw new ArgumentException();
    //        }
    //    }

    //    public void ModificarVariable(string token, double nuevoNum)
    //    {
    //        parser.GetVar()[token].Value = nuevoNum;
    //        dic[token] = nuevoNum;
    //    }

    //    public void EliminarVariable(string token)
    //    {
    //        if (!parser.GetVar().Remove(token))
    //        {
    //            if (!dic.Remove(token))
    //            {
    //                throw new KeyNotFoundException();
    //            }
    //        }
    //    }

    //    public void EliminarTodasVariables()
    //    {
    //        parser.ClearVar();
    //        dic.Clear();
    //    }

    //    public void DefinirConstante(string token, double num)
    //    {
    //        parser.DefineConst(token, num);
    //    }

    //    public void EliminarConstante(string token)
    //    {
    //        if (!parser.GetConst().Remove(token))
    //        {
    //            throw new KeyNotFoundException();
    //        }
    //    }

    //    public void EliminarTodasConstantes()
    //    {
    //        parser.ClearConst();
    //    }

    //    public double EvaluarExpresion(string operaciones)
    //    {
    //        if (expresionAnt != operaciones)
    //        {
    //            parser.SetExpr(operaciones);
    //            expresionAnt = operaciones;
    //        }

    //       return parser.Eval();
    //    }

    //    public double EvaluarExpresion()
    //    {
    //        return parser.Eval();
    //    }

    //    public double EvaluarDerivada(string expresion, string variableADerivar)
    //    {
    //        if (parser.GetVar().ContainsKey(variableADerivar))
    //        {
    //            double punto = parser.GetVar()[variableADerivar].Value;

    //            parser.GetVar()[variableADerivar].Value = punto + DELTAH;
    //            double f1 = EvaluarExpresion(expresion);

    //            parser.GetVar()[variableADerivar].Value = punto;
    //            double f2 = EvaluarExpresion(expresion);

    //            return ((f1 - f2) / DELTAH);
    //        }
    //        else
    //        {
    //            throw new ArgumentException("La variable a derivar no está definida");
    //        }
    //    }

    //    public double EvaluarDerivada(string variableADerivar)
    //    {
    //        return EvaluarDerivada(expresionAnt, variableADerivar);
    //    }

    //    public object Clone()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Dictionary<string, double> Variables
    //    {
    //        get
    //        {
    //            return dic;
    //        }
    //        set
    //        {
    //            dic = value;
    //        }
    //    }

    //    SortedList<string, double> ICalculadora.Variables
    //    {
    //        get
    //        {
    //            throw new NotImplementedException();
    //        }
    //        set
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
    //}
}
