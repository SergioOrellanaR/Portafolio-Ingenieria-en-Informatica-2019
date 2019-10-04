using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWebApp.Business.Helpers;
using log4net;

namespace TASKWebApp.Business.Classes
{
    public class LoopTask
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int Id { get; set; }
        public TaskAssignment TaskAssignment { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Isactive { get; set; }

        public LoopTask()
        {

        }

        public LoopTask(int id)
        {
            Id = id;
            if (!ReadById())
            {
                Id = -1;
                log.Error("Error al inicializar loopTask por Id (No se pudo encontrar), Id parametrizado: " + id);
            }
        }

        public bool Create()
        {
            try
            {
                if (Id != 0)
                {
                    log.Error("Se intentó crear LoopTask con Id ya existente. ID: " + Id);
                    throw new Exception();
                }
                else
                {
                    Data.LOOP_TASK loopTask = new Data.LOOP_TASK();
                    loopTask.ID_TASK_ASSIGNMENT = TaskAssignment.Id;
                    loopTask.STARTTIME = StartTime;
                    loopTask.ENDTIME = EndTime;
                    loopTask.ISACTIVE = StaticHelper.BoolToShort(Isactive);
                    Connection.ProcessSA_DB.LOOP_TASK.Add(loopTask);
                    Connection.ProcessSA_DB.SaveChanges();
                    Id = (int)loopTask.ID;
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante la creación de LoopTask de la tarea "+ TaskAssignment.Task.Id, e);
                return false;
            }
        }

        public bool ReadById()
        {
            try
            {
                Data.LOOP_TASK loopTask = Connection.ProcessSA_DB.LOOP_TASK.First(lt => lt.ID == Id);
                Id = (int)loopTask.ID;
                TaskAssignment = new TaskAssignment((int)loopTask.ID_TASK_ASSIGNMENT);
                StartTime = loopTask.STARTTIME;
                EndTime = loopTask.ENDTIME;
                Isactive = StaticHelper.ShortToBool(loopTask.ISACTIVE);
                return true;
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante la lectura de LoopTask con Id: "+Id, e);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Data.LOOP_TASK loopTask = Connection.ProcessSA_DB.LOOP_TASK.First(lt => lt.ID == Id);
                Id = (int)loopTask.ID;
                loopTask.ID_TASK_ASSIGNMENT = TaskAssignment.Id;
                loopTask.STARTTIME = StartTime;
                loopTask.ENDTIME = EndTime;
                loopTask.ISACTIVE = StaticHelper.BoolToShort(Isactive);
                Connection.ProcessSA_DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante el update de LoopTask con Id: " + Id, e);
                return false;
            }
        }
    }
}
