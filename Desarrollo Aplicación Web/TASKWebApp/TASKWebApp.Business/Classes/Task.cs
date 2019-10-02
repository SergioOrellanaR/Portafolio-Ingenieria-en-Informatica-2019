using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWebApp.Business.Helpers;
using log4net;

namespace TASKWebApp.Business.Classes
{
    public class Task
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPredefined { get; set; }
        public bool? IsActive { get; set; }
        public Task SuperiorTask { get; set; }
        public Task DependentTask { get; set; }

        public Task()
        {

        }

        public Task(int id)
        {
            Id = id;
            if (!ReadById())
            {
                Id = -1;
                log.Error("Error al inicializar tarea por Id (No se pudo encontrar), Id parametrizado: "+id);
            }
        }

        public bool Create()
        {
            try
            {
                if (Id != 0)
                {
                    log.Error("Se intentó crear Tarea con Id ya existente. ID: " +Id);
                    throw new Exception();
                }
                else
                {
                    Data.TASK task = new Data.TASK();
                    task.NAME = Name;
                    task.DESCRIPTION = Description;
                    task.ISPREDEFINED = StaticHelper.BoolToShort(IsPredefined);
                    task.ISACTIVE = StaticHelper.BoolToShort(IsActive);

                    if (SuperiorTask != null)
                    {
                        task.ID_SUPERIOR_TASK = SuperiorTask.Id;
                    }
                    else
                    {
                        task.ID_SUPERIOR_TASK = null;
                    }

                    if (DependentTask != null)
                    {
                        task.ID_DEPENDENT_TASK = DependentTask.Id;
                    }
                    else
                    {
                        task.ID_DEPENDENT_TASK = null;
                    }
                    

                    Connection.ProcessSA_DB.TASK.Add(task);
                    Connection.ProcessSA_DB.SaveChanges();
                    Id = (int)task.ID;
                    return true;
                } 
            }
            catch (Exception e)
            { 
                log.Error("Ha ocurrido un error durante la creación de Tarea de nombre: "+Name, e);
                return false;
            }
        }

        public bool ReadById()
        {
            try
            {
                Data.TASK task = Connection.ProcessSA_DB.TASK.First(tsk => tsk.ID == Id);

                Id = (int)task.ID;
                Name = task.NAME;
                Description = task.DESCRIPTION;
                IsPredefined = StaticHelper.ShortToBool(task.ISPREDEFINED);
                IsActive = StaticHelper.ShortToBool(task.ISACTIVE);

                if (task.ID_SUPERIOR_TASK != null)
                {
                    SuperiorTask = new Task() { Id = (int)task.ID_SUPERIOR_TASK };
                    SuperiorTask.ReadById();
                }
                else
                {
                    SuperiorTask = null;
                }

                if (task.ID_DEPENDENT_TASK != null)
                {
                    DependentTask = new Task() { Id = (int)task.ID_DEPENDENT_TASK };
                    DependentTask.ReadById();
                }
                else
                {
                    DependentTask = null;
                }

                return true;
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante la lectura de Tarea de Id: " + Id, e);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Data.TASK task = Connection.ProcessSA_DB.TASK.First(tsk => tsk.ID == Id);
                task.NAME = Name;
                task.DESCRIPTION = Description;
                task.ISPREDEFINED = StaticHelper.BoolToShort(IsPredefined);
                task.ISACTIVE = StaticHelper.BoolToShort(IsActive);
                task.ID_SUPERIOR_TASK = SuperiorTask.Id;
                task.ID_DEPENDENT_TASK = DependentTask.Id;
                Connection.ProcessSA_DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante el update de Tarea de Id: "+ Id, e);
                return false;
            }
        }

        public bool HaveChilds()
        {
            try
            {
                Data.TASK task = Connection.ProcessSA_DB.TASK.First(tsk => tsk.ID_SUPERIOR_TASK == Id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
