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
    [Serializable]
	public struct Intervalo
	{
        float inicio;
        float fin;

        public Intervalo(float inicio, float fin)
		{
			this.inicio = inicio;
			this.fin = fin;
		}

        public float Inicio
		{
			get { return inicio; }
			set { inicio = value; }
		}

        public float Fin
		{
			get { return fin; }
			set { fin = value; }
		}
	}
}
