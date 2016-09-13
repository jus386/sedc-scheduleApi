using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedc.ScheduleApi.TestWinClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadCourses_Click(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            RestClient client = new RestClient("http://localhost:3975/api/");
            RestRequest request = new RestRequest("course", Method.GET);
            IRestResponse<List<Course>> response = client.Execute<List<Course>>(request);
            gvCourses.DataSource = response.Data;
        }
    }

    internal class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LengthHours { get; set; }
    }
}
