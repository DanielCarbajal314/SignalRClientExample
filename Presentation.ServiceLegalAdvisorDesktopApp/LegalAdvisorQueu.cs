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

namespace Presentation.ServiceLegalAdvisorDesktopApp
{
    public partial class LegalAdvisorQueu : Form
    {
        private HubConnection connection = new HubConnection("http://localhost:50840");
        private IHubProxy hub;

        public LegalAdvisorQueu()
        {
            this.hub = connection.CreateHubProxy("ServiceEvents");
            connection.Start();
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void LegalAdvisorQueu_Load(object sender, EventArgs e)
        {
            hub.On<ServiceRegistration>("NewMessageRegistered", (serviceRegistration) => {
                this.addEventToDatagrid(serviceRegistration);
            });
        }

        private void addEventToDatagrid(ServiceRegistration serviceRegistration)
        {
            this.dataGridView1.Rows.Add(serviceRegistration.Id, serviceRegistration.DNI, serviceRegistration.ClientName);
        }
    }
}
