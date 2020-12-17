using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Komodo_Badge_Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dictionary<int, string> badge = new Dictionary<int, string>();
           {
               badge.Add(3, "door number");
                badge.Add(4, "door number");
                
                foreach(var item in badge)
                {
                    if(item.Key == 3)
                    {
                        Console.WriteLine(item.Value);
                    }
                    else
                    {
                        Console.WriteLine(item.Key);
                    }
                    
                }
           }
            
        }
        
    }
}
