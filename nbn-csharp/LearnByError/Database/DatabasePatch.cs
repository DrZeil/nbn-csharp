/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;

namespace LearnByError.Database
{
    /// <summary>
    /// Patching database class
    /// </summary>
    public class DatabasePatch
    {
        #region MAIN
        /// <summary>
        /// Patching table in database
        /// </summary>
        private static String sqlCreatePatchTable = String.Format(SQL.DatabasePatch.Create, Patch.patchTable);

        /// <summary>
        /// instance
        /// </summary>
        private static DatabasePatch instance = null;

        /// <summary>
        /// List of patches
        /// </summary>
        private List<Patch> patches = new List<Patch>();

        /// <summary>
        /// Default constructor
        /// </summary>
        private DatabasePatch()
        {
            Manager.Instance.Execute(sqlCreatePatchTable);            
            this.init();
        }

        /// <summary>
        /// DatabasePatch instance
        /// </summary>
        public static DatabasePatch Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabasePatch();
                }
                return instance;
            }
        }

        /// <summary>
        /// Executes all the necessery patches
        /// </summary>
        /// <returns>number of executed patches</returns>
        public int executePatches()
        {
            int executed = 0;
            foreach (Patch patch in this.patches)
            {
                if (patch.Exists(patch.Number)) continue;

                if (patch.execute())
                {
                    executed++;
                }
            }
            return executed;
        }
        #endregion

        #region PATCHES
        /// <summary>
        /// Create patch sqls to execute
        /// </summary>
        private void init()
        {
            patches.Add(new Patch(SQL.Table.Logs, "logs"));
            patches.Add(new Patch(SQL.Table.History,"history"));
            patches.Add(new Patch(SQL.Table.Config, "config"));

        }
        #endregion
    }//class
}//patch
