using Alumnos.Aplicacion.Servicios;
using Alumnos.Dominio.Puertos;
using Alumnos.Infraestructura.Persistencia;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Alumnos.UI.Avalonia;

public partial class App : Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            IAlumnoRepositorio repositorio = new AlumnoRepositorioEnMemoria();
            IGestionAlumnos gestion = new GestionAlumnosServicio(repositorio);

            desktop.MainWindow = new VentanaPrincipal(gestion);
        }

        base.OnFrameworkInitializationCompleted();
    }
}
