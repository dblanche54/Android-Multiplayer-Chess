using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;


namespace MP_Chess
{
	[Activity (Label = "@string/callHistory")]			
	public class CallHistoryActivity : ListActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];
			this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, phoneNumbers);
		}
	}
}

