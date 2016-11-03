using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Android.App;
using Android.Views;
using Android.Widget;

namespace Corso.Bologna.Navite.Droid.Commons
{
    public class DataAdatperBase<T> : BaseAdapter<T>
    {
        private IList<T> _items;
        private Activity _activity;
        private int _viewID;
        private Action<T, View> _bindAction;
        public DataAdatperBase(IList<T> items, Activity activity, int viewID, Action<T,View> bindAction  )
        {
            _items = items;
            INotifyCollectionChanged iNotifyCollectionChanged = _items as INotifyCollectionChanged;
            if (iNotifyCollectionChanged != null)
            {
                iNotifyCollectionChanged.CollectionChanged += INotifyCollectionChangedOnCollectionChanged;
            }
            _activity = activity;
            _viewID = viewID;
            _bindAction = bindAction;
        }

        private void INotifyCollectionChangedOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            this.NotifyDataSetChanged();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = _activity.LayoutInflater.Inflate(_viewID, null);
            _bindAction(_items[position], view);
            return view;
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override T this[int position]
        {
            get { return _items[position]; }
        }
    }
}