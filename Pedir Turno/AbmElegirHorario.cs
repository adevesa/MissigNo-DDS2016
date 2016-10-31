﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class AbmElegirHorario : Form
    {
        private String usr;
        public AbmElegirHorario(String username)
        {
            this.usr = username;
            InitializeComponent();
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            AbmRol.AbmRolAfiliado abmRolAfiliado = new AbmRol.AbmRolAfiliado(usr);
            this.Hide();
            abmRolAfiliado.ShowDialog();
            this.Close();
        }

        private void AbmElegirHorario_Load(object sender, EventArgs e)
        {
            //Centra los componentes, adaptandose al tamaño del monitor//
            Size resolucionPantalla = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;

            //Centrar Panel
            Int32 anchoDePanel = (this.Width - panel1.Width) / 2;
            Int32 largoDePanel = (this.Height - panel1.Height) / 2;
            panel1.Location = new Point(anchoDePanel, largoDePanel);
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            AbmPedirTurno abmPedirTurno = new AbmPedirTurno(usr);
            this.Hide();
            abmPedirTurno.ShowDialog();
            this.Close();
        }

        private void listaDeHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
