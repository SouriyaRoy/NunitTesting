using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalDependency
{
    public class EmployeeInfo : INotifyPropertyChanged
    {
        private string _FirstName;
        private string _LastName;
        private int _ID;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;

                OnPropertyChanged("FirstName");
            }


        }
        public string LastName
        {

            get { return _LastName; }

            set
            {
                _LastName = value;


            }


        }

        public int ID
        {

            get { return _ID; }

            set
            {
                _ID = value;


            }


        }


        protected void OnPropertyChanged(string pName)
        {

            if (PropertyChanged != null)
            {
                //Raising Event
                //PropertyChanged(this, new PropertyChangedEventArgs(pName));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
