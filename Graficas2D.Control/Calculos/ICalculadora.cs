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
    public interface ICalculadora : ICloneable
    {
        SortedList<string, double> Variables { get; set; }
        //Dictionary<string, double> Variables { get; set; }
        string Expresion { get; set; }
        int NumeroVariables { get; }
        //Operacion
        void DefinirOperacion(string token, Operacion1Delegate operacion);
        void DefinirOperacion(string token, Operacion2Delegate operacion);
        void DefinirOperacion(string token, Operacion3Delegate operacion);
        void DefinirOperacion(string token, OperadorInfijoDelegate operacion, int orden, Asociatividad asociatividad);
        void DefinirOperacion(string token, OperadorPostfijoDelegate operacion);
        //Variable
        void DefinirVariable(string token, double num);
        void ModificarVariable(string token, double nuevoNum);
        void EliminarVariable(string token);
        void EliminarTodasVariables();
        //Constante
        void DefinirConstante(string token, double num);
        void EliminarConstante(string token);
        void EliminarTodasConstantes();
        //Evaluar
        double EvaluarExpresion(string operaciones);
        double EvaluarExpresion();
        bool ComprobarValidez(string operaciones);
        double EvaluarDerivada1(string expresion, string variableADerivar);
        double EvaluarDerivada1(string variableADerivar);
        double EvaluarDerivada2(string expresion, string variableADerivar);
        double EvaluarDerivada2(string variableADerivar);
        double EvaluarDerivada3(string expresion, string variableADerivar);
        double EvaluarDerivada3(string variableADerivar);
        double EvaluarDerivada4(string expresion, string variableADerivar);
        double EvaluarDerivada4(string variableADerivar);

    }
}
