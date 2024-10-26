using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesDeCiudad.Lugares
{
    class Esquina:IIluminable,IPatrullable
    {
        int cantidadDeSemaforos { get; set; }

        public Esquina()
        { }
        public Esquina(int semaforos)
        {
            this.cantidadDeSemaforos = semaforos;
        }

        public void revisarYCambiarLamparasQuemadas()
        {
            Console.WriteLine("A implementar cambio de luces //Esquina");
        }


        public bool hayAlgoFueraDeLoNormal(Random random)
        {
            int probabilidad = 63;
            if (random.Next(0, 101) < probabilidad) return true;
            return false;
        }

    }
}
