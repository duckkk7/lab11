using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace TestConsole 
{
    class TestCollections
    {
        private List<Team> teamList = new List<Team>();
        private List<string> stringList = new List<string>();
        private Dictionary <Team, ResearchTeam> teamResearchTeamDict = new Dictionary<Team, ResearchTeam>();
        private Dictionary <string, ResearchTeam> stringResearchTeamDict = new Dictionary<string, ResearchTeam>();

        public TestCollections(int value) 
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("Value must be more than 0 ");
            else
            {
                for (int i = 0; i <= value; i++)
                {
                    ResearchTeam simpleRt = TestCollections.Generate(i);
                    teamList.Add(simpleRt.getTeamType);
                    stringList.Add(simpleRt.ToString());
                    teamResearchTeamDict.Add(simpleRt.getTeamType, simpleRt);
                    stringResearchTeamDict.Add(simpleRt.getTeamType.ToString(), simpleRt);
                }
            }
            //TestCollections.Generate(value);
        }         

        public static ResearchTeam Generate(int val)
        {
            return new ResearchTeam("Химия и жизнь", "Сколково", val, TimeFrame.Year);
        }

        public void TickC(ResearchTeam rt)
        {
            bool f = false;
            int k1 = Environment.TickCount;
            f = teamList.Contains(rt.getTeamType);
            int k2 = Environment.TickCount;
            Console.WriteLine("Время поиска элемента в List<Team>: " + (k2-k1));

            k1 = Environment.TickCount;
            f = stringList.Contains(rt.getTeamType.ToString());
            k2 = Environment.TickCount;
            Console.WriteLine("Время поиска элемента в List<string>: " + (k2-k1));

            k1 = Environment.TickCount;
            f = teamResearchTeamDict.ContainsKey(rt.getTeamType);
            k2 = Environment.TickCount;
            Console.WriteLine("Время поиска элемента КЛЮЧА в Dictionary <Team, ResearchTeam>: " + (k2-k1));

            k1 = Environment.TickCount;
            f = stringResearchTeamDict.ContainsKey(rt.getTeamType.ToString());
            k2 = Environment.TickCount;
            Console.WriteLine("Время поиска элемента КЛЮЧА в Dictionary <string, ResearchTeam>: " + (k2-k1));

            k1 = Environment.TickCount;
            f = teamResearchTeamDict.ContainsValue(rt);
            k2 = Environment.TickCount;
            Console.WriteLine("Время поиска элемента ЗНАЧЕНИЯ в Dictionary <Team, ResearchTeam>: " + (k2-k1));

            k1 = Environment.TickCount;
            f = stringResearchTeamDict.ContainsValue(rt);
            k2 = Environment.TickCount;
            Console.WriteLine("Время поиска элемента ЗНАЧЕНИЯ в Dictionary <string, ResearchTeam>: " + (k2-k1));
        }
    }
}