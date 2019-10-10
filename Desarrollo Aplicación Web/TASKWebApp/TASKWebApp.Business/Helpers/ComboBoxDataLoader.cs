using System.Collections.Generic;
using System.Linq;
using TASKWebApp.Business.Classes;

namespace TASKWebApp.Business.Helpers
{
    public class ComboBoxDataLoader
    {
        private static Dictionary<int, string> _gender;
        private static Dictionary<int, string> _region; 
        private static Dictionary<int, string> _dayOfWeek;
        private static Dictionary<int, string> _month;
        private static Dictionary<int, string> _taskStatus;

        public static Dictionary<int, string> TaskStatus
        {
            get
            {
                _taskStatus = new Dictionary<int, string>();
                foreach (Data.TASK_STATUS taskStatus in Connection.ProcessSA_DB.TASK_STATUS.ToList())
                {
                    _taskStatus.Add((int)taskStatus.ID, taskStatus.STATUS);
                }
                return _taskStatus;
            }
        }


        public static Dictionary<int, string> Month
        {
            get
            {
                _month = new Dictionary<int, string>();
                foreach (Data.MONTH month in Connection.ProcessSA_DB.MONTH.ToList())
                {
                    _month.Add((int)month.ID, month.NAME);
                }
                return _month;
            }
        }


        public static Dictionary<int, string> DayOfWeek
        {
            get
            {
                _dayOfWeek = new Dictionary<int, string>();
                foreach (Data.DAY_OF_WEEK dayOfWeek in Connection.ProcessSA_DB.DAY_OF_WEEK.ToList())
                {
                    _dayOfWeek.Add((int)dayOfWeek.ID, dayOfWeek.NAME);
                }
                return _dayOfWeek;
            }
        }


        public static Dictionary<int, string> Region
        {
            get
            {
                _region = new Dictionary<int, string>();
                foreach (Data.REGION region in Connection.ProcessSA_DB.REGION.ToList())
                {
                    _region.Add((int)region.ID, region.NAME);
                }
                return _region;
            }
        }

        public static Dictionary<int, string> Gender
        {
            get
            {
                _gender = new Dictionary<int, string>();
                foreach (Data.GENDER gender in Connection.ProcessSA_DB.GENDER.ToList())
                {
                    _gender.Add((int)gender.ID, gender.NAME);
                }
                return _gender;
            }
        }

        public static Dictionary<int, string> GetProvicesByRegionId (int idRegion)
        {
            Dictionary<int, string> provinceDictionary = new Dictionary<int, string>();
            foreach (Data.PROVINCE province in Connection.ProcessSA_DB.PROVINCE.ToList().Where(x => x.ID_REGION == idRegion))
            {
                provinceDictionary.Add((int)province.ID, province.NAME);
            }
            return provinceDictionary;
        }

        public static Dictionary<int, string> GetCommuneByProvinceId(int idProvince)
        {
            Dictionary<int, string> communeDictionary = new Dictionary<int, string>();
            foreach (Data.COMMUNE commune in Connection.ProcessSA_DB.COMMUNE.ToList().Where(x => x.ID_PROVINCE == idProvince))
            {
                communeDictionary.Add((int)commune.ID, commune.NAME);
            }
            return communeDictionary;
        }

        //Conversar sobre .IsActive() y averiguar si hay que validar
        public static Dictionary<int, string> GetPredefinedTasks()
        {
            int invalidTaskId = -1;
            Dictionary<int, string> predefinedTasks = new Dictionary<int, string>();
            foreach (Data.TASK task in Connection.ProcessSA_DB.TASK.ToList().Where(x => x.ID_SUPERIOR_TASK == null && x.ISPREDEFINED == 1 /*&& x.ID_DEPENDENT_TASK == null*/))
            {
                Task tsk = new Task((int)task.ID);
                if (tsk.Id!=invalidTaskId)
                {
                    predefinedTasks.Add(tsk.Id, tsk.Name);
                }
            }
            return predefinedTasks;
        }

        /*
         * ToDo:
         * Agregar busqueda de tareas asignadas
         * Agregar busqueda de tareas asignadas por mi.
         */
    }
}
