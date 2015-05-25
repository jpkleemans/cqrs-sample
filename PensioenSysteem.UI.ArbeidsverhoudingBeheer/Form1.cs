using Dapper;
using Newtonsoft.Json;
using PensioenSysteem.Domain.Arbeidsverhouding.Events;
using PensioenSysteem.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PensioenSysteem.UI.ArbeidsverhoudingBeheer
{
    public partial class Form1 : Form
    {
        private RabbitMQDomainEventHandler _eventHandler;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.arbeidsverhoudingTableAdapter.Fill(this.arbeidsverhoudingBeheerDataSet.Arbeidsverhouding);

            _eventHandler = new RabbitMQDomainEventHandler("127.0.0.1", "cqrs_user", "SeeQueErEs", "PensioenSysteem.Arbeidsverhouding", HandleEvent);
            _eventHandler.Start();
        }

        private bool HandleEvent(string eventType, string eventData)
        {
            bool handled = false;
            switch (eventType)
            {
                case "ArbeidsverhoudingGeregistreerd":
                    ArbeidsverhoudingGeregistreerd arbeidsverhoudingGeregistreerd = JsonConvert.DeserializeObject<ArbeidsverhoudingGeregistreerd>(eventData);
                    handled = HandleEvent(arbeidsverhoudingGeregistreerd);
                    break;
            }

            // refresh datagrid
            this.Invoke((MethodInvoker)delegate
            {
                this.arbeidsverhoudingBindingSource.SuspendBinding();
                this.arbeidsverhoudingTableAdapter.Fill(this.arbeidsverhoudingBeheerDataSet.Arbeidsverhouding);
                this.arbeidsverhoudingBindingSource.ResumeBinding();
            });

            return handled;
        }

        private bool HandleEvent(ArbeidsverhoudingGeregistreerd e)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ArbeidsverhoudingBeheer"].ConnectionString))
            {
                string commandText = @"
                    INSERT INTO [dbo].[Arbeidsverhouding] ([Nummer], [DeelnemerNummer], [WerkgeverNummer], [Ingangsdatum], [Einddatum], [Id], [Version])
                    VALUES (@Nummer, @DeelnemerNummer, @WerkgeverNummer, @Ingangsdatum, @Einddatum, @Id, @Version)";
                CommandDefinition cmd = new CommandDefinition(commandText, e);
                connection.Execute(cmd);
            }
            return true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_eventHandler != null)
            {
                _eventHandler.Stop();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.arbeidsverhoudingBindingSource.SuspendBinding();
            this.arbeidsverhoudingTableAdapter.Fill(this.arbeidsverhoudingBeheerDataSet.Arbeidsverhouding);
            this.arbeidsverhoudingBindingSource.ResumeBinding();
        }

        private void arbeidsverhoudingBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            recordCountStatusLabel.Text = "Aantal items : "  + this.arbeidsverhoudingBindingSource.List.Count;
        }
    }
}
