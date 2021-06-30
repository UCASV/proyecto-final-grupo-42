using Proyecto.Models;
using Proyecto.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Home : Form
    {
        
        private Cabin cabin { get; set; }
        private Employee employee { get; set; }
       
        public Home(Cabin cabin, Employee employee)
        {
            InitializeComponent();
            
            this.cabin = cabin;
            this.employee = employee;
        }

        public DateTime Apptime()
        {
            

            var fechacita = DateTime.Now;
            int mescita;
            int diacita;


            if (fechacita.Day >= 26)
            {
                mescita = fechacita.Month + 1;
                diacita = 1;

            }
            else
            {
                mescita = fechacita.Month;
                diacita = fechacita.Day + 5;
            }

            var cita = new DateTime(fechacita.Year, mescita, diacita, 15, 0, 0);

            return cita;
            

          
        }

        public DateTime Apptime2(DateTime date1)
        {
            

            var cita = new DateTime();

            cita = date1.AddDays(42);

            return cita;

            

            
        }

        private void button2_Click(object sender, EventArgs e)//AGREGAR UN REGISTRO DE CIUDADANO
        {
            //Expresiones regulares que controlan que solo sea una expresion con 8 digitos con numeros del 0 al 9 y otra expresion
            // de 9 digitos de 0 al 9, esto para el telefono y el DUI.
            var expression = "^[0-9]{8}$";
            var expression2 = "^[0-9]{9}$";

            if (Regex.IsMatch(textTelefono.Text, expression) && Regex.IsMatch(textDUI.Text, expression2) && comboBox3.Text != ""
                && comboBox4.Text != "" && textDireccion.Text != "" && textTelefono.Text != "" && textDUI.Text != "" && textName.Text != ""
                && textEmail.Text != "") //crea un User con los datos
            {

                //Declaramos las variables que contendran los datos de la base de datos y creamos un objeto de tipo Citizen
                //en el cual almacenaremos los datos del ciudadano para luego agregarlos a la base de datos.
                var db = new Proyecto_POO_BDDContext();
                Citizen c = new Citizen();
                List<ChronicDisease> enfermedades = db.ChronicDiseases.ToList();
                List<Ocupation> ocupaciones = db.Ocupations.ToList();
                List<Citizen> ciudadanos = db.Citizens.ToList();

                //Agregamos los datos
                c.Telephone = Int32.Parse(textTelefono.Text);
                c.Dui = textDUI.Text;
                c.FullName = textName.Text;
                c.Direction = textDireccion.Text;
                c.Age = Int32.Parse(comboBox4.Text);
                c.Email = textEmail.Text;

                bool existe = ciudadanos
                .Where(t => t.Dui == textDUI.Text)
                .ToList().Count() > 0;


                //Esta funcion lo que hace es que: el combobox contendra la enfermedad elegida 
                var filtro1 = enfermedades
                   .Where(e => e.CommonName.Equals(comboBox2.Text))
                    .ToList();

                //y exactamente lo mismo con las ocupaciones 
                var filtro2 = ocupaciones
                   .Where(o => o.CommonName.Equals(comboBox3.Text))
                    .ToList();

                if (comboBox2.Text == "")
                {
                    c.IdChronicDiseases = null;

                }
                else
                {
                    c.IdChronicDiseases = filtro1[0].Id;
                }


                c.IdOccupation = filtro2[0].Id;

                if (ciudadanos.Count() == 0)
                {
                    c.Id = 1;
                }
                else
                {
                    c.Id = (ciudadanos.Count() + 1);
                }

                if (existe)
                {
                    //datos no válidos
                    MessageBox.Show("Este ciudadano ya esta registrado", "Cabina UCA",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    db.Add(c);
                    db.SaveChanges();

                    // Notificar al usuario
                    MessageBox.Show("Ciudadano registrado exitosamente!", "Cabina UCA",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                }


            }
            else
            {
                //datos no válidos
                MessageBox.Show("Datos inválidos!", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)//NO HACE NADA :v
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)//NO HACE NADA :v
        {
        }

        private void registrarUnCiudadanoToolStripMenuItem_Click(object sender, EventArgs e) //MOVERSE A REGISTRO
        {
            tabControl1.SelectedIndex = 1;
        }

        private void UpdateDataGridView() //ACTUALIZA LA DATAGRID GRANDE 
        {
            var db = new Proyecto_POO_BDDContext();
            List<Inobservation> inobservations = db.Inobservations.ToList();
            var filas = dataGridView1.Rows;
            int rowsnumber = dataGridView1.Rows.Count ;
            inobservations = db.Inobservations.ToList();
            dataGridView1.Rows.Clear();

            foreach (Inobservation inobservation in inobservations)
            {
                string[] row1 = new string[] { $"{inobservation.Id}", inobservation.Fullname, inobservation.Vaccine1 };
                dataGridView1.Rows.Add(row1);
            }
        }

        private void UpdateDataGridView2() //ACTUALIZA LA DATAGRID DE SINTOMAS CITA 1
        {
            var db = new Proyecto_POO_BDDContext();
            List<SymptomCitizen> symptomCitizens = db.SymptomCitizens.ToList();
            List<Citizen> ciudadanos = db.Citizens.ToList();
            List<Appointment> citas1 = db.Appointments.ToList();
            int number = symptomCitizens.Count();

            var filtro1 = ciudadanos
                .Where(d => d.Dui.Equals(labelSelectdui.Text))
                .ToList();

            var filtro2 = citas1
                .Where(d => d.IdCitizen.Equals(filtro1[0].Id))
                .ToList();

            dataGridView2.Rows.Clear();

            foreach (Appointment appointment in filtro2)
            {
                var filtro3 = filtro2
                        .Where(d => d.IdVaccination.Equals(1))
                        .ToList();

                var filtro4 = symptomCitizens
                    .Where(d => d.IdAppointmen.Equals(filtro3[0].Id))
                    .ToList();

                foreach (SymptomCitizen symptom in filtro4)
                {
                    if (symptom.IdAppointmen == appointment.Id)
                    {
                        string[] row1 = new string[] { symptom.Symptom, $"{symptom.Symptomminutes}" };
                        dataGridView2.Rows.Add(row1);
                    }
                }
            }
        }

        private void UpdateDataGridView3() //ACTUALIZA LA DATAGRID DE SINTOMAS CITA 2
        {
            var db = new Proyecto_POO_BDDContext();
            List<SymptomCitizen> symptomCitizens = db.SymptomCitizens.ToList();
            List<Citizen> ciudadanos = db.Citizens.ToList();
            List<Appointment> citas1 = db.Appointments.ToList();
            int number = symptomCitizens.Count();

            var filtro1 = ciudadanos
                   .Where(d => d.Dui.Equals(labelSelectdui.Text))
                    .ToList();

            var filtro2 = citas1
               .Where(d => d.IdCitizen.Equals(filtro1[0].Id))
                .ToList();

            dataGridView3.Rows.Clear();


            foreach (Appointment appointment in filtro2)
            {


                var filtro3 = filtro2
                    .Where(d => d.IdVaccination.Equals(2))
                       .ToList();

                if (filtro3.Count == 0)
                {

                }

                else
                {
                    var filtro4 = symptomCitizens
                 .Where(d => d.IdAppointmen.Equals(filtro3[0].Id))
                  .ToList();



                    foreach (SymptomCitizen symptom in filtro4)
                    {

                        if (symptom.IdAppointmen == appointment.Id)
                        {
                            string[] row1 = new string[] { symptom.Symptom, $"{symptom.Symptomminutes}" };


                            dataGridView3.Rows.Add(row1);

                        }



                    }

                }




            }
        }

        private void InfoDataGridView() //crea una lista con los datos que se utilizaran en el DataGridView 
        {
            
            var db = new Proyecto_POO_BDDContext();
            List<Citizen> citizens = db.Citizens.ToList();
            List<Appointment> appointments = db.Appointments.ToList();
            List<Vaccine> vaccines = db.Vaccines.ToList();
            List<Symptom> symptoms = db.Symptoms.ToList();
            Inobservation i = new Inobservation();
            List<Inobservation> inobservations = db.Inobservations.ToList();

            //foreach por cada tabla de la base
            foreach (Citizen citizen in citizens)
            {
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.Observation == true) 
                    {
                        if (appointment.IdCitizen == citizen.Id)
                        {
                            bool existe1 = inobservations
                              .Where(u => u.Fullname == citizen.FullName)
                               .ToList().Count() > 0;

                            if (existe1) 
                            {

                            }
                            else
                            {
                                i.Id = appointment.Id;
                                i.Fullname = citizen.FullName;


                                if (appointment.IdVaccine == 1)
                                {
                                    i.Vaccine1 = "Primera vacuna";
                                }
                                else
                                {
                                    i.Vaccine1 = "Segunda vacuna";
                                }

                                i.Symptom = null;
                                i.Minutesymptom = null;

                                db.Add(i);
                                db.SaveChanges();

                            }
                        }
                    }
                }
            }
            UpdateDataGridView();
        }

        private void InfoDataGridView2() //GUARDA LOS SINTOMAS Y EL TIEMPO EN LA BASE DE DATOS
        {
            var db = new Proyecto_POO_BDDContext();
            List<Citizen> citizens = db.Citizens.ToList();
            List<Appointment> appointments = db.Appointments.ToList();
            List<Vaccine> vaccines = db.Vaccines.ToList();
            List<Symptom> symptoms = db.Symptoms.ToList();
            SymptomCitizen i = new SymptomCitizen();            
            List<SymptomReaction> symptomReactions = db.SymptomReactions.ToList();
            List<Obserbation> obserbations = db.Obserbations.ToList();

            //foreach por cada tabla de la base
            foreach (Citizen citizen in citizens)
            {
                foreach (Appointment appointment in appointments)
                {
                    List<SymptomCitizen> symptomCitizens = db.SymptomCitizens.ToList();

                    if (appointment.Observation == false && appointment.VaccinationDate != null)
                    {
                        foreach(Obserbation obserbation in obserbations)
                        {
                            foreach(SymptomReaction symptom in symptomReactions) 
                            {
                                if (appointment.IdCitizen == citizen.Id && obserbation.IdSymptom == symptom.Id && obserbation.IdAppointment == appointment.Id)
                                {
                                    bool existe1 = symptomCitizens
                                        .Where(u => u.IdAppointmen == appointment.Id)
                                        .ToList().Count() > 0;

                                    switch (symptom.IdSymptom)
                                    {
                                        case 1: i.Symptom = "Fiebre o escalofríos"; break;

                                        case 2: i.Symptom = "Tos"; break;

                                        case 3: i.Symptom = "Dificultad para respirar"; break;

                                        case 4: i.Symptom = "Fatiga"; break;

                                        case 5: i.Symptom = "Dolores musculares"; break;

                                        case 6: i.Symptom = "Dolor de cabeza"; break;

                                        case 7: i.Symptom = "Pérdida del olfato o el gusto"; break;

                                        case 8: i.Symptom = "Dolor de garganta"; break;

                                        case 9: i.Symptom = "Congestión o moqueo"; break;

                                        case 10: i.Symptom = "Náuseas o vómitos"; break;

                                        case 11: i.Symptom = "Diarrea"; break;

                                        default: break;
                                    }

                                    bool existe2 = symptomCitizens
                                        .Where(u => u.Symptom== i.Symptom)
                                        .ToList().Count() > 0;

                                    if (existe1 && existe2)
                                    {

                                    }
                                    else
                                    {
                                        i.Id = obserbation.IdSymptom;
                                        i.IdAppointmen = appointment.Id;
                                        i.Symptomminutes = symptom.ReactionTime;

                                        if (i.Symptomminutes == null )
                                        {

                                        }
                                        else 
                                        {
                                            db.Add(i);
                                            db.SaveChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            UpdateDataGridView2();
            UpdateDataGridView3();
        }

        private void historialDeVacunacionToolStripMenuItem_Click(object sender, EventArgs e) //MOVERSE A CITA NUEVA
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button6_Click(object sender, EventArgs e) //BOTON PARA AÑADIR UNA CITA NUEVA 1 Y 2 
        {
            var db = new Proyecto_POO_BDDContext();
            List<Citizen> ciudadanos = db.Citizens.ToList();
            List<Appointment> citas1 = db.Appointments.ToList();
            List<Record> logins = db.Records.ToList();
            string dui = textDUI2.Text;
            var expression = "^[0-9]{9}$";
            bool existe2;

            if (Regex.IsMatch(textDUI2.Text, expression))
            {
                existe2 = true;
            }
            else
            {
                existe2 = false;
            }

            bool existe1 = ciudadanos
                .Where(u => u.Dui == dui)
                .ToList().Count() > 0;

            var filtro1 = ciudadanos
                .Where(d => d.Dui.Equals(textDUI2.Text))
                .ToList();

            if (existe1 && existe2)
            {
                int prioridad = 2;
                var filtro2 = citas1
                    .Where(e => e.IdCitizen.Equals(filtro1[0].Id))
                    .ToList();

                label11.Text = Convert.ToString(filtro1[0].Age);
                label15.Text = Convert.ToString(filtro1[0].Telephone);

                if (filtro1[0].IdChronicDiseases is null)
                {
                    label16.Text = "Ninguna";
                }
                else
                {
                    switch (filtro1[0].IdChronicDiseases)
                    {
                        case 1: label16.Text = "Alzheimer"; prioridad = 1; break;

                        case 2: label16.Text = "Artritis"; prioridad = 1; break;

                        case 3: label16.Text = "Asma"; prioridad = 1; break;

                        case 4: label16.Text = "Cáncer"; prioridad = 1; break;

                        case 5: label16.Text = "Demencia"; prioridad = 1; break;

                        case 6: label16.Text = "Diabetes"; prioridad = 1; break;

                        case 7: label16.Text = "EPOC (Enfermedad pulmonal obstructiva crónica)"; prioridad = 1; break;

                        case 8: label16.Text = "Enfermedad de Crohn"; prioridad = 1; break;

                        case 9: label16.Text = "Epilipsia"; prioridad = 1; break;

                        case 10: label16.Text = "Enfermedad del corazón"; prioridad = 1; break;

                        case 11: label16.Text = "Fibrosis quística"; prioridad = 1; break;

                        case 12: label16.Text = "Gonorrea"; break;

                        case 13: label16.Text = "Herpes genital"; break;

                        case 14: label16.Text = "Parkinson"; prioridad = 1; break;

                        case 15: label16.Text = "Sifilis"; break;

                        case 16: label16.Text = "Trastornos de humor"; prioridad = 1; break;

                        case 17: label16.Text = "VIH/SIDA"; break;

                        case 18: label16.Text = "Autismo"; prioridad = 1; break;

                        case 19: label16.Text = "Deficiencia visual"; prioridad = 1; break;

                        case 20: label16.Text = "Trastorno de lengua"; prioridad = 1; break;

                        case 21: label16.Text = "Deficiencia auditiva"; prioridad = 1; break;

                        default: break;
                    }
                }

                switch (filtro1[0].IdOccupation)
                {
                    case 1: label17.Text = "civil"; break;

                    case 2: label17.Text = "educación"; break;

                    case 3: label17.Text = "salud"; prioridad = 1; break;

                    case 4: label17.Text = "PNC"; prioridad = 1; break;

                    case 5: label17.Text = "gobierno"; prioridad = 1; break;

                    case 6: label17.Text = "fuerza armada"; prioridad = 1; break;

                    case 7: label17.Text = "periodismo"; break;

                    case 8: label17.Text = "cuerpo de socorro"; prioridad = 1; break;

                    case 9: label17.Text = "personal de frontera"; prioridad = 1; break;

                    case 10: label17.Text = "centro penal"; prioridad = 1; break;

                    default: break;
                }

                if (filtro2.Count == 0 || filtro2.Count == 1)
                {
                    if (filtro2.Count == 0)
                    {
                        var c = new Appointment();
                        DateTime datehour;
                        int hour;

                        if (citas1.Count() == 0)
                        {
                            c.Id = 1;
                        }
                        else
                        {
                            c.Id = citas1.Count() + 1;
                        }

                        c.ReservationDate = Apptime();
                        c.IdCitizen = filtro1[0].Id;
                        c.IdEmployee = employee.Id;
                        c.IdVaccination = 1;
                        c.IdVaccine = 1;
                        c.AssistanceDate = null;
                        c.VaccinationDate = null;
                        datehour = (DateTime)c.ReservationDate;
                        hour = datehour.Hour;

                        if (filtro1[0].Age > 60)
                        {
                            c.IdPriority = 1;
                        }
                        else
                        {
                            c.IdPriority = prioridad;
                        }
                  

                        if (c.IdPriority == 1) 
                        {
                            label21.Text = Convert.ToString(c.ReservationDate);
                            label22.Text = Convert.ToString(hour) + ":00 PM";
                            label23.Text = Convert.ToString(c.IdVaccine);

                            db.Add(c);
                            db.SaveChanges();

                            // Notificar al usuario
                            MessageBox.Show("Cita registrada exitosamente!", "Cabina UCA",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        else
                        {
                            MessageBox.Show("Usted no es sujeto prioritario, no puede ser vacunado!", "Cabina UCA",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                     
                    }
                    else
                    {
                        if (filtro2[0].VaccinationDate != null)
                        {
                            var c = new Appointment();
                            DateTime datehour;
                            int hour;

                            var newdate = new DateTime();
                            newdate = (DateTime)filtro2[0].ReservationDate;

                            c.Id = citas1.Count() + 1;
                            c.ReservationDate = Apptime2(newdate);
                            c.IdCitizen = filtro1[0].Id;
                            c.IdEmployee = employee.Id;
                            c.IdVaccination = 2;
                            c.IdVaccine = 2;
                            c.AssistanceDate = null;
                            c.VaccinationDate = null;
                            datehour = (DateTime)c.ReservationDate;
                            hour = datehour.Hour;

                            if (filtro1[0].Age > 60)
                            {
                                c.IdPriority = 1;
                            }
                            else
                            {
                                c.IdPriority = prioridad;
                            }                            

                            if (c.IdPriority == 1)
                            {
                                label21.Text = Convert.ToString(c.ReservationDate);
                                label22.Text = Convert.ToString(hour) + ":00 PM";
                                label23.Text = Convert.ToString(c.IdVaccine);

                                db.Add(c);
                                db.SaveChanges();

                                // Notificar al usuario
                                MessageBox.Show("Cita registrada exitosamente!", "Cabina UCA",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                            else
                            {
                                MessageBox.Show("Usted no es sujeto prioritario, no puede ser vacunado!", "Cabina UCA",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Usted ya tiene una cita al cual asistir!", "Cabina UCA",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Usted ya ha recibido las dos vacunas!", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Ciudadano no encontrado!", "Cabina UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void infoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)//INFO DEL EMPLEADO
        {
            labelName.Text = employee.Fullname;
            labelDireccion.Text = employee.Addresses;
            labelEmail.Text = employee.Email;

            tabControl1.SelectedIndex = 3;
        }

        private void infoCabinaToolStripMenuItem_Click(object sender, EventArgs e)//INFO DE LA CABINA
        {
            labelNombreempleado.Text = employee.Fullname;
            labelDireccioncabina.Text = cabin.Direction;
            labelTelefonocabina.Text = Convert.ToString(cabin.Telephone);
            labelEmailcabina.Text = cabin.Email;
            
            tabControl1.SelectedIndex = 4;
        }

        private void prechequeoToolStripMenuItem_Click(object sender, EventArgs e)//**PRE-CHEQUEO**
        {


            var db = new Proyecto_POO_BDDContext();
            List<Appointment> citas1 = db.Appointments.ToList();
            List<Citizen> ciudadanos = db.Citizens.ToList();

            Dui dui1 = new Dui();
            dui1.ShowDialog();

            if (dui1.comprobacion.Text == "si")
            {
                labelSelectdui.Text = dui1.textBoxDUI3.Text;

                var filtro1 = ciudadanos
                   .Where(d => d.Dui.Equals(labelSelectdui.Text))
                    .ToList();

                var filtro2 = citas1
                 .Where(e => e.IdCitizen.Equals(filtro1[0].Id) && e.VaccinationDate == null)
               .ToList();

                var filtro3 = citas1
                 .Where(e => e.IdCitizen.Equals(filtro1[0].Id) && e.VaccinationDate != null)
               .ToList();

                int existe1 = filtro2.Count();

                if (existe1 == 1)
                {
                    if (filtro2[0].IdVaccine == 1)
                    {
                        labelPrioridad1.Text = Convert.ToString(filtro2[0].IdPriority);
                        labelFechacita1.Text = Convert.ToString(filtro2[0].ReservationDate);

                    }

                    else
                    {
                        DateTime fechacita2 = (DateTime)filtro2[0].ReservationDate;
                        labelPrioridad1.Text = "1";
                        labelFechacita1.Text = Convert.ToString(fechacita2.AddDays(-42));
                        labelPrioridad2.Text = Convert.ToString(filtro2[0].IdPriority);
                        labelFechacita2.Text = Convert.ToString(filtro2[0].ReservationDate);
                    }

                    InfoDataGridView2();
                    tabControl1.SelectedIndex = 5;
                }

                else
                {
                    labelPrioridad1.Text = Convert.ToString(filtro3[0].IdPriority);
                    labelFechacita1.Text = Convert.ToString(filtro3[0].ReservationDate);


                    if (filtro3.Count() == 1)
                    {
                        tabControl1.SelectedIndex = 5;
                        InfoDataGridView2();
                    }

                    else
                    {
                        DateTime fechacita2 = (DateTime)filtro3[1].ReservationDate;
                        labelPrioridad2.Text = Convert.ToString(filtro3[1].IdPriority);
                        labelFechacita2.Text = Convert.ToString(filtro3[1].ReservationDate);

                        tabControl1.SelectedIndex = 5;
                        InfoDataGridView2();
                    }
                }
            }           
        }

        private void colaDeEsperaToolStripMenuItem_Click(object sender, EventArgs e)//PARA ACTUALIZAR Y VER LA DGV GRANDE
        {
            tabControl1.SelectedIndex = 6;
            UpdateDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)//BOTON DE AGRIGAR A COLA DE OBSERVACION 1 VACUNA
        {
            var db = new Proyecto_POO_BDDContext();
            List<Appointment> citas1 = db.Appointments.ToList();
            List<Citizen> ciudadanos = db.Citizens.ToList();
            List<Inobservation> inobservations = db.Inobservations.ToList();

            var filtro1 = ciudadanos
                .Where(d => d.Dui.Equals(labelSelectdui.Text))
                .ToList();

            var filtro2 = citas1
                .Where(e => e.IdCitizen.Equals(filtro1[0].Id))
                .ToList();

            var filtro3 = citas1
                .Where(e => e.IdCitizen.Equals(filtro1[0].Id) && e.VaccinationDate == null)
                .ToList();

            if(filtro2.Count() == 1) 
            {
                filtro3[0].Observation = true;
                DateTime date = (DateTime)filtro3[0].ReservationDate;
                filtro3[0].AssistanceDate = date.AddMinutes(2);
                DateTime datevaccine = (DateTime)filtro3[0].AssistanceDate;
                filtro3[0].VaccinationDate = datevaccine.AddMinutes(5);

                MessageBox.Show("Usted ha sido agregado a la cola, le atenderemos en 5 min!", "Cabina UCA",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                db.Update(filtro3[0]);
                db.SaveChanges();

                InfoDataGridView();
                tabControl1.SelectedIndex = 6;
            }
            else
            {
                MessageBox.Show("Usted ya ha recibido la primera vacuna!", "Cabina UCA",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//BOTONES DGV AGREGAR ELIMINAR
        {        
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if(senderGrid.Columns[e.ColumnIndex].HeaderText == "Agregar")//BOTON AGREGAR  
                {                    
                    var currentcell = dataGridView1.CurrentRow;
                    string  minutes1 = (string)currentcell.Cells[4].Value;
                    string symptom = Convert.ToString(currentcell.Cells[3].Value);                   
                    
                    if (symptom != null && minutes1 != null) 
                    {
                        var db = new Proyecto_POO_BDDContext();
                        List<SymptomReaction> symptoms = db.SymptomReactions.ToList();
                        List<Appointment> citas1 = db.Appointments.ToList();
                        SymptomReaction s = new SymptomReaction();
                        Obserbation o = new Obserbation();
                        int idcurrent = Int32.Parse((string)currentcell.Cells[0].Value);

                        if (symptoms.Count() == 0)
                        {
                            s.Id = 1;
                        }
                        else
                        {
                            s.Id = (symptoms.Count() + 1);
                        }

                        switch (symptom)
                        {
                            case "Fiebre o escalofríos": s.IdSymptom = 1; break;

                            case "Tos": s.IdSymptom = 2; break;

                            case "Dificultad para respirar": s.IdSymptom = 3; break;

                            case "Fatiga": s.IdSymptom = 4; break;

                            case "Dolores musculares": s.IdSymptom = 5; break;

                            case "Dolor de cabeza": s.IdSymptom = 6; break;

                            case "Pérdida del olfato o el gusto": s.IdSymptom = 7; break;

                            case "Dolor de garganta": s.IdSymptom = 8; break;

                            case "Congestión o moqueo": s.IdSymptom = 9; break;

                            case "Náuseas o vómitos": s.IdSymptom = 10; break;

                            case "Diarrea": s.IdSymptom = 11; break;

                            default: break;
                        }
                        s.ReactionTime = Int32.Parse(minutes1);

                        bool existe1 = symptoms
                            .Where(u => u.IdSymptom == s.IdSymptom)
                            .ToList().Count() > 0;
                        
                        bool existe2 = citas1
                            .Where(u => u.Id == idcurrent)
                            .ToList().Count() > 0;

                        o.IdSymptom = s.Id;
                        o.IdAppointment = idcurrent;

                        if (existe1 && existe2) 
                        {
                            MessageBox.Show("Este sintoma ya ha sido registrado para este paciente!", "Cabina UCA",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else 
                        {
                            InfoDataGridView2();

                            db.Add(s);
                            db.Add(o);
                            db.SaveChanges();

                            MessageBox.Show("Sintoma registrado!", "Cabina UCA",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Datos invalidos!", "Cabina UCA",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //BOTON ELIMINAR
                {
                    var db = new Proyecto_POO_BDDContext();                    
                    List<Appointment> citas1 = db.Appointments.ToList();
                    List<Inobservation> observacion = db.Inobservations.ToList();
                    var currentcell = dataGridView1.CurrentRow;
                    int idcurrent = Int32.Parse((string)currentcell.Cells[0].Value);

                    var filtro1 = observacion
                        .Where(r => r.Id.Equals(idcurrent))
                        .ToList();

                    var filtro2 = citas1
                        .Where(r => r.Id.Equals(filtro1[0].Id))
                        .ToList();

                    filtro2[0].Observation = false;

                    db.Update(filtro2[0]);
                    db.SaveChanges();

                    foreach (Inobservation inobservations in filtro1)
                    {
                        db.Remove(inobservations);
                        db.SaveChanges();
                    }     
                  
                    UpdateDataGridView();
                }
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)//BOTON DE AGRIGAR A COLA DE OBSERVACION 2 VACUNA
        {
            var db = new Proyecto_POO_BDDContext();
            List<Appointment> citas1 = db.Appointments.ToList();
            List<Citizen> ciudadanos = db.Citizens.ToList();
            List<Inobservation> inobservations = db.Inobservations.ToList();

            var filtro1 = ciudadanos
                .Where(d => d.Dui.Equals(labelSelectdui.Text))
                .ToList();

            var filtro2 = citas1
                .Where(e => e.IdCitizen.Equals(filtro1[0].Id))
                .ToList();

            var filtro3 = citas1
                .Where(e => e.IdCitizen.Equals(filtro1[0].Id) && e.VaccinationDate == null)
                .ToList();

            if(filtro3[0].VaccinationDate == null) 
            {
                if (filtro2.Count() == 2)
                {
                    filtro3[0].Observation = true;
                    DateTime date = (DateTime)filtro3[0].ReservationDate;
                    filtro3[0].AssistanceDate = date.AddMinutes(2);
                    DateTime datevaccine = (DateTime)filtro3[0].AssistanceDate;
                    filtro3[0].VaccinationDate = datevaccine.AddMinutes(5);

                    MessageBox.Show("Usted ha sido agregado a la cola, le atenderemos en 5 min!", "Cabina UCA",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                    db.Update(filtro3[0]);
                    db.SaveChanges();
                    InfoDataGridView();
                    tabControl1.SelectedIndex = 6;
                }
                else
                {
                    MessageBox.Show("Primero debe realizarse su primera vacuna!", "Cabina UCA",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("Usted ya se realizo las dos vacunas!", "Cabina UCA",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
    }
}
