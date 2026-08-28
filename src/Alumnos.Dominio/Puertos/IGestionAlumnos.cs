using Alumnos.Dominio.Entidades;

namespace Alumnos.Dominio.Puertos;

public interface IGestionAlumnos
{
    IReadOnlyList<Alumno> ObtenerTodos();

    IReadOnlyList<Alumno> ObtenerActivos();

    IReadOnlyList<Alumno> OrdenarPorNombre(IEnumerable<Alumno> alumnos, bool ascendente);

    bool PuedeSeleccionarse(Alumno alumno, IEnumerable<Alumno> yaSeleccionados);

    Alumno Registrar(string nombre, bool activo, string descripcion);
}
