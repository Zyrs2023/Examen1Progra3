using System;

namespace Examen1Progra3
{
    internal class ClsLibro
    {
        public interface ILibro
        {
            void Prestar();
            void Devolver();
            void Consultar();
        }

        public class Libro : ILibro
        {
            public int Codigo { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public DateTime FechaDePublicacion { get; set; }
            public decimal Precio { get; set; }
            public bool Disponible { get; set; }

            public Libro(int codigo, string titulo, string autor, DateTime fechaDePublicacion, decimal precio, bool disponible = true)
            {
                Codigo = codigo;
                Titulo = titulo;
                Autor = autor;
                FechaDePublicacion = fechaDePublicacion;
                Precio = precio;
                Disponible = disponible;
            }

            public void Prestar()
            {
                try
                {
                    if (Disponible)
                    {
                        Disponible = false;
                        Console.WriteLine($"El libro '{Titulo}' ha sido prestado.");
                    }
                    else
                    {
                        Console.WriteLine($"El libro '{Titulo}' no está disponible para prestar.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al prestar el libro: {ex.Message}");
                }
            }

            public void Devolver()
            {
                Disponible = true;
                Console.WriteLine($"El libro '{Titulo}' ha sido devuelto.");
            }

            public void Consultar()
            {
                
                Console.WriteLine($"Título: {Titulo}");
                Console.WriteLine($"Autor: {Autor}");
                Console.WriteLine($"Fecha de Publicación: {FechaDePublicacion.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Precio: ₡{Precio:N2}");
                Console.WriteLine($"Disponible: {(Disponible ? "Sí" : "No")}");
            }

        }

    }
}
