using NP.Utilities;
using NP.Utilities.Behaviors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiConcernsTest.ViewModels
{
    public class BusinessGroupVM : VMBase, IRemovable, ISelectableItem<BusinessGroupVM>
    {
        #region Data_Concern_Region
        public string Name { get; set; }

        public SingleSelectionObservableCollection<PersonVM> People { get; } =
            new SingleSelectionObservableCollection<PersonVM>();
        #endregion Data_Concern_Region


        #region Removeable_Concern_Region
        public event Action<IRemovable> RemoveEvent = null;

        public void Remove()
        {
            RemoveEvent?.Invoke(this);
        }
        #endregion Removeable_Concern_Region


        #region Selectable_Concern_Region
        public event Action<ISelectableItem<BusinessGroupVM>> IsSelectedChanged;

        bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value)
                    return;

                _isSelected = value;

                IsSelectedChanged?.Invoke(this);

                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public void ToggleSelection()
        {
            this.IsSelected = !this.IsSelected;
        }

        public void SelectItem()
        {
            this.IsSelected = true;
        }

        #endregion Selectable_Concern_Region


        ParentChildSelectionBehavior<BusinessGroupVM, PersonVM> _parentChildSelectionBehavior =
            new ParentChildSelectionBehavior<BusinessGroupVM, PersonVM>();

        RemovableCollectionBehavior _removableCollectionBehavior =
            new RemovableCollectionBehavior();

        public BusinessGroupVM()
        {
            _removableCollectionBehavior.TheCollection = this.People;

            _parentChildSelectionBehavior.Parent = this;
            _parentChildSelectionBehavior.Children = this.People;
        }
    }
}
