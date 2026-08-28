namespace Alumnos.Dominio.Entidades;

public sealed class Alumno
{
    public int Identificador { get; }
    public string Nombre { get; private set; }
    public bool Activo { get; private set; }
    public string Descripcion { get; private set; }

    private Alumno(int identificador, string nombre, bool activo, string descripcion)
    {
        Identificador = identificador;
        Nombre = nombre;
        Activo = activo;
        Descripcion = descripcion;
    }


    public static Alumno Crear(int identificador, string nombre, bool activo, string descripcion)
    {
        if (identificador <= 0)
            throw new ArgumentException("El identificador debe ser mayor que cero.", nameof(identificador));

        string nombreLimpio = (nombre ?? string.Empty).Trim();

        if (nombreLimpio.Length < 3)
            throw new ArgumentException("El nombre debe tener al menos 3 caracteres.", nameof(nombre));

        return new Alumno(identificador, nombreLimpio, activo, (descripcion ?? string.Empty).Trim());
    }

    public override string ToString() => Nombre;
}
