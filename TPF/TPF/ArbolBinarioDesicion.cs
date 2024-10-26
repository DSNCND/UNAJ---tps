using System;

namespace TPF
{
    public class ArbolBinarioDesicion
    {

        private NodoDesicion raiz = null;

        public ArbolBinarioDesicion() {

            this.raiz = new NodoDesicion(new Pregunta(0,"",""));
        }
       

        public ArbolBinarioDesicion(Pregunta p)
            {
            this.raiz = new NodoDesicion(p);
            }
        public ArbolBinarioDesicion(ArbolBinarioDesicion arbol)
        {
            this.raiz = arbol.getRaiz();
        }
        public ArbolBinarioDesicion(NodoDesicion nodo)
        {
            this.raiz = nodo;
        }
        

        public NodoDesicion getRaiz()
        {
            return raiz;
        }

        public Pregunta getPregunta()
        {
            return this.getRaiz().getPregunta();
        }
        public void setPregunta(Pregunta p)
        {
            this.getRaiz().setPregunta(p);
        }

        public ConjuntoDeDatos getConjuntoDeDatos()
        {
            return this.getRaiz().getConjuntoDeDatos();
        }

        public void setConjuntoDeDatos(ConjuntoDeDatos conjuntoDeDatos)
        {
            this.getRaiz().setConjuntoDeDatos(conjuntoDeDatos);
        }


        public ArbolBinarioDesicion getHijoIzquierdo()
        {
            return new ArbolBinarioDesicion(this.raiz.getHijoIzquierdo());
        }

        public ArbolBinarioDesicion getHijoDerecho()
        {
            return new ArbolBinarioDesicion(this.raiz.getHijoDerecho());
        }

        public void agregarHijoIzquierdo(ArbolBinarioDesicion hijo)
        {
            this.raiz.setHijoIzquierdo(hijo.getRaiz());
        }

        public void agregarHijoDerecho(ArbolBinarioDesicion hijo)
        {
            this.raiz.setHijoDerecho(hijo.getRaiz());
        }

        public void eliminarHijoIzquierdo()
        {
            this.raiz.setHijoIzquierdo(null);
        }

        public void eliminarHijoDerecho()
        {
            this.raiz.setHijoDerecho(null);
        }

        public bool esVacio()
        {
            return this.raiz == null;
        }

        public bool esHoja()
        {
            return this.raiz != null && this.getHijoIzquierdo().esVacio() && this.getHijoDerecho().esVacio();
        }

        public void mostrarHojas() {

            
            if (this.esHoja())
            {
                Console.Write("Hoja: ");
                for (int x = 0; x < this.getConjuntoDeDatos().cantidadFilas(); x++)
                {
                    Console.Write(this.getConjuntoDeDatos().obtenerEtiquetaFila(x)+" ");
                }
                Console.WriteLine("");
            }
            else {
                this.getHijoIzquierdo().mostrarHojas();
                this.getHijoDerecho().mostrarHojas();
            }

        }

        public void desiciones()
        {
            if (this.esHoja())
            {
                for (int i = 0; i < getConjuntoDeDatos().cantidadFilas(); i++)
                {
                    string etiqueta = getConjuntoDeDatos().obtenerEtiquetaFila(i);
                    Console.Write(" "+etiqueta +" - ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Es " + this.getPregunta().ToString());
                Console.WriteLine(" S para si o cualquier tecla para no");
                string r = Console.ReadLine();

                if (r.ToUpper() == "S")
                {
                    this.getHijoIzquierdo().desiciones();
                }
                else
                {
                    this.getHijoDerecho().desiciones();
                }
            }
            
        }

       public void preorden()
        {
            
            for (int i=0; i<getRaiz().getConjuntoDeDatos().cantidadFilas();i++) {
                Console.Write("-" + getRaiz().getConjuntoDeDatos().obtenerEtiquetaFila(i) + "-");
            }
            Console.WriteLine(" <--");
            if (!this.getHijoIzquierdo().esVacio()) {
                Console.WriteLine("\n" + getRaiz().getPregunta()+"T");
                this.getHijoIzquierdo().preorden();
                
            }
            if (!this.getHijoDerecho().esVacio()) {
                Console.WriteLine("\n" + getRaiz().getPregunta()+"F");
                this.getHijoDerecho().preorden();
                
            }
            Console.WriteLine("presione una tecla para continuar");
            Console.ReadKey();
        }
        
        public int contarHojas()
        {
            int contador = 0;

            if (this.esHoja())
            {
                return 1;
            }
            
            if (!this.getHijoIzquierdo().esVacio()) {
                    contador += this.getHijoIzquierdo().contarHojas();
            }
            
            if (!this.getHijoDerecho().esVacio()) {
                    contador +=  this.getHijoDerecho().contarHojas();
            }
            
            return contador;
        }
        
        
        public int Altura() {
            int altura = 0;

            if (!this.esHoja())
            {
                    altura += 1;
                    int alturaI = 0;
                    int alturaD = 0;
            
                    if (!this.getHijoIzquierdo().esVacio())
                    {
                        alturaI += this.getHijoIzquierdo().Altura();
                    }
                    if (!this.getHijoDerecho().esVacio())
                    {
                        alturaD += this.getHijoDerecho().Altura();
                    }

                    if (alturaI > alturaD)
                    {
                        return altura += alturaI;
                    }
                    else {
                        return altura += alturaD;
                    }
                

            }
            else {
                return 0;
            }
        }
      
    }
}
