using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWebApp.Business.Helpers;
using TASKWebApp.Data;

namespace TASKWebApp.Business.Classes
{
    public class User
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Commune { get; set; }
        public AssignedUnit AssignedUnit { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        
        public User()
        {

        }

        public User(int id)
        {
            Id = id;
            if (!ReadById())
            {
                Id = -1;
                log.Error("Error al inicializar Usuario por Id (No se pudo encontrar), Id parametrizado: " + id);
            }
        }

        public bool ReadById()
        {
            try
            {
                Data.USER_INFO usr = Connection.ProcessSA_DB.USER_INFO.First(user => user.ID == Id);
                Id = (int)usr.ID;
                FirstName = usr.FIRSTNAME;
                LastName = usr.LASTNAME;
                Address = usr.ADDRESS;
                Phone = usr.PHONE;
                Birthdate = usr.BIRTHDATE;
                Email = usr.EMAIL;
                Commune = usr.COMMUNE.NAME;
                Gender = usr.GENDER.NAME;
                Company = usr.COMPANY.NAME;
                AssignedUnit = new AssignedUnit() { Id = (int)usr.ASSIGNED_UNIT.ID };
                if (AssignedUnit.ReadById() == false)
                {
                    log.Error(("Error al ir a buscar la unidad asignada del usuario con Id {0} a la DB", Id));
                    throw new Exception();
                }
                return true;
            }
            catch (Exception e)
            {
                log.Error("Error al buscar usuario por Id: "+Id, e);
                return false;
            }
        }

        public bool ReadByEmail()
        {
            try
            {
                Data.USER_INFO usr = Connection.ProcessSA_DB.USER_INFO.First(user => Email.Equals(user.EMAIL, StringComparison.InvariantCultureIgnoreCase));
                Id = (int)usr.ID;
                FirstName = usr.FIRSTNAME;
                LastName = usr.LASTNAME;
                Address = usr.ADDRESS;
                Phone = usr.PHONE;
                Birthdate = usr.BIRTHDATE;
                Email = usr.EMAIL;
                Commune = usr.COMMUNE.NAME;
                Gender = usr.GENDER.NAME;
                Company = usr.COMPANY.NAME;
                AssignedUnit = new AssignedUnit() { Id = (int)usr.ASSIGNED_UNIT.ID };
                if (AssignedUnit.ReadById() == false)
                {
                    log.Error(("Error al ir a buscar la unidad asignada del usuario con Id {0} a la DB", Id));
                    throw new Exception();
                }
                return true;
            }
            catch (Exception e)
            {
                log.Error("Error al buscar usuario por email: "+Email, e);
                return false;
            }
        }

        public bool Authenticate()
        {
            try
            {
                string encryptedPassword = PasswordEncryptor.Encrypt(Password);
                Data.USER_INFO usr = Connection.ProcessSA_DB.USER_INFO.First(user => Email.Equals(user.EMAIL, StringComparison.InvariantCultureIgnoreCase) && encryptedPassword == user.PASSWORD);
                ReadByEmail();
                return true;
            }
            catch (Exception e)
            {
                log.Warn("Error al autenticar el usuario, verifique que usuario y contraseña corresponda", e);
                return false;
            }
        }

        public bool UpdatePassword()
        {
            try
            {
                Data.USER_INFO usr = Connection.ProcessSA_DB.USER_INFO.First(user => Email.Equals(user.EMAIL, StringComparison.InvariantCultureIgnoreCase));
                usr.PASSWORD = PasswordEncryptor.Encrypt(Password);
                Connection.ProcessSA_DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error("Error al actualizar la contraseña de usuario de email "+Email, e);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Data.USER_INFO usr = Connection.ProcessSA_DB.USER_INFO.First(user => Email.Equals(user.EMAIL, StringComparison.InvariantCultureIgnoreCase));
                usr.PHONE = Phone;
                Connection.ProcessSA_DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error("Error al actualizar el celular del usuario con email: " + Email, e);
                return false;
            }
        }

        public Dictionary<int, string> GetPermissions()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            Data.USER_INFO usr = Connection.ProcessSA_DB.USER_INFO.First(user => Email.Equals(user.EMAIL, StringComparison.InvariantCultureIgnoreCase));

            foreach (Data.PERMISSION permission in usr.ASSIGNED_UNIT.INTERNAL_UNIT.ROLE.PERMISSION)
            {
                dictionary.Add((int)permission.ID, permission.NAME);
            }

            return dictionary;
        }

        public Dictionary<int, User> GetSubordinated()
        {
            Dictionary<int, User> dictionary = new Dictionary<int, User>();

            foreach(Data.USER_INFO user in Connection.ProcessSA_DB.USER_INFO.ToList().Where(users => (int?)users.ASSIGNED_UNIT.ID_SUPERIOR_UNIT == AssignedUnit.Id))
            {
                User usr = new User() { Email = user.EMAIL };
                usr.ReadByEmail();
                dictionary.Add(usr.Id, usr);
            }

            return dictionary;
        }

        public Dictionary<int, User> GetEqualsGrades()
        {
            Dictionary<int, User> dictionary = new Dictionary<int, User>();

            foreach (Data.USER_INFO user in Connection.ProcessSA_DB.USER_INFO.ToList().Where(users => (int)users.ASSIGNED_UNIT.ID == AssignedUnit.Id && users.ID != Id))
            {
                User usr = new User() { Email = user.EMAIL };
                usr.ReadByEmail();
                dictionary.Add(usr.Id, usr);
            }

            return dictionary;
        }

        public Dictionary<int, User> GetEqualsAndSubordinated()
        {
            Dictionary<int, User> dictionary = new Dictionary<int, User>();

            GetSubordinated().ToList().ForEach(x => dictionary.Add(x.Key, x.Value));
            GetEqualsGrades().ToList().ForEach(x => dictionary.Add(x.Key, x.Value));

            return dictionary;
            
        }

        public Dictionary<int, string> GetEqualsAndSubordinatedString()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            GetEqualsAndSubordinated().ToList().ForEach(x => dictionary.Add(x.Key, string.Format("{0} {1} ({2})", x.Value.FirstName, x.Value.LastName, x.Value.AssignedUnit.InternalUnit)));
            var sortedDict = from entry in dictionary orderby entry.Value ascending select entry;
            dictionary = sortedDict.ToDictionary(pair => pair.Key, pair => pair.Value);
            return dictionary;
        }


        public Dictionary<int, User> GetSuperiors()
        {
            Dictionary<int, User> dictionary = new Dictionary<int, User>();

            foreach (Data.USER_INFO user in Connection.ProcessSA_DB.USER_INFO.ToList().Where(users => (int)users.ASSIGNED_UNIT.ID == AssignedUnit.SuperiorUnit.Id))
            {
                User usr = new User() { Email = user.EMAIL };
                usr.ReadByEmail();
                dictionary.Add(usr.Id, usr);
            }

            return dictionary;
        }
        /*Busca en todos los permisos existentes si el permiso en cuestión está en la DB,
        en caso que no, es porque este permiso ha dejado de existir, en cuyo caso este
        método devolverá el valor configurado en App Settings cuando los permisos no existen.
        En caso de existir y el usuario poseer el permiso, devolverá true.
        En caso de existir y el usuario no posee el permiso, devolverá false.*/
        public bool HasPermission(int idPermission)
        {
            try
            {
                
                Connection.ProcessSA_DB.PERMISSION.First(x => x.ID == idPermission);
                if (GetPermissions().ContainsKey(idPermission))
                {
                    return true;
                }
                else
                {
                    log.Warn(("Se le ha denegado el acceso al usuario a un módulo al cual no estaba autorizado. Email: {0}, IdPermiso: {1}", Email, idPermission));
                    return false;
                }
            }
            catch (Exception e)
            {
                log.Error("Se ha ido a buscar un permiso que ya no existe en la base de datos, el ID de este permiso es el: " + idPermission);
                bool val;
                if (Boolean.TryParse(ConfigurationManager.AppSettings["AllowWhenPermissionDoesntExists"], out val))
                {
                    return val;
                }
                else
                {
                    log.Error("Error al parsear el valor AllowWhenPermissionDoesntExists, verifique que sea un boolean válido");
                    return false;
                }
            }
        }

        public string GetInternalUnitName()
        {
            string value;
            try
            {
                Data.USER_INFO usr = Connection.ProcessSA_DB.USER_INFO.First(user => user.ID == Id);
                value = usr.ASSIGNED_UNIT.INTERNAL_UNIT.NAME;
            }
            catch (Exception e)
            {
                value = null;
            }

            return value;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public List<ProcessedTask> SearchProcessedTaskByStatus(int status)
        {
            List<PROCESSED_TASK> tasks = Connection.ProcessSA_DB.PROCESSED_TASK.Where(X => /*X.ENDDATE>DateTime.Now*/ X.ID_TASKSTATUS == status && X.TASK_ASSIGNMENT.ID_RECEIVERUSER == Id).ToList();
            return ProcessTasks(tasks);
        }

        public List<ProcessedTask> SearchProcessedTaskByStatus(int status1, int status2)
        {
            List<PROCESSED_TASK> tasks = Connection.ProcessSA_DB.PROCESSED_TASK.Where(X => /*X.ENDDATE>DateTime.Now*/ (X.ID_TASKSTATUS == status1 || X.ID_TASKSTATUS == status2) && X.TASK_ASSIGNMENT.ID_RECEIVERUSER == Id).ToList();
            return ProcessTasks(tasks);
        }

        public List<ProcessedTask> ProcessTasks(List<PROCESSED_TASK> tasks)
        {
            List<ProcessedTask> processedTasks = new List<ProcessedTask>();
            foreach (PROCESSED_TASK task in tasks)
            {
                ProcessedTask pt = new ProcessedTask()
                {
                    Id = (int)task.ID
                };
                pt.Read();
                processedTasks.Add(pt);
            }
            processedTasks = processedTasks.OrderBy(x => x.StartDate).ToList();
            return processedTasks;
        }

        public int GetNumberOfPendentTasks()
        {
            int assignedStatus = 1;
            int reassignedStatus = 4;
            int numberOfPendentTasks = Connection.ProcessSA_DB.PROCESSED_TASK.Where(X => /*X.ENDDATE>DateTime.Now*/ (X.ID_TASKSTATUS == assignedStatus || X.ID_TASKSTATUS == reassignedStatus) && X.TASK_ASSIGNMENT.ID_RECEIVERUSER == Id).Count();
            return numberOfPendentTasks;
        }

        public int GetNumberOfInProcessTasks()
        {
            int inProcess = 2;
            int numberOfPendentTasks = Connection.ProcessSA_DB.PROCESSED_TASK.Where(X => /*X.ENDDATE>DateTime.Now*/ X.ID_TASKSTATUS == inProcess && X.TASK_ASSIGNMENT.ID_RECEIVERUSER == Id).Count();
            return numberOfPendentTasks;
        }
    }

    public class PassRecover
    {
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Code { get; set; }
        public DateTime LastTry { get; set; }
        public int NumberOfTries { get; set; }

        public PassRecover()
        {

        }

        public bool IsEmailAndBirthdayCorrect()
        {
            try
            {
                Data.USER_INFO usr = Connection.ProcessSA_DB.USER_INFO.First(user => Email.Equals(user.EMAIL, StringComparison.InvariantCultureIgnoreCase) && EntityFunctions.TruncateTime(Birthdate) == EntityFunctions.TruncateTime(user.BIRTHDATE));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool HasPermission(int idPermission)
        {
            User user = new User { Email = Email };
            return user.HasPermission(idPermission);
        }
    }
}
