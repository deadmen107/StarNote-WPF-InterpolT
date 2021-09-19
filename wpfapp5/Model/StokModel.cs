using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using StarNote.Model;
using StarNote.Command;

namespace StarNote.Model
{
    public class StokModel : BaseModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        private string stokkod;
        public string Stokkod
        {
            get { return stokkod; }
            set { stokkod = value; RaisePropertyChanged("Stokkod"); }
        }

        private string stokadı;
        public string Stokadı
        {
            get { return stokadı; }
            set { stokadı = value; RaisePropertyChanged("Stokadı"); }
        }
        
        private int miktar;
        public int Miktar
        {
            get { return miktar; }
            set { miktar = value; RaisePropertyChanged("Miktar"); }
        }

        private string birim;
        public string Birim
        {
            get { return birim; }
            set { birim = value; RaisePropertyChanged("Birim"); }
        }

        private double alışfiyat;
        public double Alışfiyat
        {
            get { return alışfiyat; }
            set { alışfiyat = value; RaisePropertyChanged("Alışfiyat"); }
        }


        private double satışfiyat;
        public double Satışfiyat
        {
            get { return satışfiyat; }
            set { satışfiyat = value; RaisePropertyChanged("Satışfiyat"); }
        }

        private string kdv;
        public string Kdv
        {
            get { return kdv; }
            set { kdv = value; RaisePropertyChanged("Kdv"); }
        }


        private double iskonto;
        public double İskonto
        {
            get { return iskonto; }
            set { iskonto = value; RaisePropertyChanged("İskonto"); }
        }

     

    }
}
