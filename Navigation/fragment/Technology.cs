using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using Fragment = Android.Support.V4.App.Fragment;
using System.Collections.Generic;
using Java.Lang;
using Android.Runtime;

namespace Navigation
{
	public class Technology : Fragment
	{
		
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.Technology, container, false);

			return view;
		}
	

	}
	public class TabAdapter : FragmentPagerAdapter
	{
		public List<SupportFragment> Fragments { get; set; }
		public List<string> FragmentNames { get; set; }

		public TabAdapter(SupportFragmentManager sfm) : base(sfm)
		{
			Fragments = new List<SupportFragment>();
			FragmentNames = new List<string>();
		}

		public void AddFragment(SupportFragment fragment, string name)
		{
			Fragments.Add(fragment);
			FragmentNames.Add(name);
		}

		public override int Count
		{
			get
			{
				return Fragments.Count;
			}
		}

		public override SupportFragment GetItem(int position)
		{
			return Fragments[position];
		}

		public override ICharSequence GetPageTitleFormatted(int position)
		{
			return new Java.Lang.String(FragmentNames[position]);
		}
	}
}
