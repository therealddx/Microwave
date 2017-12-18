using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Microwave
{
    class ImportData
    {
        public const string OutputDataPath = "C:\\Users\\Mehdy Faik\\Desktop\\Work\\Work\\Side Hustles\\Microwave\\Microwave\\Microwave\\Data\\Draft_processed.csv";
        
        public static double ParseScientificNotation(string num)
        {
            //1.00630063006301e+007
        
            double x;
            double.TryParse(SubstringProperly(num, 0, num.IndexOf("E", 0, num.Length, StringComparison.OrdinalIgnoreCase)), out x);
        
            int tothe;
            int.TryParse(num.Substring(num.IndexOf('e') + 1, 4), out tothe);

            return x * Math.Pow(10.0, tothe);
        }
        public static double ParseTestParameter(string num)
        {
            double val = 0;
            if (Double.TryParse(num, out val)) //Try normally
            {
                return val;
            }
            else //Clip last
            {
                char c = num.Last();
                num = num.Replace(c.ToString(), "");
                Double.TryParse(num, out val);

                switch (c)
                {
                    case 'm':
                        val = MenialOperations.m;
                        return val;
                    case 'u':
                        val = MenialOperations.u;
                        return val;
                    case 'n':
                        val = MenialOperations.n;
                        return val;
                    case 'p':
                        val = MenialOperations.p;
                        return val;
                    case 'f':
                        val = MenialOperations.f;
                        return val;
                    default:
                        return val;
                }
            }
        }
        
        public static XY ReadCSVtoXY(string csvPath)
        {
            //csv MUST HAVE TWO COLUMNS EXACTLY.

            string curLine = "";
            string[] curLineToElements;

            bool numberRow = false;
            int numRows = 0;
            int curRow = 0;

            double d = 0; //dummy

            //Count numRows.
            using (StreamReader fr = new StreamReader(csvPath))
            {
                while (!fr.EndOfStream)
                {
                    curLine = fr.ReadLine();
                    curLineToElements = curLine.Trim().Split(',');

                    if (Double.TryParse(curLineToElements[0], out d))
                    {
                        numRows++;
                    }
                }
            }

            double[] xvals = new double[numRows];
            double[] yvals = new double[numRows];
            using (StreamReader fr = new StreamReader(csvPath))
            {
                while (!fr.EndOfStream)
                {
                    curLine = fr.ReadLine();
                    curLineToElements = curLine.Trim().Split(',');

                    if (Double.TryParse(curLineToElements[0], out d))
                    {
                        Double.TryParse(curLineToElements[0], out xvals[curRow]);
                        Double.TryParse(curLineToElements[1], out yvals[curRow]);
                        curRow++;
                    }

                }
            }
            return new Microwave.XY(xvals, yvals);
        }
        public static double[,] ReadCSVtoDoubleArray(string csvPath)
        {
            //Just take column for column from the csv and put it in a double[,].

            //First block: Count numRows and numCols.
            int numCols = 0;
            int numRows = 0;
            using (StreamReader sr = new StreamReader(csvPath))
            { 
                string s = "";

                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    numCols = s.Count(x => x.Equals(','));
                    numRows++;
                }
            }
            double[,] table = new double[numRows, numCols];

            //Second block: Read double values.
            using (StreamReader sr = new StreamReader(csvPath))
            {
                string s = "";
                string[] sToArray;
                int curCol = 0;
                int curRow = 0;
                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    sToArray = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (curCol = 0; curCol < table.GetLength(1); curCol++)
                    {
                        double.TryParse(sToArray[curCol], out table[curRow, curCol]);
                    }
                    curRow++;
                }
            }

            return table;
        }

        #region Ad-hoc functions.
        public static XY LTSpiceVaractorImport(string path, string pathOut)
        {
            //String.
            string DataHeader = "Step Information:";
            string curLine;

            //Numerical.
            int numRuns = -1;
            int curRun = 0;
            double MaxGainForRun = Double.MinValue;
            double MaxGainFreqForRun = Double.MinValue;
            double CurFreq = Double.MinValue;
            string CurFreqString = "";
            double CurGain = Double.MinValue;
            string CurGainString = "";
            double[] TestVoltages = new double[1];
            double[] ResonantFrequencies = new double[1];
            double[] VaractorCapacitances = new double[1];

            //Circuit constants.
            double L = 2000 * MenialOperations.n;
            double C1 = 10 * MenialOperations.p;
            double C2 = 10 * MenialOperations.p;

            //Open stream to target file.
            System.IO.StreamReader fr = new System.IO.StreamReader(path);

            while (!fr.EndOfStream)
            {
                curLine = fr.ReadLine();

                //Case 1: Very first occurrence of DataHeader.
                if (curLine.Contains(DataHeader) && numRuns == -1)
                {
                    int.TryParse(curLine.Substring(curLine.IndexOf('/') + 1, curLine.IndexOf(')') - curLine.IndexOf('/') - 1), out numRuns);

                    TestVoltages = new double[numRuns];
                    TestVoltages[0] = ParseTestParameter(MenialOperations.SubstringProperly(curLine, curLine.IndexOf('=') + 1, curLine.IndexOf('(')).Trim());

                    ResonantFrequencies = new double[numRuns];
                    VaractorCapacitances = new double[numRuns];
                }
                //Case 2: Non-first occurrence of DataHeader.
                else if (curLine.Contains(DataHeader))
                {
                    //Store necessary data.
                    ResonantFrequencies[curRun] = MaxGainFreqForRun;
                    TestVoltages[curRun + 1] = ParseTestParameter(MenialOperations.SubstringProperly(curLine, curLine.IndexOf('=') + 1, curLine.IndexOf('(')).Trim());

                    //Reset maxes.
                    MaxGainForRun = Double.MinValue; //New run -> Recorded max gain from previous run is now obsolete
                    MaxGainFreqForRun = Double.MinValue;
                    curRun++; //New run -> new test voltage -> new resonant frequency -> new varactor capacitance.
                }
                //Case 3: Dealing with number.
                else if (curLine.Contains("dB"))
                {
                    //Getting freq.
                    //Take substring from [0] to ind(e) + 5.
                    CurFreqString = MenialOperations.SubstringProperly(curLine, 0, curLine.IndexOf('e') + 5);
                    CurFreq = ParseScientificNotation(CurFreqString);

                    curLine = curLine.Replace(CurFreqString, ""); //Chop it off.

                    //Getting gain.
                    //Take substring from [ind('(') + 1] to ind(e) + 5.
                    CurGainString = MenialOperations.SubstringProperly(curLine, curLine.IndexOf('(') + 1, curLine.IndexOf('e') + 5);
                    CurGain = ParseScientificNotation(CurGainString);

                    if (CurGain > MaxGainForRun)
                    {
                        MaxGainFreqForRun = CurFreq;
                        MaxGainForRun = CurGain;
                    }
                }
            }
            //Case 4: End of file.
            ResonantFrequencies[curRun] = MaxGainFreqForRun;

            //Calculate varactor capacitances from resonant frequencies in test circuit.
            for (int n = 0; n < ResonantFrequencies.Length; n++)
            {
                double combinedCaps = MenialOperations.Parallel(C1, C2);
                double inductiveResonanceFactor = 1.0 / ((2.0 * Math.PI * ResonantFrequencies[n]) * (2.0 * Math.PI * ResonantFrequencies[n]) * L);

                VaractorCapacitances[n] = (combinedCaps * inductiveResonanceFactor) / (combinedCaps - inductiveResonanceFactor);
            }

            //Now print.
            //Debug.WriteLine("Voltage, Resonant Frequency, Capacitance");
            //Console.WriteLine("Voltage, Resonant Frequency, Capacitance");
            //for (int n = 0; n < ResonantFrequencies.Length; n++)
            //{
            //    Debug.WriteLine(TestVoltages[n] + ", " + ResonantFrequencies[n] + ", " + VaractorCapacitances[n]);
            //    Console.WriteLine(TestVoltages[n] + ", " + ResonantFrequencies[n] + ", " + VaractorCapacitances[n]);
            //}
            using (StreamWriter fw = new StreamWriter(pathOut))
            {
                fw.WriteLine("Voltage, Varactor Capacitance");
                for (int n = 0; n < ResonantFrequencies.Length; n++)
                    fw.WriteLine(TestVoltages[n] + ", " + VaractorCapacitances[n]);
            }

            //Return.
            XY Cj = new Microwave.XY(TestVoltages, VaractorCapacitances);
            return Cj;

            //Find number of runs.
            //Allocate this # of resFreq terms.

            //Also fill out vector for v.

            //For each line in the file:
            //If it says "Step Information", get this value for v.
            //Get the magnitude value. (dB)
            //If it's greater than the previous magnitude value:
            //Store it.
            //Also store the freq.
            //Else, move to the next line.

            //For each resFreq term:
            //Convert this resFreq to the respective capacitance.
        }
        #endregion
    }

    class ExportData
    {
        public static void WriteXYtoCSV(string csvPath, XY xy)
        {
            using (StreamWriter fw = new StreamWriter(csvPath))
            {
                for (int n = 0; n < xy.N; n++)
                {
                    fw.WriteLine(xy.x.v[n] + ", " + xy.y[n]);
                }
            }
        }
        public static void WriteDoubleArrayToCSV(string csvPath, double[,] mat)
        {
            using (StreamWriter sw = new StreamWriter(csvPath, false))
            {
                for (int curRow = 0; curRow < mat.GetLength(0); curRow++)
                {
                    for (int curCol = 0; curCol < mat.GetLength(1); curCol++)
                    {
                        sw.Write(mat[curRow, curCol] + ", ");
                    }
                    sw.Write("\n");
                }
            }
        }
        public static int AppendXYtoCSV(string csvPath, XY xy)
        {
            string s = "";
            bool overwrite = false;
            double[,] arrayOut = new double[1,1];

            //If the file doesn't exist, create it.
            if (!File.Exists(csvPath))
            {
                using (StreamWriter sw = new StreamWriter(csvPath, false))
                {
                    sw.Write("");
                }
            }
            
            using (StreamReader sr = new StreamReader(csvPath))
            {
                s = sr.ReadLine();
                if (String.IsNullOrEmpty(s)) //Empty file -> plot full XY.
                {
                    overwrite = false;
                }
                else //Non-empty file -> read what's there, tack on XY, and overwrite.
                {
                    double[,] curTable = ImportData.ReadCSVtoDoubleArray(csvPath);
                    arrayOut = new double[curTable.GetLength(0), curTable.GetLength(1) + 1];
                    MenialOperations.copy_matrix(curTable, arrayOut);
                    for (int curRow = 0; curRow < xy.N; curRow++)
                    {
                        arrayOut[curRow, arrayOut.GetLength(1) - 1] = xy.y[curRow];
                    }

                    overwrite = true;
                }
            }
            if (!overwrite)
            {
                WriteXYtoCSV(csvPath, xy);
                return 0;
            }
                
            else
            {
                WriteDoubleArrayToCSV(csvPath, arrayOut);
                return 0;
            }

            //If there is something here:
                //read in everything
                //add XY.y as a column
                //put everything back out
        }

        /*Test code: ReadCSVtoDoubleArray(). WriteDoubleArraytoCSV(). AppendXYtoCSV().
            //Two paths.
            string csvPath = "C:\\Users\\Mehdy Faik\\Desktop\\Work\\Work\\Side Hustles\\Microwave\\Microwave\\simpletest.csv";
            string csvPath2 = "C:\\Users\\Mehdy Faik\\Desktop\\Work\\Work\\Side Hustles\\Microwave\\Microwave\\simpletest2.csv";
            string csvPath3 = "C:\\Users\\Mehdy Faik\\Desktop\\Work\\Work\\Side Hustles\\Microwave\\Microwave\\simpletest3.csv";

            //Test ability to read CSV from double array.
            double[,] table = ImportData.ReadCSVtoDoubleArray(csvPath);
            MenialOperations.print_matrix(table);

            //Test ability to write double array to CSV.
            ExportData.WriteDoubleArrayToCSV(csvPath2, table);
            
            ////Test ability to append XY onto CSV, empty or not.
            XY testXY = new Microwave.XY(new Microwave.LinearSpace(0, 1, 3));
                testXY.y[0] = 1.0;
                testXY.y[1] = 2.0;
                testXY.y[2] = 3.0;
            ExportData.AppendXYtoCSV(csvPath, testXY);
            ExportData.AppendXYtoCSV(csvPath3, testXY);
            */
    }
}
