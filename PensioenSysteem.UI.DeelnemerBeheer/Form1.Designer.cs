namespace PensioenSysteem.UI.DeelnemerBeheer
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
            this.Nummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailAdresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.woonAdresStraatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.woonAdresHuisnummerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.woonAdresHuisnummerToevoegingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.woonAdresPostcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.woonAdresPlaatsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deelnemerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deelnemerBeheerDataSet = new PensioenSysteem.UI.DeelnemerBeheer.DeelnemerBeheerDataSet();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.deelnemerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verhuisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deelnemerTableAdapter = new PensioenSysteem.UI.DeelnemerBeheer.DeelnemerBeheerDataSetTableAdapters.DeelnemerTableAdapter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.recordCountStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deelnemerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deelnemerBeheerDataSet)).BeginInit();
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
            this.naamDataGridViewTextBoxColumn,
            this.emailAdresDataGridViewTextBoxColumn,
            this.woonAdresStraatDataGridViewTextBoxColumn,
            this.woonAdresHuisnummerDataGridViewTextBoxColumn,
            this.woonAdresHuisnummerToevoegingDataGridViewTextBoxColumn,
            this.woonAdresPostcodeDataGridViewTextBoxColumn,
            this.woonAdresPlaatsDataGridViewTextBoxColumn,
            this.Id});
            this.dataGridView1.DataSource = this.deelnemerBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 352);
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
            // naamDataGridViewTextBoxColumn
            // 
            this.naamDataGridViewTextBoxColumn.DataPropertyName = "Naam";
            this.naamDataGridViewTextBoxColumn.HeaderText = "Naam";
            this.naamDataGridViewTextBoxColumn.Name = "naamDataGridViewTextBoxColumn";
            this.naamDataGridViewTextBoxColumn.ReadOnly = true;
            this.naamDataGridViewTextBoxColumn.Width = 60;
            // 
            // emailAdresDataGridViewTextBoxColumn
            // 
            this.emailAdresDataGridViewTextBoxColumn.DataPropertyName = "EmailAdres";
            this.emailAdresDataGridViewTextBoxColumn.HeaderText = "EmailAdres";
            this.emailAdresDataGridViewTextBoxColumn.Name = "emailAdresDataGridViewTextBoxColumn";
            this.emailAdresDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailAdresDataGridViewTextBoxColumn.Width = 84;
            // 
            // woonAdresStraatDataGridViewTextBoxColumn
            // 
            this.woonAdresStraatDataGridViewTextBoxColumn.DataPropertyName = "WoonAdresStraat";
            this.woonAdresStraatDataGridViewTextBoxColumn.HeaderText = "WoonAdresStraat";
            this.woonAdresStraatDataGridViewTextBoxColumn.Name = "woonAdresStraatDataGridViewTextBoxColumn";
            this.woonAdresStraatDataGridViewTextBoxColumn.ReadOnly = true;
            this.woonAdresStraatDataGridViewTextBoxColumn.Width = 116;
            // 
            // woonAdresHuisnummerDataGridViewTextBoxColumn
            // 
            this.woonAdresHuisnummerDataGridViewTextBoxColumn.DataPropertyName = "WoonAdresHuisnummer";
            this.woonAdresHuisnummerDataGridViewTextBoxColumn.HeaderText = "WoonAdresHuisnummer";
            this.woonAdresHuisnummerDataGridViewTextBoxColumn.Name = "woonAdresHuisnummerDataGridViewTextBoxColumn";
            this.woonAdresHuisnummerDataGridViewTextBoxColumn.ReadOnly = true;
            this.woonAdresHuisnummerDataGridViewTextBoxColumn.Width = 146;
            // 
            // woonAdresHuisnummerToevoegingDataGridViewTextBoxColumn
            // 
            this.woonAdresHuisnummerToevoegingDataGridViewTextBoxColumn.DataPropertyName = "WoonAdresHuisnummerToevoeging";
            this.woonAdresHuisnummerToevoegingDataGridViewTextBoxColumn.HeaderText = "WoonAdresHuisnummerToevoeging";
            this.woonAdresHuisnummerToevoegingDataGridViewTextBoxColumn.Name = "woonAdresHuisnummerToevoegingDataGridViewTextBoxColumn";
            this.woonAdresHuisnummerToevoegingDataGridViewTextBoxColumn.ReadOnly = true;
            this.woonAdresHuisnummerToevoegingDataGridViewTextBoxColumn.Width = 203;
            // 
            // woonAdresPostcodeDataGridViewTextBoxColumn
            // 
            this.woonAdresPostcodeDataGridViewTextBoxColumn.DataPropertyName = "WoonAdresPostcode";
            this.woonAdresPostcodeDataGridViewTextBoxColumn.HeaderText = "WoonAdresPostcode";
            this.woonAdresPostcodeDataGridViewTextBoxColumn.Name = "woonAdresPostcodeDataGridViewTextBoxColumn";
            this.woonAdresPostcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.woonAdresPostcodeDataGridViewTextBoxColumn.Width = 133;
            // 
            // woonAdresPlaatsDataGridViewTextBoxColumn
            // 
            this.woonAdresPlaatsDataGridViewTextBoxColumn.DataPropertyName = "WoonAdresPlaats";
            this.woonAdresPlaatsDataGridViewTextBoxColumn.HeaderText = "WoonAdresPlaats";
            this.woonAdresPlaatsDataGridViewTextBoxColumn.Name = "woonAdresPlaatsDataGridViewTextBoxColumn";
            this.woonAdresPlaatsDataGridViewTextBoxColumn.ReadOnly = true;
            this.woonAdresPlaatsDataGridViewTextBoxColumn.Width = 117;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 41;
            // 
            // deelnemerBindingSource
            // 
            this.deelnemerBindingSource.DataMember = "Deelnemer";
            this.deelnemerBindingSource.DataSource = this.deelnemerBeheerDataSet;
            this.deelnemerBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.deelnemerBindingSource_ListChanged);
            // 
            // deelnemerBeheerDataSet
            // 
            this.deelnemerBeheerDataSet.DataSetName = "DeelnemerBeheerDataSet";
            this.deelnemerBeheerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deelnemerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // deelnemerToolStripMenuItem
            // 
            this.deelnemerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.verhuisToolStripMenuItem});
            this.deelnemerToolStripMenuItem.Name = "deelnemerToolStripMenuItem";
            this.deelnemerToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.deelnemerToolStripMenuItem.Text = "&Deelnemer";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem1.Text = "&Refresh";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // verhuisToolStripMenuItem
            // 
            this.verhuisToolStripMenuItem.Name = "verhuisToolStripMenuItem";
            this.verhuisToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.verhuisToolStripMenuItem.Text = "&Verhuis";
            this.verhuisToolStripMenuItem.Click += new System.EventHandler(this.verhuisToolStripMenuItem_Click);
            // 
            // deelnemerTableAdapter
            // 
            this.deelnemerTableAdapter.ClearBeforeFill = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordCountStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 376);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
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
            this.ClientSize = new System.Drawing.Size(800, 398);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Deelnemer Beheer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deelnemerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deelnemerBeheerDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DeelnemerBeheerDataSet deelnemerBeheerDataSet;
        private System.Windows.Forms.BindingSource deelnemerBindingSource;
        private DeelnemerBeheerDataSetTableAdapters.DeelnemerTableAdapter deelnemerTableAdapter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deelnemerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verhuisToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn naamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailAdresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn woonAdresStraatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn woonAdresHuisnummerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn woonAdresHuisnummerToevoegingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn woonAdresPostcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn woonAdresPlaatsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel recordCountStatusLabel;
    }
}

