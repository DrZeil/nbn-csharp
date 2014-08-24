/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;

namespace LearnByError.Database
{
    /// <summary>
    /// SQL queries and so on
    /// </summary>
    public static class SQL
    {
        public static class General
        {
            public static String SqlInit = "select * from sqlite_master";
            public static String Vacuum = "VACUUM";
            public static String CountAllFromTable = @"select count(*) from [{0}];";
            public static String DeleteAllFromTable = @"delete from [{0}];";
            public static class Names
            {
                public static String LogTableName = "logs";
                public static String KeyValueTableName = "config";
                public static String PatchTableName = "patches";
                public static String HistoryTableName = "history";
            }
            public static String LastInsert = @"select seq from sqlite_sequence where name = '{0}'";
        }

        public static class Patch
        {
            public static String Insert = "INSERT INTO {0}(patch_number, description) VALUES ({1}, \"{2}\")";
            public static String Count = "SELECT count(*) FROM patches WHERE patch_number={0}";
        }

        public static class DatabasePatch
        {
            public static String Create = "CREATE TABLE IF NOT EXISTS patches (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, patch_number INTEGER, description TEXT)";
        }

        public static class Table
        {
            public static String Logs = @"
                                        CREATE  TABLE  IF NOT EXISTS 'main'.'logs' (
                                        'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL , 
                                        'message' TEXT NOT NULL , 
                                        'stacktrace' TEXT NOT NULL  DEFAULT brak, 
                                        'when' DATETIME NOT NULL )";

            public static String History = @"CREATE  TABLE  IF NOT EXISTS 'main'.'history' (
                                            'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL , 
                                            'name' TEXT NOT NULL , 
                                            'data' TEXT NOT NULL )";

            public static String Config = @"CREATE  TABLE  IF NOT EXISTS 'main'.'config' (
                                            'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
                                            'key' TEXT NOT NULL  UNIQUE , 
                                            'value' TEXT NOT NULL )";
        }
        public static class Config
        {
            public static String Insert = @"insert into [{0}](key, value) values('{1}', '{2}');";
            public static String Update = @"update [{0}] set [value] = '{1}' where [key] = '{2}';";
            public static String Read = @"select [id], [key], [value] from [{0}] where [key] = '{1}';";
            public static String ReadAll = @"select [id], [key], [value] from [{0}];";
            public static String Delete = @"delete from [{0}] where [id] = {1};";
            public static String Exists = @"select count(*) from [{0}] where [key] = '{1}';";
        }

        public static class Log
        {
            public static String Insert = @"insert into [{0}]('message', 'stacktrace', 'when') values('{1}', '{2}', '{3}');";
            public static String Update = @"update [{0}] set [message] = '{1}', [stacktrace] = '{2}', [when] = '{3}' where [id] = {4};";
            public static String Read = @"select [id], [message], [stacktrace], [when] from [{0}] where [id] = {1};";
            public static String ReadAll = @"select [id], [message], [stacktrace], [when] from [{0}];";
            public static String Delete = @"delete from [{0}] where [id] = {1};";            
        }

        public static class History
        {
            public static String Insert = @"insert into [{0}]('name','data') values('{1}', '{2}');";
            public static String Update = @"update [{0}] set name = '{1}', data = '{2}' where [id] = {3};";
            public static String Read = @"select [id], [name], [data] from [{0}] where [id] = {1};";
            public static String ReadAll = @"select [id], [name], [data] from [{0}];";
            public static String Delete = @"delete from [{0}] where [id] = {1};";

            
        }
    }
}
