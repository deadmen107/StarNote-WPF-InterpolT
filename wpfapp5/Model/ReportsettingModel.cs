using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.Model
{
    public class ReportsettingModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string concurrencyStamp;
        public string ConcurrencyStamp
        {
            get { return concurrencyStamp; }
            set { concurrencyStamp = value; RaisePropertyChanged("ConcurrencyStamp"); }
        }

        private string reportname;
        public string Reportname
        {
            get { return reportname; }
            set { reportname = value; RaisePropertyChanged("Reportname"); }
        }

        private int reportid;
        public int Reportid
        {
            get { return reportid; }
            set { reportid = value; RaisePropertyChanged("Reportid"); }
        }

        private int reporttype;
        public int Reporttype
        {
            get { return reporttype; }
            set { reporttype = value; RaisePropertyChanged("Reporttype"); }
        }

        private string reporttypename;
        public string Reporttypename
        {
            get { return reporttypename; }
            set { reporttypename = value; RaisePropertyChanged("Reporttypename"); }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; RaisePropertyChanged("IsActive"); }
        }

        private DateTime? lastsendtime;
        public DateTime? Lastsendtime
        {
            get { return lastsendtime; }
            set { lastsendtime = value; RaisePropertyChanged("Lastsendtime"); }
        }

        private DateTime? createtime;
        public DateTime? Createtime
        {
            get { return createtime; }
            set { createtime = value; RaisePropertyChanged("Createtime"); }
        }

        private DateTime? updatetime;
        public DateTime? Updatetime
        {
            get { return updatetime; }
            set { updatetime = value; RaisePropertyChanged("Updatetime"); }
        }

        private DateTime? deletetime;

        public DateTime? Deletetime
        {
            get { return deletetime; }
            set { deletetime = value; RaisePropertyChanged("Deletetime"); }
        }

        private string createdUser;
        public string CreatedUser
        {
            get { return createdUser; }
            set { createdUser = value; RaisePropertyChanged("CreatedUser"); }
        }

        private string updatedUser;

        public string UpdatedUser
        {
            get { return updatedUser; }
            set { updatedUser = value; RaisePropertyChanged("UpdatedUser"); }
        }

        private string deleteUser;

        public string DeleteUser
        {
            get { return deleteUser; }
            set { deleteUser = value; RaisePropertyChanged("DeleteUser"); }
        }

        private string mailusers;

        public string Mailusers
        {
            get { return mailusers; }
            set { mailusers = value; RaisePropertyChanged("Mailusers"); }
        }

    }
}
