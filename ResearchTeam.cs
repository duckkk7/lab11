using System;
using System.Collections.Generic;
using System.Collections;
namespace TestConsole 
 {
    class ResearchTeam : Team, INameAndCopy, IComparer<ResearchTeam>
    {
        private string theme;
        //private string organization;
        //private int regNum;
        private TimeFrame duration;
        public TimeFrame Duration
        {
            get
            { return duration; }
            set 
            { duration = value; }
        }
        //private List<Paper> papers = new List<Paper>(); 
        //private System.Collections.ArrayList persons = new ArrayList();
        //private System.Collections.ArrayList papers = new ArrayList();

        private List<Person> persons = new List<Person>();
        private List<Paper> papers = new List<Paper>();


        public ResearchTeam(string theme, string org, int regnum, TimeFrame duration)
        {
            this.theme = theme;
            this.organization = org;
            this.regNum = regnum;
            this.duration = duration;
        }

        public ResearchTeam() : this("Химия и жизнь", "Сколково", 11005, TimeFrame.Year) {}

        public string Theme
        {
            get
            { return theme; }   
            set
            { theme = value;}  
        }

        public List<Paper> Papers
        {
            get
            { return papers; } 
            set
            { papers = value; }
        }

        public List<Person> Persons
        {
            get
            { return persons; } 
            set
            { persons = value; }
        }

        public Team getTeamType
        {
            get
            { return new Team(Organization, RegNum); }
            set
            { 
                this.Organization = value.Organization; 
                this.RegNum = value.RegNum;
            }
        }
        public bool this[TimeFrame time]
        {
            get 
            {
                return (duration == time);
            }
        }

        public void AddMembers(params Person[] persons)
        {
            Persons.AddRange(persons);
        }

        public void AddPapers(params Paper[] papers)
        {
            Papers.AddRange(papers);
        }

        public override string ToString()
        {
            string s = this.ToShortString() + "\nСписок публикаций:\n";
            foreach (Paper p in papers)
            {
                s += p.ToString() + "\n";
            }

            s += "\nСписок участников проекта:\n";
            foreach (Person p in persons)
            {
                s += p.ToString() + "\n";
            }
            return s;
        }

        public virtual string ToShortString()
        {
            return theme + " " + organization + " " + regNum + " " + duration.ToString();
        }
        public override object DeepCopy()
        {
            ResearchTeam copyTeam = new ResearchTeam(this.theme, this.Organization, this.RegNum, this.duration);
            copyTeam.persons = persons;
            copyTeam.papers = papers; 
            return copyTeam;
        }
        public IEnumerable<Person> GetPersonsWithoutP()
        {
            System.Collections.ArrayList PersonsWithoutP = new ArrayList();
            bool f;
            foreach (Person person in persons)
            {
                f = true;
                foreach (Paper p in papers)
                {
                    string yadura = person.Name + " " + person.Surname;
                    if (p.Author.Equals(yadura))
                    {
                        f = false;
                        break;
                    }
                }
                if (f)
                    PersonsWithoutP.Add(person);
                    //Console.WriteLine(pers.ToShortString());
            }
            for (int i = 0; i < PersonsWithoutP.Count; i++) 
            {
                yield return (Person)PersonsWithoutP[i];
                //Console.Write(((Person)AutorsWithoutP[i]).ToShortString());
            }
        }

        public IEnumerable<Paper> LastPublications(int n)
        {
            for (int i = 0; i < papers.Count; i++) 
            {
                if (((Paper)papers[i]).Dt.Year >= DateTime.Now.Year - n)
                    yield return (Paper)papers[i];
                    //Console.Write(((Paper)Publications[i]).ToString());
            }
        } 

        public int Compare(ResearchTeam rt1, ResearchTeam rt2)
        {
            return String.Compare(rt1.Theme, rt2.Theme);
        }
  
    } 
}