using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWebApp.Data;

namespace TASKWebApp.Business.Helpers
{
    internal class Connection
    {
        #region Campos
        private static ProcessSAEntities _processSA_DB; //Conexión con la DataBase
        #endregion

        #region Properties
        public static ProcessSAEntities ProcessSA_DB
        {
            get
            {
                if (_processSA_DB == null)
                    _processSA_DB = new ProcessSAEntities();
                return _processSA_DB;
            }
            set
            {
                _processSA_DB = value;
            }
        }
        #endregion
    }
}
