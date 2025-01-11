using LMSDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LMSBusinessLayer
{
    public class clsLogin
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        enum enLogin { enAddNew = 0, enUpdate = 1 }

        enLogin Mode;
        public clsLogin()
        {
            UserName = "";
            Password = "";
            Mode = enLogin.enAddNew;
        }

        public clsLogin(string username , string password)
        {
            UserName = username;
            Password = password;
            Mode = enLogin.enUpdate;
        }

        public static clsLogin Find(string userName,string password)
        {
            if (clsLoginData.GetLogin(ref userName,ref password))
                return new clsLogin(userName,password);

            return null;
        }

        private int _AddLoginUser()
        {
            return clsLoginData.AddLoginUser(this.UserName,this.Password);
        }

        private bool _UpdateLoginPassword()
        {
            return clsLoginData.UpdateLoginPassword(this.UserName, this.Password);
        }

        public bool Save()
        {
            if (Mode == enLogin.enAddNew)
            {
                this.ID = _AddLoginUser();
                if (this.ID != 0)
                    return true;
            }
            else if (Mode == enLogin.enUpdate)
            {
                if (_UpdateLoginPassword())
                    return true;
            }
            return false;
        }

        public static bool DeleteLoginUser(string user)
        {
            return clsLoginData.DeleteLoginUser(user);
        }
    }
}
