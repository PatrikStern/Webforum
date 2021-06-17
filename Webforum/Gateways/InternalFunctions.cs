using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webforum.Gateways
{
    public class InternalFunctions
    {
        public static string FaultWordChecker(string wordsToCheck)
        {
            var curseWords = ListOfCurseWords.CurseWords();
            var wordhandler = wordsToCheck.Split(' ');
            wordsToCheck = "";

            for (int i = 0; i < wordhandler.Count(); i++)
            {
                for (int j = 0; j < curseWords.Count(); j++)
                {
                    if (wordhandler[i] == curseWords[j])
                    {
                        var wordChar = wordhandler[i].ToCharArray();
                        wordhandler[i] = "";
                        foreach (var Char in wordChar)
                        {
                            wordhandler[i] += "*";
                        }
                    }
                }
            }

            foreach (var word in wordhandler)
            {
                wordsToCheck += " " + word;
            }

            return wordsToCheck;
        }
    }

    public class ListOfCurseWords
    {
        public static List<string> CurseWords()
        {
            List<string> curseWords = new List<string>();

            curseWords.Add("Jävlar");
            curseWords.Add("Fan");
            curseWords.Add("Helvete");

            return curseWords;
        }

    }
}
