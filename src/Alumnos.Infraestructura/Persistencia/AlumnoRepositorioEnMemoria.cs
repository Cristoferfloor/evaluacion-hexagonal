using Alumnos.Dominio.Entidades;
using Alumnos.Dominio.Puertos;

namespace Alumnos.Infraestructura.Persistencia;

public sealed class AlumnoRepositorioEnMemoria : IAlumnoRepositorio
{
    private readonly List<Alumno> _alumnos;

    public AlumnoRepositorioEnMemoria()
    {
        _alumnos = new List<Alumno>
        {
            Alumno.Crear(1, "Marco Peréz",     true,  "Alumno con excelentes calificaciones"),
            Alumno.Crear(2, "Pilar Toapanta",  false, "Alumno ha desertado en múltiples ocasiones"),
            Alumno.Crear(3, "Adrián Almeida",  true,  "Alumno promedio, proceso aprendizaje."),
            Alumno.Crear(4, "Marcela Pazmiño", true,  "Alumno regular, requiere refuerzo"),
            Alumno.Crear(5, "Arturo Ureña",    true,  "Alumno regular, ha desertado en 2 ocasiones"),
            Alumno.Crear(6, "Lina Cachago",    false, "Alumno no asiste desde segunda clase")
        };
    }

    public IReadOnlyList<Alumno> ObtenerTodos() => _alumnos.AsReadOnly();

    public void Agregar(Alumno alumno) => _alumnos.Add(alumno);

    public int ObtenerSiguienteIdentificador()
        => _alumnos.Select(a => a.Identificador).DefaultIfEmpty(0).Max() + 1;
}
