using System;

using Xamarin.Forms;
using FreshMvvm;

namespace Placeholder
{
    public class App : Application
    {
        public App()
        {
            FreshIOC.Container.Register<PlaceholderService, PlaceholderService>().AsMultiInstance();

            // The root page of your application
            var page = FreshPageModelResolver.ResolvePageModel<LandingPageModel> ();
            var basicNavContainer = new FreshNavigationContainer (page);
            MainPage = basicNavContainer;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

