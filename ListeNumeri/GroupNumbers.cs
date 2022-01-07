using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeNumeri
{
    internal class GroupNumbers
    {
        List<int> sourceNumbers;

        Dictionary<string, List<int>> Founded = new Dictionary<string, List<int>>();
        Dictionary<string, List<int>> Unfounded = new Dictionary<string, List<int>>();
        List<int> currentGroup;

        public GroupNumbers()
        {
            sourceNumbers = new List<int> { 1, 2, 3, 4, 12, 13, 14, 15, 21, 22, 23, 24, 25 };
            
            bool foundActive = false;
            bool notFoundActive = false;

            for (int i = 0; i < 30; i++)
            {
                if (sourceNumbers.Contains(i))
                {
                    notFoundActive = false;
                    if (foundActive)
                    {
                        currentGroup.Add(i);
                    }
                    if (!foundActive)
                    {
                        currentGroup = new List<int>();
                        Founded.Add("Group"+i, currentGroup); //Crea nuovo gruppo
                        foundActive=true;
                        currentGroup.Add(i);
                    }
                }
                else
                {
                    foundActive = false;
                    if (notFoundActive)
                    {
                        currentGroup.Add(i);
                    }
                    if (!notFoundActive)
                    {
                        currentGroup = new List<int>();
                        Unfounded.Add("Group" + i, currentGroup); //Crea nuovo gruppo
                        notFoundActive = true;
                        currentGroup.Add(i);
                    }
                }
            }

            //Per mostrare cosa otteniamo dal codice
            //Anche se non lo rendiamo in alcun modo a qualcosa
            //Per elaborarlo scriviamo a console

            Console.WriteLine("Found numbers");
            string sep = "";
            foreach (KeyValuePair<string,List<int>> kvp in Founded)
            {
                Console.Write(sep);
                Console.Write($"[{kvp.Key}]");
                Console.Write(" ");
                string sop = "";
                foreach (int i in kvp.Value)
                {
                    Console.Write(sop);
                    Console.Write(i);
                    sop = ", ";
                }
                sep = "; ";
            }
            Console.WriteLine();

            Console.WriteLine("Not Found numbers");
            sep = "";
            foreach (KeyValuePair<string, List<int>> kvp in Unfounded)
            {
                Console.Write(sep);
                Console.Write($"[{kvp.Key}]");
                Console.Write(" ");
                string sop = "";
                foreach (int i in kvp.Value)
                {
                    Console.Write(sop);
                    Console.Write(i);
                    sop = ", ";
                }
                sep = "; ";
            }
            Console.WriteLine();

            Console.WriteLine("Press Enter to end the program");
            Console.ReadLine();
        }
    }
}
