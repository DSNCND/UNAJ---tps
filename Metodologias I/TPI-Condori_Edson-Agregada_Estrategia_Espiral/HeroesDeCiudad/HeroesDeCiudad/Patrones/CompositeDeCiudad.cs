using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesDeCiudad.Lugares;

namespace HeroesDeCiudad.Patrones
{
    class CompositeDeCiudad:IIluminable
    {
        List<IIluminable> componentes = new List<IIluminable>();

        public void revisarYCambiarLamparasQuemadas()
        {
            foreach (IIluminable componenteIluminable in componentes)
            {
                componenteIluminable.revisarYCambiarLamparasQuemadas();
            }
        }

        public void AgregarComponentes(IIluminable componenteIluminable)
        {
            this.componentes.Add(componenteIluminable);
        }
        public void RemoverComponentes()
        {
            this.componentes.RemoveAt(0);
        }
        public List<IIluminable> ObtenerComponentes()
        {
            return componentes;
        }
        







    }
}
