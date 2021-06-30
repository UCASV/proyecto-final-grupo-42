using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            var db = new Proyecto_POO_BDDContext();
            List<Cabin> cabinas = db.Cabins.ToList();


            List<ManagementAccount> usuarios = db.ManagementAccounts.ToList();
            List<Employee> empleados = db.Employees.ToList();


            string usuario = textUsuario.Text;
            string contra = textContraseña.Text;


            bool existe = usuarios
                .Where(u => u.UserManagement == usuario &&
                            u.PasswordManagement == contra)
                .ToList().Count() > 0;

            if (existe && comboBox1.Text != "")
            {
                var filtro = cabinas
                   .Where(a => a.Direction.Equals(comboBox1.Text))
                   .ToList();

                ManagementLogin m = new ManagementLogin();
                List<ManagementLogin> logins = db.ManagementLogins.ToList();

                Record r = new Record();

                if (logins.Count() == 0)
                {
                    m.Id = 1;
                }
                else
                {
                    m.Id = (logins.Count() + 1);
                }

                m.IdCabin = filtro[0].Id;
                m.DateHour = DateTime.Now;

                db.Add(m);
                db.SaveChanges();

                var filtro2 = usuarios
                   .Where(l => l.UserManagement.Equals(usuario) && l.PasswordManagement.Equals(contra))
                   .ToList();

                if (logins.Count() == 0)
                {
                    r.IdManagementLogin = 1;
                }
                else
                {
                    r.IdManagementLogin = (logins.Count() + 1);
                }


                r.IdEmployee = filtro2[0].Id;

                var filtro3 = empleados
                   .Where(e => e.Id.Equals(r.IdEmployee))
                   .ToList();


                db.Add(r);
                db.SaveChanges();



                
                Home ventanaprincipal = new Home(filtro[0], filtro3[0]);
                this.Hide();
                ventanaprincipal.ShowDialog();
                Close();


            }
            else
                MessageBox.Show("Usuario no encontrado!", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            
        }


    }
}