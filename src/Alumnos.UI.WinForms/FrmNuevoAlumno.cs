namespace Alumnos.UI.WinForms;

public partial class FrmNuevoAlumno : Form
{
    public string NombreAlumno { get; private set; } = string.Empty;

    public bool AlumnoActivo { get; private set; }

    public string DescripcionAlumno { get; private set; } = string.Empty;

    public FrmNuevoAlumno()
    {
        InitializeComponent();
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
        if (!EsValido(out string mensaje))
        {
            lblError.Text = mensaje;
            txtNombre.Focus();
            return;
        }

        NombreAlumno      = txtNombre.Text.Trim();
        AlumnoActivo      = chkActivo.Checked;
        DescripcionAlumno = txtDescripcion.Text.Trim();

        DialogResult = DialogResult.OK;
        Close();
    }

    private bool EsValido(out string mensaje)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            mensaje = "El nombre es obligatorio.";
            return false;
        }

        if (txtNombre.Text.Trim().Length < 3)
        {
            mensaje = "El nombre debe tener al menos 3 caracteres.";
            return false;
        }

        mensaje = string.Empty;
        return true;
    }
}
