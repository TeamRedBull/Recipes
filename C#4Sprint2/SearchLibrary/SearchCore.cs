using System.Collections.Generic;

namespace SearchLibrary
{
    public static class SearchCore
    {
        public static bool SearchKeywords(string[] keywords, List<string> elements)
        {
            bool found = false;

            foreach (string e in elements)
            {
                foreach (string k in keywords)
                {
                    //Check if the element string is empty first
                    if (e!= null && e.Contains(k))
                    {
                        found = true;
                        //Shor circuit to increase efficiency
                        break;
                    }
                }

                if (found)
                {
                  break;
                }
            }

            return found;
        }
    }
}
