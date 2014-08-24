/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByError
{
    /// <summary>
    /// Information about application
    /// </summary>
    partial class AboutBox : System.Windows.Forms.Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AboutBox()
        {
            InitializeComponent();
            this.labelVersion.Text = LearnByError.Internazional.Resource.Inst.Get("r111");
            this.labelCopyright.Text = LearnByError.Internazional.Resource.Inst.Get("r112");
            this.labelCompanyName.Text = LearnByError.Internazional.Resource.Inst.Get("r113");
            this.textBoxDescription.Text = LearnByError.Internazional.Resource.Inst.Get("r114");
            this.okButton.Text = LearnByError.Internazional.Resource.Inst.Get("r115");
            this.Text = LearnByError.Internazional.Resource.Inst.Get("r116");

            this.Text = string.Format(LearnByError.Internazional.Resource.Inst.Get("r109"), "NBN C#");
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = string.Format(LearnByError.Internazional.Resource.Inst.Get("r110"), "1.0");
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = LearnByError.Internazional.Resource.Inst.Get("r265");
        }

        /// <summary>
        /// Product name
        /// </summary>
        public string AssemblyProduct
        {
            get
            {
                object[] attributes = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Reflection.AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((System.Reflection.AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Copyright
        /// </summary>
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Reflection.AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((System.Reflection.AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /// <summary>
        /// Company name
        /// </summary>
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Reflection.AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((System.Reflection.AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        private void tableLayoutPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void githubButton_Click(object sender, System.EventArgs e)
        {
            OpenWebsite("https://github.com/marekbar1985/nbn_csharp");
        }

        private void wwwButton_Click(object sender, System.EventArgs e)
        {
            OpenWebsite("https://sites.google.com/site/neuralnetworknbn/");
        }

        public static void OpenWebsite(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(GetDefaultBrowserPath(), url);
            }
            catch
            {

            }

        }

        private static string GetDefaultBrowserPath()
        {
            try
            {
                string key = @"http\shell\open\command";
                Microsoft.Win32.RegistryKey registryKey =
                Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(key, false);
                return ((string)registryKey.GetValue(null, null)).Split('"')[1];
            }
            catch
            {
                return "";
            }
        }
    }
}
