using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace Labb
{

    class Program
    {
        

        public struct UserRole
        {
            public const string Admin = "Adminä";
            public const string Staff = "Staffä";
            public const string Parent = "Parentä"; ///Public|Static|Literal|HasDefault
        }

        static void Main(string[] args)
        {
            IEnumerable<string> _collection;

            _collection = new List<string>() { "foo", "bar", "choc" };

            foreach (var rolefield in typeof(UserRole).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var role = rolefield.GetValue(null).ToString();
                Debug.WriteLine(role);
            }

            foreach (var rolenames in typeof(UserRole).GetFields(BindingFlags.Public | BindingFlags.Static).Where(fi => fi.IsLiteral && !fi.IsInitOnly).Select(f => f.Name).ToList() )
            {
                Debug.WriteLine(rolenames);
            }

            foreach (var field in typeof(UserRole).GetFields(BindingFlags.Public))
            {
                Debug.WriteLine(field);
                //Debug.WriteLine("{0} = {1}", field.Name, field.GetValue);
            }

            foreach (var field in typeof(UserRole).GetFields(BindingFlags.Instance |
                                                            BindingFlags.NonPublic |
                                                            BindingFlags.Public))
            {
                Debug.WriteLine(field);
                //Debug.WriteLine("{0} = {1}", field.Name, field.GetValue);
            }

            foreach (var field in typeof(UserRole).GetFields(BindingFlags.Instance |
                                                            BindingFlags.NonPublic |
                                                            BindingFlags.Public))
            {
                Debug.WriteLine(field);
                //Debug.WriteLine("{0} = {1}", field.Name, field.GetValue);
            }

            foreach (var prop in typeof(UserRole).GetProperties(BindingFlags.Default))
            {
                Debug.WriteLine(prop.Name + " "  + prop.GetValue(prop).ToString());
            }

        }
   }

}
