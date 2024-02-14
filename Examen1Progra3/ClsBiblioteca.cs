using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examen1Progra3.ClsLibro;

namespace Examen1Progra3
{
    internal class ClsBiblioteca
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro)
        {
            try
            {
                libros.Add(libro);
                libros = libros.OrderBy(l => l.Titulo).ToList(); 
                Console.WriteLine("Libro agregado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el libro: {ex.Message}");
            }
        }
        public bool LibroExiste(int codigo)
        {
            return libros.Any(libro => libro.Codigo == codigo);
        }

        public void EliminarLibro(int codigo)
        {
            try
            {
                var libro = libros.FirstOrDefault(l => l.Codigo == codigo);
                if (libro != null)
                {
                    libros.Remove(libro);
                    Console.WriteLine("Libro eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("Libro no encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el libro: {ex.Message}");
            }
        }

        public void MostrarTodosLosLibros()
        {
            Console.Clear(); // Limpia la consola antes de mostrar todos los libros.

            Console.WriteLine("*************************************************");
            Console.WriteLine("*           Mostrar Todos los Libros             *");
            Console.WriteLine("*************************************************");

            try
            {
                if (!libros.Any())
                {
                    Console.WriteLine("\nNo hay libros en la biblioteca.");
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
                    Console.ReadKey();
                    
                    return;
                }

                Console.WriteLine("\nListado de libros:\n");

                foreach (var libro in libros)
                {
                    Console.WriteLine("*************************************************");
                    Console.WriteLine($"Título: {libro.Titulo}");
                    Console.WriteLine($"Autor: {libro.Autor}");
                    Console.WriteLine($"Fecha de Publicación: {libro.FechaDePublicacion.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Precio: ₡{libro.Precio:N2}");
                    Console.WriteLine($"Disponible: {(libro.Disponible ? "Sí" : "No")}");
                    Console.WriteLine("*************************************************\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al mostrar los libros: {ex.Message}");
            }

            
           
        }

        public void MostrarLibroMayorPrecio()
        {
            Console.Clear(); // Limpia la consola antes de mostrar el libro de mayor precio.

            Console.WriteLine("*************************************************");
            Console.WriteLine("*           Mostrar Libro de Mayor Precio       *");
            Console.WriteLine("*************************************************");

            if (libros.Any())
            {
                var libroMayorPrecio = libros.OrderByDescending(l => l.Precio).First();
                Console.WriteLine("\nLibro de mayor precio:\n");
                Console.WriteLine($"Título: {libroMayorPrecio.Titulo}");
                Console.WriteLine($"Autor: {libroMayorPrecio.Autor}");
                Console.WriteLine($"Fecha de Publicación: {libroMayorPrecio.FechaDePublicacion.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Precio: ₡{libroMayorPrecio.Precio:N2}");
                Console.WriteLine($"Disponible: {(libroMayorPrecio.Disponible ? "Sí" : "No")}");
            }
            else
            {
                Console.WriteLine("\nLa biblioteca está vacía.");
            }

            
        }


        public void MostrarTresLibrosMasBaratos()
        {
            Console.Clear(); // Limpia la consola antes de mostrar los libros más baratos.

            Console.WriteLine("*************************************************");
            Console.WriteLine("*       Mostrar los Tres Libros Más Baratos     *");
            Console.WriteLine("*************************************************");

            if (libros.Count >= 3)
            {
                var tresMasBaratos = libros.OrderBy(l => l.Precio).Take(3);
                Console.WriteLine("\nLos tres libros más baratos:\n");
                foreach (var libro in tresMasBaratos)
                {
                    Console.WriteLine($"Título: {libro.Titulo}");
                    Console.WriteLine($"Autor: {libro.Autor}");
                    Console.WriteLine($"Fecha de Publicación: {libro.FechaDePublicacion.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Precio: ₡{libro.Precio:N2}");
                    Console.WriteLine($"Disponible: {(libro.Disponible ? "Sí" : "No")}");
                    Console.WriteLine("----------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("\nNo hay suficientes libros en la biblioteca para mostrar los tres más baratos.");
            }

           
            
        }


        public void BuscarLibrosPorAutor(string inicioNombreAutor)
        {
            var librosAutor = libros.Where(l => l.Autor.StartsWith(inicioNombreAutor, StringComparison.OrdinalIgnoreCase)).ToList();
            if (librosAutor.Any())
            {
                Console.WriteLine($"Libros encontrados por el autor que comienza con '{inicioNombreAutor}':");
                foreach (var libro in librosAutor)
                {
                    libro.Consultar();
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron libros cuyo autor comience con '{inicioNombreAutor}'.");
            }
        }

        public void BuscarLibros(string titulo)
        {
            var librosEncontrados = libros.Where(l => l.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();
            if (librosEncontrados.Any())
            {
                Console.WriteLine($"Libros encontrados que contienen '{titulo}' en el título:");
                foreach (var libro in librosEncontrados)
                {
                    libro.Consultar();
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron libros con '{titulo}' en el título.");
            }
        }
    }

}
