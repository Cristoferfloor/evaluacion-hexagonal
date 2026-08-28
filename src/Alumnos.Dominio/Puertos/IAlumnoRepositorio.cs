using Alumnos.Dominio.Entidades;

namespace Alumnos.Dominio.Puertos;

public interface IAlumnoRepositorio
{
    IReadOnlyList<Alumno> ObtenerTodos();
    void Agregar(Alumno alumno);
    int ObtenerSiguienteIdentificador();
}
