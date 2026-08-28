namespace Alumnos.UI.WinForms;

partial class FrmNuevoAlumno
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    private void InitializeComponent()
    {
        lblNombre = new Label();
        txtNombre = new TextBox();
        chkActivo = new CheckBox();
        lblDescripcion = new Label();
        txtDescripcion = new TextBox();
        btnAceptar = new Button();
        btnCancelar = new Button();
        lblError = new Label();
        SuspendLayout();
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(16, 18);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(51, 15);
        lblNombre.TabIndex = 0;
        lblNombre.Text = "Nombre";
        txtNombre.Location = new Point(16, 38);
        txtNombre.MaxLength = 100;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(400, 23);
        txtNombre.TabIndex = 1;
        chkActivo.AutoSize = true;
        chkActivo.Checked = true;
        chkActivo.CheckState = CheckState.Checked;
        chkActivo.Location = new Point(16, 73);
        chkActivo.Name = "chkActivo";
        chkActivo.Size = new Size(60, 19);
        chkActivo.TabIndex = 2;
        chkActivo.Text = "Activo";
        chkActivo.UseVisualStyleBackColor = true;
        lblDescripcion.AutoSize = true;
        lblDescripcion.Location = new Point(16, 104);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(70, 15);
        lblDescripcion.TabIndex = 3;
        lblDescripcion.Text = "Descripción";
        txtDescripcion.Location = new Point(16, 124);
        txtDescripcion.MaxLength = 250;
        txtDescripcion.Multiline = true;
        txtDescripcion.Name = "txtDescripcion";
        txtDescripcion.ScrollBars = ScrollBars.Vertical;
        txtDescripcion.Size = new Size(400, 90);
        txtDescripcion.TabIndex = 4;
        lblError.AutoSize = true;
        lblError.ForeColor = Color.Firebrick;
        lblError.Location = new Point(16, 224);
        lblError.Name = "lblError";
        lblError.Size = new Size(0, 15);
        lblError.TabIndex = 5;
        btnAceptar.Location = new Point(226, 250);
        btnAceptar.Name = "btnAceptar";
        btnAceptar.Size = new Size(90, 30);
        btnAceptar.TabIndex = 6;
        btnAceptar.Text = "Aceptar";
        btnAceptar.UseVisualStyleBackColor = true;
        btnAceptar.Click += btnAceptar_Click;
        btnCancelar.DialogResult = DialogResult.Cancel;
        btnCancelar.Location = new Point(326, 250);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(90, 30);
        btnCancelar.TabIndex = 7;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = true;

        AcceptButton = btnAceptar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancelar;
        ClientSize = new Size(434, 296);
        Controls.Add(btnCancelar);
        Controls.Add(btnAceptar);
        Controls.Add(lblError);
        Controls.Add(txtDescripcion);
        Controls.Add(lblDescripcion);
        Controls.Add(chkActivo);
        Controls.Add(txtNombre);
        Controls.Add(lblNombre);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmNuevoAlumno";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Punto 7 - Nuevo alumno";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblNombre;
    private TextBox txtNombre;
    private CheckBox chkActivo;
    private Label lblDescripcion;
    private TextBox txtDescripcion;
    private Button btnAceptar;
    private Button btnCancelar;
    private Label lblError;
}
