namespace PensioenSysteem.UI.WerkgeverBeheer
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bedrijfsNaamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naamContactpersoonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailAdresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vestigingsAdresStraatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vestigingsAdresHuisnummerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vestigingsAdresHuisnummerToevoegingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vestigingsAdresPostcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vestigingsAdresPlaatsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.werkgeverBindingSource = new System.Windows.Forms.BindingSource();
            this.werkgeverBeheerDataSet = new PensioenSysteem.UI.WerkgeverBeheer.WerkgeverBeheerDataSet();
            this.werkgeverTableAdapter = new PensioenSysteem.UI.WerkgeverBeheer.WerkgeverBeheerDataSetTableAdapters.WerkgeverTableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.werkgeverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.recordCountStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.werkgeverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.werkgeverBeheerDataSet)).BeginInit();
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
            this.Nummer,
            this.versionDataGridViewTextBoxColumn,
            this.bedrijfsNaamDataGridViewTextBoxColumn,
            this.naamContactpersoonDataGridViewTextBoxColumn,
            this.emailAdresDataGridViewTextBoxColumn,
            this.vestigingsAdresStraatDataGridViewTextBoxColumn,
            this.vestigingsAdresHuisnummerDataGridViewTextBoxColumn,
            this.vestigingsAdresHuisnummerToevoegingDataGridViewTextBoxColumn,
            this.vestigingsAdresPostcodeDataGridViewTextBoxColumn,
            this.vestigingsAdresPlaatsDataGridViewTextBoxColumn,
            this.Id});
            this.dataGridView1.DataSource = this.werkgeverBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(853, 371);
            this.dataGridView1.TabIndex = 0;
            // 
            // Nummer
            // 
            this.Nummer.DataPropertyName = "Nummer";
            this.Nummer.HeaderText = "Nummer";
            this.Nummer.Name = "Nummer";
            this.Nummer.ReadOnly = true;
            this.Nummer.Width = 71;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            this.versionDataGridViewTextBoxColumn.Width = 67;
            // 
            // bedrijfsNaamDataGridViewTextBoxColumn
            // 
            this.bedrijfsNaamDataGridViewTextBoxColumn.DataPropertyName = "BedrijfsNaam";
            this.bedrijfsNaamDataGridViewTextBoxColumn.HeaderText = "BedrijfsNaam";
            this.bedrijfsNaamDataGridViewTextBoxColumn.Name = "bedrijfsNaamDataGridViewTextBoxColumn";
            this.bedrijfsNaamDataGridViewTextBoxColumn.ReadOnly = true;
            this.bedrijfsNaamDataGridViewTextBoxColumn.Width = 94;
            // 
            // naamContactpersoonDataGridViewTextBoxColumn
            // 
            this.naamContactpersoonDataGridViewTextBoxColumn.DataPropertyName = "NaamContactpersoon";
            this.naamContactpersoonDataGridViewTextBoxColumn.HeaderText = "NaamContactpersoon";
            this.naamContactpersoonDataGridViewTextBoxColumn.Name = "naamContactpersoonDataGridViewTextBoxColumn";
            this.naamContactpersoonDataGridViewTextBoxColumn.ReadOnly = true;
            this.naamContactpersoonDataGridViewTextBoxColumn.Width = 135;
            // 
            // emailAdresDataGridViewTextBoxColumn
            // 
            this.emailAdresDataGridViewTextBoxColumn.DataPropertyName = "EmailAdres";
            this.emailAdresDataGridViewTextBoxColumn.HeaderText = "EmailAdres";
            this.emailAdresDataGridViewTextBoxColumn.Name = "emailAdresDataGridViewTextBoxColumn";
            this.emailAdresDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailAdresDataGridViewTextBoxColumn.Width = 84;
            // 
            // vestigingsAdresStraatDataGridViewTextBoxColumn
            // 
            this.vestigingsAdresStraatDataGridViewTextBoxColumn.DataPropertyName = "VestigingsAdresStraat";
            this.vestigingsAdresStraatDataGridViewTextBoxColumn.HeaderText = "VestigingsAdresStraat";
            this.vestigingsAdresStraatDataGridViewTextBoxColumn.Name = "vestigingsAdresStraatDataGridViewTextBoxColumn";
            this.vestigingsAdresStraatDataGridViewTextBoxColumn.ReadOnly = true;
            this.vestigingsAdresStraatDataGridViewTextBoxColumn.Width = 135;
            // 
            // vestigingsAdresHuisnummerDataGridViewTextBoxColumn
            // 
            this.vestigingsAdresHuisnummerDataGridViewTextBoxColumn.DataPropertyName = "VestigingsAdresHuisnummer";
            this.vestigingsAdresHuisnummerDataGridViewTextBoxColumn.HeaderText = "VestigingsAdresHuisnummer";
            this.vestigingsAdresHuisnummerDataGridViewTextBoxColumn.Name = "vestigingsAdresHuisnummerDataGridViewTextBoxColumn";
            this.vestigingsAdresHuisnummerDataGridViewTextBoxColumn.ReadOnly = true;
            this.vestigingsAdresHuisnummerDataGridViewTextBoxColumn.Width = 165;
            // 
            // vestigingsAdresHuisnummerToevoegingDataGridViewTextBoxColumn
            // 
            this.vestigingsAdresHuisnummerToevoegingDataGridViewTextBoxColumn.DataPropertyName = "VestigingsAdresHuisnummerToevoeging";
            this.vestigingsAdresHuisnummerToevoegingDataGridViewTextBoxColumn.HeaderText = "VestigingsAdresHuisnummerToevoeging";
            this.vestigingsAdresHuisnummerToevoegingDataGridViewTextBoxColumn.Name = "vestigingsAdresHuisnummerToevoegingDataGridViewTextBoxColumn";
            this.vestigingsAdresHuisnummerToevoegingDataGridViewTextBoxColumn.ReadOnly = true;
            this.vestigingsAdresHuisnummerToevoegingDataGridViewTextBoxColumn.Width = 222;
            // 
            // vestigingsAdresPostcodeDataGridViewTextBoxColumn
            // 
            this.vestigingsAdresPostcodeDataGridViewTextBoxColumn.DataPropertyName = "VestigingsAdresPostcode";
            this.vestigingsAdresPostcodeDataGridViewTextBoxColumn.HeaderText = "VestigingsAdresPostcode";
            this.vestigingsAdresPostcodeDataGridViewTextBoxColumn.Name = "vestigingsAdresPostcodeDataGridViewTextBoxColumn";
            this.vestigingsAdresPostcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.vestigingsAdresPostcodeDataGridViewTextBoxColumn.Width = 152;
            // 
            // vestigingsAdresPlaatsDataGridViewTextBoxColumn
            // 
            this.vestigingsAdresPlaatsDataGridViewTextBoxColumn.DataPropertyName = "VestigingsAdresPlaats";
            this.vestigingsAdresPlaatsDataGridViewTextBoxColumn.HeaderText = "VestigingsAdresPlaats";
            this.vestigingsAdresPlaatsDataGridViewTextBoxColumn.Name = "vestigingsAdresPlaatsDataGridViewTextBoxColumn";
            this.vestigingsAdresPlaatsDataGridViewTextBoxColumn.ReadOnly = true;
            this.vestigingsAdresPlaatsDataGridViewTextBoxColumn.Width = 136;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 41;
            // 
            // werkgeverBindingSource
            // 
            this.werkgeverBindingSource.DataMember = "Werkgever";
            this.werkgeverBindingSource.DataSource = this.werkgeverBeheerDataSet;
            this.werkgeverBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.werkgeverBindingSource_ListChanged);
            // 
            // werkgeverBeheerDataSet
            // 
            this.werkgeverBeheerDataSet.DataSetName = "WerkgeverBeheerDataSet";
            this.werkgeverBeheerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // werkgeverTableAdapter
            // 
            this.werkgeverTableAdapter.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.werkgeverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // werkgeverToolStripMenuItem
            // 
            this.werkgeverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.werkgeverToolStripMenuItem.Name = "werkgeverToolStripMenuItem";
            this.werkgeverToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.werkgeverToolStripMenuItem.Text = "&Werkgever";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(853, 22);
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
            this.ClientSize = new System.Drawing.Size(853, 417);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Werkgever Beheer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.werkgeverBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.werkgeverBeheerDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private WerkgeverBeheerDataSet werkgeverBeheerDataSet;
        private System.Windows.Forms.BindingSource werkgeverBindingSource;
        private WerkgeverBeheerDataSetTableAdapters.WerkgeverTableAdapter werkgeverTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bedrijfsNaamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn naamContactpersoonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailAdresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vestigingsAdresStraatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vestigingsAdresHuisnummerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vestigingsAdresHuisnummerToevoegingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vestigingsAdresPostcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vestigingsAdresPlaatsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem werkgeverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel recordCountStatusLabel;
    }
}

