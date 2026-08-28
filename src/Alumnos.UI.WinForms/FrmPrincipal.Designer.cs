namespace Alumnos.UI.WinForms;

partial class FrmPrincipal
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
        lblTituloGrid = new Label();
        dgvAlumnos = new DataGridView();
        colIdentificador = new DataGridViewTextBoxColumn();
        colNombre = new DataGridViewTextBoxColumn();
        colActivo = new DataGridViewCheckBoxColumn();
        colDescripcion = new DataGridViewTextBoxColumn();
        btnOrdenar = new Button();
        btnAgregar = new Button();
        grpTransferencia = new GroupBox();
        lstDisponibles = new ListBox();
        lblAyudaDobleClic = new Label();
        grpDetalle = new GroupBox();
        lblSeleccionados = new Label();
        cboSeleccionados = new ComboBox();
        lblDescripcion = new Label();
        txtDescripcion = new TextBox();
        ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
        grpTransferencia.SuspendLayout();
        grpDetalle.SuspendLayout();
        SuspendLayout();
        // 
        // lblTituloGrid
        // 
        lblTituloGrid.AutoSize = true;
        lblTituloGrid.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTituloGrid.Location = new Point(12, 9);
        lblTituloGrid.Name = "lblTituloGrid";
        lblTituloGrid.Size = new Size(196, 15);
        lblTituloGrid.TabIndex = 0;
        lblTituloGrid.Text = "Punto 3 - Listado de alumnos";
        // 
        // dgvAlumnos
        // 
        dgvAlumnos.AllowUserToAddRows = false;
        dgvAlumnos.AllowUserToDeleteRows = false;
        dgvAlumnos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dgvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAlumnos.Columns.AddRange(new DataGridViewColumn[] { colIdentificador, colNombre, colActivo, colDescripcion });
        dgvAlumnos.Location = new Point(12, 32);
        dgvAlumnos.MultiSelect = false;
        dgvAlumnos.Name = "dgvAlumnos";
        dgvAlumnos.ReadOnly = true;
        dgvAlumnos.RowHeadersVisible = false;
        dgvAlumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAlumnos.Size = new Size(960, 230);
        dgvAlumnos.TabIndex = 1;
        // 
        // colIdentificador
        // 
        colIdentificador.DataPropertyName = "Identificador";
        colIdentificador.HeaderText = "Identificador";
        colIdentificador.Name = "colIdentificador";
        colIdentificador.ReadOnly = true;
        colIdentificador.Width = 110;
        // 
        // colNombre
        // 
        colNombre.DataPropertyName = "Nombre";
        colNombre.HeaderText = "Nombre";
        colNombre.Name = "colNombre";
        colNombre.ReadOnly = true;
        colNombre.Width = 220;
        // 
        // colActivo
        // 
        colActivo.DataPropertyName = "Activo";
        colActivo.HeaderText = "Activo";
        colActivo.Name = "colActivo";
        colActivo.ReadOnly = true;
        colActivo.Width = 70;
        // 
        // colDescripcion
        // 
        colDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colDescripcion.DataPropertyName = "Descripcion";
        colDescripcion.HeaderText = "Descripción";
        colDescripcion.Name = "colDescripcion";
        colDescripcion.ReadOnly = true;
        // 
        // btnOrdenar
        // 
        btnOrdenar.Location = new Point(12, 274);
        btnOrdenar.Name = "btnOrdenar";
        btnOrdenar.Size = new Size(230, 32);
        btnOrdenar.TabIndex = 2;
        btnOrdenar.Text = "Punto 5 - Ordenar por nombre (A-Z)";
        btnOrdenar.UseVisualStyleBackColor = true;
        btnOrdenar.Click += btnOrdenar_Click;
        // 
        // btnAgregar
        // 
        btnAgregar.Location = new Point(254, 274);
        btnAgregar.Name = "btnAgregar";
        btnAgregar.Size = new Size(230, 32);
        btnAgregar.TabIndex = 3;
        btnAgregar.Text = "Punto 7 - Agregar alumno...";
        btnAgregar.UseVisualStyleBackColor = true;
        btnAgregar.Click += btnAgregar_Click;
        // 
        // grpTransferencia
        // 
        grpTransferencia.Controls.Add(lblAyudaDobleClic);
        grpTransferencia.Controls.Add(lstDisponibles);
        grpTransferencia.Location = new Point(12, 320);
        grpTransferencia.Name = "grpTransferencia";
        grpTransferencia.Size = new Size(472, 300);
        grpTransferencia.TabIndex = 4;
        grpTransferencia.TabStop = false;
        grpTransferencia.Text = "Punto 4 - DISPONIBLES (solo alumnos activos)";
        // 
        // lstDisponibles
        // 
        lstDisponibles.FormattingEnabled = true;
        lstDisponibles.ItemHeight = 15;
        lstDisponibles.Location = new Point(16, 50);
        lstDisponibles.Name = "lstDisponibles";
        lstDisponibles.Size = new Size(440, 229);
        lstDisponibles.TabIndex = 1;
        lstDisponibles.DoubleClick += lstDisponibles_DoubleClick;
        // 
        // lblAyudaDobleClic
        // 
        lblAyudaDobleClic.AutoSize = true;
        lblAyudaDobleClic.ForeColor = SystemColors.GrayText;
        lblAyudaDobleClic.Location = new Point(16, 28);
        lblAyudaDobleClic.Name = "lblAyudaDobleClic";
        lblAyudaDobleClic.Size = new Size(268, 15);
        lblAyudaDobleClic.TabIndex = 0;
        lblAyudaDobleClic.Text = "Doble clic sobre un ítem para pasarlo a SELECCIONADOS";
        // 
        // grpDetalle
        // 
        grpDetalle.Controls.Add(txtDescripcion);
        grpDetalle.Controls.Add(lblDescripcion);
        grpDetalle.Controls.Add(cboSeleccionados);
        grpDetalle.Controls.Add(lblSeleccionados);
        grpDetalle.Location = new Point(500, 320);
        grpDetalle.Name = "grpDetalle";
        grpDetalle.Size = new Size(472, 300);
        grpDetalle.TabIndex = 5;
        grpDetalle.TabStop = false;
        grpDetalle.Text = "Puntos 4 y 6 - SELECCIONADOS y descripción";
        // 
        // lblSeleccionados
        // 
        lblSeleccionados.AutoSize = true;
        lblSeleccionados.Location = new Point(16, 28);
        lblSeleccionados.Name = "lblSeleccionados";
        lblSeleccionados.Size = new Size(97, 15);
        lblSeleccionados.TabIndex = 0;
        lblSeleccionados.Text = "SELECCIONADOS";
        // 
        // cboSeleccionados
        // 
        cboSeleccionados.DropDownStyle = ComboBoxStyle.DropDownList;
        cboSeleccionados.FormattingEnabled = true;
        cboSeleccionados.Location = new Point(16, 50);
        cboSeleccionados.Name = "cboSeleccionados";
        cboSeleccionados.Size = new Size(440, 23);
        cboSeleccionados.TabIndex = 1;
        cboSeleccionados.SelectedIndexChanged += cboSeleccionados_SelectedIndexChanged;
        // 
        // lblDescripcion
        // 
        lblDescripcion.AutoSize = true;
        lblDescripcion.Location = new Point(16, 90);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(190, 15);
        lblDescripcion.TabIndex = 2;
        lblDescripcion.Text = "Descripción del alumno seleccionado";
        // 
        // txtDescripcion
        // 
        txtDescripcion.Location = new Point(16, 112);
        txtDescripcion.Multiline = true;
        txtDescripcion.Name = "txtDescripcion";
        txtDescripcion.ReadOnly = true;
        txtDescripcion.ScrollBars = ScrollBars.Vertical;
        txtDescripcion.Size = new Size(440, 167);
        txtDescripcion.TabIndex = 3;
        // 
        // FrmPrincipal
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(984, 640);
        Controls.Add(grpDetalle);
        Controls.Add(grpTransferencia);
        Controls.Add(btnAgregar);
        Controls.Add(btnOrdenar);
        Controls.Add(dgvAlumnos);
        Controls.Add(lblTituloGrid);
        MinimumSize = new Size(1000, 679);
        Name = "FrmPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Evaluación Técnica - Analista de Aplicaciones de Software";
        Load += FrmPrincipal_Load;
        ((System.ComponentModel.ISupportInitialize)dgvAlumnos).EndInit();
        grpTransferencia.ResumeLayout(false);
        grpTransferencia.PerformLayout();
        grpDetalle.ResumeLayout(false);
        grpDetalle.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTituloGrid;
    private DataGridView dgvAlumnos;
    private DataGridViewTextBoxColumn colIdentificador;
    private DataGridViewTextBoxColumn colNombre;
    private DataGridViewCheckBoxColumn colActivo;
    private DataGridViewTextBoxColumn colDescripcion;
    private Button btnOrdenar;
    private Button btnAgregar;
    private GroupBox grpTransferencia;
    private ListBox lstDisponibles;
    private Label lblAyudaDobleClic;
    private GroupBox grpDetalle;
    private Label lblSeleccionados;
    private ComboBox cboSeleccionados;
    private Label lblDescripcion;
    private TextBox txtDescripcion;
}
