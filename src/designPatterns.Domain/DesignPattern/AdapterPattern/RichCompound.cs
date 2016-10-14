using System;

namespace designPatterns.Domain.DesignPattern.AdapterPattern
{
    public class RichCompound : Compound
    {
        private ChemicalDatabank _bank;

        public RichCompound(string name)
            : base(name)
        {
        }

        public override string Display()
        {
            _bank = new ChemicalDatabank();

            BoilingPoint = _bank.GetCriticalPoint(Chemical, "B");
            MeltingPoint = _bank.GetCriticalPoint(Chemical, "M");
            MolecularWeight = _bank.GetMolecularWeight(Chemical);
            MolecularFormula = _bank.GetMolecularStructure(Chemical);

            base.Display();
            var response = "";
            response += string.Format(" Formula: {0}", MolecularFormula);
            response += " - " + string.Format(" Weight : {0}", MolecularWeight);
            response += " - " + string.Format(" Melting Pt: {0}", MeltingPoint);
            response += " - " + string.Format(" Boiling Pt: {0}", BoilingPoint);

            return response;
        }
    }
}