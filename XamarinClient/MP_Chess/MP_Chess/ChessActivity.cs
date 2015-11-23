
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
	[Activity (Label = "ChessActivity")]			
	public class ChessActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Chess);



			// Create your application here
			Button exitButton = FindViewById<Button>(Resource.Id.ExitButton);

			//Wire up the connnect button
			exitButton.Click += (object sender, EventArgs e) =>
			{
				Intent intent = new Intent(Intent.ActionMain);
				intent.AddCategory(Intent.CategoryHome);
				intent.SetFlags(ActivityFlags.NewTask);
				StartActivity(intent);
				Finish();
			};
		}
	}
}

