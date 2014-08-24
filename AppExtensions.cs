/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Collections.Generic;
using System.Linq;
using LearnByErrorLibrary;

namespace LearnByError
{
    public static class AppExtensions
    {
        public static void BlockInterface(System.Windows.Forms.Form form)
        {
            try
            {
                for (int i = 0; i < form.Controls.Count; i++)
                {
                    form.Controls[i].Enabled = false;
                }
            }
            catch { }
        }

        public static void UnblockInterface(System.Windows.Forms.Form form)
        {
            try
            {
                for (int i = 0; i < form.Controls.Count; i++)
                {
                    form.Controls[i].Enabled = true;
                }
            }
            catch { }
        }

        public static System.Drawing.Color ToColor(this int i)
        {
            switch (i)
            {
                case 0: return System.Drawing.Color.Red;
                case 1: return System.Drawing.Color.Green;
                case 2: return System.Drawing.Color.Blue;
                case 3: return System.Drawing.Color.Orange;
                case 4: return System.Drawing.Color.Yellow;
                case 5: return System.Drawing.Color.Violet;
                case 6: return System.Drawing.Color.Purple;
                case 7: return System.Drawing.Color.Fuchsia;
                case 8: return System.Drawing.Color.Brown;
                case 9: return System.Drawing.Color.GreenYellow;
                case 10: return System.Drawing.Color.DarkSeaGreen;
                case 11: return System.Drawing.Color.Olive;
                case 12: return System.Drawing.Color.Maroon;
                case 13: return System.Drawing.Color.Gold;
                case 14: return System.Drawing.Color.DarkViolet;
                case 15: return System.Drawing.Color.Violet;
                default: return System.Drawing.Color.Red;
            }
        }

        public static double ToMili(this string str)
        {
            var data = str.Split(".".ToCharArray());
            var mili = int.Parse(data[1].TrimEnd("0".ToCharArray()).Length == 0 ? "0" : data[1].TrimEnd("0".ToCharArray()));
            var d = data[0].Split(":".ToCharArray());
            var h = int.Parse(d[0].TrimEnd("0".ToCharArray()).Length == 0 ? "0" : d[0].TrimEnd("0".ToCharArray()));
            var m = int.Parse(d[1].TrimEnd("0".ToCharArray()).Length == 0 ? "0" : d[1].TrimEnd("0".ToCharArray()));
            var s = int.Parse(d[2].TrimEnd("0".ToCharArray()).Length == 0 ? "0" : d[2].TrimEnd("0".ToCharArray()));
            var ts = new TimeSpan(0, h, m, s, mili);
            return ts.TotalMilliseconds;
        }

        public static String GetLearnTime(this List<LearnResult> list)
        {
            double total = list.Sum(q => q.AverageLearnTime.ToMili()) / list.Count;            
            var ts = TimeSpan.FromMilliseconds(total);
            return string.Format("{0}:{1}:{2}.{3}", 
                (ts.Hours < 10 ? "0" + ts.Hours.ToString() : ts.Hours.ToString()),
                (ts.Minutes< 10 ? "0" + ts.Minutes.ToString() : ts.Minutes.ToString()), 
                (ts.Seconds< 10 ? "0" + ts.Seconds.ToString() : ts.Seconds.ToString()), 
                (ts.Milliseconds < 100 ? (ts.Milliseconds < 10 ? "00" + ts.Milliseconds.ToString() : "0" + ts.Milliseconds.ToString()) : ts.Milliseconds.ToString())
                );
        }

        public static String GetTestTime(this List<LearnResult> list)
        {
            double total = list.Sum(q => q.AverageTestTime.ToMili()) / list.Count;
            var ts = TimeSpan.FromMilliseconds(total);
            return string.Format("{0}:{1}:{2}.{3}",
                (ts.Hours < 10 ? "0" + ts.Hours.ToString() : ts.Hours.ToString()),
                (ts.Minutes < 10 ? "0" + ts.Minutes.ToString() : ts.Minutes.ToString()),
                (ts.Seconds < 10 ? "0" + ts.Seconds.ToString() : ts.Seconds.ToString()),
                (ts.Milliseconds < 100 ? (ts.Milliseconds < 10 ? "00" + ts.Milliseconds.ToString() : "0" + ts.Milliseconds.ToString()) : ts.Milliseconds.ToString())
                );
        }
    }
}
