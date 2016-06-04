using System;
using PropertyChanged;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Placeholder
{
    [ImplementPropertyChanged]
    public class AlbumDetailsPageModel : BasePageModel
    {
        Album _album;

        PlaceholderService _serive;

        public AlbumDetailsPageModel(PlaceholderService service)
        {
            _serive = service;
            Photos = new ObservableCollection<Photo>();
        }

        public string TitleText
        {
            get
            {
                if (_album == null)
                    return string.Empty; 
                return string.Format("Phots in Album {0}", _album.title);
            }
        }

        public ObservableCollection<Photo> Photos
        {
            get;
            set;
        }

        public async override void Init(object initData)
        {
            base.Init(initData);
            _album = initData as Album;

            await GetPhotosAsync();
        }


        public Command GetPhotosCommand
        {
            get
            { 
                return new Command(async () => { await GetPhotosAsync(); });
            }
        }

        async Task GetPhotosAsync()
        {
            IsBusy = true;
            var photos = await _serive.GetPhotosAsync(_album.id);
            Photos = new ObservableCollection<Photo>(photos);
            IsBusy = false;
        }

    }
}


