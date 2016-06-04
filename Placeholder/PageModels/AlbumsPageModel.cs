using System;
using FreshMvvm;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Placeholder
{
    [ImplementPropertyChanged]
    public class AlbumsPageModel : BasePageModel
    {
        PlaceholderService _service;

        public AlbumsPageModel(PlaceholderService service)
        {
            _service = service;
            Albums = new ObservableCollection<Album>();
        }

        public ObservableCollection<Album> Albums { get; set; }

        public Album SelectedItem 
        {
            get { return null; }
            set { 
                if (value != null)
                {
                    SelectedItemCommand.Execute(value);
                }
            }
        }

        public Command<Album> SelectedItemCommand 
        {
            get 
            {
                return new Command<Album>(async (album) => { await CoreMethods.PushPageModel<AlbumDetailsPageModel>(album);});
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
            var albums = await _service.GetAlbumsAsync();
            Albums = new ObservableCollection<Album>(albums);
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

