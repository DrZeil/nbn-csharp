/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Data.SQLite;

namespace LearnByError.Database
{
    /// <summary>
    /// Database table
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Table name
        /// </summary>
        public String TableName { get; set; }        

        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Insert action
        /// </summary>
        /// <returns>bool</returns>
        public virtual bool Insert() { return false; }

        /// <summary>
        /// Update action
        /// </summary>
        /// <returns>bool</returns>
        public virtual bool Update() { return false; }

        /// <summary>
        /// Delete action
        /// </summary>
        /// <returns>bool</returns>
        public virtual bool Delete() { return false; }

        /// <summary>
        /// Read action
        /// </summary>
        /// <remarks>http://zetcode.com/db/sqlitecsharp/read/</remarks>
        /// <returns>bool</returns>
        public virtual bool Read() { return false; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">String - table name</param>
        public Table(String name)
        {
            TableName = name;
        }

        /// <summary>
        /// Gets last inserted row id for this table
        /// </summary>
        public int LastInsertedId
        {
            get
            {
                int rowId = -1;
                try
                {
                    using (SQLiteConnection connection = Manager.Instance.Connection)
                    {
                        connection.Open();
                        using (SQLiteCommand command = new SQLiteCommand(connection))
                        {
                            command.CommandText = String.Format(SQL.General.LastInsert, TableName);
                            rowId = Convert.ToInt32(command.ExecuteScalar());
                        }
                        connection.Close();
                    }
                }
                catch (SQLiteException se)
                {
                    Manager.LogSQLiteExceptionReason(se.ResultCode);
                }
                catch (Exception e)
                {
                    Common.Log.Write(e);
                }
                return rowId;
            }
        }

        public int Total
        {
            get
            {
                try
                {
                    return Manager.countIt(String.Format(SQL.General.CountAllFromTable, TableName));
                }
                catch { return 0; }
            }
        }

        public bool DeleteAll()
        {
            try
            {
                var result = Manager.Instance.Execute(String.Format(SQL.General.DeleteAllFromTable, TableName));                
                Manager.Instance.Vacuum();
                return result;
            }
            catch (Exception ex)
            {
                Common.Log.Write(ex);
                return false;
            }
        }
    }
}
