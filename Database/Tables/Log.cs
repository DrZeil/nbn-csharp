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
    /// Log table containing application errors
    /// </summary>
    public class Log : Table
    {
        /// <summary>
        /// Message
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// Error trace
        /// </summary>
        public String Stacktrace { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime When { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Log()
            : base(SQL.General.Names.LogTableName)
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
                String sql = String.Format(SQL.Log.Insert, TableName, Message, Stacktrace, When);
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
                String sql = String.Format(SQL.Log.Update, TableName, Message, Stacktrace, When, Id);
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
                String sql = String.Format(SQL.Log.Delete, TableName, Id);
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
                String sql = String.Format(SQL.Log.Read, TableName, Id);
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
                                Message = rdr.GetString(1);
                                Stacktrace = rdr.GetString(2);
                                When = rdr.GetDateTime(3);
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
        /// Read all positions action
        /// </summary>
        /// <returns>list of positions</returns>
        public static List<Log> ReadAll()
        {
            List<Log> logs = new List<Log>();
            try
            {
                String sql = String.Format(SQL.Log.ReadAll, SQL.General.Names.LogTableName);
                using (SQLiteConnection con = Manager.Instance.Connection)
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                Log log = new Log();
                                log.Id = rdr.GetInt32(0);
                                log.Message = rdr.GetString(1);
                                log.Stacktrace = rdr.GetString(2);
                                log.When = rdr.GetDateTime(3);
                                logs.Add(log);
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
            return logs;
        }         
    }
}
