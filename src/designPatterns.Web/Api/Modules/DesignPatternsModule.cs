﻿using System.Collections.Generic;
using designPatterns.Domain.DesignPattern.BridgePattern;
using designPatterns.Domain.DesignPattern.NullObjectPattern;
using designPatterns.Domain.DesignPattern.ObserverPattern;
using designPatterns.Domain.DesignPattern.StatePattern;
using designPatterns.Domain.DesignPattern.visitorPattern;
using Nancy;
using NHibernate.Linq;

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
        }
    }
}