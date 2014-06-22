/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;

namespace LearnByError.Internazional
{
    /// <summary>
    /// Language resource
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Current language in use
        /// </summary>
        private static Languages lang = Languages.pl;

        /// <summary>
        /// Resource manager instance
        /// </summary>
        private static Resource instance = null;

        /// <summary>
        /// Language resources
        /// </summary>
        private static System.Collections.Hashtable resource;

        /// <summary>
        /// Language resource getter
        /// </summary>
        public static Resource Inst
        {
            get
            {
                if (instance == null)
                {
                    instance = new Resource();
                }
                return instance;
            }
        }

        /// <summary>
        /// Hidden constructor
        /// </summary>
        private Resource()
        {
            try
            {
                var app = new AppSetting();
                lang = app.Language;
            }
            catch { }

            switch (lang)
            {
                case Languages.pl:
                    {
                        resource = (new LearnByError.Internazional.Lang.Polish()).Resource;
                    }break;
                case Languages.en:
                    {
                        resource = (new LearnByError.Internazional.Lang.English()).Resource;
                    }break;
                default:
                    {
                        resource = (new LearnByError.Internazional.Lang.English()).Resource;
                    }break;
            }
        }

        /// <summary>
        /// Resource getter
        /// </summary>
        /// <param name="name">String - resource name</param>
        /// <returns>String - language translation</returns>
        public String Get(String name)
        {
            try
            {
                return (String)resource[name];
            }
            catch
            {
                return "";
            }
        }
    }
}
