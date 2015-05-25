using PensioenSysteem.Domain.Deelnemer.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PensioenSysteem.UI.DeelnemerBeheer
{
    public partial class Verhuis : Form
    {
        private Guid _id;
        private int _version;

        public Verhuis(Guid id, int version, string straat, int huisnummer, string huisnummerToevoeging, string postcode, string plaats)
        {
            _id = id;
            _version = version;

            InitializeComponent();

            straatTextbox.Text = straat;
            huisnummerTextbox.Text = huisnummer.ToString();
            toevoegingTextbox.Text = huisnummerToevoeging;
            postcodeTextbox.Text = postcode;
            plaatsTextbox.Text = plaats;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO validatie van de ingevoerde gegevens

            this.Cursor = Cursors.WaitCursor;

            try 
            {
                VerhuisDeelnemerCommand command = new VerhuisDeelnemerCommand
                {
                    CorrelationId = Guid.NewGuid(),
                    Id = _id,
                    Version = _version,
                    Straat = straatTextbox.Text,
                    Huisnummer = Convert.ToInt32(huisnummerTextbox.Text),
                    HuisnummerToevoeging = toevoegingTextbox.Text.Length > 0 ? toevoegingTextbox.Text : null,
                    Postcode = postcodeTextbox.Text,
                    Plaats = plaatsTextbox.Text
                };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:29713");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string uri = string.Format("/api/deelnemer/{0}/verhuis", _id.ToString("D"));
                    HttpResponseMessage response = client.PutAsJsonAsync(uri, command).Result;

                    // niet gevonden apart afhandelen
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        MessageBox.Show(this, "Deelnemer niet gevonden.");
                    }
                    else
                    {
                        // checken op 200-OK
                        response.EnsureSuccessStatusCode();
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
