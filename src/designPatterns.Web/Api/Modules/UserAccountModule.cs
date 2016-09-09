using System;
using System.Collections.Generic;
using System.Linq;
using AcklenAvenue.Commands;
using AutoMapper;
using designPatterns.Domain.Application.Commands;
using designPatterns.Domain.Entities;
using designPatterns.Domain.Services;
using Nancy;
using Nancy.ModelBinding;

using designPatterns.Web.Api.Infrastructure;
using designPatterns.Web.Api.Requests;
using designPatterns.Web.Api.Requests.Facebook;
using designPatterns.Web.Api.Requests.Google;

namespace designPatterns.Web.Api.Modules
{

    public class UserAccountModule : NancyModule
    {        
        public UserAccountModule(IReadOnlyRepository readOnlyRepository,ICommandDispatcher commandDispatcher, IPasswordEncryptor passwordEncryptor, IMappingEngine mappingEngine)
        {
            Post["/register"] =
                _ =>
                    {
                        var req = this.Bind<NewUserRequest>();
                        var abilities = mappingEngine.Map<IEnumerable<UserAbilityRequest>, IEnumerable<UserAbility>>(req.Abilities);
                        commandDispatcher.Dispatch(this.UserSession(),
                                                   new CreateEmailLoginUser(req.Email, passwordEncryptor.Encrypt(req.Password), req.Name, req.PhoneNumber, abilities));
                        return null;
                    };


            Post["/register/facebook"] =
                _ =>
                    {
                        var req = this.Bind<FacebookRegisterRequest>();
                        commandDispatcher.Dispatch(this.UserSession(), new CreateFacebookLoginUser(req.id,req.email, req.first_name, req.last_name,req.link,req.name,req.url_image));
                        return null;
                    };

            Post["/register/google"] =
                _ =>
                    {
                        var req = this.Bind<GoogleRegisterRequest>();
                        commandDispatcher.Dispatch(this.UserSession(), new CreateGoogleLoginUser(req.id,req.email,req.name.givenName,req.name.familyName,req.url,req.displayName,req.image.url));
                        return null;
                    };

            Post["/password/requestReset"] =
                _ =>
                {
                    var req = this.Bind<ResetPasswordRequest>();
                    commandDispatcher.Dispatch(this.UserSession(),
                                               new CreatePasswordResetToken(req.Email) );
                    return null;
                };

            Put["/password/reset/{token}"] =
                p =>
                {
                    var newPasswordRequest = this.Bind<NewPasswordRequest>();
                    var token = Guid.Parse((string)p.token);
                    commandDispatcher.Dispatch(this.UserSession(),
                                               new ResetPassword(token, passwordEncryptor.Encrypt(newPasswordRequest.Password)));
                    return null;
                };

            Post["/user/abilites"] = p =>
            {

                var requestAbilites = this.Bind<UserAbilitiesRequest>();
                commandDispatcher.Dispatch(this.UserSession(), new AddAbilitiesToUser(requestAbilites.UserId, requestAbilites.Abilities.Select(x => x.Id)));

                return null;


            };

            Get["/abilities"] = _ =>
            {
                var abilites = readOnlyRepository.GetAll<UserAbility>();

                var mappedAbilites = mappingEngine.Map<IEnumerable<UserAbility>, IEnumerable<UserAbilityRequest>>(abilites);

                return mappedAbilites;
            };

            Get["/testStatePattern"] = _ =>
            {
                var traficLight = new Domain.DesignPattern.StatePattern.TraficLight();
                var process = traficLight.StartTheTraficLight();

                return process;
            };

            Get["/testNullObjectPattern"] = _ =>
            {
                var dog = new Domain.DesignPattern.NullObjectPattern.Dog();
                var dougSound = "Dog Sound: " + dog.MakeSound() + ", ";
                var unknown = Domain.DesignPattern.NullObjectPattern.Animal.Null;
                var noAnimalSound = "No Animal Sound: " + unknown.MakeSound();

                return dougSound + noAnimalSound;
            };

            Get["/testObserverPattern"] = _ =>
            {
                var observable = new Domain.DesignPattern.ObserverPattern.Observable();
                var observer = new Domain.DesignPattern.ObserverPattern.Observer();
                observable.SomethingHappened += observer.HandleEvent;

                var observerValue = observable.DoSomething();

                return observerValue;
            };
            Get["/testBridgePattern/{currentSource}"] = _ =>
            {
                var currentSource = (string)_.currentSource;

                var myCustomTv = new Domain.DesignPattern.BridgePattern.MyCustomTv();
                switch (currentSource)
                {
                    case "1":
                        myCustomTv.VideoSource = new Domain.DesignPattern.BridgePattern.LocalCableTv();
                        break;

                    case "2":
                        myCustomTv.VideoSource = new Domain.DesignPattern.BridgePattern.CableColorTv();
                        break;

                    case "3":
                        myCustomTv.VideoSource = new Domain.DesignPattern.BridgePattern.TigoService();
                        break;
                }

                var tvGuide = myCustomTv.ShowTvGuide();
                var playVideo = myCustomTv.ShowTvGuide();

                return tvGuide + " / " + playVideo;
            };
        }
    }
}