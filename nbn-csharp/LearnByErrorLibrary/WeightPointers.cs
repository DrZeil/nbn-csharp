/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Weight pointers/indexes in weights vector
    /// </summary>
    public class Index : VectorHorizontal
    {
        /// <summary>
        /// WeightsPointers constructor
        /// </summary>
        /// <param name="size">int - size of vector for pointers - must match number of weights vector</param>
        public Index(int size)
            : base(size)
        {
        }

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
        /// Finds weight indexes
        /// </summary>
        /// <param name="topo">Topography - topography</param>
        /// <returns>WeightPointers - weight indexes</returns>
        public static Index Find(ref Topography topo)
        {

            System.Collections.Generic.List<double> iw = new System.Collections.Generic.List<double>();
            int nmax = 0;
            int i = 0;
            for (i = 0; i < topo.Length; i++)
            {
                if (topo.getValue(i) > nmax)
                {
                    nmax = topo.getValue(i).ToInt();
                 
                    iw.Add(i);
                }                
            }

            //iw.Add(i-1);
            iw.Add(i);//otherwise error calculation will be wrong

            Index ip = new Index(iw.Count);
            ip.Data[0] = iw.ToArray();
            return ip;

            /*
             function iw = findiw(topo)
                nmax=0; j=0;
                for i=1:length(topo),
                    if topo(i)>nmax,
                        nmax=topo(i);
                        j=j+1; iw(j)=i;
                    end;
                end;
                iw(j+1)=i+1;
                return
             */
        }

        /// <summary>
        /// Convert to string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();

            sb.AppendLine();
            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine("Index pointers (topography)");
            string tmp = "";
            for (int i = 0; i < Length; i++)
            {
                tmp += this.Data[0][i].ToString() + (i == Length - 1 ? "" : ", ");
            }
            sb.AppendLine(tmp);
            sb.AppendLine("------------------------------------------------------------");
            return sb.ToString();
        }
    }
}
