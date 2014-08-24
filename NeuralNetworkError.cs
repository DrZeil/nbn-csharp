/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Neural network exception
    /// </summary>
    public class NeuralNetworkError : System.Exception
    {
        /// <summary>
        /// Default neural network exception constructor
        /// </summary>
        public NeuralNetworkError()
        {
        }

        /// <summary>
        /// Neural network exception
        /// </summary>
        /// <param name="message">String - message</param>
        public NeuralNetworkError(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Neural network exception
        /// </summary>
        /// <param name="message">String - message</param>
        /// <param name="inner">Exception - exception</param>
        public NeuralNetworkError(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
