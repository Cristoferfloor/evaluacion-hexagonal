using Alumnos.Dominio.Entidades;
using Alumnos.Dominio.Puertos;

namespace Alumnos.Aplicacion.Servicios;

public sealed class GestionAlumnosServicio : IGestionAlumnos
{
    private readonly IAlumnoRepositorio _repositorio;

    public GestionAlumnosServicio(IAlumnoRepositorio repositorio)
        => _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));

    public IReadOnlyList<Alumno> ObtenerTodos() => _repositorio.ObtenerTodos();

    public IReadOnlyList<Alumno> ObtenerActivos()
        => _repositorio.ObtenerTodos()
                       .Where(a => a.Activo)
                       .ToList();

    public IReadOnlyList<Alumno> OrdenarPorNombre(IEnumerable<Alumno> alumnos, bool ascendente)
        => ascendente
            ? alumnos.OrderBy(a => a.Nombre, StringComparer.CurrentCulture).ToList()
            : alumnos.OrderByDescending(a => a.Nombre, StringComparer.CurrentCulture).ToList();

    public bool PuedeSeleccionarse(Alumno alumno, IEnumerable<Alumno> yaSeleccionados)
        => alumno is not null
           && !yaSeleccionados.Any(a => a.Identificador == alumno.Identificador);

    public Alumno Registrar(string nombre, bool activo, string descripcion)
    {
        var alumno = Alumno.Crear(
            _repositorio.ObtenerSiguienteIdentificador(),
            nombre,
            activo,
            descripcion);

        _repositorio.Agregar(alumno);
        return alumno;
    }
}
