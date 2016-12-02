using System;
using System.Collections.Generic;
using System.Linq;
using designPatterns.Domain.DesignPattern.AdapterPattern;
using designPatterns.Domain.DesignPattern.BridgePattern;
using designPatterns.Domain.DesignPattern.BuilderPattern;
using designPatterns.Domain.DesignPattern.ChainOfResponsabilityPattern;
using designPatterns.Domain.DesignPattern.CommandPattern;
using designPatterns.Domain.DesignPattern.DoubleDispatch;
using designPatterns.Domain.DesignPattern.factoryPattern;
using designPatterns.Domain.DesignPattern.FacadePattern;
using designPatterns.Domain.DesignPattern.FlyweightPattern;
using designPatterns.Domain.DesignPattern.InterpreterPattern;
using designPatterns.Domain.DesignPattern.IteratorPattern;
using designPatterns.Domain.DesignPattern.MediatorPattern;
using designPatterns.Domain.DesignPattern.MomentoPattern;
using designPatterns.Domain.DesignPattern.NullObjectPattern;
using designPatterns.Domain.DesignPattern.ObserverPattern;
using designPatterns.Domain.DesignPattern.StatePattern;
using designPatterns.Domain.DesignPattern.StrategyPattern;
using designPatterns.Domain.DesignPattern.TemplateMethodPattern;
using designPatterns.Domain.DesignPattern.TransactionScriptPattern;
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
                response += "MergeSort: " + studentRecords.Sort();
                return response;
            };
            Get["/testTemplatePattern"] = _ =>
            {
                var response = "";
                AbstractClass aA = new ConcreteClassA();
                response += aA.TemplateMethod();

                AbstractClass aB = new ConcreteClassB();
                response += aB.TemplateMethod();
                return response;
            };
            Get["/testFacadePattern"] = _ =>
            {
                var response = "";
                var mortgage = new Mortgage();

                var customer = new Customer("Ann McKinsey");
                var eligible = mortgage.IsEligible(customer, 125000);

                response += customer.Name + " has been " + (eligible ? "Approved" : "Rejected");
                return response;
            };
            Get["/mediatorPattern"] = _ =>
            {
                var response = "";
                var chatroom = new Chatroom();

                Participant paul = new Beatle("Paul");
                Participant john = new Beatle("John");
                Participant yoko = new NonBeatle("Yoko");
                Participant ringo = new Beatle("Ringo");

                chatroom.Register(paul);
                chatroom.Register(john);
                chatroom.Register(yoko);
                chatroom.Register(ringo);

                response += yoko.Send("John", "Hi John!") + " ";
                response += paul.Send("Ringo", "All you need is love") + " ";
                response += paul.Send("John", "Can't buy me love") + " ";
                response += john.Send("Yoko", "My sweet love");

                return response;
            };
            Get["/testFlyweightPattern"] = _ =>
            {
                var response = "";
                const string document = "AAZZBBZB";
                var chars = document.ToCharArray();

                var factory = new CharacterFactory();
                var pointSize = 10;

                foreach (var c in chars)
                {
                    pointSize++;
                    var character = factory.GetCharacter(c);
                    response += character.Display(pointSize) +" ";
                }
                return response;
            };
            Get["/testMomentoPattern"] = _ =>
            {
                var response = "Save Sales, Restore Memento";
                var s = new SalesProspect
                {
                    Name = "Noel van Halen",
                    Phone = "(412) 256-0990",
                    Budget = 25000.0
                };

                var m = new ProspectMemory {Memento = s.SaveMemento()};

                s.Name = "Leo Welch";
                s.Phone = "(310) 209-7111";
                s.Budget = 1000000.0;

                s.RestoreMemento(m.Memento);

                return response;
            };
            Get["/testDoubleDispatchPattern"] = _ =>
            {
                var response = "";
                object x = 5;
                var dispatch = new DoubleDispatch();

                response += dispatch.Foo<int>(x);
                response += dispatch.Foo<string>(x.ToString());
                return response;
            };
            Get["/testTransactionScriptPattern"] = _ =>
            {
                var response = "";
                response += "Booked Holiday: " + HolidayService.BookHolidayFor(1, new DateTime(2016, 12, 31), new DateTime(2017, 1, 5)) + " - ";
                response += "Employes Leaving in Holiday: "  + string.Join(", ", HolidayService.GetAllEmployeesOnLeaveBetween(new DateTime(2016, 12, 31),
                    new DateTime(2017, 1, 5)).Select(x=> x.Name)) + " - ";
                response += "Employes without Holiday: " + string.Join(", ", HolidayService.GetAllEmployeesWithHolidayRemaining().Select(x => x.Name));
                return response;
            };
        }
    }
}