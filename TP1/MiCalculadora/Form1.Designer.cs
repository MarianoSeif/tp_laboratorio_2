namespace MiCalculadora
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
            this.tbOperando1 = new System.Windows.Forms.TextBox();
            this.tbOperando2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOperando1 = new System.Windows.Forms.Label();
            this.lblOperando2 = new System.Windows.Forms.Label();
            this.cbOperador = new System.Windows.Forms.ComboBox();
            this.btnOperar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbOperando1
            // 
            this.tbOperando1.Location = new System.Drawing.Point(36, 68);
            this.tbOperando1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOperando1.MinimumSize = new System.Drawing.Size(4, 50);
            this.tbOperando1.Name = "tbOperando1";
            this.tbOperando1.Size = new System.Drawing.Size(148, 50);
            this.tbOperando1.TabIndex = 0;
            // 
            // tbOperando2
            // 
            this.tbOperando2.Location = new System.Drawing.Point(480, 68);
            this.tbOperando2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOperando2.MinimumSize = new System.Drawing.Size(4, 50);
            this.tbOperando2.Name = "tbOperando2";
            this.tbOperando2.Size = new System.Drawing.Size(148, 50);
            this.tbOperando2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 32);
            this.label1.TabIndex = 0;
            // 
            // lblOperando1
            // 
            this.lblOperando1.AutoSize = true;
            this.lblOperando1.Location = new System.Drawing.Point(36, 23);
            this.lblOperando1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOperando1.Name = "lblOperando1";
            this.lblOperando1.Size = new System.Drawing.Size(92, 22);
            this.lblOperando1.TabIndex = 3;
            this.lblOperando1.Text = "Operando 1";
            // 
            // lblOperando2
            // 
            this.lblOperando2.AutoSize = true;
            this.lblOperando2.Location = new System.Drawing.Point(476, 23);
            this.lblOperando2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOperando2.Name = "lblOperando2";
            this.lblOperando2.Size = new System.Drawing.Size(92, 22);
            this.lblOperando2.TabIndex = 4;
            this.lblOperando2.Text = "Operando 2";
            // 
            // cbOperador
            // 
            this.cbOperador.FormattingEnabled = true;
            this.cbOperador.Location = new System.Drawing.Point(258, 68);
            this.cbOperador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbOperador.Name = "cbOperador";
            this.cbOperador.Size = new System.Drawing.Size(180, 30);
            this.cbOperador.TabIndex = 5;
            // 
            // btnOperar
            // 
            this.btnOperar.Location = new System.Drawing.Point(16, 167);
            this.btnOperar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(225, 69);
            this.btnOperar.TabIndex = 6;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(275, 167);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(225, 69);
            this.button2.TabIndex = 7;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(531, 167);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(225, 69);
            this.button3.TabIndex = 8;
            this.button3.Text = "Cerrar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 262);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(350, 69);
            this.button4.TabIndex = 9;
            this.button4.Text = "Convertir a Binario";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(406, 262);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(350, 69);
            this.button5.TabIndex = 10;
            this.button5.Text = "Convertir a Decimal";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOperar);
            this.Controls.Add(this.cbOperador);
            this.Controls.Add(this.lblOperando2);
            this.Controls.Add(this.lblOperando1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOperando2);
            this.Controls.Add(this.tbOperando1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Form1";
            this.Text = "Calculadora de Mariano Seif del curso 2D";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOperando1;
        private System.Windows.Forms.TextBox tbOperando2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOperando1;
        private System.Windows.Forms.Label lblOperando2;
        private System.Windows.Forms.ComboBox cbOperador;
        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

