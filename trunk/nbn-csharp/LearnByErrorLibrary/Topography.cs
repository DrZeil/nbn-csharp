/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using LearnByErrorLibrary;
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Network topology
    /// </summary>
    public class Topography : VectorHorizontal
    {
        /// <summary>
        /// Network topology constructor
        /// </summary>
        /// <param name="size">int - size of vector to store network topology</param>
        public Topography(int size)
            : base(size)
        {
        }

        /// <summary>
        /// Type of topography
        /// </summary>
        public TopographyType Type;

        /// <summary>
        /// Easy access to value
        /// </summary>
        /// <param name="index">int - index</param>
        /// <returns>int - value as integer</returns>
        /// <remarks>skip warning</remarks>
        public int this[int index]
        {
            get { return (int)Data[0][index]; }
            set { Data[0][index] = value; }
        }
        
        /// <summary>
        /// Network topology constructor
        /// </summary>
        /// <param name="values">double[] - topology values</param>
        public Topography(double[] values)
            : base(values.Length)
        {
            for (int i = 0; i < values.Length; i++)
            {
                this.Data[0][i] = values[i];
            }
        }

        /// <summary>
        /// Check if topography is correct - all values must be positive
        /// </summary>
        public bool IsCorrect
        {
            get
            {
                for (int i = 0; i < this.Length; i++)
                {
                    if (this.Data[0][i] < 0) return false;//was 1
                }
                return true;
            }
        }

        /// <summary>
        /// Generate network topography
        /// </summary>
        /// <param name="type">TopographyType - topo type</param>
        /// <param name="lbl">VectorHorizontal</param>
        /// <returns>Topography - generated topography</returns>
        public static Topography Generate(TopographyType type, VectorHorizontal lbl)
        {
            try
            {                
                System.Collections.Generic.List<double> vals = new System.Collections.Generic.List<double>();
                int nl = lbl.Length;
                for (int i = 1; i < nl; i++)
                {
                    int s = lbl.Sum(0, i - 1).ToInt();
                    for (int j = 0; j < lbl.getValue(i); j++)
                    {
                        switch (type)
                        {
                            case TopographyType.MLP://doesn not work properly
                                {
                                    vals.Add(s + j);
                                    vals.AddRange(lbl.GetRange(s - lbl.getValue(i - 1).ToInt() + 1, s));
                                } //MLP
                                break;

                            case TopographyType.BMLP:
                                {
                                    vals.Add(s + j);
                                    double[] tmp = new double[s];
                                    for (int ii = 0; ii < s; ii++)
                                    {
                                        tmp[ii] = ii;// ii + 1;
                                    }
                                    vals.AddRange(tmp);
                                }//BMLP
                                break;
                        }//switch
                    }//inner for
                }//first for
                var topo = new Topography(vals.ToArray());
                topo.Type = type;
                return topo;
            }
            catch (Exception)
            {
                return null;
            }
        }//generate

        /// <summary>
        /// Topography as string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine();
            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine("Topography");
            sb.AppendLine("Type: " + (Type == TopographyType.BMLP ? "BMLP" : "MLP"));
            String tmp = "";
            for (int i = 0; i < Length; i++)
            {
                tmp += this.Data[0][i].ToString() + (i == Length-1 ? "" : ", ");
            }
            sb.AppendLine(tmp);
            sb.AppendLine("------------------------------------------------------------");
            return sb.ToString();
        }
    }//class
}//ns