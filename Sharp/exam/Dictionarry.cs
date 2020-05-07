using System;
using System.Collections.Generic;
using System.Text;

namespace exam
{
    class Dictionarry
    {
        string[] english = new string[100];
        string[] russian = new string[100];
        string[] ukrainianR = new string[100];
        string[] ukrainianE = new string[100];


        public void AddRus(string r, string u)
        {
           
            if (russian.Length > 1)
            {
                russian[russian.Length - 1] = r;
                ukrainianR[ukrainianR.Length - 1] = u;
            }
            else
            {
                russian[1] = r;
                ukrainianR[1] = u;
            }
        }
        public void AddEng(string e, string u)
        {
            if (russian.Length > 1)
            {
                english[english.Length - 1] = e;
                ukrainianE[ukrainianE.Length - 1] = u;
            }
            else
            {
                english[1] = e;
                ukrainianE[1] = u;
            }
        }
        public void GetUkrEng(string u)
        {
            try
            {
                bool k = false;
                for (int i = 0; i < ukrainianE.Length; i++)
                {
                    if (ukrainianE[i] == u)
                    {
                        k = true;
                        Console.WriteLine(english[i]);
                    }
                }
                if(!k)
                {
                    throw new Exception("!!!nothing found!!!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GetUkrRus(string u)
        {
            try
            {
                bool k = false;
                for (int i = 0; i < ukrainianR.Length; i++)
                {
                    if (ukrainianR[i] == u)
                    {
                        k = true;
                        Console.WriteLine(russian[i]);
                    }
                }
                if (!k)
                {
                    throw new Exception("!!!nothing found!!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
