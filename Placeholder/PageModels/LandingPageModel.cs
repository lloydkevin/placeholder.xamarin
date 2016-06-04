using System;
using FreshMvvm;
using Xamarin.Forms;
using PropertyChanged;

namespace Placeholder
{
    [ImplementPropertyChanged]
    public class LandingPageModel : FreshBasePageModel
    {
        public LandingPageModel()
        {
        }

        public Command AlbumsCommand
        {
            get
            { 
                return new Command(async () => { await CoreMethods.PushPageModel<AlbumsPageModel>(); });
            }
        }
    }
}

