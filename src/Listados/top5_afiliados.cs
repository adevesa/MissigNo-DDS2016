﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class top5_afiliados : Form
    {
        private String anio;

        private int mes1;
        private int mes2;
        private int mes3;
        private int mes4;
        private int mes5;
        private int mes6;

        BindingSource bindingSource = null;

        public top5_afiliados()
        {
            InitializeComponent();
        }

        public top5_afiliados(String anio, String semestre) : this()
        {
             txtAnio.Text = anio;
            txtSemestre.Text = semestre;

            //se guardan los meses
            guardarSemestre(semestre);

            //nuevo
            bindingSource = new BindingSource();
            //
            dataGridView.DataSource = bindingSource;

            //se carga el dataGrid
            buscarLoNecesario();
            
        }

        private void guardarSemestre(String semestre)
        {
            if (semestre == "Primer semestre")
            {
                this.mes1 = 1;
                this.mes2 = 2;
                this.mes3 = 3;
                this.mes4 = 4;
                this.mes5 = 5;
                this.mes6 = 6;
            }
            if (semestre == "Segundo semestre")
            {
                this.mes1 = 7;
                this.mes2 = 8;
                this.mes3 = 9;
                this.mes1 = 10;
                this.mes2 = 11;
                this.mes3 = 12;
            }


        }

        private void buscarLoNecesario()
        {
            // Aca va la consulta que hay que armar

            String conslt = "SELECT TOP 5 U.nombre, U.apellido, count(B.bono_id), 'Pertenece grupo familiar' = CASE WHEN afiliado_encargado = 0 THEN 'NO' WHEN afiliado_encargado = 1 THEN 'SI' ELSE 'NO SE REGISTRAN DATOS INGRESADOS' END FROM MISSINGNO.Usuario AS U, MISSINGNO.Bono AS B, MISSINGNO.Afiliado AS A, MISSINGNO.Compra_bono AS CB WHERE	A.afiliado_id = B.afiliado_id AND A.username = U.username AND B.compra_bono_id = CB.compra_bono_id AND YEAR (CB.fecha_compra) = '" + Convert.ToInt32(txtAnio.Text) + "'AND MONTH(CB.fecha_compra) IN ('" + mes1 + "','" + mes2 + "','" + mes3 + "','" + mes4 + "','" + mes5 + "','" + mes6 + "') GROUP BY U.nombre,U.apellido, A.afiliado_encargado ORDER BY count(B.bono_id) desc";
            

            //a cargar el datagrid
            cargarDatagrid(conslt);

            //edito nombre de columnas del datagrid
            dataGridView.Columns[0].HeaderText = "Nombre";
            dataGridView.Columns[1].HeaderText = "Apellido";
            dataGridView.Columns[2].HeaderText = "Bonos comprados";
            dataGridView.Columns[3].HeaderText = "Pertenece a grupo familiar";
        }

        private void cargarDatagrid(String consulta)
        {
            //nuevo
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            //consulta para llenar el datagrid
            dataAdapter.SelectCommand = new SqlCommand();
            dataAdapter.SelectCommand.CommandText = consulta;
            dataAdapter.SelectCommand.Connection = BDComun.ObtenerConexion();

            //nuevo
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            //nueva
            DataTable tabla = new DataTable();
            //
            bindingSource.DataSource = tabla;

            //cargamos el datagrid
            dataAdapter.Fill(tabla);

            //libero
            dataAdapter.Dispose();
            //libero
            commandBuilder.Dispose();
            //libero
            tabla.Dispose();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            Listados.AbmListados frmAbmListados = new Listados.AbmListados();
            this.Hide();
            frmAbmListados.ShowDialog();
            this.Close();
        }

        private void top5_afiliados_Load(object sender, EventArgs e)
        {

        }
    }
}
