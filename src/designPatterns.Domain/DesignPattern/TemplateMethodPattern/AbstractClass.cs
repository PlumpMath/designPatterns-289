using System;

namespace designPatterns.Domain.DesignPattern.TemplateMethodPattern
{
    public abstract class AbstractClass
    {
        public abstract string PrimitiveOperation1();
        public abstract string PrimitiveOperation2();

        // The "Template method"
        public string TemplateMethod()
        {
            var response = "";
            response += PrimitiveOperation1();
            response += PrimitiveOperation2();
            return response;
        }
    }
}