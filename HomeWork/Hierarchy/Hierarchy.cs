using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Hierarchy
{
    public class A
    {
        public virtual void PrintMessage()
        {
            Console.WriteLine("A");
        }
    }
    public class B : A
    {
        public override void PrintMessage()
        {
            Console.WriteLine("B");
        }
    }
    public class C:A
    {
        public new void PrintMessage()
        {
            Console.WriteLine("C");
        }
    }
    class HierarchyClass
    {
        public static void Hierarchy ()
        {
            var b = new B();
            var c = new C();
            ((A)c).PrintMessage();
            ((A)b).PrintMessage();
            c.PrintMessage();
        }
    }
}
