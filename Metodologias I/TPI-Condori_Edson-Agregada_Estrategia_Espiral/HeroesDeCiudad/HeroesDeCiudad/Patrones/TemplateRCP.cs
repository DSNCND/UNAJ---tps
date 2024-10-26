using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesDeCiudad.Heroes;

namespace HeroesDeCiudad.Patrones
{
    public abstract class TemplateRCP
    {
        protected IInfartable infartable;
        protected Medico medico;
        public void aplicarRCP(IInfartable infartable, Medico medico)
        {
            this.infartable = infartable;
            this.medico=medico;
            revisarObstruccionViasRespiratorias();
            
            if (infartable.estasConciente())
            {
                llamarAmbulancia();
                descubrirTorax();
                acomodarCabeza();
            }
            else
            {
            	bool ritmoCardiaco = infartable.tenesRitmoCardiaco();
            	compresionesToracicas();
                insuflaciones();
            	while (!respira())
            	{
                compresionesToracicas();
                insuflaciones();
            	
    	        	if (!ritmoCardiaco) 
    	        	{
    	        		usarDesfibrilador((Desfibrilador)this.medico.getHerramienta());
    	           	ritmoCardiaco=infartable.tenesRitmoCardiaco();
    	        	}
    	        }
            }
        }

        protected void revisarObstruccionViasRespiratorias()
        {
            Console.WriteLine("Eliminando de la boca los objetos que estén obstruyendo las vías respiratorias.");
        }
        public abstract bool respira();
        public abstract void llamarAmbulancia();
        public abstract void descubrirTorax();
        public abstract void acomodarCabeza();
        public abstract void compresionesToracicas();
        public abstract void insuflaciones();
        public abstract void usarDesfibrilador(Desfibrilador desfibrilador);

        

        
    }

    public class RCP1:TemplateRCP
    {

        public override bool respira()
        {
            return base.infartable.estasRespirando();
        }

        public override void llamarAmbulancia()
        {
        	medico.getVehiculo().conducir();
        	medico.getVehiculo().encenderSirena();
            Console.WriteLine("Llamando una ambulancia");
        }
        public override void descubrirTorax()
        {
            Console.WriteLine("Descubriendo el torax del paciente");
        }
        public override void acomodarCabeza()
        {
            Console.WriteLine("acomodando la cabeza del paciente");
        }
        public override void compresionesToracicas()
        {
            Console.WriteLine("realizando compresiones torasicas");
        }
        public override void insuflaciones()
        {
            Console.WriteLine("realizando insuflaciones");
        }
        public override void usarDesfibrilador(Desfibrilador desfibrilador)
        {
        	desfibrilador.usar();
            Console.WriteLine("utilizando el desfibrilador");
            desfibrilador.guardar();
        }

    }
    public class RCP2:TemplateRCP
    {
        static int cont = 5;
        public override bool respira()
        {
            cont--;
            Console.WriteLine("---"+cont);
            if (cont==0) {Console.WriteLine("descistiendo intentos"); }
            return infartable.estasRespirando() || (cont!=0);
        }

        public override void llamarAmbulancia()
        {
            Console.WriteLine("Llamando una ambulancia //RCP2");
        }
        public override void descubrirTorax()
        {
            Console.WriteLine("Descubriendo el torax del paciente //RCP2");
        }
        public override void acomodarCabeza()
        {
            Console.WriteLine("acomodando la cabeza del paciente //RCP2");
        }
        public override void compresionesToracicas()
        {
            Console.WriteLine("realizando compresiones torasicas //RCP2");
        }
        public override void insuflaciones()
        {
            Console.WriteLine("realizando insuflaciones //RCP2");
        }
        public override void usarDesfibrilador(Desfibrilador desfibrilador)
        {
        	desfibrilador.usar();
            Console.WriteLine("utilizando el desfibrilador //RCP2");
            desfibrilador.guardar();
        }
    }
}
