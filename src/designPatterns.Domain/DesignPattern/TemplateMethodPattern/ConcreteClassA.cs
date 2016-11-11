using System;

namespace designPatterns.Domain.DesignPattern.TemplateMethodPattern
{
    public class ConcreteClassA : AbstractClass
    {
        public override string PrimitiveOperation1()
        {
            return "ConcreteClassA.PrimitiveOperation1()";
        }
        public override string PrimitiveOperation2()
        {
            return "ConcreteClassA.PrimitiveOperation2()";
        }
    }
}