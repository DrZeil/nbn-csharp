/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace LearnByError
{
    /// <summary>
    /// Some usefull methods
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// File actions
        /// </summary>
        public static class File
        {
            public static bool WriteToTextFile(String filename, String text, bool appendOnEndIfExists = false)
            {
                try
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(filename, appendOnEndIfExists);
                    file.Write(text);
                    file.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public static String GetXmlFileNameForHistory()
            {
                DateTime d = DateTime.Now;
                return String.Format("{0}\\{1}_{2}_{3}_{4}_{5}_{6}.xml", Common.Folder.LearnHistory, d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
            }
        }

        /// <summary>
        /// Folders
        /// </summary>
        public static class Folder
        {
            /// <summary>
            /// Application main folder - this is not installation folder
            /// </summary>
            public static String Application
            {
                get
                {
                    String dir = "";
                    dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NBN";
                    if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
                    return dir;
                }
            }

            /// <summary>
            /// Logs folder
            /// </summary>
            public static String Log
            {
                get
                {
                    var dir = Application + "\\Application Logs";
                    if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
                    return dir;
                }
            }

            /// <summary>
            /// Learn history folder
            /// </summary>
            public static String LearnHistory
            {
                get
                {
                    var dir = Application + "\\Learn History";
                    if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
                    return dir;
                }
            }

            /// <summary>
            /// Settings folder
            /// </summary>
            public static String Settings
            {
                get
                {
                    var dir = Application + "\\Application Settings";
                    if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
                    return dir;
                }
            }

            /// <summary>
            /// Data folder
            /// </summary>
            public static String Data
            {
                get
                {
                    var dir = Application + "\\Data";
                    if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
                    return dir;
                }
            }

            /// <summary>
            /// Samples folder
            /// </summary>
            public static String Samples
            {
                get
                {
                    var dir = Application + "\\Samples";
                    if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
                    return dir;
                }
            }
        }//Folder

        /// <summary>
        /// Logging errors
        /// </summary>
        public static class Log
        {
            /// <summary>
            /// Write log
            /// </summary>
            /// <param name="message">String - error message</param>
            /// <param name="ex">Exception - optional</param>
            /// <remarks>Saves to DB or if failure then to file</remarks>
            public static void Write(String message, Exception ex = null)
            {
                DateTime now = DateTime.Now;
                String filename = String.Format("{0}\\log_from_{1}_{2}_{3}.txt",
                            Common.Folder.Log,
                            now.Year,
                            (now.Month.ToString().Length == 1 ? "0" + now.Month.ToString() : now.Month.ToString()),
                            (now.Day.ToString().Length == 1 ? "0" + now.Day.ToString() : now.Day.ToString())
                            );
                String logText = String.Format("[{0}]: {1}", now.ToString(), message);

                try
                {
                    LearnByError.Database.Tables.Log log = new Database.Tables.Log();
                    log.Message = message;
                    if (ex != null)
                    {
                        log.Stacktrace = ex.StackTrace + ex.InnerException != null ? ex.InnerException.StackTrace : "";
                    }
                    else
                    {
                        log.Stacktrace = "";
                    }
                    log.When = DateTime.Now;
                    if (!log.Insert()) throw new Exception("");
                }
                catch
                {
                    try
                    {
                        System.IO.StreamWriter file = new System.IO.StreamWriter(filename, true);
                        file.WriteLine(logText);
                        file.Close();
                    }
                    catch { }
                }
            }

            /// <summary>
            /// Write exception to error log
            /// </summary>
            /// <param name="ex">Exception - exception</param>
            /// <remarks>Saves to DB or if failure then to file</remarks>
            public static void Write(Exception ex)
            {
                Common.Log.Write(ex.Message + (ex.InnerException != null ? ex.InnerException.Message : ""), ex);
            }
        }

        /// <summary>
        /// Dialogs
        /// </summary>
        public static class Dialog
        {
            /// <summary>
            /// Open file dialog
            /// </summary>
            /// <param name="title">String - window title</param>
            /// <param name="names">String - names of allowed file types</param>
            /// <param name="filters">String - allowed extensions</param>
            /// <returns>String - selected file or empty string</returns>
            public static String Open(String title = "", String names = "", String filters = "")
            {
                String path = "";
                try
                {
                    names = names.Replace(';', ',');
                    filters = filters.Replace(';', ',');
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.CheckFileExists = true;
                    dlg.Title = title == "" ? LearnByError.Internazional.Resource.Inst.Get("r155") : title;
                    dlg.Multiselect = false;
                    String pattern = "{0} (*.{1})|*.{2}";
                    String filter = "";
                    var Filters = filters.Split(new char[] { ',' });
                    var FiltersNames = names.Split(new char[] { ',' });

                    int i = 0;
                    foreach (var f in Filters)
                    {
                        if (f != "")
                        {
                            filter += String.Format(pattern, FiltersNames[i], f, f) + "|";
                        }
                        i++;
                    }

                    filter = filter.TrimEnd(new char[] { '|', ',', ' ' });
                    dlg.Filter = filter;
                    dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        return dlg.FileName;
                    }
                }
                catch (Exception ex)
                {
                    ex.ToLog(filters + "\r\n" + names);
                }
                return path;
            }

            /// <summary>
            /// Save file dialog - choose name for file
            /// </summary>
            /// <param name="extensionName">String - file extension name</param>
            /// <param name="extension">String - file extension</param>
            /// <param name="filename">String - proposed name</param>
            /// <param name="title">String - window title</param>
            /// <returns>String - chosen filename or empty string if cancelled</returns>
            public static String Save(String extensionName, String extension, String filename = "", String title = "")
            {
                try
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = title == "" ? LearnByError.Internazional.Resource.Inst.Get("r156") : title;
                    sfd.InitialDirectory = Common.Folder.Data;
                    sfd.AddExtension = true;
                    sfd.FileName = filename;
                    sfd.Filter = extensionName + " (*." + extension + ")|*." + extension;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        return sfd.FileName;
                    }
                    return "";
                }
                catch (Exception ex)
                {
                    ex.ToLog();
                    return "";
                }
            }

            /// <summary>
            /// Enter text dialog
            /// </summary>
            /// <param name="title">String - window title</param>
            /// <param name="promptText">String - prompt</param>
            /// <param name="value">String - output text by ref</param>
            /// <param name="ok">String - ok button text</param>
            /// <param name="cancel">Strign - cancel button text</param>
            /// <returns>DialogResult</returns>
            public static DialogResult InputBox(string title, string promptText, ref string value, string ok = "OK", string cancel = "Anuluj")
            {
                Form form = new Form();
                Label label = new Label();
                TextBox textBox = new TextBox();
                Button buttonOk = new Button();
                Button buttonCancel = new Button();

                form.Text = title;
                label.Text = promptText;
                textBox.Text = value;

                buttonOk.Text = ok;
                buttonCancel.Text = cancel;
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label.SetBounds(9, 20, 372, 13);
                textBox.SetBounds(12, 36, 372, 20);
                buttonOk.SetBounds(228, 72, 75, 23);
                buttonCancel.SetBounds(309, 72, 75, 23);

                label.AutoSize = true;
                textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                form.ClientSize = new Size(396, 107);
                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;
                form.TopMost = true;

                DialogResult dialogResult = form.ShowDialog();
                value = textBox.Text;
                return dialogResult;
            }

            /// <summary>
            /// Select folder dialog
            /// </summary>
            /// <param name="path">String - initial path</param>
            /// <returns>String - selected folder</returns>
            public static String SelectFolder(String path = "")
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.RootFolder = Environment.SpecialFolder.MyDocuments;
                dialog.ShowNewFolderButton = true;
                dialog.Description = LearnByError.Internazional.Resource.Inst.Get("r157");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
                return path;
            }
        }//Dialog
    }//Common

    /// <summary>
    /// Application objects extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Log exception to log table/file
        /// </summary>
        /// <param name="ex">Exception - exception</param>
        /// <param name="msg">String - optional message</param>
        /// <returns>Exception</returns>
        public static Exception ToLog(this Exception ex, String msg = "")
        {
            Common.Log.Write(ex);
            Common.Log.Write(msg);
            return ex;
        }

        /// <summary>
        /// Show matrix in window
        /// </summary>
        /// <param name="mat">MatrixMB</param>
        /// <param name="title">String - window title - optional</param>
        /// <returns>System.Windows.Forms.Form</returns>
        public static Form ToWindow(this LearnByErrorLibrary.MatrixMB mat, String title = "")
        {
            Form f = new Form();
            //f.Icon = Properties.Resources.logo;
            f.Text = title == "" ? mat.Name : title;
            f.Width = 500;
            f.Height = 400;
            f.StartPosition = FormStartPosition.CenterScreen;
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.ColumnHeadersVisible = false;
            grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            grid.AutoSize = true;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



            f.Controls.Add(grid);

            var rowCount = mat.Rows;
            var rowLength = mat.Cols;

            for (int i = 0; i < rowLength; i++)
            {
                grid.Columns.Add("data" + (i + 1).ToString(), "");
            }

            for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
            {
                var row = new DataGridViewRow();

                for (int columnIndex = 0; columnIndex < rowLength; ++columnIndex)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = mat.Data[rowIndex][columnIndex]
                    });
                }

                grid.Rows.Add(row);
            }
            return f;
        }        
    }
}//ns
