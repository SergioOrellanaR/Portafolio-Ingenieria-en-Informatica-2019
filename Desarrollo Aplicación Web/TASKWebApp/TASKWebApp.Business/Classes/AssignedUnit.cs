using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using TASKWebApp.Business.Helpers;

namespace TASKWebApp.Business.Classes
{
    public class AssignedUnit
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int Id { get; set; }
        public string InternalUnit { get; set; }
        public string Company { get; set; }
        public AssignedUnit SuperiorUnit { get; set; }

        public AssignedUnit()
        {

        }

        public bool ReadById()
        {
            try
            {
                Data.ASSIGNED_UNIT au = Connection.ProcessSA_DB.ASSIGNED_UNIT.First(re => (int)re.ID == Id);
                Id = (int)au.ID;
                InternalUnit = au.INTERNAL_UNIT.NAME;
                Company = au.COMPANY.NAME;
                if (au.ID_SUPERIOR_UNIT != null)
                {
                    SuperiorUnit = new AssignedUnit() { Id = (int)au.ID_SUPERIOR_UNIT };
                    if (SuperiorUnit.ReadById() == false)
                    {
                        log.Error("Error al ir a buscar la unidad superior, esta no fue encontrada en DB");
                        throw new Exception();
                    }
                }
                else
                {
                    SuperiorUnit = null;
                }
                return true;
            }
            catch (Exception e)
            {
                log.Error("Error al buscar unidad asignada por ID", e);
                return false;
            }
        }
        
    }
}
