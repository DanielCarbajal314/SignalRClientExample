using Domain.Entities.RealTimeEvents;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.ServiceRegistrationDesktopApp
{
    public partial class ServiceRegistrationForm : Form
    {
        private HubConnection connection = new HubConnection("http://localhost:50840");
        private IHubProxy hub;
        private int Id = 1;

        public ServiceRegistrationForm()
        {
            this.hub = connection.CreateHubProxy("ServiceEvents");
            connection.Start();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void RegistrationSummitButton_Click(object sender, EventArgs e)
        {
            ServiceRegistration serviceRegistration = GetServiceData();
            hub.Invoke("RegisterNewService", serviceRegistration);
            this.clearClientForm();
            this.addEventToDatagrid(serviceRegistration);
        }

        private ServiceRegistration GetServiceData() {
            return new ServiceRegistration() {
                Id = this.Id++,
                DNI = this.DocumentNumber_TextBox.Text,
                ClientName = this.Name_TextBox.Text
            };
        }

        private void clearClientForm() {
            this.DocumentNumber_TextBox.Text = "";
            this.Name_TextBox.Text = "";
        }

        private void addEventToDatagrid(ServiceRegistration serviceRegistration) {
            this.dataGridView1.Rows.Add(serviceRegistration.Id, serviceRegistration.DNI, serviceRegistration.ClientName);
        }
    }
}
