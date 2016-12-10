using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;

namespace Navigation
{
	[Activity(Label = "Technitab", Icon = "@mipmap/icon", Theme = "@style/Theme.DesignDemo")]
	public class MainActivity : AppCompatActivity
	{
		private DrawerLayout mDrawerLayout;
		TabLayout tabs;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
			SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
			SetSupportActionBar(toolBar);
			SupportActionBar ab = SupportActionBar;
			ab.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
			ab.SetDisplayHomeAsUpEnabled(true);
			mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

			//SupportFragmentManager.BeginTransaction().Replace(Resource.Id.viewpager,new Technology()) .Commit();
			if (navigationView != null)
			{
				SetUpDrawerContent(navigationView);
			}

			//slider
			tabs = FindViewById<TabLayout>(Resource.Id.tabs);

			ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);

			SetUpViewPager(viewPager);

			tabs.SetupWithViewPager(viewPager);
		}
		private void SetUpViewPager(ViewPager viewPager)
		{
			TabAdapter adapter = new TabAdapter(SupportFragmentManager);
			adapter.AddFragment(new Technology(), "TECHNOLOGY");
			adapter.AddFragment(new Startup(), "STARTUP");
			adapter.AddFragment(new Services(), "SERVICES");

			viewPager.Adapter = adapter;
		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{

			switch (item.ItemId)
			{

				case Android.Resource.Id.Home:
					mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
					return true;


				default:

					return base.OnOptionsItemSelected(item);
			}

		}

		private void SetUpDrawerContent(NavigationView navigationView)
		{
			navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
			{
				//e.MenuItem.SetChecked(true);
				//mDrawerLayout.CloseDrawers();
				SupportFragment fragment = null;
				switch (e.MenuItem.ItemId)
				{
					case Resource.Id.gadgets:
						fragment = new Gadgets();
						break;
					case Resource.Id.internet:
						fragment = new Internet();
						break;
					case Resource.Id.iotsmart:
						fragment = new Iotsmart();
						break;
					case Resource.Id.mobile:
						fragment = new Mobile();
						break;
					case Resource.Id.buzz:
						fragment = new Buzz();
						break;
					case Resource.Id.softwareapps:
						fragment = new Softwareapps();
						break;
					case Resource.Id.startup:
						fragment = new Startup();
						break;
					case Resource.Id.startupbuzz:
						fragment = new Startupbuzz();
						break;
					case Resource.Id.startupblog:
						fragment = new Startupblog();
						break;
					case Resource.Id.services:
						fragment = new Services();
						break;

				}

				SupportFragmentManager.BeginTransaction()
									  .Replace(Resource.Id.content_frame, fragment).AddToBackStack(null)
				   .Commit();

				//this.drawerListView.SetItemChecked(position, true);
				//SupportActionBar.Title = this.title = Sections[position];
				e.MenuItem.SetChecked(true);
				mDrawerLayout.CloseDrawers();
				tabs.Visibility = ViewStates.Gone;
			};
		}

		public override void OnBackPressed()
		{
			base.OnBackPressed();
			tabs.Visibility = ViewStates.Visible;
		}
		public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.sample_actions, menu);
			return true;
		}

	}
}

