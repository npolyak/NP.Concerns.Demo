using NP.Utilities.Behaviors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiConcernsTest.ViewModels
{
    public class BusinessGroupsVM : SingleSelectionObservableCollection<BusinessGroupVM>
    {
        RemovableCollectionBehavior _removableCollectionBehavior =
            new RemovableCollectionBehavior();

        public BusinessGroupsVM()
        {
            _removableCollectionBehavior.TheCollection = this;
        }
    }
}
