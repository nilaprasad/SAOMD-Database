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
using Android.Database.Sqlite;

namespace SAOMD_Database1
{
    class SAODatabase : SQLiteOpenHelper
    {
        public static readonly string create_table_sql =
           "CREATE TABLE [SAOProfile] ([_id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, [charname] TEXT NOT NULL UNIQUE, [rarity] TEXT NOT NULL, [weaptype] TEXT NOT NULL, [skill1] TEXT NOT NULL, [skill2] TEXT, [skill3] TEXT)";
        public static readonly new string DatabaseName = "SAOProfile.db";
        public static readonly int DatabaseVersion = 1;
        public SAODatabase(Context context) : base(context, DatabaseName, null, DatabaseVersion) { }
        public override void OnCreate(SQLiteDatabase db)
        {
            //db.ExecSQL(delete_table_sql);
            db.ExecSQL(create_table_sql);
            // seed with data
            db.ExecSQL("INSERT INTO SAOProfile (charname, rarity, weaptype, skill1, skill2, skill3) VALUES ('Kirito [Hero''s Return]', '4', 'Sword', 'Vorpal Strike', 'Horizontal Square', 'Augmented Kinetic')");
            db.ExecSQL("INSERT INTO SAOProfile (charname, rarity, weaptype, skill1, skill2, skill3) VALUES ('Asuna [Heart of Comfort]', '4', 'Rapier', 'Shooting Star', 'Quadruple Pain', 'Mother''s Rosario')");
            db.ExecSQL("INSERT INTO SAOProfile (charname, rarity, weaptype, skill1, skill2, skill3) VALUES ('Silica [Augmented Tamer]', '4', 'Dagger', 'Swift Trick', 'Fading Edge', 'Dragonic Stream')");
            db.ExecSQL("INSERT INTO SAOProfile (charname, rarity, weaptype, skill1, skill2, skill3) VALUES ('Lisbeth [Efficient Smith]', '4', 'Mace', 'Collision', 'Blast Swing', 'Augmented Smash')");
            db.ExecSQL("INSERT INTO SAOProfile (charname, rarity, weaptype, skill1, skill2, skill3) VALUES ('Sinon [Progressive Gunner]', '4', 'Gun', 'Quick Draw', 'Laser Rifle', 'Extended Spark')");
        }
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {   // not 
            throw new NotImplementedException();
        }
    }
}