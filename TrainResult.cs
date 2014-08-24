namespace LearnByErrorLibrary
{
    /// <summary>
    /// Train result
    /// </summary>
    public class TrainResult
    {
        /// <summary>
        /// Weigths - trained weights
        /// </summary>
        public Weights weights { get; set; }

        /// <summary>
        /// Number of iterations
        /// </summary>
        public int iterations { get; set; }

        /// <summary>
        /// Received SSE
        /// </summary>
        public double sse { get; set; }
    }
}
