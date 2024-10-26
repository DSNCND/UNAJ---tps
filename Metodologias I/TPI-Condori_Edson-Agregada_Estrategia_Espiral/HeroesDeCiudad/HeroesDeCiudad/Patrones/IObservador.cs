using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesDeCiudad.Lugares;

namespace HeroesDeCiudad.Patrones
{
    public interface IObservador 
    {
        void alarmaDeIncendio(ILugar lugar); //actualizar
    }

    public interface IObservado  
    {
        void agregarObservador(IObservador o);
        void quitarObservador();
        //notificar() --> en Ilugar chispa()
        
    }
    
       
}
