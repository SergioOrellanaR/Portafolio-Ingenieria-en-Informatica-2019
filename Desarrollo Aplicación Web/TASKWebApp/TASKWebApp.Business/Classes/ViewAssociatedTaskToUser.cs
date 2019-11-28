using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWebApp.Business.Helpers;
using TASKWebApp.Data;

namespace TASKWebApp.Business.Classes
{
    public class ViewAssociatedTaskToUser
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
    }
}
