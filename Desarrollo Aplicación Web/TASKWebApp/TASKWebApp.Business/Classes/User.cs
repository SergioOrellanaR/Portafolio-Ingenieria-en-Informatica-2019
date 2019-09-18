﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASKWebApp.Business.Helpers;

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
                    log.Error("Error al ir a buscar la unidad asignada a la DB");
                    throw new Exception();
                }
                return true;
            }
            catch (Exception e)
            {
                log.Error("Error al buscar usuario por email", e);
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

            foreach(Data.USER_INFO user in Connection.ProcessSA_DB.USER_INFO.ToList().Where(users => (int)users.ASSIGNED_UNIT.ID_SUPERIOR_UNIT == AssignedUnit.Id))
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
    }
}
