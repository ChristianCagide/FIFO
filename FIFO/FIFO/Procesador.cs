using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO
{
    class Procesador
    {
        private Proceso inicio { get; set; }
        private static Random rand;
        private int ciclosVacio { get; set; }
        private int procesosPendientes { get; set; }
        private int ciclosPendientes { get; set; }

        public Procesador()
        {
            inicio = null;
            rand = new Random();
            ciclosVacio = 0;
            ciclosPendientes = 0;
            procesosPendientes = 0;
        }

        public void agregar(Proceso nuevo)
        {
            if (inicio == null)
            {
                inicio = nuevo;
                procesosPendientes++;
                ciclosPendientes += nuevo.ciclos;
            }
            else
                agregar(inicio, nuevo);
        }

        private void agregar(Proceso ultimo, Proceso nuevo)
        {
            if (ultimo.siguiente == null)
            {
                ultimo.siguiente = nuevo;
                procesosPendientes++;
                ciclosPendientes += nuevo.ciclos;
            }
            else
                agregar(ultimo.siguiente, nuevo);
        }

        public void procesar()
        {
            bool enEjec = false;
            for(int i = 0; i < 200; i++)
            {
                if (enEjec == false)
                    if(inicio!=null)
                        if (rand.Next(1, 5) == 1)
                        {
                            enEjec = true;
                            procesosPendientes--;
                            ciclosPendientes -= inicio.ciclos;
                        }


                if (enEjec == true)
                {
                    inicio.ciclos--;
                    if (inicio.ciclos == 0)
                    {
                        inicio = inicio.siguiente;
                        enEjec = false;
                    }
                }
                else
                    ciclosVacio++;
            }
        }

        public string mostrar()
        {
            if(inicio==null)
                return "Vacio";
            else
            {
                Proceso temp = inicio;
                string mostrar = "";
                while (temp != null)
                {
                    mostrar += temp.ToString() + Environment.NewLine + Environment.NewLine;
                    temp = temp.siguiente;
                }
                return mostrar;
            }

        }

        public override string ToString()
        {
            return procesosPendientes.ToString() + " " + ciclosPendientes.ToString() + " " + ciclosVacio.ToString();
        }
    }
}
