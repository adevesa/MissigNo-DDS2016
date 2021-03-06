﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    
    public partial class AbmCrearAfiliado2 : Form
    {   //Atributos//
        AfiliadoCompleto afiliado = new AfiliadoCompleto();
        BDComun conexion = new BDComun();
        public int contador = 0;
        public string plan;
        public int planIdViejo = -1;

        public AbmCrearAfiliado2()
        {
            InitializeComponent();
        }

        private void AbmAfiliado_Load(object sender, EventArgs e)
        {
            //Centra los componentes, adaptandose al tamaño del monitor//
            Size resolucionPantalla = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;


            //Centrar Panel
            Int32 anchoDePanel = (this.Width - panel1.Width) / 2;
            Int32 largoDePanel = (this.Height - panel1.Height) / 2;
            panel1.Location = new Point(anchoDePanel, largoDePanel);
            textMotivo.Enabled = false;

            //Inicializo el combobox de planes con todos los de la base de datos
            conexion.recuperarPlanes(planMedico, plan);
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //@Desc evita que se manden textBox vacios
        public bool errores_de_registro()
        {
            return (textoDireccion.Text.Length == 0 || textoTelefono.Text.Length == 0 ||  eleccionSexo.Text.Length == 0 || planMedico.Text == "Elija uno" || eleccionSexo.Text == "Sexo" || textoContraseña.Text.Length == 0 || textoEmail.Text.Length == 0 || textoUsername.Text.Length == 0 || (textMotivo.Text.Length == 0 && textMotivo.Enabled == true));

        }

        public bool errores_de_exceso()
        {
            return (textoDireccion.Text.Length < 150 && textoTelefono.Text.Length < 15 && textoContraseña.Text.Length < 30 && textoEmail.Text.Length < 60 && textoUsername.Text.Length < 60);
        }

        private void BotonConfirmar2_Click(object sender, EventArgs e)
        {

            if( errores_de_exceso())
                {
            if (errores_de_registro())//verifico que esten todos los datos
            {
                MessageBox.Show("Faltan completar datos");
            }
            else
            {
                if (textMotivo.Text.Length > 139) 
                { 
                    MessageBox.Show("El motivo no debe superar los 140 caracteres");
                }
                else
                {
                 if (conexion.existeUsuario(textoUsername.Text))//verifico existencia del usuario
                    {
                     List<AfiliadoSimple> lista = new List<AfiliadoSimple>();
                    conexion.modificarAfiliado(textoUsername.Text, textoContraseña.Text, eleccionSexo.Text, textoDireccion.Text, textoEmail.Text, textoTelefono.Text, estadoCivil.Text, planMedico.Text, textMotivo.Text);
                    AbmAdministrarAfiliado abmAfiliado = new AbmAdministrarAfiliado();
                    MessageBox.Show("Usuario modificado exitosamente");
                    this.Hide();
                    abmAfiliado.ShowDialog();
                    this.Close();
                  }
                 else MessageBox.Show("Usuario inexistente");
                }
                
            }
                }
            else MessageBox.Show("Hay exceso de caracteres en uno de los campos");
            
            
            
 
           
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            AbmAdministrarAfiliado abmAfiliado = new AbmAdministrarAfiliado();
            this.Hide();
            abmAfiliado.ShowDialog();
            this.Close();
           
        }

        private void butonAgregar_Click(object sender, EventArgs e)
        {
            List<AfiliadoSimple> lista = new List<AfiliadoSimple>();
            //verifico si el contador es distinto de 0 para poder avanzara  la siguiente abm,
            //este contador cambia de valor al realizar una busqueda exitosa de un username.
            //Es decir, hasta que no se busque un usuario no te deja modificar datos
     /* if(contador != 0){
            int tam = afiliado.hijos.Count();
            if (tam != 0){
            int i;
            for(i = 0; tam>i; i++)  {
               AfiliadoSimple datosAfiliado =  conexion.obtenerDatosAfiliadoSimple(afiliado.hijos[i]);
               lista.Add(datosAfiliado);
                }

            }
     
            AbmConsultaFamiliar abmConsulta = new AbmConsultaFamiliar(lista, textoUsername.Text, textoDireccion.Text);
            this.Hide();
            abmConsulta.ShowDialog();
            this.Close();
     }
     else MessageBox.Show("Primero debes buscar un usuario");
       
            */

             if( errores_de_exceso())
                {
             if (errores_de_registro())//verifico que esten todos los datos
            {
                MessageBox.Show("Faltan completar datos");
            }
            else
            {
                if (textMotivo.Text.Length > 139) 
                { 
                    MessageBox.Show("El motivo no debe superar los 140 caracteres");
                }
                else
                {
                 if (conexion.existeUsuario(textoUsername.Text))//verifico existencia del usuario
                    {
      if(contador != 0){
            int tam = afiliado.hijos.Count();
            if (tam != 0){
            int i;
            for(i = 0; tam>i; i++)  {
               AfiliadoSimple datosAfiliado =  conexion.obtenerDatosAfiliadoSimple(afiliado.hijos[i]);
               lista.Add(datosAfiliado);
                }
                }
            conexion.modificarAfiliado(textoUsername.Text, textoContraseña.Text, eleccionSexo.Text, textoDireccion.Text, textoEmail.Text, textoTelefono.Text, estadoCivil.Text, planMedico.Text, textMotivo.Text);
            AbmConsultaFamiliar abmConsulta = new AbmConsultaFamiliar(lista, textoUsername.Text, textoDireccion.Text);
            this.Hide();
            abmConsulta.ShowDialog();
            this.Close();
                  }
                 else MessageBox.Show("Usuario inexistente");
                }

        }
            }
                }
             else MessageBox.Show("Hay exceso de caracteres en uno de los campos");
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {//verifica que hayan escrito algo en el textBox del username
            if((textoUsername.Text).Length != 0){
                //controlo que exista el username
                if (conexion.esAfiliado(textoUsername.Text))
                {
                    //obtengo todos los datos del afiliado buscado y los guardo en una clase
                    afiliado = conexion.obtenerDatosAfiliadoCompleto(textoUsername.Text);
                    //Copio los datos guardados en la clase en los textBox del abm                                                                       
                    textoDireccion.Text = afiliado.domicilio;
                    textoTelefono.Text = Convert.ToString(afiliado.telefono);
                    textoEmail.Text = afiliado.mail;
                    eleccionSexo.Text = reDescifrar(afiliado.sexo);
                    estadoCivil.Text = afiliado.afiliado_estado_civil;
                    string descripcionDePlan = conexion.obtenerDescripcionDePlan(afiliado.planId);
                    planMedico.Text = descripcionDePlan;
                    //planMedico.Text
                    planIdViejo = conexion.obtenerPlanIdDeAfiliado(textoUsername.Text);
                    //sumo uno al contador
                    contador ++;
                }
                else MessageBox.Show("Afiliado inexistente");
            }
            else MessageBox.Show("Debes introducir un nombre de usuario");
        }

        public string reDescifrar(string genero)
        {
            if (genero == "H") return "Hombre";
            else return "Mujer";
        }


        private void textoTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void textoTelefono_Click(object sender, EventArgs e)
        {

        }

        //Funciones para asegurar que solo se escriban numeros en los textBox de telefono y documento

        private void textoTelefono_KeyPress(object sender, KeyPressEventArgs e)
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


        private void textoDocumento_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textoContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void textMotivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textoNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void planMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comprobarCambio(object sender, EventArgs e)
        {
            if (planIdViejo != -1)
            {
                if (conexion.obtenerPlanId(planMedico.Text).ToString() != planIdViejo.ToString())
                {
                    textMotivo.Enabled = true;
                }
                else
                    textMotivo.Enabled = false;
            }
        }
    }
}
