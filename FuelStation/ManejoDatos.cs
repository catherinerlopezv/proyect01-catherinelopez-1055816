using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivo
{
    /// <summary>
    /// Clase que gestionará la carga de datos por medio de un archivo
    /// El estudiante no debe modificar código de esta clase; de lo contrario cualquier error de la misma 
    /// (por cambios del estudiante) será un aspecto que impactará negativamente en la nota del proyecto.
    /// </summary>
    class ManejoDatos
    {
        //Atributo que manejará el archivo de bitácora de las principales acciones de esta clase
        StreamWriter objArchivoBitacora;
        //Nombre del archivo de bitácora
        string strNombreBitacora;

        /// <summary>
        /// Inicializa los valores de algunos atributos del objeto
        /// </summary>
        public ManejoDatos()
        {
            strNombreBitacora = "BitacoraManejoDatos.txt";
        }

        public bool CargaryEjecutarDatosArchivo(string strRutaArchivo, Gasolinera objGasolinera)
        {
            bool bolResultadoOperacion = true; //Variable que guardará el resultado de las operaciones que realizará el método
            StreamReader objArchivo = null;   //objeto que manejará el archivo
            string strLinea = "";   //variable que guardará la información de cada línea de un archivo
            int intNumeroRegistros = 1; //variable que señalará cuántos registros fueron leídos del archivo
            string[] arrDatos = null;   //arreglo de datos por línea
            int intTipoCombustible = -1;    //Tipo de combustible para venta
            int intBomba = -1;  //Número de bomba para venta
            double dblCantidadCombustible;  //Cantidad de combustible en galones a comprar
            double dblDineroVenta;  //Monto de efectivo de venta.
            
            try
            {
                //Crear o abrir archivo de bitácora
                CrearAbrirArchivoBitacora();
                EscribirEnBitacora("Inicio Carga Archivo: " + strRutaArchivo + " ------------------------------- ");

                //Comprobar que el archivo exista
                if(File.Exists(strRutaArchivo))
                {
                    objArchivo = new StreamReader(strRutaArchivo);  //Si existe el archivo, crear un objeto que lo gestione
                    strLinea = objArchivo.ReadLine();   //Leer la primera línea de archivo y obviarla (porque es el encabezado)
                    intNumeroRegistros++;
                    strLinea = objArchivo.ReadLine();   //Leer la segunda línea de archivo
                    while(strLinea != null) //Si la línea no está vacía
                    {
                        try
                        {
                            //Dividir datos en una línea por coma.
                            arrDatos = strLinea.Split(',');
                        
                            //Cada dato en el arreglo representará un valor
                            intTipoCombustible = int.Parse(arrDatos[0].Trim());
                            intBomba = int.Parse(arrDatos[1].Trim());
                            dblCantidadCombustible = double.Parse(arrDatos[2].Trim());
                            dblDineroVenta = double.Parse(arrDatos[3].Trim());

                            //No se puede enviar tanto cantidad de combustible como monto de dinero al mismo tiempo
                            if ((dblCantidadCombustible != -1 && dblDineroVenta != -1)
                                || (dblCantidadCombustible < 0 && dblDineroVenta < 0))
                            {
                                bolResultadoOperacion = false;  //Con un dato malo en archivo se devuelve error general
                                throw new Exception("Está mal configurada la cantidad de combustible o monto de dinero");
                            }

                            //Si los datos están bien ejecutar acción en gasolinera
                            if(objGasolinera.EjecutarAccion(intTipoCombustible, intBomba, dblCantidadCombustible, dblDineroVenta))
                            {
                                EscribirEnBitacora("Acción ejecutada correctamente. Línea: " + intNumeroRegistros.ToString());
                            }
                            else
                            {
                                bolResultadoOperacion = false;  //Con una acción mal ejecutada se devuelve error
                                //Si no se ejecutó acción en gasolinera levantar una excepción para ese registro
                                throw new Exception("No se ejecutó correctamente la acción en gasolinera");
                            }
                        }
                        catch(Exception e)
                        {
                            EscribirEnBitacora(e.Message + " (línea: "+ intNumeroRegistros.ToString() +")");
                        }

                        intNumeroRegistros++;
                        strLinea = objArchivo.ReadLine();   //Leer siguiente línea de archivo
                    }
                }
            }
            catch(Exception e)
            {
                EscribirEnBitacora("Error general en carga de datos. (" + e.Message + ")");
                bolResultadoOperacion = false;  //Señalar que la operación no fue exitosa
            }
            finally
            {
                objArchivo.Close();
                EscribirEnBitacora("Finalización carga Archivo: " + strRutaArchivo + " ------------------------------- \n");
                CerrarBitacora();
            }
            //Devolver el resultado de la carga de datos
            return bolResultadoOperacion;
        }

        /// <summary>
        /// Crea o abre el archivo de bitácora
        /// </summary>
        private void CrearAbrirArchivoBitacora()
        {
            FileStream objArchivoTemporal;
            try
            {
                if (objArchivoBitacora == null) //Solo si el objeto aún no se ha inicializado, se intenta crear o abrir
                {
                    if (!File.Exists(strNombreBitacora))
                    {
                        //Si el archivo no existe, crearlo
                        objArchivoTemporal = File.Create(strNombreBitacora);
                        objArchivoTemporal.Close();
                    }
                    //Si existe, se abre
                    objArchivoBitacora = File.AppendText(strNombreBitacora);
                }
            }
            catch(Exception e)
            {
                //Si hay un error al crear o abrir el archivo de bitácora, se muestra el error directamente en consola.
                Console.WriteLine("Error inesperado al tratar de crear o abrir el archivo de bitácora. ("+ e.Message +")");
            }
        }

        /// <summary>
        /// Escribe en el archivo de bitácora
        /// </summary>
        /// <param name="strMensaje">Mensaje a escribir en bitácora</param>
        private void EscribirEnBitacora(string strMensaje)
        {
            try
            {
                //Agregar fecha y hora al mensaje
                strMensaje = DateTime.Now.ToString() + " " + strMensaje;
                //Escribir mensaje en archivo
                objArchivoBitacora.WriteLine(strMensaje);
            }
            catch (Exception e)
            {
                //Si hay algún error al escribir en bitácora, se muestra el error directamente a consola.
                Console.WriteLine("Error al intentar escribir en consola. (" + e.Message + ")");
            }
        }
        
        /// <summary>
        /// Cerrar archivo de bitácora
        /// </summary>
        private void CerrarBitacora()
        {
            if (objArchivoBitacora != null) //Sólo si hay un archivo bitácora, se cierra
            {
                objArchivoBitacora.Close();
                objArchivoBitacora = null;
            }
        }

    }
}