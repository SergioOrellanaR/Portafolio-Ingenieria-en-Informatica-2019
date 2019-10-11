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
                if (Id == -1)
                {
                    log.Error("Se intentó crear Tarea inválida. ID: " +Id);
                    throw new Exception();
                }
                else
                {
                    if(Id > 0 && IsPredefined)
                    {
                        //En caso que esté intentando crear una predeterminada
                        return true;
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

        public Dictionary<int, Task> LoadChildTasks()
        {
            Dictionary<int, Task> childTasks = new Dictionary<int, Task>();
            foreach (Data.TASK task in Connection.ProcessSA_DB.TASK.ToList().Where(x => x.ID_SUPERIOR_TASK == Id))
            {
                int taskId = (int)task.ID;
                Task taskReaded = new Task(taskId);
                childTasks.Add(taskId, taskReaded);
            }
            return childTasks;
        }
    }

    public class TaskFlowInfo
    {
        public bool IsRepetitive { get; set; }
        public bool IsPredefined { get; set; }
        public bool? IsDayOfWeek { get; set; }
        public ProcessedTask ProcessedTask { get; set; }
        public LoopTask LoopTask { get; set; }
        public List<LoopTaskSchedule> LoopTaskScheduleList { get; set; }
        public Task OriginalTask { get; set; }
    }

    //Recursividad Mindblowing, trae la tarea con sus hijas.
    public class ChildTaskContainer
    {
        //public int VirtualId { get; set; }
        public Task Task { get; set; }
        public List<ChildTaskContainer> ChildTasks { get; set; }
        public int Level { get; set; }

        public ChildTaskContainer(Task task)
        {
            Task = task;
            if (Task.HaveChilds())
            {
                ChildTasks = new List<ChildTaskContainer>();
                foreach (Task child in Task.LoadChildTasks().Values)
                {
                    ChildTaskContainer ctc = new ChildTaskContainer(child);
                    ChildTasks.Add(ctc);
                }
            }
        }

        //Carga los niveles, estos deben ser cargados DESDE LA RAIZ.
        public void LoadLevel(int paramVal)
        {
            Level = paramVal;
            if (ChildTasks != null && ChildTasks.Count > 0)
            {
                foreach (ChildTaskContainer ctc in ChildTasks)
                {
                    ctc.LoadLevel(paramVal + 1);
                }
            }
        }

        public List<TaskWithLevel> TransformToListPlainWithLevels(List<TaskWithLevel> list)
        {
            TaskWithLevel twl = new TaskWithLevel { Task = Task, Level = Level};
            list.Add(twl);
            if (ChildTasks != null && ChildTasks.Count > 0)
            {
                foreach (ChildTaskContainer ctc in ChildTasks)
                {
                    ctc.TransformToListPlainWithLevels(list);
                }
            }
            return list;
        }
        /*
        public int GetNumberOfTasksInFamily(int val)
        {
            if (ChildTasks != null && ChildTasks.Count > 0)
            {
                val += ChildTasks.Count;
                foreach (ChildTaskContainer ctc in ChildTasks)
                {
                    ctc.GetNumberOfTasksInFamily(val);
                }
            }
            else
            {
                val++;
            }
            return val;
        }
        */
    }

    public class TaskWithLevel
    {
        public Task Task { get; set; }
        public int Level { get; set; }
        public int? virtualId { get; set; }
        public int? virtualParentId { get; set; }
        public int? virtualDependentid { get; set; }
        public int OperationId { get; set; }
        public TaskLevelDetail Detail { get; set; }

        public TaskWithLevel()
        {

        }

    }

    public class TaskLevelDetail
    {
        public bool IsRepetitive { get; set; }

        public DateTime? Start { get; set; }
        public DateTime End { get; set; }

        public List<string> SelectedDaysOfWeek { get; set; }
        public List<string> SelectedWeeks { get; set; }
        public string SelectedDay { get; set; }
        public int? IdMonth { get; set; }

        public void LoadTimeForRepetitive(string StartTime, string EndTime)
        {
            string defaultDate = "1900-01-01";
            DateTime startTime = DateTime.Parse(defaultDate + " " + StartTime);
            DateTime endTime = DateTime.Parse(defaultDate + " " + EndTime);

            Start = startTime;
            End = endTime;
        }
    }
}
