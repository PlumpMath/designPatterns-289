using System;
using System.Linq;
using System.Reflection;

namespace designPatterns.Domain.DesignPattern.DoubleDispatch
{
    public class DoubleDispatch
    {
        public T Foo<T>(object arg)
        {
            var method =
                from m in GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                where m.Name == "Foo"
                      && m.GetParameters().Length == 1
                      && Type.GetType(m.GetParameters()[0].ParameterType.FullName)
                            .IsAssignableFrom(arg.GetType())
                      && m.ReturnType == typeof (T)
                select m;


            return (T) method.Single().Invoke(this, new[] {arg});
        }

        public int Foo(int arg)
        {
            return 10;
        }

        public string Foo(string arg)
        {
            return 5.ToString();
        }
    }
}
