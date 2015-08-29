using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.Animations;
using Android.Media;

namespace Pendulum
{
	[Activity (Label = "Pendulum", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		//int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
		

			// Get our button from the layout resource,
			// and attach an event to it
			Button start = FindViewById<Button> (Resource.Id.Start);
			Button stop = FindViewById<Button> (Resource.Id.Stop);

			ImageView iv= FindViewById<ImageView>(Resource.Id.imageView1);

			stop.Click += (sender, e) => {iv.ClearAnimation();
				stop.Enabled=false;
				start.Enabled=true;
			};
			iv.SetImageResource(Resource.Drawable.left);
			start.Click+=(object sender, EventArgs e) => {
				
				Animation lAnimation= AnimationUtils.LoadAnimation(this,Resource.Animation.RotateLeft);
				//Animation rAnimation=AnimationUtils.LoadAnimation(this,Resource.Animation.RotateRight);
				//lAnimation.RepeatCount=10;
				//lAnimation.RepeatMode=RepeatMode.Reverse;
			
				start.Enabled=false;
				stop.Enabled=true;
				lAnimation.AnimationEnd+=(object s, Animation.AnimationEndEventArgs ep) => {


					//iv.StartAnimation(lAnimation);

					//iv.StartAnimation(rAnimation);

					//iv.SetImageResource(Resource.Drawable.right);

				};



				//rAnimation.AnimationEnd+=(object s, Animation.AnimationEndEventArgs ep) => {
				//	iv.StartAnimation(lAnimation);
					//iv.SetImageResource(Resource.Drawable.left);


				//};

				iv.StartAnimation(lAnimation);
				
			};
			

		}
	}
}


