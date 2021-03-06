﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Compra_Bono
{
    public partial class AbmComprarBono : Form
    {   //Atributos//
        BDComun conexion = new BDComun();
        private String username;

        public AbmComprarBono()
        {
            this.username = Program.usuario;
            InitializeComponent();
        }

        private void AbmComprarBono_Load(object sender, EventArgs e)
        {
            conexion.usernamesFamiliares(username, comboBoxUsuario);
        }

        private void textoCantidadDeBonos_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textoCantidadesDeBonos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        public bool errores_de_registro()
        {
            return ((textoCantidadDeBonos.Text.Length == 0) || (textoCantidadDeBonos.Text == "Ingrese un número") || Convert.ToInt32(textoCantidadDeBonos.Text) <= 0 || comboBoxUsuario.Text == "Elija un afiliado");
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            if (errores_de_registro())
            {
                MessageBox.Show("Datos incorrectos");
            }
            else
            {
               conexion.comprarBonos(Convert.ToInt32(textoCantidadDeBonos.Text), comboBoxUsuario.Text);
            }
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void boxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
