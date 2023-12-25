using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SlidePuzzleTest
{
    public static class TestHelper
    {
        //https://stackoverflow.com/questions/9122708/unit-testing-private-methods-in-c-sharp
        public static TReturn CallPrivateMethod<TReturn>(
       this object instance,
       string methodName,
       params object[] parameters)
        {
            Type type = instance.GetType();
            BindingFlags bindingAttr = BindingFlags.NonPublic | BindingFlags.Instance;
            MethodInfo method = type.GetMethod(methodName, bindingAttr);

            return (TReturn)method.Invoke(instance, parameters);
        }
    }
}
