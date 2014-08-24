/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;

namespace LearnByErrorLibrary
{
    /// <summary>
    /// Trainer resources
    /// </summary>
    public class TrainerResource
    {
        #region FILES
        /// <summary>
        /// Online resource address
        /// </summary>
        private String address = "https://sites.google.com/site/neuralnetworknbn/home/dane/{0}.dat";

        public List<string> ResourceList
        {
            get
            {
                List<string> list = new List<string>();
                foreach (var item in Resources)
                {
                    list.Add(String.Format(address, item));
                }
                return list;
            }
        }
        /// <summary>
        /// Resource list
        /// </summary>
        public String[] Resources = new String[] 
        {
            "and",
            "cube",
            "or",
            "sample1",
            "sample2",
            "16_4_encoder",
            "2spiral",
            "3_8_decoder",
            "4_16_decoder",
            "8_3_decoder",
            "abalone",
            "auto_MPG",
            "auto_price",
            "boston_housing",
            "cal_housing",
            "control_surface",
            "delta_ailerons",
            "delta_elevators",
            "errorcorrection4",
            "fuzzy_data",
            "machine",
            "parity2",
            "parity3",
            "parity4",
            "parity5",
            "parity6",
            "parity7",
            "parity8",
            "parity9",
            "parity10",
            "parity11",
            "parity12",
            "parity13",
            "parity14",
            "parity15",
            "parity16",
            "parity17",
            "peaks1000",
            "peaks2000",
            "peaks2000r",
        };
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public TrainerResource()
        {
            for (int i = 0; i < Resources.Length; i++)
            {
                Resources[i] = String.Format(address, Resources[i]);
            }
        }

        private static string _url = "";
        private static string _file = "";
        public static void loadSample(String url)
        {
            try
            {
                _url = @"https://sites.google.com/site/neuralnetworknbn/home/dane/" + System.IO.Path.GetFileName(url).Replace(".dat","") + ".dat";                
                _file = LearnByError.Common.Folder.Samples + "\\" + System.IO.Path.GetFileName(url).Replace(".dat","") + ".dat";
                if (!System.IO.File.Exists(_file))
                {
                    var request = System.Net.WebRequest.Create(_url);
                    request.Timeout = 60000;

                    using (var response = request.GetResponse())
                    {
                        using (var file = System.IO.File.Create(_file))
                        {
                            response.GetResponseStream().CopyTo(file);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LearnByError.Common.Log.Write(ex);
            }
        }
        public static void DownloadAll()
        {
            try
            {
                List<string> list = (new TrainerResource()).ResourceList;
                System.Threading.Tasks.Parallel.ForEach(list, item =>
                {
                    loadSample(item);
                });
            }
            catch { }
        }
    }
}
