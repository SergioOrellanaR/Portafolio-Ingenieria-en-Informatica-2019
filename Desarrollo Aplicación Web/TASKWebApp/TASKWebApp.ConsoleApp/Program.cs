using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Task task = new Task(6);
            ChildTaskContainer ctc = new ChildTaskContainer(task);
            ctc.LoadLevel(0);
            List<TaskWithLevel> tl = new List<TaskWithLevel>();
            ctc.TransformToListPlainWithLevels(tl);
            foreach(TaskWithLevel tsk in tl)
            {
                Console.WriteLine(tsk.Level+" "+tsk.Task.Name);
            }
            Console.WriteLine("Un yogurazo");

            Console.ReadKey();
        }
    }
}
