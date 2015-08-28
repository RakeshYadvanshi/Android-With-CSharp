using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RkCall
{
	[Activity (Label = "RkCall", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		string translatedNo=string.Empty;
		Button call,Translate;
		EditText textbox;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
		 call= FindViewById<Button>(Resource.Id.Call);
		 Translate = FindViewById<Button> (Resource.Id.Translate);

		 textbox = FindViewById<EditText> (Resource.Id.phoneNoText);

			Translate.Click += new EventHandler (translate_click);
			call.Enabled = false;

			call.Click += new EventHandler (Call_click);

			

		}

		protected void Call_click(object o, EventArgs e)
		{
			var callDialog = new AlertDialog.Builder(this);

			callDialog.SetMessage("Call " + translatedNo + "?");

			callDialog.SetNeutralButton("Call", delegate {
				// Create intent to dial phone
				var callIntent = new Intent(Intent.ActionCall);
				callIntent.SetData(Android.Net.Uri.Parse("tel:" +
					translatedNo));
				StartActivity(callIntent);

			});
			callDialog.SetNegativeButton("Cancel", delegate { });
			// Show the alert dialog to the user and wait for response.
			callDialog.Show();
		}


		protected void translate_click(object obj,EventArgs e)
		{
			translatedNo = PhonewordTranslator.ToNumber (textbox.Text);
			if (string.IsNullOrWhiteSpace(translatedNo)) {
				call.Text="Call";
				call.Enabled = false;
			} else {
				call.Text = "Call " + translatedNo;
				call.Enabled = true;
				
			}
			
		}
	}
}


