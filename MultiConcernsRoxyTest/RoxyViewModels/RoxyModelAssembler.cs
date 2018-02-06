using NP.Roxy;
using NP.Roxy.TypeConfigImpl;
using NP.Utilities;
using NP.Utilities.Behaviors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiConcernsRoxyTest.RoxyViewModels
{
    // represents item that is selectable and removable
    public interface ISelectableRemovableItem<T> : 
        ISelectableItem<T>, 
        IRemovable, 
        INotifyPropertyChanged
       where T : ISelectableItem<T>
    {
    }

    // Wrapper interface for implementing 
    // ISelectableRemovableItem interface
    public interface ISelectableRemovableWrapper<T>
        where T : ISelectableItem<T>
    {
        SelectableItem<T> Selectable { get; }

        Removable Removable { get; }
    }


    // represents PersonVM - 
    // the IPersonDataVM with Selectable and
    // Removable functionality
    public interface ISelectableRemovablePerson :
        IPersonDataVM, ISelectableRemovableItem<ISelectableRemovablePerson>
    {

    }


    // the wrapper for 
    // implementing ISelectableRemovablePerson
    public interface ISelectableRemovablePersonWrapper :
        ISelectableRemovableWrapper<ISelectableRemovablePerson>
    {
    }


    // represents IBusinessGroup with Selectable and
    // Removable functionality
    public interface ISelectableRemovableBusinessGroup :
        IBusinessGroup,
        ISelectableRemovableItem<ISelectableRemovableBusinessGroup>
    {

    }


    // Wrapper for the RemovableCollectionBehavior
    public interface IRemovableCollectionBehaviorWrapper
    {
        RemovableCollectionBehavior TheRemovableCollectionBehavior { get; }
    }


    // Wrapper for RemovableCollectionBehavior and 
    // ParentChildSelectionBehavior
    public interface ISelectableRemovableBusinessGroupWrapper :
        ISelectableRemovableWrapper<ISelectableRemovableBusinessGroup>,
        IRemovableCollectionBehaviorWrapper
    {
        ParentChildSelectionBehavior<ISelectableRemovableBusinessGroup, ISelectableRemovablePerson> TheParentChildSelectionBehavior { get; }
    }

    public static class RoxyModelAssembler
    {

        // assembles the functionality for PersonVM with 
        // selectable and removable capabilities
        public static void AssembleSelectableRemovablePerson()
        {
            // create type config
            ITypeConfig typeConfig =
                Core.FindOrCreateTypeConfig<ISelectableRemovablePerson, PersonDataVM, ISelectableRemovablePersonWrapper>("PersonVM");

            // set the first argument for PropertyChanged event 
            // to map into 'this'
            typeConfig.SetEventArgThisIdx(nameof(INotifyPropertyChanged.PropertyChanged), 0);

            // complete the configuration
            typeConfig.ConfigurationCompleted();
        }

        // Assembles the BusinessGroupVM functionality with 
        // Selectable and Removable implementations and also 
        // with ParentChildSelectionBehavior and RemovableCollectionBehavior.
        public static void AssembleSelectableRemovableBusinessGroup()
        {
            // get the type config object
            ITypeConfig typeConfig =
                Core.FindOrCreateTypeConfig<ISelectableRemovableBusinessGroup, ISelectableRemovableBusinessGroupWrapper>("BusinessGroupVM");

            // Adds the initialization of People collection to
            // an empty SingleSelectionObservableCollection collection within the constructor
            typeConfig.SetInit<SingleSelectionObservableCollection<ISelectableRemovablePerson>>(nameof(IBusinessGroup.People));

            // set the first argument for PropertyChanged event 
            // to map into 'this'
            typeConfig.SetEventArgThisIdx(nameof(INotifyPropertyChanged.PropertyChanged), 0);

            // maps Parent property of wrapped ParentChildSelectionBehavior
            // into 'this' field of the generated type. 
            typeConfig.SetThisMemberMap
            (
                nameof(ISelectableRemovableBusinessGroupWrapper.TheParentChildSelectionBehavior),
                nameof(ParentChildSelectionBehavior<ISelectableRemovableBusinessGroup, ISelectableRemovablePerson>.Parent)
            );

            // maps Children property of wrapped ParentChildCollectionBehavior
            // into People property of the generated type. 
            typeConfig.SetMemberMap
            (
                nameof(ISelectableRemovableBusinessGroupWrapper.TheParentChildSelectionBehavior),
                nameof(ParentChildSelectionBehavior<ISelectableRemovableBusinessGroup, ISelectableRemovablePerson>.Children),
                nameof(IBusinessGroup.People)
            );


            // maps TheCollection property of wrapped RemovableCollectionBehavior
            // into People property of the generated type. 
            typeConfig.SetMemberMap
            (
                nameof(ISelectableRemovableBusinessGroupWrapper.TheRemovableCollectionBehavior),
                nameof(RemovableCollectionBehavior.TheCollection),
                nameof(IBusinessGroup.People)
            );

            // specifies that the configuration is completed.
            typeConfig.ConfigurationCompleted();
        }

        // Assembles the BusinessGroupsVM collection. 
        public static void AssembleBusinessGroupsCollection()
        {
            ITypeConfig typeConfig =
                Core.FindOrCreateTypeConfig<NoInterface, SingleSelectionObservableCollection<ISelectableRemovableBusinessGroup>, IRemovableCollectionBehaviorWrapper>("BusinessGroupsVM");

            // maps TheCollection property of RemovableCollectionBehavior
            // into 'this' of the generated object. 
            typeConfig.SetThisMemberMap
            (
                nameof(IRemovableCollectionBehaviorWrapper.TheRemovableCollectionBehavior),
                nameof(RemovableCollectionBehavior.TheCollection)
            );

            typeConfig.ConfigurationCompleted();
        }
    }
}
