using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWebApp.Business.Helpers;
using log4net;

namespace TASKWebApp.Business.Classes
{
    public class ProcessedTask
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int Id { get; set; }
        public string Commentary { get; set; }
        public DateTime AssignationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdTaskStatus { get; set; }
        public TaskAssignment TaskAssignment { get; set; }
        public LoopTaskSchedule LoopTaskSchedule { get; set; }

        public ProcessedTask()
        {

        }

        public bool Create()
        {
            try
            {
                if (Id != 0)
                {
                    log.Error("Se intentó crear ProcessedTask con Id ya existente. ID: " + Id);
                    throw new Exception();
                }
                else
                {
                    Data.PROCESSED_TASK processedTask = new Data.PROCESSED_TASK();
                    processedTask.COMMENTARY = Commentary;
                    processedTask.ASSIGNATIONDATE = AssignationDate;
                    processedTask.ENDDATE = EndDate;
                    processedTask.STARTDATE = StartDate;
                    processedTask.ID_TASKSTATUS = IdTaskStatus;
                    processedTask.ID_TASK_ASSIGNMENT = TaskAssignment.Id;

                    if (LoopTaskSchedule != null)
                    {
                        processedTask.ID_SCHEDULED_LOOPTASK = LoopTaskSchedule.Id;
                    }
                    else
                    {
                        processedTask.ID_SCHEDULED_LOOPTASK = null;
                    }

                    Connection.ProcessSA_DB.PROCESSED_TASK.Add(processedTask);
                    Connection.ProcessSA_DB.SaveChanges();
                    Id = (int)processedTask.ID;
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante la creación de ProcessedTask ", e);
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                Data.PROCESSED_TASK processedTask = Connection.ProcessSA_DB.PROCESSED_TASK.First(pt => pt.ID == Id);
                Id = (int)processedTask.ID;
                Commentary = processedTask.COMMENTARY;
                AssignationDate = processedTask.ASSIGNATIONDATE;
                StartDate = processedTask.STARTDATE;
                EndDate = processedTask.ENDDATE;
                IdTaskStatus = (int)processedTask.ID_TASKSTATUS;
                TaskAssignment = new TaskAssignment((int)processedTask.ID_TASK_ASSIGNMENT);

                if (processedTask.ID_SCHEDULED_LOOPTASK != null)
                {
                    LoopTaskSchedule = new LoopTaskSchedule((int)processedTask.ID_SCHEDULED_LOOPTASK);
                }
                else
                {
                    LoopTaskSchedule = null;
                }
                return true;
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante la lectura de ProcessedTask con Id: "+ Id, e);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Data.PROCESSED_TASK processedTask = Connection.ProcessSA_DB.PROCESSED_TASK.First(pt => pt.ID == Id);
                processedTask.COMMENTARY = Commentary;
                processedTask.ASSIGNATIONDATE = AssignationDate;
                processedTask.ENDDATE = EndDate;
                processedTask.STARTDATE = StartDate;
                processedTask.ID_TASKSTATUS = IdTaskStatus;
                processedTask.ID_TASK_ASSIGNMENT = TaskAssignment.Id;

                if (LoopTaskSchedule != null)
                {
                    processedTask.ID_SCHEDULED_LOOPTASK = LoopTaskSchedule.Id;
                }
                else
                {
                    processedTask.ID_SCHEDULED_LOOPTASK = null;
                }
                Connection.ProcessSA_DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error("Ha ocurrido un error durante el update de ProcessedTask con Id: "+Id, e);
                return false;
            }
        }
    }
}
