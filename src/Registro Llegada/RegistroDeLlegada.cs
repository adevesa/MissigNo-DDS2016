﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroDeLlegada : Form
    {
         List<Palabra> listaEspecialidades = new List<Palabra>();
          BDComun conexion = new BDComun();
          Palabra especialidad = new Palabra();


        public RegistroDeLlegada()
        {
            InitializeComponent();
        }

        private void RegistroDeLlegada_Load(object sender, EventArgs e)
        {
            //Centra los componentes, adaptandose al tamaño del monitor//
            Size resolucionPantalla = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;


            //Centrar Panel
            Int32 anchoDePanel = (this.Width - panel1.Width) / 2;
            Int32 largoDePanel = (this.Height - panel1.Height) / 2;
            panel1.Location = new Point(anchoDePanel, largoDePanel);

            listaEspecialidades = conexion.obtenerTodasLasEspecialidades();
            dgvEspecialidades.DataSource = listaEspecialidades;
        }

        private void BotonConfirmar2_Click(object sender, EventArgs e)
        {
            AbmRol.AbmRolAdministrador abmRolAdministrador = new AbmRol.AbmRolAdministrador();
            this.Hide();
            abmRolAdministrador.ShowDialog();
            this.Close();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            AbmRol.AbmRolAdministrador abmRolAdministrador = new AbmRol.AbmRolAdministrador();
            this.Hide();
            abmRolAdministrador.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void botonFiltrar_Click(object sender, EventArgs e)
        {   
            


            if(especialidad.unElemento != null)
            {
            if(textoUsername.TextLength != 0)
            {
                if (conexion.esAfiliado(textoUsername.Text))
                {
                    int afiliadoId = conexion.obtenerAfiliadoId(textoUsername.Text);
                    List<int> bonos = conexion.obtenerBonosDeAfiliado(afiliadoId);
                    if(bonos.Count != 0){
            
            cargarProfesionales abm = new cargarProfesionales(especialidad, textoUsername.Text, 0);
            this.Hide();
            abm.ShowDialog();
            this.Close();
                    }
                    else MessageBox.Show("Afiliado sin bonos");
                }
                else MessageBox.Show("Afiliado inexistente");
           }
            else MessageBox.Show("Introduzca un afiliado");
            }
            else MessageBox.Show("Seleccione una especialidad");
        }

        private void dgvEspecialidades_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dgvEspecialidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int posicion = dgvEspecialidades.CurrentRow.Index;
            especialidad.unElemento = Convert.ToString( dgvEspecialidades[0, posicion].Value);
 
        }

        private void dgvEspecialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
