/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System.Linq;
namespace LearnByError
{
    public class AnalyseNBN
    {
        private System.Collections.Generic.List<LearnByErrorLibrary.LearnResult> results = new System.Collections.Generic.List<LearnByErrorLibrary.LearnResult>();
        public AnalyseNBN() { }

        public void LoadResultsIntoMemory() 
        {        
            var histories = LearnByError.Database.Tables.History.ReadAll();            
            System.Threading.Tasks.Parallel.ForEach(histories, history =>
            {
                var result = marekbar.Xml.Deserialize<LearnByErrorLibrary.LearnResult>(history.Data);
                results.Add(result);
            });
        }

        private System.Collections.Generic.List<LearnByErrorLibrary.LearnResult> GetByNumberOfNeurons(int numberOfNeurons)
        {
            return results.Where(q => q.Info.nn == numberOfNeurons).ToList();
        }
    }
}
