﻿namespace ClinicaFrba.Listados
{
    partial class top5_profesional_menos_horas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.botonVolver = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtSemestre = new System.Windows.Forms.TextBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // botonVolver
            // 
            this.botonVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.botonVolver.ForeColor = System.Drawing.Color.Black;
            this.botonVolver.Location = new System.Drawing.Point(305, 328);
            this.botonVolver.Margin = new System.Windows.Forms.Padding(2);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(153, 52);
            this.botonVolver.TabIndex = 120;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(93, 109);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(543, 186);
            this.dataGridView.TabIndex = 119;
            // 
            // txtSemestre
            // 
            this.txtSemestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSemestre.Location = new System.Drawing.Point(424, 33);
            this.txtSemestre.Name = "txtSemestre";
            this.txtSemestre.ReadOnly = true;
            this.txtSemestre.Size = new System.Drawing.Size(212, 24);
            this.txtSemestre.TabIndex = 132;
            // 
            // txtAnio
            // 
            this.txtAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.Location = new System.Drawing.Point(175, 34);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.ReadOnly = true;
            this.txtAnio.Size = new System.Drawing.Size(100, 24);
            this.txtAnio.TabIndex = 131;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 130;
            this.label2.Text = "Semestre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 129;
            this.label1.Text = "Año:";
            // 
            // top5_profesional_menos_horas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 437);
            this.Controls.Add(this.txtSemestre);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "top5_profesional_menos_horas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clinica FRBA-Top 5 Profesionales";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtSemestre;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}