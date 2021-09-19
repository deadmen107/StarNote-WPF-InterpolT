using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.Model;
using StarNote.Utils;
namespace StarNote.ViewModel
{
    public class LisanceVM : BaseModel
    {
        LisanceUtils lisanceutil = new LisanceUtils();
        public LisanceVM()
        {
            loaddata();          
        }
        #region Defines
        private List<LisanceModel> lisancelist;
        public List<LisanceModel> Lisancelist
        {
            get { return lisancelist; }
            set { lisancelist = value; RaisePropertyChanged("Lisancelist"); }
        }      
        #endregion

        #region method       
        public void loaddata()
        {
            try
            {
                //Lisancelist = new List<LisanceModel>(lisanceutil.GetAll().Where(u=>u.LisansAdı==));
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Lisance Tablo dolduruldu", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Lisance Tablo doldurma Hatası", ex.Message);
            }
        }        
        #endregion
    }
}
