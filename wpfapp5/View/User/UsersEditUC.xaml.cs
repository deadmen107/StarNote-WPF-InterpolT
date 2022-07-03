using DevExpress.Xpf.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarNote.View.User
{
    /// <summary>
    /// Interaction logic for UsersEditUC.xaml
    /// </summary>
    public partial class UsersEditUC : UserControl
    {
        public UsersEditUC()
        {
            InitializeComponent();
        }

        private void clearcheckedits()
        {
            CheckEdit[] checkEdits = new CheckEdit[]
            {
                cmb_1, cmb_2, cmb_3, cmb_4, cmb_5, cmb_6, cmb_7, cmb_8, cmb_9, cmb_10, cmb_11, cmb_12,
                cmb_13, cmb_14, cmb_15, cmb_16, cmb_17, cmb_18, cmb_19, cmb_20, cmb_21, cmb_22, cmb_23,
                cmb_24, cmb_25,cmb_26,cmb_27,cmb_28,cmb_29,cmb_30,cmb_31,cmb_32,cmb_33,cmb_34,cmb_35,cmb_36,cmb_37
                ,cmb_38,cmb_39,cmb_40,cmb_41,cmb_42,cmb_43,cmb_44,cmb_45,cmb_46,cmb_47,cmb_48,cmb_49,cmb_50,cmb_51,cmb_52
                ,cmb_53,cmb_54,cmb_55,cmb_56,cmb_57,cmb_58,cmb_59,cmb_60,cmb_61,cmb_62,cmb_63,cmb_64,cmb_65,cmb_66,cmb_67,cmb_68,cmb_69
            };
            foreach (var checkedit in checkEdits)
            {
                checkedit.IsChecked = false;
            }

        }

        private void parseyetki()
        {
            CheckEdit[] checkEdits = new CheckEdit[]
              {
                 cmb_1, cmb_2, cmb_3, cmb_4, cmb_5, cmb_6, cmb_7, cmb_8, cmb_9, cmb_10, cmb_11, cmb_12,
                cmb_13, cmb_14, cmb_15, cmb_16, cmb_17, cmb_18, cmb_19, cmb_20, cmb_21, cmb_22, cmb_23,
                cmb_24, cmb_25,cmb_26,cmb_27,cmb_28,cmb_29,cmb_30,cmb_31,cmb_32,cmb_33,cmb_34,cmb_35,cmb_36,cmb_37
                ,cmb_38,cmb_39,cmb_40,cmb_41,cmb_42,cmb_43,cmb_44,cmb_45,cmb_46,cmb_47,cmb_48,cmb_49,cmb_50,cmb_51,cmb_52
                ,cmb_53,cmb_54,cmb_55,cmb_56,cmb_57,cmb_58,cmb_59,cmb_60,cmb_61,cmb_62
              };
            //string Yetkitext = grdmain.GetFocusedRowCellDisplayText("Yetki");
            string Yetkitext = "";
            foreach (var item in checkEdits)
            {
                item.IsChecked = false;
            }
            if (Yetkitext != "" || Yetkitext != string.Empty)
            {
                if (Yetkitext == "All")
                {
                    foreach (var item in checkEdits)
                    {
                        item.IsChecked = true;
                    }
                }
                else
                {
                    string[] yetkiler = Yetkitext.Split(',');
                    foreach (var checkboxes in checkEdits)
                    {
                        foreach (var yetki in yetkiler)
                        {
                            if (yetki == checkboxes.NullText.Replace('ı', 'i') || yetki == checkboxes.NullText.Replace('I', 'İ'))
                            {
                                checkboxes.IsChecked = true;
                            }
                        }
                    }
                }
            }
        }

        private void Cmb_yetki_Checked(object sender, RoutedEventArgs e)
        {
            int yetkicheckedcount = 0;
            string Yetkitext = "";
            //UserUtils.Authority = new List<string>();
            CheckEdit[] checkEdits = new CheckEdit[]
            {
                cmb_1, cmb_2, cmb_3, cmb_4, cmb_5, cmb_6, cmb_7, cmb_8, cmb_9, cmb_10, cmb_11, cmb_12,
                cmb_13, cmb_14, cmb_15, cmb_16, cmb_17, cmb_18, cmb_19, cmb_20, cmb_21, cmb_22, cmb_23,
                cmb_24, cmb_25,cmb_26,cmb_27,cmb_28,cmb_29,cmb_30,cmb_31,cmb_32,cmb_33,cmb_34,cmb_35,cmb_36,cmb_37
                ,cmb_38,cmb_39,cmb_40,cmb_41,cmb_42,cmb_43,cmb_44,cmb_45,cmb_46,cmb_47,cmb_48,cmb_49,cmb_50,cmb_51,cmb_52
                ,cmb_53,cmb_54,cmb_55,cmb_56,cmb_57,cmb_58,cmb_59,cmb_60,cmb_61,cmb_62,cmb_63,cmb_64,cmb_65,cmb_66,cmb_67,cmb_68,cmb_69
            };
            for (int i = 0; i < checkEdits.Length; i++)
            {
                if (checkEdits[i].IsChecked == true)
                {
                    yetkicheckedcount++;
                    if (Yetkitext == string.Empty)
                        Yetkitext = checkEdits[i].NullText;
                    else
                        Yetkitext = Yetkitext + "," + checkEdits[i].NullText;
                    //UserUtils.Authority.Add(checkEdits[i].NullText);
                }
            }
            if (yetkicheckedcount == checkEdits.Length)
            {
                Yetkitext = "All";
            }
            //usersVM.Currentdata.Yetki = Yetkitext;
        }

     

        private void Buttonallauthory_Click(object sender, RoutedEventArgs e)
        {
            CheckEdit[] checkEdits = new CheckEdit[]
             {
                cmb_1, cmb_2, cmb_3, cmb_4, cmb_5, cmb_6, cmb_7, cmb_8, cmb_9, cmb_10, cmb_11, cmb_12,
                cmb_13, cmb_14, cmb_15, cmb_16, cmb_17, cmb_18, cmb_19, cmb_20, cmb_21, cmb_22, cmb_23,
                cmb_24, cmb_25,cmb_26,cmb_27,cmb_28,cmb_29,cmb_30,cmb_31,cmb_32,cmb_33,cmb_34,cmb_35,cmb_36,cmb_37
                ,cmb_38,cmb_39,cmb_40,cmb_41,cmb_42,cmb_43,cmb_44,cmb_45,cmb_46,cmb_47,cmb_48,cmb_49,cmb_50,cmb_51,cmb_52
                ,cmb_53,cmb_54,cmb_55,cmb_56,cmb_57,cmb_58,cmb_59,cmb_60,cmb_61,cmb_62,cmb_63,cmb_64,cmb_65,cmb_66,cmb_67,cmb_68,cmb_69
             };
            foreach (var checkedit in checkEdits)
            {
                checkedit.IsChecked = true;
            }
        }
    }
}
