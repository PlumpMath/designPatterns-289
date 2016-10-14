using System;

namespace designPatterns.Domain.DesignPattern.AdapterPattern
{
    public class Compound
    {
        protected string Chemical;
        protected float BoilingPoint;
        protected float MeltingPoint;
        protected double MolecularWeight;
        protected string MolecularFormula;

        // Constructor
        public Compound(string chemical)
        {
            Chemical = chemical;
        }

        public virtual string Display()
        {
            return string.Format("\nCompound: {0} ------ ", Chemical);
        }
    }
}