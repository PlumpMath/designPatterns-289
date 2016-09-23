using System;
using System.Collections.Generic;
using designPatterns.Domain.DesignPattern.BridgePattern;
using designPatterns.Domain.DesignPattern.BuilderPattern;
using designPatterns.Domain.DesignPattern.InterpreterPattern;
using designPatterns.Domain.DesignPattern.NullObjectPattern;
using designPatterns.Domain.DesignPattern.ObserverPattern;
using designPatterns.Domain.DesignPattern.StatePattern;
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
        }
    }
}