/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{

    /// <summary>
    /// Information about basic neural network parameters
    /// </summary>
    public class NetworkInfo
    {
        /// <summary>
        /// Number of patterns
        /// </summary>
        public int np;

        /// <summary>
        /// Number of inputs
        /// </summary>
        public int ni;

        /// <summary>
        /// Number of outputs
        /// </summary>
        public int no;

        /// <summary>
        /// Number of neurons
        /// </summary>
        public int nn;

        /// <summary>
        /// Number of weights
        /// </summary>
        public int nw;

        /// <summary>
        /// nio = nn + ni - no
        /// </summary>
        public int nio
        {
            get
            {
                return nn + ni - no;
            }
        }

        /// <summary>
        /// Constructor with setting parameters
        /// </summary>
        /// <param name="np">int - Number of patterns</param>
        /// <param name="ni">int - Number of inputs</param>
        /// <param name="no">int - Number of outputs</param>
        /// <param name="nn">int - Number of neurons</param>
        /// <param name="nw">int - Number of weights</param>
        public NetworkInfo(int np, int ni, int no, int nn, int nw)
        {
            this.np = np;
            this.ni = ni;
            this.no = no;
            this.nn = nn;
            this.nw = nw;            
        }

        /// <summary>
        /// Basic constructor with no setting parameters
        /// </summary>
        public NetworkInfo()
        {
        }


        /// <summary>
        /// Copy neural network information
        /// </summary>
        /// <returns>NetworkInfo</returns>
        public NetworkInfo Copy()
        {
            NetworkInfo info = new NetworkInfo();
            info.np = this.np;
            info.no = this.no;
            info.ni = this.ni;
            info.nn = this.nn;
            info.nw = this.nw;
            return info;
        }

        /// <summary>
        /// Convert neural network information to text
        /// </summary>
        /// <returns>string - text</returns>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine("Network information");
            sb.AppendLine("Number of patterns: " + np.ToString());
            sb.AppendLine("Number of inputs: " + ni.ToString());
            sb.AppendLine("Number of outputs: " + no.ToString());
            sb.AppendLine("Number of neurons: " + nn.ToString());
            sb.AppendLine("Number of weights: " + nw.ToString());
            sb.AppendLine("------------------------------------------------------------");
            return sb.ToString();
        }
    }
}
