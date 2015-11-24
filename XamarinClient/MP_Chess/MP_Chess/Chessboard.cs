
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

namespace MP_Chess
{
	[Activity (Label = "Chessboard")]			
	public class Chessboard: Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Chessboard);

			var gridview = FindViewById<GridView> (Resource.Id.chessboard);
			gridview.Adapter = new ImageAdapter (this);

			gridview.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
				Toast.MakeText (this, args.Position.ToString (), ToastLength.Short).Show ();
			};
			// Create your application here
		}
	}
}

