
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmLibrary
{
    [Serializable]
    public class BindableCollection<T> : ObservableCollection<T>, ITypedList
    {
        string ITypedList.GetListName(PropertyDescriptor[] listAccesories) { return null; }

        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return TypeDescriptor.GetProperties(typeof(T), PropertyFilter);
        }

        static readonly Attribute[] PropertyFilter = { BrowsableAttribute.Yes };
    }
}