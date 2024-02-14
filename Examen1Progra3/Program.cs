using System;


namespace Examen1Progra3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ClsMenu menu = new ClsMenu();
            menu.MostrarMenu(); 
        }
    }
}