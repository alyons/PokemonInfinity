using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEEditor
{
    public class ObservableList<T> : List<T>
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ObservableList() { }

        public new void Add(T value)
        {
            base.Add(value);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
        }

        public new void Remove(T value)
        {
            base.Remove(value);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, value));
        }

        #region INotifyCollectionChanged
        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (this.CollectionChanged != null)
                this.CollectionChanged(this, args);
        }
        #endregion
    }
}
