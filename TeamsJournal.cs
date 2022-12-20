using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace TestConsole 
{
    class TeamsJournal
    {
        private List<TeamsJournalEntry> teamsJE = new List<TeamsJournalEntry>();
        public void TeamEventHandler(object o, TeamListHandlerEventArgs args) 
        {
           teamsJE.Add(new TeamsJournalEntry(args.CollectionName, args.ChangeName, args.ChangeElementNumber));
        }
        public override string ToString()
        {
            string s = "";
            foreach (TeamsJournalEntry teamJE in teamsJE)
            {
                s += teamJE.ToString() + "\n";
            }
            return s;
        }
    }
}