using Acr.UserDialogs;
using AppFlurl.Models;
using AppFlurl.Service;
using AppFlurl.ViewModel;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AppFlurl.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Users = new ObservableCollection<User>();
            _sb = new StringBuilder();
            ObterUsuariosCommand = new Command(ExecuteObterUsuariosCommand);
            ObterPostCommand = new Command<string>(ExecuteObterPostCommand);
        }

        public Command ObterUsuariosCommand { get; }
        public Command ObterPostCommand { get; }
        public ObservableCollection<User> Users { get; }
        private StringBuilder _sb { get; set; }


        private string _dados;
        public string Dados
        {
            get { return _dados; }
            set
            {
                SetProperty(ref _dados, value);
            }
        }

        private async void ExecuteObterUsuariosCommand()
        {
            using (UserDialogs.Instance.Loading("Aguarde, consultando...", null, null, true, MaskType.Gradient))
            {
                var res = await ServiceRest.ObterUsuarios();

                if (res != null)
                {
                    foreach (var item in res)
                    {
                        Users.Add(item);
                        _sb.AppendLine($"Nome: {item.name}\nE-mail: {item.email}");
                    }

                    Dados = _sb.ToString();
                }
            }
        }

        private async void ExecuteObterPostCommand(string postId)
        {
            using (UserDialogs.Instance.Loading("Aguarde, consultando...", null, null, true, MaskType.Gradient))
            {
                var res = await ServiceRest.ObterPost(postId);
                if (res != null)
                {
                    Dados = $"Id: {res.id}\nTítulo: {res.title}\nBody: {res.body}";
                }
            }
        }
    }
}
