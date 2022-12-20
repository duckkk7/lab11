using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace TestConsole 
{
    class TeamsJournalEntry
    {
        public string CollectionName { get; set; }
        public string EventName { get; set; }
        public int NewElementNumber;
        public TeamsJournalEntry(string collectionName, string eventName, int newElementNumber)
        {
            this.CollectionName = collectionName;
            this.EventName = eventName;
            this.NewElementNumber = newElementNumber;
        }
        public override string ToString()
        {
            return CollectionName + " " + EventName + " " + NewElementNumber.ToString();
        }
    }
}