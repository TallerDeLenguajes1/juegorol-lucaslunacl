
namespace JuegoRol
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Humano = new System.Windows.Forms.RadioButton();
            this.Orco = new System.Windows.Forms.RadioButton();
            this.Elfo = new System.Windows.Forms.RadioButton();
            this.Hobbit = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.nombre = new System.Windows.Forms.TextBox();
            this.apodo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fecnaci = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Apodo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tipo De Personaje";
            // 
            // Humano
            // 
            this.Humano.AutoSize = true;
            this.Humano.Checked = true;
            this.Humano.Location = new System.Drawing.Point(12, 191);
            this.Humano.Name = "Humano";
            this.Humano.Size = new System.Drawing.Size(65, 17);
            this.Humano.TabIndex = 3;
            this.Humano.TabStop = true;
            this.Humano.Text = "Humano";
            this.Humano.UseVisualStyleBackColor = true;
            // 
            // Orco
            // 
            this.Orco.AutoSize = true;
            this.Orco.Location = new System.Drawing.Point(88, 191);
            this.Orco.Name = "Orco";
            this.Orco.Size = new System.Drawing.Size(48, 17);
            this.Orco.TabIndex = 4;
            this.Orco.Text = "Orco";
            this.Orco.UseVisualStyleBackColor = true;
            // 
            // Elfo
            // 
            this.Elfo.AutoSize = true;
            this.Elfo.Location = new System.Drawing.Point(153, 191);
            this.Elfo.Name = "Elfo";
            this.Elfo.Size = new System.Drawing.Size(43, 17);
            this.Elfo.TabIndex = 5;
            this.Elfo.Text = "Elfo";
            this.Elfo.UseVisualStyleBackColor = true;
            // 
            // Hobbit
            // 
            this.Hobbit.AutoSize = true;
            this.Hobbit.Location = new System.Drawing.Point(216, 191);
            this.Hobbit.Name = "Hobbit";
            this.Hobbit.Size = new System.Drawing.Size(56, 17);
            this.Hobbit.TabIndex = 6;
            this.Hobbit.Text = "Hobbit";
            this.Hobbit.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Crear Personaje";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.click_crear);
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(88, 38);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(100, 20);
            this.nombre.TabIndex = 8;
            // 
            // apodo
            // 
            this.apodo.Location = new System.Drawing.Point(88, 82);
            this.apodo.Name = "apodo";
            this.apodo.Size = new System.Drawing.Size(100, 20);
            this.apodo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha de Nacimiento";
            // 
            // fecnaci
            // 
            this.fecnaci.Location = new System.Drawing.Point(49, 131);
            this.fecnaci.Name = "fecnaci";
            this.fecnaci.Size = new System.Drawing.Size(200, 20);
            this.fecnaci.TabIndex = 11;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.fecnaci);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.apodo);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Hobbit);
            this.Controls.Add(this.Elfo);
            this.Controls.Add(this.Orco);
            this.Controls.Add(this.Humano);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton Humano;
        private System.Windows.Forms.RadioButton Orco;
        private System.Windows.Forms.RadioButton Elfo;
        private System.Windows.Forms.RadioButton Hobbit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox apodo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker fecnaci;
    }
}

