﻿using Android.OS;
using Android.Views;
using Android.Support.V4.App;
namespace Navigation
{
	public class Internet : Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.Internet, container, false);

			return view;
		}
	}
}
