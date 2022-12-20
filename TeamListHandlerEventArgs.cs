using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace TestConsole 
{
    class TeamListHandlerEventArgs : System.EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeName { get; set; }
        public int ChangeElementNumber { get; set; }
        public TeamListHandlerEventArgs(string collectionName, string changeName, int changeElementNumber)
        {
            this.CollectionName = collectionName;
            this.ChangeName = changeName;
            this.ChangeElementNumber = changeElementNumber;
        }
        public override string ToString()
        {
            return CollectionName + " " + ChangeName + " " + ChangeElementNumber.ToString();
        }

        
    }

}