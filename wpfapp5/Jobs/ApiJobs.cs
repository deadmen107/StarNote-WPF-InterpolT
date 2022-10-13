using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.Utils;
using StarNote.Model;
using StarNote.ViewModel;
using StarNote.Service;
using StarNote.DataAccess;

namespace StarNote.Jobs
{
    class ApiJobs : IJob
    {
       

        public async Task Execute(IJobExecutionContext context)
        {
            LogVM.Addlog("IJOBS", System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "TOKEN BAŞLADI", "");            
            TokenModel tk = new TokenModel();      
            tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            WebapiUtils.access_token = tk.access_token;
            WebapiUtils.expires_in = tk.expires_in;
            WebapiUtils.token_type = tk.token_type;
            LogVM.Addlog("IJOBS", System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "TOKEN TAMAMLANDI", "");
            BaseDa dataaccess = new BaseDa();
            try
            {
                GlobalStore.Maindataorder = dataaccess.DoGet(GlobalStore.Maindataorder, "MainScreen", "GetMainAll");
                GlobalStore.MaindataCostumer = dataaccess.DoGet(GlobalStore.MaindataCostumer, "MainScreen", "GetCostumerOrders");
                GlobalStore.MaindataJoborder = dataaccess.DoGet(GlobalStore.MaindataJoborder, "MainScreen", "GetJobOrders");
            }
            catch (Exception ex)
            {

                LogVM.Addlog("IJOBS", System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Global Kayıtlar Çekilemedi", ex.Message);
            }
           
            if (RefreshViews.appstatus)
            {
                LogVM.Addlog("IJOBS", System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "HATIRLATMA KONTROL BAŞLADI", "");
                RemindingVM remindingVM = new RemindingVM();
                remindingVM.Remindingcontrol();
                LogVM.Addlog("IJOBS", System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "HATIRLATMA KONTROL TAMAMLANDI", "");
            }


            if (RefreshViews.appstatus)
            {
                LogVM.Addlog("IJOBS", System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "RAPOR KONTROL BAŞLADI", "");
                ReportCheck reportCheck = new ReportCheck();
                reportCheck.CreateReport();
                LogVM.Addlog("IJOBS", System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "RAPOR KONTROL TAMAMLANDI", "");

            }
        }
    }
}
