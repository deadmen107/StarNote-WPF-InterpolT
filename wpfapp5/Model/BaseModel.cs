using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Linq.Expressions;

namespace StarNote.Model
{
    public class BaseModel : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void RaisePropertyChanged(string property)
        //{
        //    if (PropertyChanged != null)
        //    {            
        //        PropertyChanged(this, new PropertyChangedEventArgs(property));
        //    }
        //}
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (propertyName=="Kelimesayı")
            {

            }

            var ev = PropertyChanged;
            if (ev != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="expr">Lambda expression that identifies the updated property</param>
        public void RaisePropertyChanged<TProp>(Expression<Func<JobOrderModel, TProp>> expr)
        {
            var prop = (MemberExpression)expr.Body;
            RaisePropertyChanged(prop.Member.Name);
        }
    }
}
