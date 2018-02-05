﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NP.Utilities.Behaviors
{
    public interface ISelectableItem<T>
        where T : ISelectableItem<T>
    {
        bool IsSelected { get; set; }

        event Action<ISelectableItem<T>> IsSelectedChanged;

        void ToggleSelection();

        void SelectItem();
    }

    public class SelectableItem<T> : VMBase, ISelectableItem<T>, INotifyPropertyChanged
        where T : ISelectableItem<T>
    {
        bool _isSelected = false;

        [XmlIgnore]
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }

            set
            {
                if (_isSelected == value)
                    return;

                _isSelected = value;

                IsSelectedChanged?.Invoke(this);

                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public event Action<ISelectableItem<T>> IsSelectedChanged;

        public void SelectItem()
        {
            this.IsSelected = true;
        }

        public void ToggleSelection()
        {
            this.IsSelected = !this.IsSelected;
        }
    }
}
