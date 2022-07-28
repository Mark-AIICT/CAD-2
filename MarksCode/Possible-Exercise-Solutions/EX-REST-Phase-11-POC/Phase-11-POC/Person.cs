using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase_11_POC
{
    static class PersonEventArgsClass
    {
        internal static PropertyChangedEventArgs personChanged = new PropertyChangedEventArgs("PersonChanged");
    }

    class Person : INotifyPropertyChanged
    {
 

        private string _firstName;
        private string _lastName;
 

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(PersonEventArgsClass.personChanged);
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(PersonEventArgsClass.personChanged);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs eventargs)
        {
            PropertyChanged?.Invoke(this, eventargs);
        }

    }
}
