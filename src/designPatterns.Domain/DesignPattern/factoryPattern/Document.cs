using System.Collections.Generic;

namespace designPatterns.Domain.DesignPattern.factoryPattern
{
    public abstract class Document
    {
        private readonly List<Page> _pages = new List<Page>();

        // Constructor calls abstract Factory method
        protected Document()
        {
            CreatePages();
        }

        public List<Page> Pages
        {
            get { return _pages; }
        }

        // Factory Method
        public abstract void CreatePages();
    }
}