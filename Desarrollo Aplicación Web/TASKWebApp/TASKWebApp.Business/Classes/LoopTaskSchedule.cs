using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWebApp.Business.Helpers;
using log4net;

namespace TASKWebApp.Business.Classes
{
    public class LoopTaskSchedule
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int Id { get; set; }
        public LoopTask LoopTask { get; set; }
        public int? DayOfWeek { get; set; }
        public int? DayOfMonth { get; set; }
        public int? NumberOfWeek { get; set; }
        public int? IdMonth { get; set; }

        public LoopTaskSchedule()
        {

        }

        public LoopTaskSchedule(int id)
        {
            Id = id;
            if (!ReadById())
            {
                Id = -1;
                log.Error("Error al inicializar LoopTaskSchedule por Id (No se pudo encontrar), Id parametrizado: " + id);
            }
        }

        public bool Create()
        {
            try
            {
                if (Id != 0)
                {
                    log.Error("Se intentó crear LoopTaskSchedule con Id ya existente. ID: " + Id);
                    throw new Exception();
                }
                else
                {
                    Data.LOOP_TASK_SCHEDULE loopTaskSchedule = new Data.LOOP_TASK_SCHEDULE();
                    loopTaskSchedule.ID_LOOP_TASK = LoopTask.Id;
                    loopTaskSchedule.ID_DAYOFWEEK = DayOfWeek;
                    loopTaskSchedule.DAYOFMONTH = DayOfMonth;
                    loopTaskSchedule.NUMBEROFWEEK = NumberOfWeek;
                    loopTaskSchedule.ID_MONTH = IdMonth;
                    Connection.ProcessSA_DB.LOOP_TASK_SCHEDULE.Add(loopTaskSchedule);
                    Connection.ProcessSA_DB.SaveChanges();
                    Id = (int)loopTaskSchedule.ID;
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante la creación de LoopTaskSchedule. Id Loop Task: "+LoopTask.Id, e);
                return false;
            }
        }

        public bool ReadById()
        {
            try
            {
                Data.LOOP_TASK_SCHEDULE loopTaskSchedule = Connection.ProcessSA_DB.LOOP_TASK_SCHEDULE.First(lts => lts.ID == Id);
                Id = (int)loopTaskSchedule.ID;
                LoopTask = new LoopTask((int)loopTaskSchedule.ID);
                DayOfWeek = (int?)loopTaskSchedule.ID_DAYOFWEEK;
                DayOfMonth = (int?)loopTaskSchedule.DAYOFMONTH;
                IdMonth = (int?)loopTaskSchedule.ID_MONTH;
                NumberOfWeek = (int?)loopTaskSchedule.NUMBEROFWEEK;
                return true;
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante la lectura de LoopTaskSchedule, Id: "+Id, e);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Data.LOOP_TASK_SCHEDULE loopTaskSchedule = Connection.ProcessSA_DB.LOOP_TASK_SCHEDULE.First(lts => lts.ID == Id);
                loopTaskSchedule.ID_LOOP_TASK = LoopTask.Id;
                loopTaskSchedule.ID_DAYOFWEEK = DayOfWeek;
                loopTaskSchedule.DAYOFMONTH = DayOfMonth;
                loopTaskSchedule.NUMBEROFWEEK = NumberOfWeek;
                loopTaskSchedule.ID_MONTH = IdMonth;
                Connection.ProcessSA_DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante el update de LoopTaskSchedule. Id: "+Id, e);
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                Data.LOOP_TASK_SCHEDULE loopTaskSchedule = Connection.ProcessSA_DB.LOOP_TASK_SCHEDULE.First(lts => lts.ID == Id);
                UpdateProcessedTaskToNull();
                Connection.ProcessSA_DB.LOOP_TASK_SCHEDULE.Remove(loopTaskSchedule);
                Connection.ProcessSA_DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante el update de LoopTaskSchedule. Id: "+Id, e);
                return false;
            }
        }

        public void UpdateProcessedTaskToNull()
        {
            int expiredStatus = 8;
            List<Data.PROCESSED_TASK> processedTasks = Connection.ProcessSA_DB.PROCESSED_TASK.Where(pt => pt.ID_SCHEDULED_LOOPTASK == Id).ToList();
            foreach (Data.PROCESSED_TASK pt in processedTasks)
            {
                pt.ID_TASKSTATUS = expiredStatus;
                pt.ID_SCHEDULED_LOOPTASK = null;
            }
                
            Connection.ProcessSA_DB.SaveChanges();
        }


    }
}
