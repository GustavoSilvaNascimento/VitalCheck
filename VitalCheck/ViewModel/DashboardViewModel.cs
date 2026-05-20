using VitalCheck.ViewModels;

namespace VitalCheck.ViewModel;

public class DashboardViewModel : BaseViewModel
{

	private string _nomeUsuario;
	public string NomeUsuario
	{
		get => _nomeUsuario;
		set
		{
			_nomeUsuario = value;
			OnPropertyChanged();
		}
	}
	public DashboardViewModel()
	{
		NomeUsuario = Preferences.Get("NomeUsuario", "Usuário");
	}
}