using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPF
{
    /// <summary>
    /// Description of Cola.
    /// </summary>
    public class Cola
    {
        private ArrayList datos;

        public Cola () {
            datos = new ArrayList();
    }

    public void encolar(dynamic elem)
    {
            this.datos.Add(elem);
        }

    public dynamic desencolar()
        {
            dynamic temp = this.datos[0];
        this.datos.RemoveAt(0);
        return temp;
    }

    public dynamic tope()
    {
        return this.datos[0];
    }

    public bool esVacia()
    {
        return this.datos.Count == 0;
    }



    }
     
}