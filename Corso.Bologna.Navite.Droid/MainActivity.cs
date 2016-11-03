using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Corso.Bologna.Models;
using Corso.Bologna.Navite.Droid.Commons;
using Corso.Bologna.Services;
using Corso.Bologna.ViewModels;
using FFImageLoading;
using FFImageLoading.Views;

namespace Corso.Bologna.Navite.Droid
{
    [Activity(Label = "Corso.Bologna.Navite.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : DataActivity<MainViewModel>, View.IOnClickListener
    {
        private TextView _textView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ImageService.Instance.Initialize();
            SetContentView(Resource.Layout.MainView);
            _textView = FindViewById<TextView>(Resource.Id.MainView_WelcomeText);
            

            //var listViewiew = FindViewById<ListView>(Resource.Id.MainView_ListView);
            //var items = new List<string> {"marco", "andrea"};
            //listViewiew.Adapter =  new DataAdatperBase<string>(
            //    items,
            //    this, Android.Resource.Layout.SimpleListItem1, 
            //    BindViewAction);

        }

        protected override void OnStart()
        {
            base.OnStart();
            LoadData();
        }

        private async void LoadData()
        {
        //    var service = new RecipeService();
        //    var items = await service.GetRecipeAsync();

            var listViewiew = FindViewById<ListView>(Resource.Id.MainView_ListView);
            listViewiew.ItemClick += ListViewiewOnItemClick;
            listViewiew.Clickable = true;
            listViewiew.Adapter = new DataAdatperBase<Recipe>(
                ViewModel.Recipes,
                this, Resource.Layout.MainView_RecipeList_SimpleRecipeCell,
                BindViewAction);
        }

        private void ListViewiewOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            ViewModel.SelectedRecipe = ViewModel.Recipes[itemClickEventArgs.Position];
        }

        private void BindViewAction(Recipe item, View view)
        {
            var nameTextView = view.FindViewById<TextView>(Resource.Id.Name_SimpleRecipeCell);
            var imageView = view.FindViewById<ImageViewAsync>(Resource.Id.Image_SimpleRecipeCell);

            ImageService.Instance.LoadUrl(item.PicturePath).Into(imageView);
            nameTextView.Text = item.Name;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            _textView.Text = DateTime.Now.ToLongTimeString();
        }

        public void OnClick(View v)
        {
            throw new NotImplementedException();
        }
    }

    public class MyAdapter : BaseAdapter<string>
    {
        private IList<string> _items;
        private Activity _context;
        public MyAdapter(IList<string> items, Activity context)
        {
            _items = items;
            _context = context;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = (TextView)_context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.Text = _items[position];
            return view;
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override string this[int position]
        {
            get { return _items[position]; }
        }
    }
}

