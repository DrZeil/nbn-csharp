/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LearnByError.Database.Tables
{
    /// <summary>
    /// Settings table
    /// </summary>
    public class KeyValue : Table
    {
        /// <summary>
        /// Setting name
        /// </summary>
        public String Key { get; set; }

        /// <summary>
        /// setting value
        /// </summary>
        public String Value { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public KeyValue()
            : base(SQL.General.Names.KeyValueTableName)
        {
           
        }

        /// <summary>
        /// Insert action
        /// </summary>
        /// <returns>bool</returns>
        public override bool Insert()
        {
            try
            {
                
                if (Manager.countIt(String.Format(SQL.Config.Exists, TableName, Key)) == 0)
                {
                    String sql = String.Format(SQL.Config.Insert, TableName, Key, Value);
                    if (Manager.Instance.Execute(sql))
                    {
                        Id = LastInsertedId;
                        return true;
                    }
                }
                else
                {
                    String sql = String.Format(SQL.Config.Update, TableName, Value, Key);
                    return Manager.Instance.Execute(sql);
                }
                
                return false;
            }
            catch (Exception ex)
            {
                Common.Log.Write(ex);
                return false;
            }
        }

        /// <summary>
        /// Update action
        /// </summary>
        /// <returns>bool</returns>
        public override bool Update()
        {
            try
            {
                String sql = String.Format(SQL.Config.Update, TableName, Value, Key);
                return Manager.Instance.Execute(sql);
            }
            catch (Exception ex)
            {
                Common.Log.Write(ex);
                return false;
            }
        }

        /// <summary>
        /// Delete action
        /// </summary>
        /// <returns>bool</returns>
        public override bool Delete()
        {
            try
            {
                String sql = String.Format(SQL.Config.Delete, TableName, Id);
                return Manager.Instance.Execute(sql);
            }
            catch (Exception ex)
            {
                Common.Log.Write(ex);
                return false;
            }
        }

        /// <summary>
        /// Read action
        /// </summary>
        /// <returns>bool</returns>
        public override bool Read()
        {
            try
            {
                String sql = String.Format(SQL.Config.Read, TableName, Key);
                using (SQLiteConnection con = Manager.Instance.Connection)
                {
                    con.Open();                    
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                Id = rdr.GetInt32(0);
                                Key = rdr.GetString(1);
                                Value = rdr.GetString(2);                                
                            }
                        }
                    }

                    con.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                Common.Log.Write(ex);
                return false;
            }
        }

        /// <summary>
        /// Read all positions
        /// </summary>
        /// <returns>list of positions</returns>
        public static List<KeyValue> ReadAll()
        {
            List<KeyValue> configs = new List<KeyValue>();
            try
            {
                String sql = String.Format(SQL.Config.ReadAll, SQL.General.Names.KeyValueTableName);
                using (SQLiteConnection con = Manager.Instance.Connection)
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                KeyValue what = new KeyValue();
                                what.Id = rdr.GetInt32(0);
                                what.Key = rdr.GetString(1);
                                what.Value = rdr.GetString(2);
                                configs.Add(what);
                            }
                        }
                    }

                    con.Close();
                }                
            }
            catch (Exception ex)
            {
                Common.Log.Write(ex);                
            }
            return configs;
        }

        /// <summary>
        /// Check if setting exists
        /// </summary>
        /// <param name="key">String - setting name</param>
        /// <returns>bool</returns>
        public static bool Exists(String key)
        {
            try
            {
                return Manager.countIt(String.Format(SQL.Config.Exists, SQL.General.Names.KeyValueTableName, key)) == 1;
            }
            catch (Exception ex)
            {
                Common.Log.Write(ex);
                return false;
            }
        }
         
    }
}
