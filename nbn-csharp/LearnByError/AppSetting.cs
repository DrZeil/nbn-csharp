/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Linq;
using LearnByError.Database.Tables;

namespace LearnByError
{
    /// <summary>
    /// Application settings
    /// </summary>
    public class AppSetting
    {
        #region PRIVATE

        /// <summary>
        /// Sets property
        /// </summary>
        /// <param name="name">String - property name</param>
        /// <param name="value">String - property value</param>
        private void set(String name, String value)
        {
            KeyValue kv = new KeyValue();
            kv.Key = name;
            kv.Value = value;
            kv.Insert();//insert of update - see sql            
        }

        /// <summary>
        /// Gets property
        /// </summary>
        /// <param name="name">String - property name</param>
        /// <returns>String - property value</returns>
        private String get(String name)
        {
            if (!KeyValue.Exists(name))
            {
                return "";
            }
            else
            {
                KeyValue kv = new KeyValue();
                kv.Key = name;
                kv.Read();
                return kv.Value;
            }
        }

        #endregion

        #region PUBLIC

        #region NEURAL_NETWORK_SETTINGS

        /// <summary>
        /// MU controls how much the weights are changed on each iteration.
        /// </summary>
        public double MU
        {
            get
            {
                double val = 0;
                if(double.TryParse(get("MU"),out val))
                {
                    return val;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                set("MU", value.ToString());
            }
        }

        public double Threshold
        {
            get
            {
                double val = 1;
                if (double.TryParse(get("THRESHOLD"), out val))
                {
                    return val;
                }
                else
                {
                    return 1;
                }
            }

            set
            {
                set("THRESHOLD", value.ToString());
            }
        }

        /// <summary>
        /// High bound of MU
        /// </summary>
        public double MUH
        {
            get
            {
                double val = 0;
                if (double.TryParse(get("MUH"), out val))
                {
                    return val;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                set("MUH", value.ToString());
            }
        }

        /// <summary>
        /// Low bound of MU
        /// </summary>
        public double MUL
        {
            get
            {
                double val = 0;
                if (double.TryParse(get("MUL"), out val))
                {
                    return val;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                set("MUL", value.ToString());
            }
        }

        /// <summary>
        /// Scale - increase or decrease MU factor
        /// </summary>
        public int Scale
        {
            get
            {
                int val = 0;
                if (int.TryParse(get("SCALE"), out val))
                {
                    return val;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                set("SCALE", value.ToString());
            }
        }

        /// <summary>
        /// Max required error
        /// </summary>
        public double MaxError
        {
            get
            {
                double val = 0;
                if (double.TryParse(get("MAX_ERROR"), out val))
                {
                    return val;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                set("MAX_ERROR", value.ToString());
            }
        }

        /// <summary>
        /// Maximum number of iteration that can be perforemed during learning process
        /// </summary>
        public int MaxIterations
        {
            get
            {
                int val = 0;
                if (int.TryParse(get("MAX_ITERATIONS"), out val))
                {
                    return val;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                set("MAX_ITERATIONS", value.ToString());
            }
        }

        /// <summary>
        /// Application data folder
        /// </summary>
        public String ApplicationDataFolder
        {
            get
            {
                return get("APP_FOLDER");
            }

            set
            {
                set("APP_FOLDER", value);
            }
        }

        /// <summary>
        /// Learning process console visibility
        /// </summary>
        public bool ShowConsole
        {
            get
            {
                int val = 0;
                if (int.TryParse(get("SHOW_CONSOLE"), out val))
                {
                    return val == 1;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                set("SHOW_CONSOLE", (value ? 1 : 0).ToString());
            }
        }

        /// <summary>
        /// Learning process console visibility
        /// </summary>
        public bool DontDrawChart
        {
            get
            {
                int val = 0;
                if (int.TryParse(get("NOCHART"), out val))
                {
                    return val == 1;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                set("NOCHART", (value ? 1 : 0).ToString());
            }
        }

        public bool IsClassification
        {
            get
            {
                int val = 0;
                if (int.TryParse(get("KLASYFIKACJA"), out val))
                {
                    return val == 1;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                set("KLASYFIKACJA", (value ? 1 : 0).ToString());
            }
        }

        /// <summary>
        /// Auto save learning process results
        /// </summary>
        public bool AutoSaveLearningResults
        {
            get
            {
                int val = 0;
                if (int.TryParse(get("AUTO_SAVE_RESULTS"), out val))
                {
                    return val == 1;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                set("AUTO_SAVE_RESULTS", (value ? 1 : 0).ToString());
            }
        }

        public int LearnTrials
        {
            get
            {
                int val = 0;
                if (int.TryParse(get("TRIALS"), out val))
                {
                    return val;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                set("TRIALS", value.ToString());
            }
        }

        public int NeuronNumber
        {
            get
            {
                int val = 2;
                if (int.TryParse(get("NEURONS"), out val))
                {
                    return val;
                }
                else
                {
                    return 2;
                }
            }

            set
            {
                set("NEURONS", value.ToString());
            }
        }


        /// <summary>
        /// Netowork topology type
        /// </summary>
        public int TopologyType
        {
            get
            {
                int val = 0;
                if (int.TryParse(get("TOPOLOGY"), out val))
                {
                    return val;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                set("TOPOLOGY", value.ToString());
            }
        }


        /// <summary>
        /// Activation function index
        /// </summary>
        public int ActivationFunction
        {
            get
            {
                int val = 2;
                if (int.TryParse(get("FA"), out val))
                {
                    return val;
                }
                else
                {
                    return 2;
                }
            }

            set
            {
                set("FA", value.ToString());
            }
        }

        public double Gain
        {
            get
            {
                double val = 1;
                if (double.TryParse(get("GAIN"), out val))
                {
                    return val;
                }
                else
                {
                    return 1;
                }
            }

            set
            {
                set("GAIN", value.ToString());
            }
        }

        public LearnByError.Internazional.Languages Language
        {
            get
            {
                int val = 0;
                if (int.TryParse(get("LANGUAGE"), out val))
                {
                    return (LearnByError.Internazional.Languages)val;
                }
                else
                {
                    return LearnByError.Internazional.Languages.pl;
                }
            }

            set
            {
                set("LANGUAGE", ((int)value).ToString());
            }
        }

        /// <summary>
        /// Application buffer
        /// </summary>
        public String Buffer
        {
            get
            {
                return get("APP_BUFFER");
            }

            set
            {
                set("APP_BUFFER", value);
            }
        }
        #endregion

        #endregion
    }
}
