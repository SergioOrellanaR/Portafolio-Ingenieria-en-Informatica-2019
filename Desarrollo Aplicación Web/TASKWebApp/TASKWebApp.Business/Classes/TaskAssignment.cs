using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWebApp.Business.Helpers;
using log4net;

namespace TASKWebApp.Business.Classes
{
    public class TaskAssignment
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int Id { get; set; }
        public Task Task { get; set; }
        public User AssignerUser { get; set; }
        public User ReceiverUser { get; set; }

        public TaskAssignment()
        {
            
        }

        public TaskAssignment(int id)
        {
            Id = id;
            if (!ReadById())
            {
                Id = -1;
                log.Error("Error al inicializar TaskAssignment por Id (No se pudo encontrar), Id parametrizado: " + id);
            }
        }

        public bool Create()
        {
            try
            {
                if (Id != 0)
                {
                    log.Error("Se intentó crear objeto TaskAssignment con Id ya existente. ID: " + Id);
                    throw new Exception();
                }
                else
                {
                    Data.TASK_ASSIGNMENT taskAssignment = new Data.TASK_ASSIGNMENT();
                    taskAssignment.ID_TASK = Task.Id;
                    taskAssignment.ID_ASSIGNERUSER = AssignerUser.Id;
                    if (ReceiverUser != null)
                    {
                        taskAssignment.ID_RECEIVERUSER = ReceiverUser.Id;
                    }
                    else
                    {
                        taskAssignment.ID_RECEIVERUSER = null;
                    }
                    Connection.ProcessSA_DB.TASK_ASSIGNMENT.Add(taskAssignment);
                    Connection.ProcessSA_DB.SaveChanges();
                    Id = (int)taskAssignment.ID;
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante la creación de Task assignment de Id tarea: "+Task.Id, e);
                return false;
            }
        }

        public bool ReadById()
        {
            try
            {
                Data.TASK_ASSIGNMENT taskAssignment = Connection.ProcessSA_DB.TASK_ASSIGNMENT.First(ta => ta.ID == Id);

                Id = (int)taskAssignment.ID;
                Task = new Task((int)taskAssignment.TASK.ID);
                AssignerUser = new User((int)taskAssignment.ID_ASSIGNERUSER);
                if (taskAssignment.ID_RECEIVERUSER != null)
                {
                    ReceiverUser = new User((int)taskAssignment.ID_RECEIVERUSER);
                }
                else
                {
                    ReceiverUser = null;
                }
                return true;
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante la lectura de Task assignment de Id: "+Id, e);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Data.TASK_ASSIGNMENT taskAssignment = Connection.ProcessSA_DB.TASK_ASSIGNMENT.First(ta => ta.ID == Id);
                taskAssignment.ID_TASK = Task.Id;
                taskAssignment.ID_ASSIGNERUSER = AssignerUser.Id;
                if (ReceiverUser != null)
                {
                    taskAssignment.ID_RECEIVERUSER = ReceiverUser.Id;
                }
                else
                {
                    taskAssignment.ID_RECEIVERUSER = null;
                }
                Connection.ProcessSA_DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante el update de Task assignment con Id "+Id, e);
                return false;
            }
        }
    }
}
