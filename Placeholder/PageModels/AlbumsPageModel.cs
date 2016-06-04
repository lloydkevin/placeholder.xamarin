using System;
using PropertyChanged;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;


namespace Placeholder
{
    [ImplementPropertyChanged]
    public class AlbumsPageModel : BasePageModel
    {
        PlaceholderService _service;

        public AlbumsPageModel(PlaceholderService service)
        {
            _service = service;
        }

        public List<Album> Albums { get; set; }

        public Album SelectedItem 
        {
            get { return null; }
            set { 
                if (value != null)
                {
                    CoreMethods.PushPageModel<AlbumDetailsPageModel>(value);
                }
                RaisePropertyChanged();
            }
        }
           
        public override async void Init(object initData)
        {
            base.Init(initData);
            await GetAlbumsAsync();
        }

        async Task GetAlbumsAsync()
        {
            this.IsBusy = true;
            Albums = await _service.GetAlbumsAsync();
            IsBusy = false;
        }


        public Command GetAlbumsCommand
        {
            get
            { 
                return new Command(async () => { await GetAlbumsAsync(); });
            }
        }
    }
}

