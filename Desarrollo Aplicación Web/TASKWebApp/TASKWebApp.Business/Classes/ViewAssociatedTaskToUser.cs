using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWebApp.Business.Helpers;
using TASKWebApp.Data;

namespace TASKWebApp.Business.Classes
{
    class ViewAssociatedTaskToUser
    {
        public DateTime AssignationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TaskStatus { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string AssignerName { get; set; }
        public string ReceiverName { get; set; }
        public string Justification { get; set; }

        public ViewAssociatedTaskToUser()
        {

        }

        public List<ViewAssociatedTaskToUser> RealizeFiltering(int idUser, int idMonth, int year, int idStatus, bool isAssigner)
        {
            List<VW_TASK_ASSOCIATED_TO_USER> taskList = FilterByUserTaskList(idUser, isAssigner, year);

            if(idMonth != 13)
                taskList = taskList.Where(X => X.Fecha_Inicio.Month == idMonth).ToList();

            if (idStatus != 0)
                taskList = taskList.Where(X => X.IDSTATUS == idStatus).ToList();

            List<ViewAssociatedTaskToUser> filteredList = new List<ViewAssociatedTaskToUser>();

            foreach (VW_TASK_ASSOCIATED_TO_USER task in taskList)
            {
                ViewAssociatedTaskToUser associatedTask = new ViewAssociatedTaskToUser()
                {
                    AssignationDate = task.Fecha_Asignacion,
                    StartDate = task.Fecha_Inicio,
                    EndDate = task.Fecha_Fin,
                    TaskStatus = task.Estado,
                    TaskName = task.Nombre_Tarea,
                    Description = task.Descripcion,
                    AssignerName = task.Asignado_Por,
                    ReceiverName = task.Asignado_A,
                    Justification = task.Justificacion
                };

                filteredList.Add(associatedTask);
            }

            return filteredList;
        }

        public List<VW_TASK_ASSOCIATED_TO_USER> FilterByUserTaskList(int idUser, bool isAssigner, int year)
        {
            List<VW_TASK_ASSOCIATED_TO_USER> taskList;
            if (isAssigner)
                taskList = Connection.ProcessSA_DB.VW_TASK_ASSOCIATED_TO_USER.Where(X => (int)X.IDASSIGNERUSER == idUser && X.Fecha_Inicio.Year == year).ToList();
            else
                taskList = Connection.ProcessSA_DB.VW_TASK_ASSOCIATED_TO_USER.Where(X => (int)X.IDRECEIVERUSER == idUser && X.Fecha_Inicio.Year == year).ToList();
            return taskList;
        }

    }
}
