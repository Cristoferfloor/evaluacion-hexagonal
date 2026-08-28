using System.ComponentModel;
using Alumnos.Dominio.Entidades;
using Alumnos.Dominio.Puertos;

namespace Alumnos.UI.WinForms;

public partial class FrmPrincipal : Form
{
    private readonly IGestionAlumnos _gestion;

    private BindingList<Alumno> _grid = new();
    private readonly BindingList<Alumno> _disponibles = new();
    private readonly BindingList<Alumno> _seleccionados = new();

    private bool _ordenAscendente = true;

    public FrmPrincipal(IGestionAlumnos gestion)
    {
        _gestion = gestion ?? throw new ArgumentNullException(nameof(gestion));
        InitializeComponent();
    }

    private void FrmPrincipal_Load(object sender, EventArgs e)
    {
        _grid = new BindingList<Alumno>(_gestion.ObtenerTodos().ToList());
        dgvAlumnos.AutoGenerateColumns = false;
        dgvAlumnos.DataSource = _grid;

        foreach (var activo in _gestion.ObtenerActivos())
            _disponibles.Add(activo);

        lstDisponibles.DataSource = _disponibles;
        lstDisponibles.DisplayMember = nameof(Alumno.Nombre);

        cboSeleccionados.DataSource = _seleccionados;
        cboSeleccionados.DisplayMember = nameof(Alumno.Nombre);

        MostrarDescripcion();
    }

    private void lstDisponibles_DoubleClick(object sender, EventArgs e)
    {
        if (lstDisponibles.SelectedItem is not Alumno alumno)
            return;

        if (_gestion.PuedeSeleccionarse(alumno, _seleccionados))
            _seleccionados.Add(alumno);

        _disponibles.Remove(alumno);
        cboSeleccionados.SelectedItem = alumno;
    }

    private void btnOrdenar_Click(object sender, EventArgs e)
    {
        _grid = new BindingList<Alumno>(_gestion.OrdenarPorNombre(_grid, _ordenAscendente).ToList());
        dgvAlumnos.DataSource = _grid;

        _ordenAscendente = !_ordenAscendente;
        btnOrdenar.Text = _ordenAscendente
            ? "Punto 5 - Ordenar por nombre (A-Z)"
            : "Punto 5 - Ordenar por nombre (Z-A)";
    }

    private void cboSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        => MostrarDescripcion();

    private void MostrarDescripcion()
        => txtDescripcion.Text = cboSeleccionados.SelectedItem is Alumno a ? a.Descripcion : string.Empty;

    private void btnAgregar_Click(object sender, EventArgs e)
    {
        using var formulario = new FrmNuevoAlumno();

        if (formulario.ShowDialog(this) != DialogResult.OK)
            return;

        var alumno = _gestion.Registrar(
            formulario.NombreAlumno,
            formulario.AlumnoActivo,
            formulario.DescripcionAlumno);

        _grid.Add(alumno);

        if (alumno.Activo)
            _disponibles.Add(alumno);

        dgvAlumnos.ClearSelection();
        dgvAlumnos.Rows[dgvAlumnos.Rows.Count - 1].Selected = true;
    }
}
