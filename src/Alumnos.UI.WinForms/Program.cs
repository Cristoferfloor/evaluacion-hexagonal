using Alumnos.Aplicacion.Servicios;
using Alumnos.Dominio.Puertos;
using Alumnos.Infraestructura.Persistencia;

namespace Alumnos.UI.WinForms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        IAlumnoRepositorio repositorio = new AlumnoRepositorioEnMemoria();
        IGestionAlumnos gestion = new GestionAlumnosServicio(repositorio);

        Application.Run(new FrmPrincipal(gestion));
    }
}
