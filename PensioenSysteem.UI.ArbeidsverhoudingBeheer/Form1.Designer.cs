namespace PensioenSysteem.UI.ArbeidsverhoudingBeheer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nummerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deelnemerNummerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.werkgeverNummerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingangsdatumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.einddatumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arbeidsverhoudingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.arbeidsverhoudingBeheerDataSet = new PensioenSysteem.UI.ArbeidsverhoudingBeheer.ArbeidsverhoudingBeheerDataSet();
            this.arbeidsverhoudingTableAdapter = new PensioenSysteem.UI.ArbeidsverhoudingBeheer.ArbeidsverhoudingBeheerDataSetTableAdapters.ArbeidsverhoudingTableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arbeidsverhoudingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.recordCountStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbeidsverhoudingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbeidsverhoudingBeheerDataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nummerDataGridViewTextBoxColumn,
            this.deelnemerNummerDataGridViewTextBoxColumn,
            this.werkgeverNummerDataGridViewTextBoxColumn,
            this.ingangsdatumDataGridViewTextBoxColumn,
            this.einddatumDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.arbeidsverhoudingBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(866, 320);
            this.dataGridView1.TabIndex = 0;
            // 
            // nummerDataGridViewTextBoxColumn
            // 
            this.nummerDataGridViewTextBoxColumn.DataPropertyName = "Nummer";
            this.nummerDataGridViewTextBoxColumn.HeaderText = "Nummer";
            this.nummerDataGridViewTextBoxColumn.Name = "nummerDataGridViewTextBoxColumn";
            this.nummerDataGridViewTextBoxColumn.ReadOnly = true;
            this.nummerDataGridViewTextBoxColumn.Width = 71;
            // 
            // deelnemerNummerDataGridViewTextBoxColumn
            // 
            this.deelnemerNummerDataGridViewTextBoxColumn.DataPropertyName = "DeelnemerNummer";
            this.deelnemerNummerDataGridViewTextBoxColumn.HeaderText = "DeelnemerNummer";
            this.deelnemerNummerDataGridViewTextBoxColumn.Name = "deelnemerNummerDataGridViewTextBoxColumn";
            this.deelnemerNummerDataGridViewTextBoxColumn.ReadOnly = true;
            this.deelnemerNummerDataGridViewTextBoxColumn.Width = 122;
            // 
            // werkgeverNummerDataGridViewTextBoxColumn
            // 
            this.werkgeverNummerDataGridViewTextBoxColumn.DataPropertyName = "WerkgeverNummer";
            this.werkgeverNummerDataGridViewTextBoxColumn.HeaderText = "WerkgeverNummer";
            this.werkgeverNummerDataGridViewTextBoxColumn.Name = "werkgeverNummerDataGridViewTextBoxColumn";
            this.werkgeverNummerDataGridViewTextBoxColumn.ReadOnly = true;
            this.werkgeverNummerDataGridViewTextBoxColumn.Width = 124;
            // 
            // ingangsdatumDataGridViewTextBoxColumn
            // 
            this.ingangsdatumDataGridViewTextBoxColumn.DataPropertyName = "Ingangsdatum";
            this.ingangsdatumDataGridViewTextBoxColumn.HeaderText = "Ingangsdatum";
            this.ingangsdatumDataGridViewTextBoxColumn.Name = "ingangsdatumDataGridViewTextBoxColumn";
            this.ingangsdatumDataGridViewTextBoxColumn.ReadOnly = true;
            this.ingangsdatumDataGridViewTextBoxColumn.Width = 99;
            // 
            // einddatumDataGridViewTextBoxColumn
            // 
            this.einddatumDataGridViewTextBoxColumn.DataPropertyName = "Einddatum";
            this.einddatumDataGridViewTextBoxColumn.HeaderText = "Einddatum";
            this.einddatumDataGridViewTextBoxColumn.Name = "einddatumDataGridViewTextBoxColumn";
            this.einddatumDataGridViewTextBoxColumn.ReadOnly = true;
            this.einddatumDataGridViewTextBoxColumn.Width = 82;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 41;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            this.versionDataGridViewTextBoxColumn.Width = 67;
            // 
            // arbeidsverhoudingBindingSource
            // 
            this.arbeidsverhoudingBindingSource.DataMember = "Arbeidsverhouding";
            this.arbeidsverhoudingBindingSource.DataSource = this.arbeidsverhoudingBeheerDataSet;
            this.arbeidsverhoudingBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.arbeidsverhoudingBindingSource_ListChanged);
            // 
            // arbeidsverhoudingBeheerDataSet
            // 
            this.arbeidsverhoudingBeheerDataSet.DataSetName = "ArbeidsverhoudingBeheerDataSet";
            this.arbeidsverhoudingBeheerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // arbeidsverhoudingTableAdapter
            // 
            this.arbeidsverhoudingTableAdapter.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arbeidsverhoudingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arbeidsverhoudingToolStripMenuItem
            // 
            this.arbeidsverhoudingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.arbeidsverhoudingToolStripMenuItem.Name = "arbeidsverhoudingToolStripMenuItem";
            this.arbeidsverhoudingToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.arbeidsverhoudingToolStripMenuItem.Text = "&Arbeidsverhouding";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordCountStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(866, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // recordCountStatusLabel
            // 
            this.recordCountStatusLabel.Name = "recordCountStatusLabel";
            this.recordCountStatusLabel.Size = new System.Drawing.Size(82, 17);
            this.recordCountStatusLabel.Text = "Aantal items : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 366);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Arbeidsverhouding Beheer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbeidsverhoudingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbeidsverhoudingBeheerDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ArbeidsverhoudingBeheerDataSet arbeidsverhoudingBeheerDataSet;
        private System.Windows.Forms.BindingSource arbeidsverhoudingBindingSource;
        private ArbeidsverhoudingBeheerDataSetTableAdapters.ArbeidsverhoudingTableAdapter arbeidsverhoudingTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nummerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deelnemerNummerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn werkgeverNummerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingangsdatumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn einddatumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arbeidsverhoudingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel recordCountStatusLabel;
    }
}

