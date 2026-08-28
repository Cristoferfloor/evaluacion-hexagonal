using System.Collections.ObjectModel;
using Alumnos.Dominio.Entidades;
using Alumnos.Dominio.Puertos;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Alumnos.UI.Avalonia;

public partial class VentanaPrincipal : Window
{
    private readonly IGestionAlumnos _gestion;

    private ObservableCollection<Alumno> _grid = new();
    private readonly ObservableCollection<Alumno> _disponibles = new();
    private readonly ObservableCollection<Alumno> _seleccionados = new();

    private bool _ordenAscendente = true;

    public VentanaPrincipal(IGestionAlumnos gestion)
    {
        _gestion = gestion ?? throw new ArgumentNullException(nameof(gestion));
        InitializeComponent();
        CargarDatosIniciales();
    }

    private void CargarDatosIniciales()
    {
        _grid = new ObservableCollection<Alumno>(_gestion.ObtenerTodos());
        dgvAlumnos.ItemsSource = _grid;

        foreach (var activo in _gestion.ObtenerActivos())
            _disponibles.Add(activo);

        lstDisponibles.ItemsSource = _disponibles;
        cboSeleccionados.ItemsSource = _seleccionados;

        MostrarDescripcion();
    }

    private void LstDisponibles_DoubleTapped(object? sender, TappedEventArgs e)
    {
        if (lstDisponibles.SelectedItem is not Alumno alumno)
            return;

        if (_gestion.PuedeSeleccionarse(alumno, _seleccionados))
            _seleccionados.Add(alumno);

        _disponibles.Remove(alumno);
        cboSeleccionados.SelectedItem = alumno;
    }

    private void BtnOrdenar_Click(object? sender, RoutedEventArgs e)
    {
        _grid = new ObservableCollection<Alumno>(_gestion.OrdenarPorNombre(_grid, _ordenAscendente));
        dgvAlumnos.ItemsSource = _grid;

        _ordenAscendente = !_ordenAscendente;
        btnOrdenar.Content = _ordenAscendente
            ? "Punto 5 - Ordenar por nombre (A-Z)"
            : "Punto 5 - Ordenar por nombre (Z-A)";
    }

    private void CboSeleccionados_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        => MostrarDescripcion();

    private void MostrarDescripcion()
        => txtDescripcion.Text = cboSeleccionados.SelectedItem is Alumno a ? a.Descripcion : string.Empty;

    private async void BtnAgregar_Click(object? sender, RoutedEventArgs e)
    {
        var ventana = new VentanaNuevoAlumno();

        if (!await ventana.ShowDialog<bool>(this))
            return;

        var alumno = _gestion.Registrar(ventana.NombreAlumno, ventana.AlumnoActivo, ventana.DescripcionAlumno);

        _grid.Add(alumno);

        if (alumno.Activo)
            _disponibles.Add(alumno);
    }
}
