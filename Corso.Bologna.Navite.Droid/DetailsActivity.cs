using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Corso.Bologna.Models;
using Corso.Bologna.Navite.Droid.Commons;
using Corso.Bologna.ViewModels;
using FFImageLoading;
using FFImageLoading.Views;

namespace Corso.Bologna.Navite.Droid
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : DataActivity<DetailsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.DeatailsView);
            // Create your application here
            var recipe = CorsoApp.NavigationService.GetAndRemoveParameter<Recipe>(this.Intent);
            ViewModel.CurrentRecipe = recipe;
            var imageView = FindViewById<ImageViewAsync>(Resource.Id.DetailsView_ImageView);
            var textView = FindViewById<TextView>(Resource.Id.DetailsView_NameView);
            textView.Text = recipe.Name;
            ImageService.Instance.LoadUrl(recipe.PicturePath).Into(imageView);

            var listViewiew = FindViewById<ListView>(Resource.Id.DetailsView_IngredientsListView);
            listViewiew.Adapter = new DataAdatperBase<Ingredient>(
                ViewModel.Ingredients,
                this, Android.Resource.Layout.SimpleListItem1,
                BindViewAction);
        }
        private void BindViewAction(Ingredient item, View view)
        {
            var ingredientView = (TextView)view;
            ingredientView.Text = item.Name;
        }
    }
}