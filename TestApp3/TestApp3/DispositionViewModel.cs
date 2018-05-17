using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestApp3
{
    class DispositionViewModel : INotifyPropertyChanged
    {
        AlertType typeOfAlert;

        public AlertType TypeOfAlert
        {
            get
            {
                return typeOfAlert;
            }
            set
            {
                if (typeOfAlert != value)
                {
                    typeOfAlert = value;
                    OnPropertyChanged("TypeOfAlert");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
