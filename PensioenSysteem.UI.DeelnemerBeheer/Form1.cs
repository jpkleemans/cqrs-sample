using Newtonsoft.Json;
using PensioenSysteem.Domain.Core;
using PensioenSysteem.Domain.Deelnemer.Events;
using PensioenSysteem.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Configuration;

namespace PensioenSysteem.UI.DeelnemerBeheer
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
            this.deelnemerTableAdapter.Fill(this.deelnemerBeheerDataSet.Deelnemer);

            _eventHandler = new RabbitMQDomainEventHandler("127.0.0.1", "cqrs_user", "SeeQueErEs", "PensioenSysteem.Deelnemer", HandleEvent);
            _eventHandler.Start();
        }

        private bool HandleEvent(string eventType, string eventData)
        {
            bool handled = false;
            switch (eventType)
            {
                case "DeelnemerGeregistreerd":
                    DeelnemerGeregistreerd deelnemerGeregistreerd = JsonConvert.DeserializeObject<DeelnemerGeregistreerd>(eventData);
                    handled = HandleEvent(deelnemerGeregistreerd);
                    break;
                case "DeelnemerVerhuisd":
                    DeelnemerVerhuisd deelnemerVerhuisd = JsonConvert.DeserializeObject<DeelnemerVerhuisd>(eventData);
                    handled = HandleEvent(deelnemerVerhuisd);
                    break;
            }

            // refresh datagrid
            this.Invoke((MethodInvoker)delegate
            {
                this.deelnemerBindingSource.SuspendBinding();
                this.deelnemerTableAdapter.Fill(this.deelnemerBeheerDataSet.Deelnemer);
                this.deelnemerBindingSource.ResumeBinding();
            });

            return handled;
        }

        private bool HandleEvent(DeelnemerGeregistreerd e)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DeelnemerBeheer"].ConnectionString))
            {
                string commandText = @"
                    INSERT INTO [dbo].[Deelnemer] ([Nummer], [Version], [Naam], [EmailAdres], [WoonAdresStraat], [WoonAdresHuisnummer], 
                                                   [WoonAdresHuisnummerToevoeging], [WoonAdresPostcode], [WoonAdresPlaats], [Id])
                    VALUES (@Nummer, @Version, @Naam, @EmailAdres, @Straat, @Huisnummer, @HuisnummerToevoeging, @Postcode, @Plaats, @Id)";
                CommandDefinition cmd = new CommandDefinition(commandText, e);
                connection.Execute(cmd);
            }
            return true;
        }

        private bool HandleEvent(DeelnemerVerhuisd e)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DeelnemerBeheer"].ConnectionString))
            {
                string commandText = @"
                    UPDATE [dbo].[Deelnemer] 
                    Set [WoonAdresStraat] = @Straat, 
                        [WoonAdresHuisnummer] = @Huisnummer, 
                        [WoonAdresHuisnummerToevoeging] = @HuisnummerToevoeging, 
                        [WoonAdresPostcode] = @Postcode, 
                        [WoonAdresPlaats] = @Plaats,
                        [Version] = @Version
                    WHERE [Nummer] = @Nummer";
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

        private void verhuisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView data = deelnemerBindingSource.Current as DataRowView;
            if (data != null)
            {
                Verhuis dialog = new Verhuis((Guid)data["Id"], (int)data["Version"], data["WoonAdresStraat"].ToString(), (int)data["WoonAdresHuisnummer"],
                    data["WoonAdresHuisnummerToevoeging"].ToString(), data["WoonAdresPostcode"].ToString(), data["WoonAdresPlaats"].ToString());
                dialog.ShowDialog(this);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.deelnemerBindingSource.SuspendBinding();
            this.deelnemerTableAdapter.Fill(this.deelnemerBeheerDataSet.Deelnemer);
            this.deelnemerBindingSource.ResumeBinding();
        }

        private void deelnemerBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            recordCountStatusLabel.Text = "Aantal items : " + this.deelnemerBindingSource.List.Count;
        }
    }
}
