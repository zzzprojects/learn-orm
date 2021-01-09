using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class DefaultLiteralExpressions
    {
        //double doubleValue = default(double);
        //bool boolValue = default(bool);
        //string str = default(string);
        //int? nullableInt = default(int?);

        //Action<int, bool> action = default(Action<int, bool>);
        //Predicate<string> predicate = default(Predicate<string>);
        //List<string> list = default(List<string>);
        //Dictionary<int, string> dictionary = default(Dictionary<int, string>);

        //public int Add(int x, int y = default(int), int z = default(int))
        //{
        //    return x + y + z;
        //}


        double doubleValue = default;
        bool boolValue = default;
        string str = default;
        int? nullableInt = default;

        Action<int, bool> action = default;
        Predicate<string> predicate = default;
        List<string> list = default;
        Dictionary<int, string> dictionary = default;

        public int Add(int x, int y = default, int z = default)
        {
            return x + y + z;
        }
    }
}
