using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesDeCiudad.Patrones
{
    interface ICommand
    {
        void comando();
    }

    class armarRecorridoAPatrullar : ICommand
    {
        public void comando()
        {
            //podria pasarle el lugarPatrullable como parametro para avisar que lugar se va a recorrer
            //tendria que modificar la interfaz y refactorizar
            Console.WriteLine("Agregando lugar al recorrido");
        }
    }

    class VozDeAlto:ICommand
    {
        public void comando()
        {
            Console.WriteLine("Dar voz de alto para que el delincuente se vaya");
        }
    }
    class Perseguir:ICommand
    {
        public void comando()
        {
            Console.WriteLine("Perseguir hasta arrestar al delincuente");
        }
    }
    class PedirRefuerzos:ICommand
    {
        public void comando()
        {
            Console.WriteLine("Avisar a la comisaria y pedir refuerzos");

        }
    }

}
