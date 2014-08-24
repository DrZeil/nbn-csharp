/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Matrix operation exception
    /// </summary>
    public class MatrixException : System.Exception
    {
        /// <summary>
        /// Matrix operation exception
        /// </summary>
        public MatrixException()
        {
        }

        /// <summary>
        /// Matrix operation exception
        /// </summary>
        /// <param name="message">String - message</param>
        public MatrixException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Matrix operation exception
        /// </summary>
        /// <param name="message">String - message</param>
        /// <param name="inner">System.Exception - exception</param>
        public MatrixException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
