using System;
using System.Collections;
namespace TestConsole 
{
    class Team : INameAndCopy, IComparable
    {
        protected string organization;
        protected int regNum;

        public Team(string org, int regnum)
        {
            this.organization = org;
            this.regNum = regnum;
        }

        public Team()
        {
            this.organization = "33 cows";
            this.regNum = 12345;
        }

        public string Organization
        {
            get
            { return organization; }   
            set
            { organization = value;}  
        }
        public int RegNum
        {
            get
            { return regNum; }   
            set
            { 
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Registration number must be more than 0 ");
                else 
                    regNum = value;
            }
        }
        string INameAndCopy.Name
        {
            get
            {
                return string.Format("Team of organisation {0} with registration number {1}", organization, regNum);
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual object DeepCopy()
        {
            Team teamCopy = new Team(this.Organization, this.RegNum);
            return teamCopy;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Team objTeam = obj as Team;
            if (obj as Team == null)
                return false;
            return objTeam.Organization.Equals(organization) && objTeam.RegNum.Equals(regNum);
        }

        public static bool operator ==(Team t1, Team t2)
        {
            if (ReferenceEquals(t1, null) && ReferenceEquals(t2, null)) 
                return true; 
            else if (ReferenceEquals(t1, null) || ReferenceEquals(t2, null)) 
                return false; 
            if (ReferenceEquals(t1, t2))
                return true;
            return t1.Organization.Equals(t2.Organization) && t1.RegNum.Equals(t2.RegNum);
        }

        public static bool operator !=(Team t1, Team t2)
        {
            if (ReferenceEquals(t1, null) && ReferenceEquals(t2, null)) 
                return false; 
            else if (ReferenceEquals(t1, null) || ReferenceEquals(t2, null)) 
                return true; 
            if (ReferenceEquals(t1, t2))
                return false;
            if (t1.Organization.Equals(t2.Organization) && t1.RegNum.Equals(t2.RegNum))
                return false;
            else 
                return true;
        }

        public override int GetHashCode()
        {
            int hashcode = 0;
            char[] NameChar = organization.ToCharArray();
            foreach (char ch in NameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            hashcode += regNum;
            return hashcode;
        }

        public override string ToString()
        {
            return organization + " " + regNum;
        }

        public int CompareTo(object o)
        {
            Team t = o as Team;
            if (t != null)
                return this.RegNum.CompareTo(t.RegNum);
            else
                throw new Exception("Невозможно сравнить два объекта");
        } 

    }
}

