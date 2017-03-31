using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmLibrary {
    public class HyperBindableCollection<T> : BindableCollection<T> where T : INotifyPropertyChanged {
        public HyperBindableCollection () {
            CollectionChanged += HyperBindableCollection_CollectionChanged;
        }

        public HyperBindableCollection(IEnumerable<T> items) : this() {
            foreach(var item in items) {
                Add(item);
            }
        }

        private void HyperBindableCollection_CollectionChanged ( object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e ) {
            if(e.NewItems != null) {
                foreach(var i in e.NewItems) {

                    ((INotifyPropertyChanged)i).PropertyChanged += ItemPropertyChanged;
                }
            }
            if(e.OldItems != null) {
                foreach(var i in e.OldItems) {
                    ((INotifyPropertyChanged)i).PropertyChanged += ItemPropertyChanged;
                }
            }
        }

        private void ItemPropertyChanged ( object sender, PropertyChangedEventArgs e ) {
            var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender, IndexOf((T)sender));
            OnCollectionChanged(args);
        }
    }
}
