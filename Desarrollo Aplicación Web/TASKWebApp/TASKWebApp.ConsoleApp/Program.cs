using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWebApp.Business.Classes;
using TASKWebApp.Business.Helpers;

namespace TASKWebApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pruebas de usuario!");
            Console.WriteLine("");
            User user = new User() { Email = "serorellanar@gmail.com" };
            Console.WriteLine("Resultado de Leer datos = "+user.ReadByEmail());
            Console.WriteLine("Id: "+user.Id);
            Console.WriteLine("Email: "+user.Email);
            Console.WriteLine("Nombres: "+user.FirstName);
            Console.WriteLine("Apellidos: "+user.LastName);
            Console.WriteLine("Fono: "+user.Phone);
            Console.WriteLine("Dirección: "+user.Address);
            Console.WriteLine("Comuna: "+user.Commune);
            Console.WriteLine("Compañia: "+user.Company);
            Console.WriteLine("Genero: "+user.Gender);
            Console.WriteLine("Fecha de nacimiento: "+user.Birthdate.ToString());
            Console.WriteLine("Unidad interna: " + user.AssignedUnit.InternalUnit + " en "+ user.AssignedUnit.Company);
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Se listarán todos los permisos del usuario: ");
            foreach(string val in user.GetPermissions().Values.ToList())
            {
                Console.WriteLine(val);
            }
            Console.ReadKey();
        }
    }
}
