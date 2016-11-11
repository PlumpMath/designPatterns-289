﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Domain.DesignPattern.factoryPattern
{
    public class Report : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }
}
