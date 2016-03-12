using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivo;

namespace FuelStation
{
    class Program
    {
        /// <summary>
        /// Muestra las opciones de menu principal
        /// </summary>
        public static void MostarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("+==========================+");
            Console.WriteLine("|| 1.Rellenar Deposito    ||");
            Console.WriteLine("|| 2.Definir precios      ||");
            Console.WriteLine("|| 3.Venta de combustible ||");
            Console.WriteLine("|| 4.Cargar Acciones      ||");
            Console.WriteLine("|| 5.Mostrar Acciones     ||");
            Console.WriteLine("|| 6.Salir                ||");
            Console.WriteLine("+==========================+");
        }



        static void Main(string[] args)
        {


            Gasolinera gasolinera = new Gasolinera();

            // se muestra el menu principal
            string option = "";
            while (option != "6")
            {
                MostarMenuPrincipal();

                try
                {
                    option = Console.ReadLine();
                }
                catch (Exception)
                {

                    Console.WriteLine("ingreso un caracter no valido");
                }

                switch (option)
                {
                    case "1":
                        gasolinera.Rellenar();
                        break;
                    case "2":
                        gasolinera.DefinirPrecios();
                        break;
                    case "3":
                        gasolinera.Vender();
                        break;
                    case "4":
                        ManejoDatos datos = new ManejoDatos();
                        datos.CargaryEjecutarDatosArchivo("", gasolinera);
                        break;
                    case "5":
                        gasolinera.Mostrar();
                        break;

                }

            }
        }
    }
}


