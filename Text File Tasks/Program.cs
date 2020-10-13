using System;
using System.Collections.Generic;
using System.IO;

namespace Text_File_Tasks
{
    class Program
    {
        static void Main()
        {
            StationsAnalysis();
        }

        static void WriteToFile()
        {
            Console.Write("Enter the filename: ");
            string fileName = "FileWritingTask/" + Console.ReadLine();
            if(fileName[fileName.Length - 4]!='.' || fileName[fileName.Length - 3] != 't' || fileName[fileName.Length - 2] != 'x' || fileName[fileName.Length - 1] != 't')
            {
                fileName += ".txt";
            }
            StreamWriter fileStr;
            if (! File.Exists(fileName))
            {
                fileStr = File.CreateText(fileName);
            }
            else
            {
                fileStr = File.AppendText(fileName);
            }
            Console.WriteLine("Enter an empty string to exit loop");
            string line;
            do
            {
                line = Console.ReadLine();
                if (line != "")
                {
                    fileStr.WriteLine(line);
                }
            } while (line != "");
            fileStr.Close();
        }

        static void GenerateRandomInts(int numberOfRandomInts, int upperLimit)
        {
            Random randomSeed = new Random();
            string fileName = "RandomIntsTask/unsorted.txt";
            StreamWriter fileStr = File.CreateText(fileName);
            for (int i = 0; i < numberOfRandomInts; i++)
            {
                fileStr.WriteLine(randomSeed.Next(1, upperLimit + 1));
            }
            fileStr.Close();
        }

        static void SortRandomInts()
        {
            string unsortedFileName = "RandomIntsTask/unsorted.txt";
            string sortedFileName = "RandomIntsTask/sorted.txt";
            StreamReader unsortedFile = File.OpenText(unsortedFileName);
            StreamWriter sortedFile = File.CreateText(sortedFileName);
            List<int> numbers = new List<int> { };
            string line;
            do
            {
                line = unsortedFile.ReadLine();
                if (line != null)
                {
                    numbers.Add(int.Parse(line));
                }
            } while (line != null);
            unsortedFile.Close();
            numbers.Sort();
            for(int i = 0; i<numbers.Count; i++)
            {
                sortedFile.WriteLine(numbers[i]);
            }
            sortedFile.Close();
        }

        static bool CompareWords(string word1, string word2)
        {
            bool word = true;
            bool letter;
            for (int a = 0; a < word2.Length; a++)
            {
                letter = false;
                for (int b = 0; b < word1.Length; b++)
                {
                    if (word2[a] == word1[b])
                    {
                        letter = true;
                    }
                }
                if (!letter)
                {
                    word = false;
                }
            }
            return word;
        }

        static void StationsAnalysis()
        {
            string stationsFileName = "StationsTask/stations.txt";
            string analysisFileName = "StationsTask/analysis.txt";
            StreamReader stationsFile = File.OpenText(stationsFileName);
            StreamWriter analysisFile = File.CreateText(analysisFileName);
            List<string> stations = new List<string> { };
            string line;
            do
            {
                line = stationsFile.ReadLine();
                string station = "";
                if (line != null)
                {
                    for(int i = 0; i<line.Length; i++)
                    {
                        if (line[i] != ',')
                        {
                            station += line[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                    stations.Add(station);
                }
            } while (line != null);
            stationsFile.Close();
            List<string> mackerelComparisons = new List<string> { "\nStations sharing no letters with Mackerel:\n" };
            List<string> piranhaComparisons = new List<string> { "\nStations sharing no letters with Piranha:\n" };
            List<string> sturgeonComparisons = new List<string> { "\nStations sharing no letters with Sturgeon:\n" };
            List<string> bacteriaComparisons = new List<string> { "\nStations sharing no letters with Bacteria:\n" };
            List<string> twoWordsSameFirstLetter = new List<string> { "\nStations with two words that have the same first letter:\n" };
            for (int i = 0; i<stations.Count; i++)
            {
                if (CompareWords(stations[i],"mackerel"))
                {
                    mackerelComparisons.Add(stations[i] + "\n");
                }
                if (CompareWords(stations[i], "piranha"))
                {
                    piranhaComparisons.Add(stations[i] + "\n");
                }
                if (CompareWords(stations[i], "sturgeon"))
                {
                    sturgeonComparisons.Add(stations[i] + "\n");
                }
                if (CompareWords(stations[i], "bacteria"))
                {
                    bacteriaComparisons.Add(stations[i] + "\n");
                }
                for(int a = 0; a < stations[i].Length; a++)
                {
                    if(stations[i][a]==' ')
                    {
                        if(stations[i][0] != stations[i][a + 1])
                        {
                            break;
                        }
                        twoWordsSameFirstLetter.Add(stations[i] + "\n");
                        
                    }
                }
            }
            List<List<string>> analysisText = new List<List<string>> {
                mackerelComparisons,
                piranhaComparisons,
                sturgeonComparisons,
                bacteriaComparisons,
                twoWordsSameFirstLetter};
            analysisFile.WriteLine("Stations Analysis:");
            for(int a = 0; a<analysisText.Count; a++)
            {
                for (int b = 0; b < analysisText[a].Count; b++)  
                {
                    analysisFile.Write(analysisText[a][b]);
                }
            }
            analysisFile.Close();
        }
    }
}
