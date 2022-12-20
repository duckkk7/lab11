using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace TestConsole 
{
    class ResearchTeamCollection
    {
        private List<ResearchTeam> researchTeams = new List<ResearchTeam>();

        public string CollectionName { get; set; }
        public int MinRegNum
        {
            get 
            { 
                if (researchTeams.Count == 0)
                    return 0;
                else
                    return (researchTeams.Min(researchTeam => researchTeam.RegNum)); 
            }
        }
 
        public IEnumerable<ResearchTeam> TwoYearsDuration
        {
            get
            { 
                IEnumerable<ResearchTeam> query = researchTeams.Where(researchTeam => researchTeam.Duration == TimeFrame.TwoYears);
                return query;
            }
        }
        public delegate void TeamListHandler (object source, TeamListHandlerEventArgs args);
        public event TeamListHandler ResearchTeamAdded;
        public event TeamListHandler ResearchTeamInserted;


        public void InsertAt(int j, ResearchTeam rt)
        {
            if (j > researchTeams.Count) 
            {
                researchTeams.Add(rt);
                ResearchTeamAdded(researchTeams[researchTeams.Count-1], new TeamListHandlerEventArgs(this.CollectionName, "Last element added", researchTeams.Count - 1));
            }
            else 
            {
                researchTeams.Insert(j, rt);
                ResearchTeamInserted(researchTeams[j], new TeamListHandlerEventArgs(this.CollectionName, "Element was added", j));
            }
        }

        public ResearchTeam this[int i]
        {
            get { return researchTeams[i]; }
            set { researchTeams[i] = value; }
        }





        public List<ResearchTeam> NGroup(int value)
        {
            List<ResearchTeam> RT = researchTeams.Where(researchTeam => researchTeam.Persons.Count == value).ToList();
            return RT;
        }

        public void AddDefaults()
        {
            researchTeams.AddRange(new List<ResearchTeam>() {new ResearchTeam("Аниме", "Анимелюбители", 150, TimeFrame.Year), new ResearchTeam("Современная литература", "Клуб любителей", 15, TimeFrame.TwoYears), new ResearchTeam()}); 
            researchTeams[0].Papers.Add(new Paper("Барышня-крестьянка", "Alexandr Pushkin", new DateTime(1444, 05, 30)));
            researchTeams[0].Persons.Add(new Person("Alexandr", "Pushkin", new DateTime(1400, 10, 12)));
            researchTeams[1].Papers.Add(new Paper("Мертвые души", "Николай Гоголь", new DateTime(1444, 05, 30)));
            researchTeams[1].Papers.Add(new Paper("Станционный смотритеть", "Sasha Pushkin", new DateTime(1488, 06, 28)));
            researchTeams[1].Persons.Add(new Person("Николай", "Гоголь", new DateTime(1784, 11, 25)));
            researchTeams[1].Persons.Add(new Person("Sasha", "Pushkin", new DateTime(1400, 10, 12)));
            ResearchTeamAdded(researchTeams[researchTeams.Count-1], new TeamListHandlerEventArgs(this.CollectionName, "Last element added", 2));
        }

        public void AddResearchTeams(params ResearchTeam[] teams)
        {
            researchTeams.AddRange(teams);
            ResearchTeamAdded(researchTeams[researchTeams.Count-1], new TeamListHandlerEventArgs(this.CollectionName, "Last element added", researchTeams.Count-1));
        }

        public override string ToString()
        {
            string s = "";
            foreach (ResearchTeam r in researchTeams)
            {
                s += r.ToString() + "\n";
            }
            return s;
        }

        public virtual string ToShortString()
        {
            string s = "";
            foreach (ResearchTeam r in researchTeams)
            {
                s += r.ToShortString() + "\nЧисло публикаций: " + r.Papers.Count +"\nЧисло участников: "+ r.Persons.Count + "\n";
            }
            return s;
        }

        public void OrderByRegNum()
        {
            researchTeams.Sort((x, y) => x.CompareTo(y));
        }

        public void OrderByTheme()
        {
            researchTeams.Sort((x, y) => x.Compare(x, y)); 
        }

        public void OrderByPubclicationsCount()
        {
            researchTeams.Sort(new PublicationsComparer());
        }



    }
}