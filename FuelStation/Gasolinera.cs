using FuelStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivo
{
    /// <summary>
    /// Clase plantilla que deberá implementar el estudiante
    /// </summary>
    class Gasolinera
    {
        Deposito dpDiesel;
        Deposito dpRegular;
        Deposito dpSuper;

        public Gasolinera()
        {
            //Se crea el deposito de diesel y se inicia con los valores indicados
            dpDiesel = new Deposito();
            dpDiesel.setDblCantidaCombustible(50);
            dpDiesel.setDblCostoCombustible(10);
            dpDiesel.setDblPrecioCombustible(14);

            //Se crea el deposito de regular y se inicia con los valores indicados
             dpRegular = new Deposito();
            dpRegular.setDblCantidaCombustible(50);
            dpRegular.setDblCostoCombustible(12);
            dpRegular.setDblPrecioCombustible(18);

            //Se crea el deposito de super y se inicia con los valores indicados
            dpSuper = new Deposito();
            dpSuper.setDblCantidaCombustible(50);
            dpSuper.setDblCostoCombustible(15);
            dpSuper.setDblPrecioCombustible(20);
        }
        /// <summary>
        /// Muestra la cantidad de combustible en los depositos
        /// </summary>
        public void mostrarCombustible()
        {
            Console.WriteLine("Inventario de combustible (Galones)");
            Console.WriteLine("Diesel: "+ dpDiesel.getDblCantidadCombustible());
            Console.WriteLine("Regular: " + dpRegular.getDblCantidadCombustible());
            Console.WriteLine("Super: " + dpSuper.getDblCantidadCombustible());
        }


        /// <summary>
        /// Muestra los costos de combustible en los depositos
        /// </summary>
        public void mostrarCostos()
        {
            Console.WriteLine("Costos de  combustible (Quetzales)");
            Console.WriteLine("Diesel: " + dpDiesel.getDblCostoCombustible());
            Console.WriteLine("Regular: " + dpRegular.getDblCostoCombustible());
            Console.WriteLine("Super: " + dpSuper.getDblCostoCombustible());
        }

        /// <summary>
        /// Muestra los precios de combustible en los depositos
        /// </summary>
        public void mostrarPrecios()
        {
            Console.WriteLine("Precios de  combustible (Quetzales)");
            Console.WriteLine("Diesel: " + dpDiesel.getDblPrecioCombustible());
            Console.WriteLine("Regular: " + dpRegular.getDblPrecioCombustible());
            Console.WriteLine("Super: " + dpSuper.getDblPrecioCombustible());
        }

        public string MostrarMenuRellenar()
        {
            Console.WriteLine("Desea rellenar depositos y/n");
            string opcion = "";
            while ((opcion != "y") && (opcion != "n"))
            {
                opcion = Console.ReadLine();   
                Console.WriteLine("opcion ....= " + opcion);
            }
            Console.WriteLine("opcion = " + opcion);
            return opcion;
        }

        public void Rellenar()
        {
            mostrarCombustible();
            if (MostrarMenuRellenar() == "y")
            {
                Console.WriteLine("ingrese compras de diesel");
                dpDiesel.comprar();

                Console.WriteLine("ingrese compras de regular");
                dpRegular.comprar();

                Console.WriteLine("ingrese compras de super");
                dpSuper.comprar();
            }
            mostrarCombustible();
        }

        public void DefinirPrecios()
        {
            mostrarPrecios();
            Console.WriteLine("ingrese precio de diesel");
            dpDiesel.setDblPrecioCombustible(double.Parse(Console.ReadLine()));
            Console.WriteLine("ingrese precio de Regular");
            dpRegular.setDblPrecioCombustible(double.Parse(Console.ReadLine()));
            Console.WriteLine("ingrese precio de Super");
            dpSuper.setDblPrecioCombustible(double.Parse(Console.ReadLine()));
            mostrarPrecios();
        }

        public void VentaGasolina(int bomba)
        {
            int tipoCombustible=0 ; 
            Console.WriteLine("1. Diesel");
            Console.WriteLine("2. Regular");
            Console.WriteLine("3. Super");
            tipoCombustible = int.Parse(Console.ReadLine());

            double dinero = -1;
            double cantidad = -1;
            string opcion= "c";
            Console.WriteLine("Ingrese Cantidad o dinero(c/d)");
            opcion = Console.ReadLine();

            if (opcion == "d")
            {
                Console.WriteLine("ingrese dinero");
                dinero = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("ingrese cantidad");
                cantidad = double.Parse(Console.ReadLine());
            }
            double precio = 0;

            if (tipoCombustible == 1)
            {
                dpDiesel.vender(bomba,cantidad,dinero);
                precio= dpDiesel.getDblPrecioCombustible();
            }
            if (tipoCombustible == 2)
            {
                dpRegular.vender(bomba, cantidad, dinero);
                precio = dpRegular.getDblPrecioCombustible();
            }
            if (tipoCombustible == 3)
            {
                dpSuper.vender(bomba, cantidad, dinero);
                precio = dpSuper.getDblPrecioCombustible();
            }

            if (cantidad == -1)
            {
                Console.WriteLine("cantidad Vendida=" +dinero/ precio );
            }
            else
            {
                Console.WriteLine("Monto =" + cantidad* precio );
            }
            Console.ReadKey();
            
        }

        public void VentaDiesel()
        {
            
            Console.WriteLine("1. Diesel");
            double dinero = -1;
            double cantidad = -1;
            string opcion = "c";
            Console.WriteLine("Ingrese Cantidad o dinero(c/d)");
            opcion = Console.ReadLine();

            if (opcion == "d")
            {
                Console.WriteLine("ingrese dinero");
                dinero = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("ingrese cantidad");
                cantidad = double.Parse(Console.ReadLine());
            }

             
                dpDiesel.vender(4, cantidad, dinero);
            
        }

        public void Vender()
        {
            string option = "";
            
            
                Console.WriteLine("Indicar en que bomba está");
                Console.WriteLine("1. Bomba 1");
                Console.WriteLine("2. Bomba 2");
                Console.WriteLine("3. Bomba 3");
                Console.WriteLine("4. Bomba 4");

                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        VentaGasolina(1);
                        break;
                    case "2":
                        VentaGasolina(2);
                        break;
                    case "3":
                        VentaGasolina(3);
                        break;
                    case "4":
                        VentaDiesel();
                        break;
                }
            

        }

        public void Mostrar()
        {
            mostrarCombustible();
            mostrarCostos();
            mostrarPrecios();
            Console.WriteLine("diesel");
            dpDiesel.listarCompras();
            dpDiesel.listarVentas();
            Console.WriteLine("Regular");
            dpRegular.listarCompras();
            dpRegular.listarVentas();
            Console.WriteLine("Super");
            dpSuper.listarCompras();
            dpSuper.listarVentas();
            Console.ReadKey();

        }

        /// <summary>
        /// Función plantilla escrita sólo con el propósito que ManejoDatos no presente errores de compilación en este proyecto
        /// </summary>
        /// <param name="intTipoCombustible">Número entero que representa el tipo de combustible de la venta a realizar</param>
        /// <param name="intBomba">Número de bomba escogida para realizar la venta</param>
        /// <param name="dblCantidadCombustible">Cantidad de combustible en galones de la venta a realziar. Si no se escoge por galones de combustible se enviará -1.</param>
        /// <param name="dblDineroVenta">Monto de dinero en quetzales de la venta a realizar. Si no se escoge venta por cantidad de dinero se enviará -1.</param>
        /// <returns>Retornará siempre falso pues esta plantilla no realiza acción alguna.</returns>
        public bool EjecutarAccion(int intTipoCombustible, int intBomba, double dblCantidadCombustible, double dblDineroVenta)
        {
            if (intTipoCombustible == 1)
            {
                dpDiesel.vender(intBomba, dblCantidadCombustible, dblDineroVenta);
            }
            if (intTipoCombustible == 2)
            {
                dpRegular.vender(intBomba, dblCantidadCombustible, dblDineroVenta);
            }
            if (intTipoCombustible == 3)
            {
                dpSuper.vender(intBomba, dblCantidadCombustible, dblDineroVenta);
            }
            return true;
        }
    }
}
