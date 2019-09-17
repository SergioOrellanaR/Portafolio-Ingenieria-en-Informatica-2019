using System.Collections.Generic;
using System.Linq;

namespace TASKWebApp.Business.Helpers
{
    public class ComboBoxDataLoader
    {
        private static Dictionary<int, string> _gender;

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
    }
}
