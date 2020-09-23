using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            ManejadorArchivo manejadorArch;
            Console.WriteLine("Elija el modo:");
            Console.WriteLine("1 - TXT");
            Console.WriteLine("2 - XML");
            if (Console.ReadLine() == "2")
            {
                manejadorArch = new ManejadorArchivoXml();
            }
            else
            {
                manejadorArch = new ManejadorArchivoTxt();
            }
            manejadorArch.listar();
            menu(manejadorArch);
        }

        static void menu(ManejadorArchivo manejadorArch)
        {
            string rta = "";
            do
            {
                Console.WriteLine("1 - Listar");
                Console.WriteLine("2 - Agregar");
                Console.WriteLine("3 - Modificar");
                Console.WriteLine("4 - Eliminar");
                Console.WriteLine("5 - Guardar Cambios");
                Console.WriteLine("6 - Salir");
                rta = Console.ReadLine();
                switch (rta)
                {
                    case "1":
                        manejadorArch.listar();
                        break;
                    case "2":
                        manejadorArch.nuevaFila();
                        break;
                    case "3":
                        manejadorArch.editarFila();
                        break;
                    case "4":
                        manejadorArch.eliminarFila();
                        break;
                    case "5":
                        manejadorArch.aplicaCambios();
                        break;
                    default:
                        break;
                }
            } while (rta != "6");
        }


    }
}
