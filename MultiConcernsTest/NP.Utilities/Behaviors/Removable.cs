using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Utilities.Behaviors
{
    public class Removable : IRemovable
    {
        public event Action<IRemovable> RemoveEvent;

        public void Remove()
        {
            RemoveEvent?.Invoke(this);
        }
    }
}
