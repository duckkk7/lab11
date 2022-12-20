using System;
using System.Collections;
namespace TestConsole 
{    
    class Person
    {   
        private string name;
        private string surname;
        private System.DateTime wasBorn;

        public Person(string name, string surname, DateTime wasBorn)
        {
            this.name = name;
            this.surname = surname;
            this.wasBorn = wasBorn;
        }
        public Person()
        {
            this.name = "Boris";
            this.surname = "Gaidukov";
            this.wasBorn = new DateTime(2003, 2, 1);
        }

        public string Name
        {
            get
            { return name; }   
            set
            { name = value;}  
        }
        public string Surname
        {
            get
            { return surname; }   
            set
            { surname = value;}  
        }
        public DateTime WasBorn
        {
            get
            { return wasBorn; }   
            set
            { wasBorn = value;}  
        }
        public int DateYear
        {
            get
            { return wasBorn.Year; }   
            set
            { 
                DateTime newDt = new DateTime(value, wasBorn.Month, wasBorn.Day);
                wasBorn = newDt;
            }  
        }

        public override string ToString()
        {
            return name + " " + surname + " " + wasBorn.ToString();
        }
        public virtual string ToShortString()
        {
            return name + " " + " " + surname;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Person objPers = obj as Person;
            if (obj as Person == null)
            {
                return false;
            }
            return objPers.Name.Equals(name) && objPers.Surname.Equals(surname) && objPers.WasBorn.Equals(wasBorn);
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }
            if ((object)p1 == null || (object)p2 == null)
            {
                return false;
            }
            return p1.Name.Equals(p2.Name) && p1.Surname.Equals(p2.Surname) && p1.WasBorn.Equals(p2.WasBorn);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }
            if ((object)p1 == null || (object)p2 == null)
            {
                return false;
            }
            if (p1.Name.Equals(p2.Name) && p1.Surname.Equals(p2.Surname) && p1.WasBorn.Equals(p2.WasBorn))
                return false;
            else 
                return true;
        }

        public override int GetHashCode()
        {
            int hashcode = 0;
            char[] NameChar = name.ToCharArray();
            foreach (char ch in NameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            char[] SurnameChar = surname.ToCharArray();
            foreach (char ch in SurnameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            hashcode += wasBorn.Year * wasBorn.Month;
            return hashcode;
        }
        public virtual object DeepCopy()
        {
            Person persCopy = new Person(this.Name, this.Surname, this.WasBorn);
            return persCopy;
        }
    }
}