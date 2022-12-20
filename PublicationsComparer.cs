using System;
using System.Collections;
using System.Collections.Generic;
namespace TestConsole 
{
    class PublicationsComparer : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam rt1, ResearchTeam rt2)
        {
            if (rt1.Papers.Count > rt2.Papers.Count) 
                return 1;
            if (rt1.Papers.Count < rt2.Papers.Count)
                return -1;
            else
                return 0;
        }
    }
}