using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace GDNative_Project_Creator
{
    public static class OpcionesMenu
    {
        public static void NuevoProyecto()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la carpeta donde desea crear el proyecto proyecto:\n");

            Console.Write("Respuesta: ");
            var RespuestaRutaStr = Console.ReadLine();

            if(RespuestaRutaStr != null && System.IO.Directory.Exists(RespuestaRutaStr))
            {
                Console.Clear();
                Console.WriteLine("Ingrese el nombre del proyecto:\n");

                Console.Write("Respuesta: ");
                var RespuestaNombreStr = Console.ReadLine();

                if (RespuestaNombreStr != null)
                {
                    string NuevaCarpeta = Path.Combine(RespuestaRutaStr, RespuestaNombreStr);
                    string temp_path = Path.Combine(NuevaCarpeta, "temp");

                    try
                    {
                        System.IO.Directory.CreateDirectory(NuevaCarpeta);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nNo se pudo crear la carpeta para el proyecto.");
                        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                        Console.ReadKey();

                        return;
                    }

                    //Obtener archivo de configuración
                    DataAndFilesDownloader versions_downloader = new DataAndFilesDownloader("https://drive.google.com/u/0/uc?id=1D9d3ZGLcrOYb7_z9-UiZ95MbIXiE3z42&export=download", "Lista de versiones");

                    var Versions = JsonConvert.DeserializeObject<GDVersion[]>(versions_downloader.DownloadString());

                    Console.Clear();
                    Console.WriteLine("Seleccione la versión de Godot que desea utilizar:\n");

                    if (Versions != null)
                    {
                        for (int i = 0; i < Versions.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1}) Versión {Versions[i].version}");
                        }

                        Console.Write("\nRespuesta: ");
                        var RespuestaStr = Console.ReadLine();
                        int result = 0;

                        if (int.TryParse(RespuestaStr, out result) && result > 0 && result <= Versions.Count())
                        {
                            //Obtener archivo de C++
                            DataAndFilesDownloader cpp_downloader = new DataAndFilesDownloader(Versions[result - 1].godot_cpp_url, "godot_cpp");

                            string godot_cpp_path = Path.Combine(NuevaCarpeta, "godot_cpp.zip");
                            string godot_cpp_folder_path = Path.Combine(NuevaCarpeta, "godot_cpp");

                            //Descomprimir archivo Cpp a carpeta temporal

                            cpp_downloader.DownloadFile(godot_cpp_path);

                            Console.Clear();
                            Console.WriteLine("Descomprimiendo...");

                            ZipFile.ExtractToDirectory(godot_cpp_path, temp_path, true);

                            //Mover carpeta descomprimida a carpeta de proyecto

                            string[] TempDirectories = System.IO.Directory.GetDirectories(temp_path);

                            for (int i = 0; i < 1; i++)
                            {
                                System.IO.Directory.Move(TempDirectories[0], godot_cpp_folder_path);
                            }

                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("\nLa respuesta seleccionada no es válida.");
                            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nLa respuesta seleccionada no es válida.");
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();

                    return;
                }
            }
            else
            {
                Console.WriteLine("\nNo se encontró la ruta seleccionada.");
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();

                return;
            }
        }
    }
}
