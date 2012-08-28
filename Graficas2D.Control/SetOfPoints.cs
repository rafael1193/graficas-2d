/* Copyright (C) 2010, 2011, 2012 rafael1193
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

namespace Graficas2D.Control
{
    public class SetOfPoints
    {
        protected PointF[] puntos;
        protected Color colorLinea;
        protected float grosor;
        protected bool dib;
        protected string nom;

        public SetOfPoints() { }

        public SetOfPoints(PointF[] puntos, Color color, float grosor, string nombre, bool dibujar)
        {
            this.puntos = puntos;
            this.colorLinea = color;
            this.grosor = grosor;
            this.dib = dibujar;
            this.nom = nombre;
        }

        public PointF[] Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }

        public Color ColorLinea
        {
            get { return colorLinea; }
            set { colorLinea = value; }
        }

        public float Grosor
        {
            get { return grosor; }
            set { grosor = value; }
        }

        public bool Dibujar
        {
            get { return dib; }
            set { dib = value; }
        }

        public string Nombre
        {
            get { return nom; }
            set { nom = value; }
        }
    }
}
