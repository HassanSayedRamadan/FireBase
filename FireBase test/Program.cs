using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBase_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firebaseObj = new firebase();
            firebaseObj.SendNotification();

        }
    }
}
