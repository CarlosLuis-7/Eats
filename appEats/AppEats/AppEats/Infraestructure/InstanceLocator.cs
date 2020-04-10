using System;
using System.Collections.Generic;
using System.Text;

namespace AppEats.Infraestructure
{
    using ViewModels;

    public class InstanceLocator
    {
        #region Properties
        public MainViewModel Main
        {
            get; set;
        }
        #endregion

        #region Construction
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion


    }
}
