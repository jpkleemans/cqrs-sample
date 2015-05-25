using Dapper;
using Newtonsoft.Json;
using PensioenSysteem.Domain.Werkgever.Events;
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

namespace PensioenSysteem.UI.WerkgeverBeheer
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
            this.werkgeverTableAdapter.Fill(this.werkgeverBeheerDataSet.Werkgever);

            _eventHandler = new RabbitMQDomainEventHandler("127.0.0.1", "cqrs_user", "SeeQueErEs", "PensioenSysteem.Werkgever", HandleEvent);
            _eventHandler.Start();
        }

        private bool HandleEvent(string eventType, string eventData)
        {
            bool handled = false;
            switch (eventType)
            {
                case "WerkgeverGeregistreerd":
                    WerkgeverGeregistreerd werkgeverGeregistreerd = JsonConvert.DeserializeObject<WerkgeverGeregistreerd>(eventData);
                    handled = HandleEvent(werkgeverGeregistreerd);
                    break;
            }

            // refresh datagrid
            this.Invoke((MethodInvoker)delegate
            {
                this.werkgeverBindingSource.SuspendBinding();
                this.werkgeverTableAdapter.Fill(this.werkgeverBeheerDataSet.Werkgever);
                this.werkgeverBindingSource.ResumeBinding();
            });

            return handled;
        }

        private bool HandleEvent(WerkgeverGeregistreerd e)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["WerkgeverBeheer"].ConnectionString))
            {
                string commandText = @"
                    INSERT INTO [dbo].[Werkgever] ([Nummer], [Version], [BedrijfsNaam], [NaamContactpersoon], [EmailAdres], [VestigingsAdresStraat], [VestigingsAdresHuisnummer], 
                                                   [VestigingsAdresHuisnummerToevoeging], [VestigingsAdresPostcode], [VestigingsAdresPlaats], [Id])
                    VALUES (@Nummer, @Version, @BedrijfsNaam, @NaamContactpersoon, @EmailAdres, @Straat, @Huisnummer, @HuisnummerToevoeging, @Postcode, @Plaats, @Id)";
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
            this.werkgeverBindingSource.SuspendBinding();
            this.werkgeverTableAdapter.Fill(this.werkgeverBeheerDataSet.Werkgever);
            this.werkgeverBindingSource.ResumeBinding();
        }

        private void werkgeverBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            recordCountStatusLabel.Text = "Aantal items : " + this.werkgeverBindingSource.List.Count;
        }
    }
}
