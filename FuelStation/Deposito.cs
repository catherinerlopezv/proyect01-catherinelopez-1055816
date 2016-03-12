using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation
{
    class Deposito
    {
        //estructura que lleva las compras realizadas
       public struct Compra
        {
         public   double dblCantidad;
         public   double dblCosto;
  
        }
        //estructuras que lleva las ventas realizadas
        public struct Venta
        {
          public  double dblPrecio;
          public  double dblCantidad;
        public  int intBomba;
        }
        
        private double dblCantidadCombustible; // cuanto pide de combustible
        private double dblPrecioCombustible; //precio de los tipos de combustibles
        private double dblCostoCombustible; //costo de combustible para los depositos
        private List<Compra> lstCompras;  // guardar compras realizadas
        private List<Venta> lstVentas;    // guardar ventas realizadas

        public Deposito()
        {
            lstCompras = new List<Compra>();
            lstVentas = new List<Venta>();
        }

        private List<Compra> LstCompras
        {
            get
            {
                return lstCompras;
            }

            set
            {
                lstCompras = value;
            }
        }

        private List<Venta> LstVentas
        {
            get
            {
                return lstVentas;
            }

            set
            {
                lstVentas = value;
            }
        }
        /// <summary>
        /// registar compras
        /// </summary>
        /// <returns>Retornará siempre  a verdadero o falso, segun se realiza la compra </returns>
        public bool comprar()  
        {
            Compra cmp = new Compra();
            Console.WriteLine("ingrese galones");
            cmp.dblCantidad = double.Parse(Console.ReadLine());
            Console.WriteLine("ingrese Costo");
            cmp.dblCosto = double.Parse(Console.ReadLine());

            lstCompras.Add(cmp);
            dblCantidadCombustible += cmp.dblCantidad;
            dblCostoCombustible = cmp.dblCosto;



       
            return false;
        }
        /// <summary>
        /// registar ventas
        /// </summary>
        /// <returns>Retornará siempre  a verdadero o falso, segun se realiza las ventas </returns>
        public bool vender(int intBomba, double dblCantidadCombustible, double dblDineroVenta)
        {
            Venta vnt = new Venta();
            vnt.intBomba = intBomba;
            if (dblCantidadCombustible > -1)
            {
                vnt.dblCantidad = dblCantidadCombustible;
            }
            else
            {
                vnt.dblCantidad = dblDineroVenta/this.dblPrecioCombustible;
            }
            vnt.dblPrecio = this.dblPrecioCombustible;
            lstVentas.Add(vnt);
            this.dblCantidadCombustible -= vnt.dblCantidad;
            return true;
        }

        public void listarCompras()
        {
            Console.WriteLine("(+) Compras");
            Console.WriteLine("Cantidad, Costo ");
            foreach (Compra item in lstCompras)
            {
                Console.WriteLine(item.dblCantidad+", "+item.dblCosto);
            }
            Console.WriteLine("------------");
        }

        public void listarVentas()
        {
            Console.WriteLine("(-) Ventas");
            Console.WriteLine("Bomba, Cantidad, Precio ");
            foreach (Venta item in lstVentas)
            {
                Console.WriteLine(item.intBomba + ", " + item.dblCantidad + ", " + item.dblPrecio);
            }
            Console.WriteLine("------------");
        }

        public double getDblCantidadCombustible()
        {
            return dblCantidadCombustible;
        }
        public void setDblCantidaCombustible(double dblCantidadCombustible)
        {
            this.dblCantidadCombustible = dblCantidadCombustible;
        }
        public double getDblPrecioCombustible()
        {
            return dblPrecioCombustible;
        }
        public void setDblPrecioCombustible(double dblPrecioCombustible)
        {
            this.dblPrecioCombustible = dblPrecioCombustible;
        }
        public double getDblCostoCombustible()
        {
            return dblCostoCombustible;
        }
        public void setDblCostoCombustible(double dblCostoCombustible)
        {
            this.dblCostoCombustible = dblCostoCombustible;
        }
   
        

    }  
}
