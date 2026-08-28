using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Alumnos.UI.Avalonia;

public partial class VentanaNuevoAlumno : Window
{
    public string NombreAlumno { get; private set; } = string.Empty;
    public bool AlumnoActivo { get; private set; }
    public string DescripcionAlumno { get; private set; } = string.Empty;

    public VentanaNuevoAlumno() => InitializeComponent();

    private void BtnAceptar_Click(object? sender, RoutedEventArgs e)
    {
        string nombre = txtNombre.Text?.Trim() ?? string.Empty;

        if (nombre.Length < 3)
        {
            lblError.Text = "El nombre debe tener al menos 3 caracteres.";
            txtNombre.Focus();
            return;
        }

        NombreAlumno = nombre;
        AlumnoActivo = chkActivo.IsChecked == true;
        DescripcionAlumno = txtDescripcion.Text?.Trim() ?? string.Empty;

        Close(true);
    }

    private void BtnCancelar_Click(object? sender, RoutedEventArgs e) => Close(false);
}
