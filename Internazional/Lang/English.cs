/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
namespace LearnByError.Internazional.Lang
{
    /// <summary>
    /// English language resources
    /// </summary>
    public class English
    {
        /// <summary>
        /// Resource container
        /// </summary>
        public System.Collections.Hashtable Resource { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public English()
        {
            Resource = new System.Collections.Hashtable();
            initialize();
        }

        /// <summary>
        /// Initializer
        /// </summary>
        private void initialize()
        {
            Resource["r1"] = "NBN C#";
            Resource["r2"] = "About application";
            Resource["r3"] = "Application folders";
            Resource["r4"] = "Main folder";
            Resource["r5"] = "Logs folder";
            Resource["r6"] = "Settings folder";
            Resource["r7"] = "Data folder";
            Resource["r8"] = "Settings";
            Resource["r9"] = "History";
            Resource["r10"] = "Exit";
            Resource["r11"] = "Sample data";
            Resource["r12"] = "Help";
            Resource["r13"] = "Application logs";
            Resource["r14"] = "Send message to the author";
            Resource["r15"] = "Load data from file";
            Resource["r16"] = "Start learning";
            Resource["r17"] = "Save chart";
            Resource["r18"] = "Settings";
            Resource["r19"] = "History";
            Resource["r20"] = "Close";
            Resource["r21"] = "Save chart";
            Resource["r22"] = "Sample chart";
            Resource["r23"] = "Iterations";
            Resource["r24"] = "RMSE";
            Resource["r25"] = "Bitmap";
            Resource["r26"] = "Saving chart";
            Resource["r27"] = "Chart saved as: ";
            Resource["r28"] = "Chart was not saved.";
            Resource["r29"] = "Learn error: {0}, testing error: {1}, allowed error: {2}";
            Resource["r30"] = "Save to file";
            Resource["r31"] = "Send by e-mail";
            Resource["r32"] = "Learning console";
            Resource["r33"] = "Text file";
            Resource["r34"] = "Send learn result by e-mail";
            Resource["r35"] = "Learn result -  NBN C#";
            Resource["r36"] = "OK";
            Resource["r37"] = "Enter e-mail";
            Resource["r38"] = "Application NBN C#";
            Resource["r39"] = "Options";
            Resource["r40"] = "Save chart to file";
            Resource["r41"] = "Save weights to file";
            Resource["r42"] = "Save as PDF";
            Resource["r43"] = "Previous";
            Resource["r44"] = "Next";
            Resource["r45"] = "Close";
            Resource["r46"] = "Weights";
            Resource["r47"] = "Chart";
            Resource["r48"] = "Save chart";
            Resource["r49"] = "Remove selected learn result";
            Resource["r50"] = "History";
            Resource["r51"] = "Save chart";
            Resource["r52"] = "Learn history";
            Resource["r53"] = "Learn try number ";
            Resource["r54"] = "Number of patterns used to learnd not read.";
            Resource["r55"] = "Learn result loaded";
            Resource["r56"] = "RMSE";
            Resource["r57"] = "Iterations";
            Resource["r58"] = "Bitmap";
            Resource["r59"] = "Save";
            Resource["r60"] = "Chart saved as: ";
            Resource["r61"] = "Chart was not saved.";
            Resource["r62"] = "Text file";
            Resource["r63"] = "Save";
            Resource["r64"] = "Weights not saved to file: ";
            Resource["r65"] = "Weight not saved.";
            Resource["r66"] = "do you want to remove selected learn result?";
            Resource["r67"] = "Deleting";
            Resource["r68"] = "PDF file";
            Resource["r69"] = "Saved as: ";
            Resource["r70"] = "File was not saved.";
            Resource["r71"] = "Application logs";
            Resource["r72"] = "Send errors";
            Resource["r73"] = "Thank you for feedback.";
            Resource["r74"] = "Application logs NBN C# - learning neural network";
            Resource["r75"] = "Message subject:";
            Resource["r76"] = "Message content:";
            Resource["r77"] = "Sending e-mail";
            Resource["r78"] = "Message sent.";
            Resource["r79"] = "General";
            Resource["r80"] = "Database";
            Resource["r81"] = "Remove whole learn history";
            Resource["r82"] = "Remove all logs";
            Resource["r83"] = "Number of learn trials: ";
            Resource["r84"] = "Saving learn results:";
            Resource["r85"] = "Showing console:";
            Resource["r86"] = "Application data folder";
            Resource["r87"] = "Neural network options";
            Resource["r88"] = "Scale";
            Resource["r89"] = "Maximum learning error";
            Resource["r90"] = "Maximum number of iterations";
            Resource["r91"] = "MUH - top border of MU";
            Resource["r92"] = "MUL - bottom border of MU";
            Resource["r93"] = "MU - determinates how fast weights can change during each epoch";
            Resource["r94"] = "Save changes";
            Resource["r95"] = "Load default settings";
            Resource["r96"] = "Close";
            Resource["r97"] = "Language change";
            Resource["r98"] = "Application settings";
            Resource["r99"] = "Remove all logs";
            Resource["r100"] = "Remove learn history";
            Resource["r101"] = "Logs were removed";
            Resource["r102"] = "Logs were't removed";
            Resource["r103"] = "Learn result removed";
            Resource["r104"] = "Learn result were't removed";
            Resource["r105"] = "Are you sure to remove whole learn history from database?";
            Resource["r106"] = "Deleting";
            Resource["r107"] = "Are you sure you want to load default settings?";
            Resource["r108"] = "Settings";
            Resource["r109"] = "About";
            Resource["r110"] = "Version";
            Resource["r111"] = "Version";
            Resource["r112"] = "Author";
            Resource["r113"] = "Publisher";
            Resource["r114"] = "Description";
            Resource["r115"] = "Close";
            Resource["r116"] = "About";
            Resource["r117"] = "NBN C# - learing result";
            Resource["r118"] = "Learning neural network by algorithm NBN C#";
            Resource["r119"] = "...because only good code matters.";
            Resource["r120"] = "C#, NBN, neuron, learning, network, nbn c#";
            Resource["r121"] = "Index";
            Resource["r122"] = "Learning process chart";
            Resource["r123"] = "Information about neural network";
            Resource["r124"] = "Name";
            Resource["r125"] = "Value";
            Resource["r126"] = "Weights received in learning process";
            Resource["r127"] = "Weights received in learning process for: ";
            Resource["r128"] = "Weights received in learning process for trial: ";
            Resource["r129"] = "Weight number";
            Resource["r130"] = "Weight";
            Resource["r131"] = "Learning process chart";
            Resource["r132"] = "Learning process chart for";
            Resource["r133"] = "Creation date: ";
            Resource["r134"] = "Input data";
            Resource["r135"] = "Counting error in method countIt from Manager";
            Resource["r136"] = "Connection to SQLite is dameed or closed.";
            Resource["r137"] = "Query error: ";
            Resource["r138"] = "Database cleanup error.";
            Resource["r139"] = "SQLite: ";
            Resource["r140"] = "SQL execution error in method execute from DatabaseManager: ";
            Resource["r141"] = "SQL execution error in method execute from DatabaseManager: ";
            Resource["r142"] = "Database cleanup error. ";
            Resource["r143"] = "SQLite: ";
            Resource["r144"] = "Broken";
            Resource["r145"] = "Cannot open database";
            Resource["r146"] = "Database file is broken";
            Resource["r147"] = "Access to database is restricted - file is closed.";
            Resource["r148"] = "Lack of memory.";
            Resource["r149"] = "No database file was found.";
            Resource["r150"] = "No rights to open database.";
            Resource["r151"] = "Database connection was open for read only, but write operation detected.";
            Resource["r152"] = "database structure is damaged.";
            Resource["r153"] = "SQL query is not correct or database was not located.";
            Resource["r154"] = "Database is empty";
            Resource["r155"] = "Open file";
            Resource["r156"] = "Save file";
            Resource["r157"] = "Select folder";
            Resource["r158"] = "Don't save";
            Resource["r159"] = "Save learn results";
            Resource["r160"] = "Don't show learn console";
            Resource["r161"] = "Show learn console";
            Resource["r162"] = "Save as PDF file with input data";
            Resource["r163"] = "Data not loaded, please check input data file.";
            Resource["r164"] = "Data loaded from file: ";
            Resource["r165"] = "Select input data";
            Resource["r166"] = "Input data";
            Resource["r167"] = "Learning - {0}";
            Resource["r168"] = "Testing - {0}";
            Resource["r169"] = "OK";
            Resource["r170"] = "failure";
            Resource["r171"] = "Average learn time: {0} and average test time: {1}";
            Resource["r172"] = "Success rate: {0}";
            Resource["r173"] = "Remove all logs";
            Resource["r174"] = "Removing logs";
            Resource["r175"] = "Do you want to remove all logs?";
            Resource["r176"] = "Number of neurons";
            Resource["r177"] = "Manual";
            Resource["r178"] = "Save weights";
            Resource["r179"] = "Reasearch";
            Resource["r180"] = "Run for all sample data";

            Resource["r181"] = "Number of neurons";
            Resource["r182"] = "Learn trial number: ";
            Resource["r183"] = "SSE number {0} = {1}";
            Resource["r184"] = "Learn trial number: ";
            Resource["r185"] = "RMSE number {0} = {1}";
            Resource["r186"] = "Nothing selected on the list.";
            Resource["r187"] = "Learning will begin in a minute for {0} trials with data.";
            Resource["r188"] = "Stopping...";
            Resource["r189"] = "Wait for end of currently working task end.";
            Resource["r190"] = "Select learn data filename";
            Resource["r191"] = "Learn data";
            Resource["r192"] = "Select number or trainings";
            Resource["r193"] = "Task ended";
            Resource["r194"] = "Research results";
            Resource["r195"] = "Cancelled";
            Resource["r196"] = "No file selected or file does not exist.";
            Resource["r197"] = "Research";
            Resource["r198"] = "Run for sample data";
            Resource["r199"] = "Research neural network learning";
            Resource["r200"] = "Stop research";
            Resource["r201"] = "Number of neurons";
            Resource["r202"] = "Copy to clipboard";
            Resource["r203"] = "Learning data";
            Resource["r204"] = "Number of neurons";
            Resource["r205"] = "Number of learn trials";
            Resource["r206"] = "Average testing RMSE";
            Resource["r207"] = "Average learn time";
            Resource["r208"] = "Average testing time";
            Resource["r209"] = "Copy to clipboard";
            Resource["r210"] = "Average learn RMSE";
            Resource["r211"] = "Filter by number of neurons";
            Resource["r212"] = "10 and more neurons";
            Resource["r213"] = "9 neurons";
            Resource["r214"] = "8 neurons";
            Resource["r215"] = "7 neurons";
            Resource["r216"] = "6 neurons";
            Resource["r217"] = "5 neurons";
            Resource["r218"] = "4 neurons";
            Resource["r219"] = "3 neurons";
            Resource["r220"] = "2 neurons";
            Resource["r221"] = "All";
            Resource["r222"] = "Filter by RMSE";
            Resource["r223"] = "RMSE below 0.0001";
            Resource["r224"] = "RMSE below 0.001";
            Resource["r225"] = "RMSE below 0.01";
            Resource["r226"] = "RMSE below 0.1";
            Resource["r227"] = "RMSE below 0";
            Resource["r228"] = "All";
            Resource["r229"] = "History ({0})";
            Resource["r230"] = "Learn RMSE: {0} (average)";
            Resource["r231"] = "Test RMSE: {0} (average)";
            Resource["r232"] = "Average learn time: {0}, Average test time: {1}";
            Resource["r233"] = "In traing for data from: {0} used: {1} neurons";
            Resource["r234"] = "Done";
            Resource["r235"] = "Loading";
            Resource["r236"] = "Address changed";
            Resource["r237"] = "Manual";
            Resource["r238"] = "2 neurons";
            Resource["r239"] = "What is the maximum number of neurons that can neural network use for test?";
            Resource["r240"] = "3 neurons";
            Resource["r241"] = "4 neurons";
            Resource["r242"] = "7 neurons";
            Resource["r243"] = "6 neurons";
            Resource["r244"] = "5 neurons";
            Resource["r245"] = "10 neurons";
            Resource["r246"] = "9 neurons";
            Resource["r247"] = "8 neurons";
            Resource["r248"] = "Cancel";
            Resource["r249"] = "Maximum number of neurons";
            Resource["r250"] = "Select number of repeats:";
            Resource["r251"] = "Selection of repeats";
            Resource["r252"] = "Number of repeats for each file:";
            Resource["r253"] = "Maximum number of neurons ";
            Resource["r254"] = "that can be used for tests:";
            Resource["r255"] = "Number of files taking part in research:";
            Resource["r256"] = "Run";
            Resource["r257"] = "Generate PDF file for each training";
            Resource["r258"] = "Select forlder with files";
            Resource["r259"] = "Load samples";
            Resource["r260"] = "Research of learning neural network";
            Resource["r261"] = "Downloaded {0} from {1}";
            Resource["r262"] = "Loading samples started.";
            Resource["r263"] = "Wait while loading samples takes place.";
            Resource["r264"] = "Learning data: {0}\r\nNumber of neurons: {1}\r\nNumber of trials: {2}\r\nAverage learn RMSE: {3}\r\nAverage test RMSE: {4}\r\nAverage learn time: {5}\r\nAverage test time: {6}\r\n\r\n";
            Resource["r265"] = "C# NBN algorithm implementation used for learning neural networks with its modifications.";
        }
    }
}
