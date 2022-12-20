using System;
using System.Collections;
namespace TestConsole 
{
    interface INameAndCopy
    {   
        string Name { get; set;}
        object DeepCopy(); 
    }
}