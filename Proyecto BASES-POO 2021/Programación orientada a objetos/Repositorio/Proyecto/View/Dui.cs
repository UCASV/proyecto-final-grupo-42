using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using Proyecto.View;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto.View
{
    public partial class Dui : Form
    {
        public Dui()
        {
            InitializeComponent();
        }

        public void FirstDate()
        {


            var db = new Proyecto_POO_BDDContext();
            List<Appointment> citas1 = db.Appointments.ToList();
            List<Citizen> ciudadanos = db.Citizens.ToList();

            var filtro1 = ciudadanos
                  .Where(d => d.Dui.Equals(textBoxDUI3.Text))
                   .ToList();

            var filtro2 = citas1
               .Where(e => e.IdCitizen.Equals(filtro1[0].Id))
                .ToList();


            comprobacion.Text = "si";
            Close();




        }

        public void SecondDate()
        {
            
            
            var db = new Proyecto_POO_BDDContext();
            List<Appointment> citas1 = db.Appointments.ToList();
            List<Citizen> ciudadanos = db.Citizens.ToList();

            var filtro1 = ciudadanos
                   .Where(d => d.Dui.Equals(textBoxDUI3.Text))
                    .ToList();

            var filtro2 = citas1
               .Where(e => e.IdCitizen.Equals(filtro1[0].Id))
                .ToList();

            
            
                comprobacion.Text = "si";
                Close();        
            
            
                

            
            

        }

        public void WithoutDate()
        {
            
            MessageBox.Show("Solicite una cita para realizarse su primera vacuna", "Cabina UCA",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            

        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            
            var db = new Proyecto_POO_BDDContext();
            List<Appointment> citas1 = db.Appointments.ToList();
            List<Citizen> ciudadanos = db.Citizens.ToList();

            var expression = "^[0-9]{9}$";


            bool existe1 = ciudadanos
                .Where(c => c.Dui == textBoxDUI3.Text)
                .ToList().Count() > 0;



            if (Regex.IsMatch(textBoxDUI3.Text, expression) && existe1)
            {
                var filtro1 = ciudadanos
                   .Where(d => d.Dui.Equals(textBoxDUI3.Text))
                    .ToList();

                var filtro2 = citas1
                   .Where(e => e.IdCitizen.Equals(filtro1[0].Id))
                    .ToList();


                switch (filtro2.Count())
                {
                    case 0:
                        WithoutDate();
                        break;
                    case 1:
                        FirstDate();
                        break;

                    case 2:
                        SecondDate();
                        break;

                    default:
                        break;
                }
            }

            else
            {
                MessageBox.Show("DUI invalido", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
