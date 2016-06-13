using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestViaticos
{
    public class BruteForce
    {
        int IntPasswordsGenerated = 0;
        public char[] CharList = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public List<int> IntList = new List<int> { 0 };

        public string GenerateString()
        {
            int Number = IntList.Count - 1;

            IntPasswordsGenerated++;
            if (IntPasswordsGenerated == 1) return CharList[0].ToString();

            do
            {
                IntList[Number]++;
                if (IntList[Number] == CharList.Length && Number == 0)
                {
                    IntList[Number] = 0;
                    IntList.Add(0);
                    break;
                }
                else if (IntList[Number] == CharList.Length)
                {
                    IntList[Number] = 0;
                    Number--;
                    continue;
                }
                else
                {
                    break;
                }
            } while (true);

            string BruteForceString = "";

            foreach (int CurrentInt in IntList)
                BruteForceString += CharList[CurrentInt];

            return BruteForceString;
        }
        public int PasswordsGenerated()
        {
            return IntPasswordsGenerated;
        }
    }
}
