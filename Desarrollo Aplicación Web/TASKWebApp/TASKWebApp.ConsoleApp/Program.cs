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
            log4net.Config.XmlConfigurator.Configure();
            Console.WriteLine("Se creará una tarea!");
            Console.WriteLine("");
            Business.Classes.Task task = new Business.Classes.Task()
            {
                DependentTask = null,
                Description = "Tarea de prueba",
                Name = "Test",
                IsActive = false,
                IsPredefined = false,
                SuperiorTask = null
            };

            Console.WriteLine("Resultado de Crear tarea = "+task.Create());
            Console.WriteLine("Id: " + task.Id);
            Console.ReadKey();
        }
    }
}
