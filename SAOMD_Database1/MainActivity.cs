using Android.App;
using Android.Widget;
using Android.OS;
using Android.Database;
using Android.Media;
using System.Threading;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Views;
using System;

namespace SAOMD_Database1
{
    [Activity(Label = "SAOMD DB")]
    public class MainActivity : Activity
    {
        ListView listView;
        SAODatabase vdb;
        ICursor cursor;
        MediaPlayer _player;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "SAOMD Database";

            _player = MediaPlayer.Create(this, Resource.Raw.music);
            listView = FindViewById<ListView>(Resource.Id.List);

            Thread thread = new Thread(() =>
            {
                _player.Start();
            });
            thread.Start();

            // create the cursor
            vdb = new SAODatabase(this);
            cursor = vdb.ReadableDatabase.RawQuery("SELECT * FROM SAOProfile", null);
            StartManagingCursor(cursor);

            // create the CursorAdapter
            listView.Adapter = (IListAdapter)new StatsAdapter(this, cursor, false);

            listView.ItemClick += OnListItemClick;
            //listView.IsPullToRefreshEnabled = true;

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.topmenus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            StartActivity(typeof(AddItem));
            //Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
              //  ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }

        protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var obj = listView.Adapter.GetItem(e.Position);
            var curs = (ICursor)obj;
            var text = "Rarity: " + curs.GetString(2) + " Weapon Type: " + curs.GetString(3) + " Skill 1: " + curs.GetString(4) + " Skill 2: " + curs.GetString(5) + " Skill 3: " + curs.GetString(6); // 'name' is column 1
            Android.Widget.Toast.MakeText(this, text, Android.Widget.ToastLength.Short).Show();
            System.Console.WriteLine("Clicked on " + text);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnDestroy()
        {
            StopManagingCursor(cursor);
            cursor.Close();
            _player.Stop();
            base.OnDestroy();
        }
    }
}

