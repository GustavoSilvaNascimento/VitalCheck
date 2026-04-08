using Microsoft.Maui.Storage;
using System.Text.Json;
using System.Linq;
using VitalCheck.Data.Interfaces;
using VitalCheck.Model;

public class UsuarioPreferencesCrud : ICrud<Usuario>
{
    private const string KEY = "usuarios";

    private List<Usuario> GetLista()
    {
        var json = Preferences.Get(KEY, string.Empty);

        if (string.IsNullOrEmpty(json))
            return new List<Usuario>();

        return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
    }

    private void SalvarLista(List<Usuario> lista)
    {
        var json = JsonSerializer.Serialize(lista);
        Preferences.Set(KEY, json);
    }

    Task<List<Usuario>> ICrud<Usuario>.GetAll()
    {
        return Task.FromResult(GetLista());
    }

    Task<Usuario?> ICrud<Usuario>.GetById(int id)
    {
        var lista = GetLista();
        var usuario = lista.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(usuario);
    }

    Task ICrud<Usuario>.Add(Usuario item)
    {
        var lista = GetLista();

        item.Id = lista.Count > 0 ? lista.Max(u => u.Id) + 1 : 1;

        lista.Add(item);
        SalvarLista(lista);

        return Task.CompletedTask;
    }

    Task ICrud<Usuario>.Update(Usuario item)
    {
        var lista = GetLista();

        var index = lista.FindIndex(u => u.Id == item.Id);

        if (index != -1)
        {
            lista[index] = item;
            SalvarLista(lista);
        }

        return Task.CompletedTask;
    }

    Task ICrud<Usuario>.Delete(int id)
    {
        var lista = GetLista();

        var usuario = lista.FirstOrDefault(u => u.Id == id);

        if (usuario != null)
        {
            lista.Remove(usuario);
            SalvarLista(lista);
        }

        return Task.CompletedTask;
    }
}