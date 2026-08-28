using Alumnos.Aplicacion.Servicios;
using Alumnos.Dominio.Entidades;
using Alumnos.Infraestructura.Persistencia;
using Xunit;

namespace Alumnos.Pruebas;

public class GestionAlumnosServicioPruebas
{
    private static GestionAlumnosServicio CrearServicio()
        => new(new AlumnoRepositorioEnMemoria());

    [Fact]
    public void ObtenerTodos_DevuelveLosSeisAlumnosDelEnunciado()
    {
        var servicio = CrearServicio();

        Assert.Equal(6, servicio.ObtenerTodos().Count);
    }

    [Fact]
    public void ObtenerActivos_DevuelveSoloLosAlumnosActivos()
    {
        var servicio = CrearServicio();

        var activos = servicio.ObtenerActivos();

        Assert.Equal(4, activos.Count);
        Assert.All(activos, a => Assert.True(a.Activo));
    }

    [Fact]
    public void OrdenarPorNombre_Ascendente_ColocaAdrianPrimero()
    {
        var servicio = CrearServicio();

        var ordenados = servicio.OrdenarPorNombre(servicio.ObtenerTodos(), ascendente: true);

        Assert.Equal("Adrián Almeida", ordenados[0].Nombre);
        Assert.Equal("Pilar Toapanta", ordenados[^1].Nombre);
    }

    [Fact]
    public void OrdenarPorNombre_Descendente_InvierteElOrden()
    {
        var servicio = CrearServicio();

        var ordenados = servicio.OrdenarPorNombre(servicio.ObtenerTodos(), ascendente: false);

        Assert.Equal("Pilar Toapanta", ordenados[0].Nombre);
    }

    [Fact]
    public void PuedeSeleccionarse_DevuelveFalso_SiElAlumnoYaFueSeleccionado()
    {
        var servicio = CrearServicio();
        var alumno = servicio.ObtenerActivos()[0];
        var seleccionados = new List<Alumno> { alumno };

        Assert.False(servicio.PuedeSeleccionarse(alumno, seleccionados));
        Assert.True(servicio.PuedeSeleccionarse(alumno, new List<Alumno>()));
    }

    [Fact]
    public void Registrar_AgregaElAlumnoYAsignaElSiguienteIdentificador()
    {
        var servicio = CrearServicio();

        var nuevo = servicio.Registrar("Juan Cevallos", true, "Alumno nuevo");

        Assert.Equal(7, nuevo.Identificador);
        Assert.Equal(7, servicio.ObtenerTodos().Count);
        Assert.Equal(5, servicio.ObtenerActivos().Count);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("Ab")]
    public void Registrar_RechazaNombresInvalidos(string nombre)
    {
        var servicio = CrearServicio();

        Assert.Throws<ArgumentException>(() => servicio.Registrar(nombre, true, "x"));
    }
}
