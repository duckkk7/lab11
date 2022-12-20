using System;
using System.Collections;
namespace TestConsole 
{ 
    class Paper
    {
        public string NameP { get; set; }
        public string Author { get; set; }
        public DateTime Dt { get; set; }

        public Paper(string name, string author, DateTime dt)
        {
            this.NameP = name;
            this.Author = author;
            this.Dt = dt;
        }
        public Paper() : this("Химия и жизнь", "Boris Gaidukov", new DateTime(2013, 2, 17)) {}

        public override string ToString()
        {
            return NameP + " " + Author + " " + Dt.ToString();
        }

        public virtual object DeepCopy()
        {
            Paper paperCopy = new Paper(this.NameP, this.Author, this.Dt);
            return paperCopy;
        }
    }
}