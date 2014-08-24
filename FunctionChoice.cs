/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wy¿sza Szko³a Informatyki i Zarz¹dzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Available activation functions
    /// </summary>
    public enum FunctionChoice
    {
        /// <summary>
        /// Linear neuron function
        /// </summary>
        LinearNeuron = 0,

        /// <summary>
        /// Unipolar neuron function
        /// </summary>
        UnipolarNeuron = 1,

        /// <summary>
        /// Bipolar neuron function
        /// </summary>
        BipolarNeuron = 2,

        /// <summary>
        /// Elliot's bipolar neuron function
        /// </summary>
        BipolarElliotNeuron = 3,

        /// <summary>
        /// Elliot's unipolar neuron function
        /// </summary>
        UnipolarElliotNeuron = 4
    }
}
