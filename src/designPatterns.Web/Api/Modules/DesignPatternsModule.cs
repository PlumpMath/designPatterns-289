﻿using System;
using System.Collections.Generic;
using designPatterns.Domain.DesignPattern.AdapterPattern;
using designPatterns.Domain.DesignPattern.BridgePattern;
using designPatterns.Domain.DesignPattern.BuilderPattern;
using designPatterns.Domain.DesignPattern.ChainOfResponsabilityPattern;
using designPatterns.Domain.DesignPattern.CommandPattern;
using designPatterns.Domain.DesignPattern.factoryPattern;
using designPatterns.Domain.DesignPattern.InterpreterPattern;
using designPatterns.Domain.DesignPattern.IteratorPattern;
using designPatterns.Domain.DesignPattern.NullObjectPattern;
using designPatterns.Domain.DesignPattern.ObserverPattern;
using designPatterns.Domain.DesignPattern.StatePattern;
using designPatterns.Domain.DesignPattern.StrategyPattern;
using designPatterns.Domain.DesignPattern.visitorPattern;
using Nancy;

namespace designPatterns.Web.Api.Modules
{

    public class DesignPatternModule : NancyModule
    {
        public DesignPatternModule()
        {

            Get["/testStatePattern"] = _ =>
            {
                var traficLight = new TraficLight();
                var process = traficLight.StartTheTraficLight();

                return process;
            };

            Get["/testNullObjectPattern"] = _ =>
            {
                var dog = new Dog();
                var dougSound = "Dog Sound: " + dog.MakeSound() + ", ";
                var unknown = Animal.Null;
                var noAnimalSound = "No Animal Sound: " + unknown.MakeSound();

                return dougSound + noAnimalSound;
            };

            Get["/testObserverPattern"] = _ =>
            {
                var observable = new Observable();
                var observer = new Observer();
                observable.SomethingHappened += observer.HandleEvent;

                var observerValue = observable.DoSomething();

                return observerValue;
            };
            Get["/testBridgePattern/{currentSource}"] = _ =>
            {
                var currentSource = (string)_.currentSource;

                var myCustomTv = new MyCustomTv();
                switch (currentSource)
                {
                    case "1":
                        myCustomTv.VideoSource = new LocalCableTv();
                        break;

                    case "2":
                        myCustomTv.VideoSource = new CableColorTv();
                        break;

                    case "3":
                        myCustomTv.VideoSource = new TigoService();
                        break;
                }

                var tvGuide = myCustomTv.ShowTvGuide();
                var playVideo = myCustomTv.ShowTvGuide();

                return tvGuide + " / " + playVideo;
            };
            Get["/testVisitorPattern"] = _ =>
            {
                var popRock = new PopRockMusicVisitor();
                var musicLibrary = new MusicLibrary();
                var songs = musicLibrary.Accept(popRock);

                return songs;
            };

            Get["/testBuilderPattern"] = _ =>
            {
                var shop = new Shop();
                VehicleBuilder builder = new CarBuilder();
                shop.Construct(builder);
                var getBuilderProcess = builder.Vehicle.Show();
                return getBuilderProcess;
            };
            Get["/testInterpreterPattern"] = _ =>
            {
                const string roman = "MCMXXVIII";
                var context = new Context(roman);

                var tree = new List<Expression>
                {
                    new ThousandExpression(),
                    new HundredExpression(),
                    new TenExpression(),
                    new OneExpression()
                };

                foreach (var exp in tree)
                {
                    exp.Interpret(context);
                }

                return "Interpreter Input: " + roman + ", Interpreter Output: " + context.Output;
            };

            Get["/testChainOfResponsabilityPattern"] = _ =>
            {
                var response = "";
                var pamela = new Director();
                var byron = new VicePresident();
                var colin = new President();

                pamela.SetSuccessor(byron);
                byron.SetSuccessor(colin);
                
                var p = new Purchase(2034, 350.00, "Assets");
                response = pamela.ProcessRequest(p);

                p = new Purchase(2035, 32590.10, "Project X");
                response += " / " + pamela.ProcessRequest(p);

                p = new Purchase(2036, 90000.00, "Project Y");
                response += " / " + pamela.ProcessRequest(p);

                p = new Purchase(2036, 122100.00, "Project Z");
                response += " / " + pamela.ProcessRequest(p);
                return response;
            };

            Get["/testIteratorPattern"] = _ =>
            {
                var collection = new Collection();
                collection[0] = new Item("Item 0");
                collection[1] = new Item("Item 1");
                collection[2] = new Item("Item 2");
                collection[3] = new Item("Item 3");
                collection[4] = new Item("Item 4");
                collection[5] = new Item("Item 5");
                collection[6] = new Item("Item 6");
                collection[7] = new Item("Item 7");
                collection[8] = new Item("Item 8");

                var iterator = collection.CreateIterator();

                iterator.Step = 2;

                var response = "Iterating over collection:";

                for (var item = iterator.First(); !iterator.IsDone; item = iterator.Next())
                {
                    response += item.Name +  " / ";
                }
                return response;
            };

            Get["/testAdapterPattern"] = _ =>
            {
                var response = "";
                var unknown = new Compound("Unknown");
                response += " / " + unknown.Display();

                var water = new RichCompound("Water");
                response += " / " + water.Display();

                var benzene = new RichCompound("Benzene");
                response += " / " + benzene.Display();

                var ethanol = new RichCompound("Ethanol");
                response += " / " + ethanol.Display();

                return response;
            };

            Get["/testCommandPattern"] = _ =>
            {
                var response = "";
                var user = new User();

                response += user.Compute('+', 100) + " / ";
                response += user.Compute('-', 50) + " / ";
                response += user.Compute('*', 10) + " / ";
                response += user.Compute('/', 2) + " / ";

                response += user.Undo(4) + " / ";
                response += user.Redo(3);
                return response;
            };
            Get["/testFactoryPattern"] = _ =>
            {
                var response = "";
                var documents = new Document[2];

                documents[0] = new Resume();
                documents[1] = new Report();

                foreach (var document in documents)
                {
                    response += document.GetType().Name + "--";
                    foreach (var page in document.Pages)
                    {
                        response += " " + page.GetType().Name;
                    }
                }
                return response;
            };
            Get["/testStrategyPattern"] = _ =>
            {
                var response = "";
                var studentRecords = new SortedList();

                studentRecords.Add("Samual");
                studentRecords.Add("Jimmy");
                studentRecords.Add("Sandra");
                studentRecords.Add("Vivek");
                studentRecords.Add("Anna");

                studentRecords.SetSortStrategy(new QuickSort());
                response += "Quicksort: " + studentRecords.Sort() + " -- ";

                studentRecords.SetSortStrategy(new ShellSort());
                response += "ShellSort: " + studentRecords.Sort() + " -- ";

                studentRecords.SetSortStrategy(new MergeSort());
                response += "MergeSort: " + studentRecords.Sort() + " -- ";
                return response;
            };
        }
    }
}