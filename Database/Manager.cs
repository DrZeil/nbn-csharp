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
    /// SQLite database manager
    /// </summary>
    public class Manager
    {
        #region FIELDS
        /// <summary>
        /// SQLite database version number
        /// </summary>
        private const int DB_VERSION = 3;

        /// <summary>
        /// Error message
        /// </summary>
        public static String Error { get; set; }

        /// <summary>
        /// Database filename
        /// </summary>
        public const String DB_NAME = "nbn.sqlite";

        /// <summary>
        /// Database cache size
        /// </summary>
        private const int DB_CACHE_SIZE = 2000;

        /// <summary>
        /// Database paging size
        /// </summary>
        private const int DB_PAGE_SIZE = 1024;

        /// <summary>
        /// Determinates if database is read only
        /// </summary>
        private const bool IS_DB_READ_ONLY = false;

        /// <summary>
        /// Database connection timeout. After this time try to connection fails
        /// </summary>
        private const int DEFAULT_TIMEOUT_IN_SECONDS = 60;

        /// <summary>
        /// SQlite database connection object
        /// </summary>
        private SQLiteConnection connection = new SQLiteConnection();

        /// <summary>
        /// Database connection string - connection parameters
        /// </summary>
        private String connectionString = "";

        /// <summary>
        /// Database manager instance - for singleton purpose
        /// </summary>
        private static Manager instance = null;

        #endregion

        #region CREATION
        /// <summary>
        /// Manager instance getter
        /// </summary>
        public static Manager Instance
        {
            get
            {
                try
                {
                    if (instance == null) instance = new Manager();
                }
                catch (Exception ex)
                {
                    Common.Log.Write(ex);
                }
                return instance;
            }
        }

        /// <summary>
        /// Hidden constructor
        /// </summary>
        private Manager() { }
        #endregion

        #region BASIC
        /// <summary>
        /// Get connection string
        /// </summary>
        /// <remarks>https://www.connectionstrings.com/sqlite/</remarks>
        private String ConnectionString
        {
            get
            {
                if (connectionString == "")
                {
                    var builder = new SQLiteConnectionStringBuilder();
                    builder.DataSource = String.Format("{0}\\{1}", Common.Folder.Settings, DB_NAME);
                    builder.SyncMode = SynchronizationModes.Full;
                    builder.Version = DB_VERSION;
                    builder.ReadOnly = false;
                    builder.Pooling = false;
                    builder.UseUTF16Encoding = false;
                    builder.MaxPageCount = 0;//{size in pages} - Limits the maximum number of pages (limits the size) of the database
                    builder.PageSize = DB_PAGE_SIZE;
                    builder.DateTimeFormat = SQLiteDateFormats.ISO8601;
                    builder.DateTimeKind = DateTimeKind.Unspecified;//Not specified as either UTC or local time.
                    builder.Flags = SQLiteConnectionFlags.None;
                    builder.JournalMode = SQLiteJournalModeEnum.Delete;//Delete the journal file after a commit
                    builder.FailIfMissing = false;//Automatically create the database if it does not exist
                    builder.DefaultTimeout = DEFAULT_TIMEOUT_IN_SECONDS;//in seconds
                    builder.CacheSize = DB_CACHE_SIZE;

                    connectionString = builder.ConnectionString;
                }
                return connectionString;
            }
        }

        /// <summary>
        /// Database connection
        /// </summary>
        public SQLiteConnection Connection
        {
            get
            {
                try
                {
                    SQLiteConnection conn = new SQLiteConnection();//loop or recursion may destroy
                    conn.ConnectionString = ConnectionString;
                    conn.DefaultTimeout = DEFAULT_TIMEOUT_IN_SECONDS;
                    return conn;
                }
                catch
                {
                    return null;
                }
            }
        }
        #endregion

        #region EXECUTING
        /// <summary>
        /// Count items with specified SQL code
        /// </summary>
        /// <param name="countingSql">sql to count items</param>
        /// <returns>number of items</returns>
        public static int countIt(String countingSql)
        {
            int total = -1;
            try
            {
                using (SQLiteConnection connection = Manager.Instance.Connection)
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        using (SQLiteCommand command = connection.CreateCommand())
                        {
                            command.CommandText = countingSql;
                            total = Convert.ToInt32(command.ExecuteScalar());
                        }
                        connection.Close();
                    }
                    else
                    {
                        Common.Log.Write(LearnByError.Internazional.Resource.Inst.Get("r135"));
                    }
                }
            }
            catch (SQLiteException se)
            {
                Common.Log.Write(LearnByError.Internazional.Resource.Inst.Get("r135"));
                Manager.LogSQLiteExceptionReason(se.ResultCode);
                Common.Log.Write(se);
            }
            catch (Exception e)
            {
                Common.Log.Write(LearnByError.Internazional.Resource.Inst.Get("r135"));
                Common.Log.Write(e);
            }
            return total;
        }

        /// <summary>
        /// Execute non query commane
        /// </summary>
        /// <param name="sql">String - sql</param>
        /// <returns>bool</returns>
        public bool Execute(String sql)
        {
            bool answer = true;
            try
            {
                using (SQLiteConnection connection = Connection)
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Broken)
                    {
                        throw new Exception(LearnByError.Internazional.Resource.Inst.Get("r136"));
                    }

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        using (SQLiteCommand command = new SQLiteCommand(connection))
                        {
                            try
                            {
                                command.CommandText = sql;
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }
                            catch (SQLiteException se)
                            {
                                transaction.Rollback();
                                Common.Log.Write(LearnByError.Internazional.Resource.Inst.Get("r137") + sql);
                                Common.Log.Write(se);
                                Common.Log.Write(sql);
                                Manager.LogSQLiteExceptionReason(se.ResultCode, sql);
                                answer = false;
                            }
                        }

                    }
                    connection.Close();
                }
            }
            catch (SQLiteException se)
            {
                Common.Log.Write(LearnByError.Internazional.Resource.Inst.Get("r137") + sql);
                Common.Log.Write(se);
                Manager.LogSQLiteExceptionReason(se.ResultCode, sql);
                answer = false;
            }
            catch (InvalidOperationException ioe)
            {
                Common.Log.Write(LearnByError.Internazional.Resource.Inst.Get("r137") + sql);
                Common.Log.Write(ioe);
                answer = false;
            }
            catch (Exception e)
            {
                Common.Log.Write(LearnByError.Internazional.Resource.Inst.Get("r137") + sql);
                Common.Log.Write(e);
                answer = false;
            }

            return answer;
        }

        public void Initialize()
        {
            try
            {                
                Execute(SQL.General.SqlInit);
                InitializeStructure();

            }
            catch { }
        }

        /// <summary>
        /// Database clean up
        /// </summary>
        public void Vacuum()
        {
            try
            {
                using (SQLiteConnection connection = Connection)
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = SQL.General.Vacuum;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Common.Log.Write(LearnByError.Internazional.Resource.Inst.Get("r138"));
                Common.Log.Write(e);
            }
        }

        #endregion

        #region STATIC
        /// <summary>
        /// Initializes database structure
        /// </summary>
        public static void InitializeStructure()
        {
            try
            {
                DatabasePatch.Instance.executePatches();
            }
            catch (Exception ex)
            {
                Common.Log.Write(ex);
            }
        }
        /// <summary>
        /// Logs sqlite database exceptions
        /// </summary>
        /// <param name="code">SQLiteErrorCode</param>
        /// <param name="sql">String</param>
        public static void LogSQLiteExceptionReason(SQLiteErrorCode code, String sql = "")
        {
            String msg = LearnByError.Internazional.Resource.Inst.Get("r139");
            switch (code)
            {
                case SQLiteErrorCode.Abort:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r140");
                    break;
                case SQLiteErrorCode.CantOpen:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r141");
                    break;
                case SQLiteErrorCode.Corrupt:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r142");
                    break;
                case SQLiteErrorCode.Locked:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r143");
                    break;
                case SQLiteErrorCode.NoMem:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r144");
                    break;
                case SQLiteErrorCode.NotFound:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r145");
                    break;
                case SQLiteErrorCode.Perm:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r146");
                    break;
                case SQLiteErrorCode.ReadOnly:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r147");
                    break;
                case SQLiteErrorCode.Schema:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r148");
                    break;
                case SQLiteErrorCode.Error:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r149") + sql;
                    break;
                case SQLiteErrorCode.Empty:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r150");
                    break;
                case SQLiteErrorCode.TooBig:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r151");
                    break;
                case SQLiteErrorCode.Misuse:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r152");
                    break;
                case SQLiteErrorCode.NotADb:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r153");
                    break;
                default:
                    msg += LearnByError.Internazional.Resource.Inst.Get("r154");
                    break;
            }

            Error = msg;
            Common.Log.Write(msg);
        }
        #endregion
    }

    /// <summary>
    /// SQLite database manager extensions
    /// </summary>
    public static class SqliteExtensions
    {
        /// <summary>
        /// Determinates database state
        /// </summary>
        /// <param name="code">SQLiteErrorCode</param>
        /// <returns>bool - true if issue or false if ok</returns>
        public static bool IsBusyOrLocked(this SQLiteErrorCode code)
        {
            if (code == SQLiteErrorCode.Error || code == SQLiteErrorCode.Locked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}