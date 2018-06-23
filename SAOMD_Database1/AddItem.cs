using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database.Sqlite;

namespace SAOMD_Database1
{
    [Activity(Label = "SAOMD DB")]
    public class AddItem : Activity
    {
        public event EventHandler DataOK;
        protected virtual void OnDataOK(EventArgs e)
        {
            EventHandler handler = DataOK;
            if (handler != null)
            {
                var editCharName = FindViewById<EditText>(Resource.Id.editCharName);
                var charnameView = FindViewById<TextView>(Resource.Id.charnameView);

                var editRarity = FindViewById<EditText>(Resource.Id.editRarity);
                var rarityView = FindViewById<TextView>(Resource.Id.rarityView);

                var editWeapType = FindViewById<EditText>(Resource.Id.editWeaponType);
                var weapontypeView = FindViewById<TextView>(Resource.Id.weapontypeView);

                var editSkill1 = FindViewById<EditText>(Resource.Id.editSkill1);
                var skill1View = FindViewById<TextView>(Resource.Id.skill1View);

                var editSkill2 = FindViewById<EditText>(Resource.Id.editSkill2);
                var skill2View = FindViewById<TextView>(Resource.Id.skill2View);

                var editSkill3 = FindViewById<EditText>(Resource.Id.editSkill3);
                var skill3View = FindViewById<TextView>(Resource.Id.skill3View);
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetTheme(Resource.Style.MyTheme);
            SetContentView(Resource.Layout.AddItem);

            this.OnDataOK(new EventArgs());

            /* var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
             SetActionBar(toolbar);
             ActionBar.Title = "SAOMD Database"; */

            //var editCharName = FindViewById<EditText>(Resource.Id.editCharName);
            //var charnameView = FindViewById<TextView>(Resource.Id.charnameView);

            //var editRarity = FindViewById<EditText>(Resource.Id.editRarity);
            //var rarityView = FindViewById<TextView>(Resource.Id.rarityView);

            //var editWeapType = FindViewById<EditText>(Resource.Id.editWeaponType);
            //var weapontypeView = FindViewById<TextView>(Resource.Id.weapontypeView);

            //var editSkill1 = FindViewById<EditText>(Resource.Id.editSkill1);
            //var skill1View = FindViewById<TextView>(Resource.Id.skill1View);

            //var editSkill2 = FindViewById<EditText>(Resource.Id.editSkill2);
            //var skill2View = FindViewById<TextView>(Resource.Id.skill2View);

            //var editSkill3 = FindViewById<EditText>(Resource.Id.editSkill3);
            //var skill3View = FindViewById<TextView>(Resource.Id.skill3View);

            Button btnclick = FindViewById<Button>(Resource.Id.btnAdd);

            btnclick.Click += delegate
            {
                SAODatabase vdb;
                vdb = new SAODatabase(this);
                SQLiteDatabase conn = null;
                conn = (SQLiteDatabase)vdb.ReadableDatabase.RawQuery("INSERT INTO SAOProfile (charname, rarity, weaptype, skill1, skill2, skill3) VALUES ('editCharName', 'editRarity', 'editWeaponType', 'editSkill1', editSkill2', 'editSkill3')", null);
                //conn.ExecSQL("INSERT INTO SAOProfile (charname, rarity, weaptype, skill1, skill2, skill3) VALUES ('editCharName', 'editRarity', 'editWeaponType', 'editSkill1', editSkill2', 'editSkill3')");
            };
        }
    }
}