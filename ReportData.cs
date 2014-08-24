using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnByError
{
    public class ReportData
    {
        [Description("Dane uczące")]
        public String LearnData { get; set; }

        [Description("Liczba neuronów")]
        public String NeuronNumber { get; set; }

        [Description("Liczba prób")]
        public String Trials { get; set; }

        [Description("Średnie RMSE uczenia")]
        public String LearnRMSE { get; set; }

        [Description("Średnie RMSE testowania")]
        public String TestRMSE { get; set; }

        [Description("Średni czas uczenia")]
        public String LearnTime { get; set; }

        [Description("Średni czas testowania")]
        public String TestTime { get; set; }
        public override string ToString()
        {
            return String.Format(LearnByError.Internazional.Resource.Inst.Get("r264"),
                LearnData, NeuronNumber,Trials, LearnRMSE, TestRMSE, LearnTime, TestTime);            
        }
    }
}
