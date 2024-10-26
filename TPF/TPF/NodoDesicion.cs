using System;

namespace TPF
{
    /// <summary>
	/// Description of NodoDesicion.
	/// </summary>
	public class NodoDesicion
    {
        private Pregunta pregunta; //el objeto pregunta tiene un metodo toString
        private ConjuntoDeDatos CD;
        private NodoDesicion hijoIzquierdo;
        private NodoDesicion hijoDerecho;

        public NodoDesicion(Pregunta p)
        {
            this.pregunta = p; 
            this.hijoIzquierdo = null;
            this.hijoDerecho = null;
        }

        public ConjuntoDeDatos getConjuntoDeDatos()
        {
            return this.CD;
        }
        public void setConjuntoDeDatos(ConjuntoDeDatos CD)
        {
            this.CD = CD;
        }

        public Pregunta getPregunta()
        {
            return this.pregunta;
        }
        public void setPregunta(Pregunta p)
        {
            this.pregunta = p;
        }

        public NodoDesicion getHijoIzquierdo()
        {
            return this.hijoIzquierdo;
        }

        public NodoDesicion getHijoDerecho()
        {
            return this.hijoDerecho;
        }

       

        public void setHijoIzquierdo(NodoDesicion hijoIzq)
        {
            this.hijoIzquierdo = hijoIzq;
        }

        public void setHijoDerecho(NodoDesicion hijoDer)
        {
            this.hijoDerecho = hijoDer;
        }

    }
}
