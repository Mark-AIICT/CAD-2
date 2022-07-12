using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace CollectionViewsSimple
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public ObservableTownsCollection TownsObservable
        {
            get
            {
                return new ObservableTownsCollection();

            }
        }
    }

   
}
