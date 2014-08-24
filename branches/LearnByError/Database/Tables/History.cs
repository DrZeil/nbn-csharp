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
    /// Learning history table
    /// </summary>
    public class History : Table
    {
        /// <summary>
        /// Learn name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Serialized data containing information about whole learning
        /// </summary>
        public String Data { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public History()
            : base(SQL.General.Names.HistoryTableName)
        { }

        /// <summary>
        /// Insert action
        /// </summary>
        /// <returns>bool</returns>
        public override bool Insert()
        {
            try
            {
                String sql = String.Format(SQL.History.Insert, TableName, Name, Data);
                if (Manager.Instance.Execute(sql))
                {
                    Id = LastInsertedId;
                    return true;
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
                String sql = String.Format(SQL.History.Update, TableName, Name, Data, Id);
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
                String sql = String.Format(SQL.History.Delete, TableName, Id);
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
                String sql = String.Format(SQL.History.Read, TableName, Id);
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
                                Name = rdr.GetString(1);
                                Data = rdr.GetString(2);                                
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
        /// Read all from table action
        /// </summary>
        /// <returns>list of positions</returns>
        public static List<History> ReadAll()
        {
            List<History> list = new List<History>();
            try
            {
                String sql = String.Format(SQL.History.ReadAll, SQL.General.Names.HistoryTableName);
                using (SQLiteConnection con = Manager.Instance.Connection)
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                History item = new History();
                                item.Id = rdr.GetInt32(0);
                                item.Name = rdr.GetString(1);
                                item.Data = rdr.GetString(2);
                                list.Add(item);
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
            return list;
        }
    }
}
