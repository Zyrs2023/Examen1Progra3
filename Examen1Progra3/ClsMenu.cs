using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examen1Progra3.ClsLibro;

namespace Examen1Progra3
{
    public class ClsMenu
    {
        private ClsBiblioteca biblioteca = new ClsBiblioteca();

        public void MostrarMenu()
        {
            Console.Clear(); 

            Console.WriteLine("*****************************************************");
            Console.WriteLine("*               Menú de la Biblioteca               *");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("* 1. Agregar un libro                               *");
            Console.WriteLine("* 2. Eliminar un libro                              *");
            Console.WriteLine("* 3. Mostrar todos los libros                        *");
            Console.WriteLine("* 4. Buscar libros                                  *");
            Console.WriteLine("* 5. Mostrar libro de mayor precio                  *");
            Console.WriteLine("* 6. Mostrar los tres libros más baratos            *");
            Console.WriteLine("* 7. Buscar libros por inicio del nombre del autor  *");
            Console.WriteLine("* 8. Salir                                          *");
            Console.WriteLine("*****************************************************");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();
            ProcesarOpcion(opcion);
        }

        private void ProcesarOpcion(string opcion)
        {
            switch (opcion)
            {
                case "1":
                    AgregarLibro();
                    break;
                case "2":
                    EliminarLibro();
                    break;
                case "3":
                    biblioteca.MostrarTodosLosLibros();
                    break;
                case "4":
                    BuscarLibros();
                    break;
                case "5":
                    biblioteca.MostrarLibroMayorPrecio();
                    break;
                case "6":
                    biblioteca.MostrarTresLibrosMasBaratos();
                    break;
                case "7":
                    BuscarLibrosPorAutor();
                    break;
                case "8":
                    Console.WriteLine("Gracias por usar la aplicación. ¡Hasta luego!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }

            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
            Console.ReadKey();
            MostrarMenu();
        }

        private void AgregarLibro()
        {
            do
            {
                Console.Clear(); 

                Console.WriteLine("*************************************************");
                Console.WriteLine("*             Agregar Nuevo Libro               *");
                Console.WriteLine("*************************************************");

                int codigo;
                while (true)
                {
                    Console.WriteLine("\nIngrese el código del libro (números solamente):");
                    Console.Write("Código: ");
                    if (!int.TryParse(Console.ReadLine(), out codigo))
                    {
                        Console.WriteLine("\nPor favor, ingrese un número válido.");
                        continue;
                    }

                    if (biblioteca.LibroExiste(codigo))
                    {
                        Console.WriteLine("\n¡Error! Un libro con este código ya existe. Por favor, ingrese un código diferente.");
                        continue;
                    }
                    break;
                }

                string titulo;
                do
                {
                    Console.WriteLine("\nIngrese el título del libro:");
                    Console.Write("Título: ");
                    titulo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(titulo))
                    {
                        Console.WriteLine("\nEl título no puede estar en blanco.");
                    }
                } while (string.IsNullOrWhiteSpace(titulo));

                string autor;
                do
                {
                    Console.WriteLine("\nIngrese el autor del libro (solo letras):");
                    Console.Write("Autor: ");
                    autor = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(autor) || autor.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch)))
                    {
                        Console.WriteLine("\nEl autor no puede estar en blanco y debe contener solo letras.");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                DateTime fechaPublicacion;
                while (true)
                {
                    Console.WriteLine("\nIngrese la fecha de publicación (dd/MM/yyyy):");
                    Console.Write("Fecha de Publicación: ");
                    if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaPublicacion))
                    {
                        Console.WriteLine("\nPor favor, ingrese una fecha en el formato correcto dd/MM/yyyy.");
                        continue;
                    }
                    break;
                }

                decimal precio;
                while (true)
                {
                    Console.WriteLine("\nIngrese el precio del libro:");
                    Console.Write("Precio: ");
                    if (!decimal.TryParse(Console.ReadLine(), out precio))
                    {
                        Console.WriteLine("\nPor favor, ingrese un número válido para el precio.");
                        continue;
                    }
                    break;
                }

                try
                {
                    Libro libro = new Libro(codigo, titulo, autor, fechaPublicacion, precio, true);
                    biblioteca.AgregarLibro(libro);
                    Console.WriteLine("\n¡El libro se agregó correctamente!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError al agregar el libro: {ex.Message}");
                }

                Console.WriteLine("\n¿Desea agregar otro libro? (s/n)");
            } while (Console.ReadLine().ToLower() == "s");

            Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
            Console.ReadKey();
            MostrarMenu();
        }


        private void EliminarLibro()
        {
            do
            {
                Console.Clear(); 

                Console.WriteLine("*************************************************");
                Console.WriteLine("*             Eliminar Libro                    *");
                Console.WriteLine("*************************************************");

                int codigo;
                while (true)
                {
                    Console.WriteLine("\nIngrese el código del libro a eliminar (números solamente):");
                    Console.Write("Código: ");
                    if (!int.TryParse(Console.ReadLine(), out codigo))
                    {
                        Console.WriteLine("\nPor favor, ingrese un número válido.");
                        continue;
                    }

                    break;
                }

                try
                {
                    biblioteca.EliminarLibro(codigo);
                    Console.WriteLine("\n¡El libro se eliminó correctamente!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError al eliminar el libro: {ex.Message}");
                }

                Console.WriteLine("\n¿Desea eliminar otro libro? (s/n)");
            } while (Console.ReadLine().ToLower() == "s");

            Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
            Console.ReadKey();
            MostrarMenu();
        }



        private void BuscarLibros()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("*************************************************");
                Console.WriteLine("*          Búsqueda de Libros por Título        *");
                Console.WriteLine("*************************************************");

                string titulo;
                do
                {
                    Console.WriteLine("\nIngrese el título del libro a buscar:");
                    Console.Write("Título: ");
                    titulo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(titulo))
                    {
                        Console.WriteLine("\nEl título no puede estar en blanco.");
                    }
                } while (string.IsNullOrWhiteSpace(titulo));

                biblioteca.BuscarLibros(titulo);

                Console.WriteLine("\n¿Desea buscar otro libro por título? (s/n)");
            } while (Console.ReadLine().ToLower() == "s");

            Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
            Console.ReadKey();
            MostrarMenu();
        }

        private void BuscarLibrosPorAutor()
        {
            do
            {
                Console.Clear(); 

                Console.WriteLine("*************************************************");
                Console.WriteLine("*        Búsqueda de Libros por Autor           *");
                Console.WriteLine("*************************************************");

                string inicioNombreAutor;
                do
                {
                    Console.WriteLine("\nIngrese el inicio del nombre del autor a buscar:");
                    Console.Write("Autor: ");
                    inicioNombreAutor = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inicioNombreAutor))
                    {
                        Console.WriteLine("\nEl nombre del autor no puede estar en blanco.");
                    }
                } while (string.IsNullOrWhiteSpace(inicioNombreAutor));

                biblioteca.BuscarLibrosPorAutor(inicioNombreAutor);

                Console.WriteLine("\n¿Desea buscar otro libro por autor? (s/n)");
            } while (Console.ReadLine().ToLower() == "s");

            Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
            Console.ReadKey();
            MostrarMenu();
        }

    }
}

