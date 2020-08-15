namespace VirtualMachine
{
    partial class MainForm
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
            this.BreakPoints = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Linha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instrução = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentário = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Índice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BreakPoints
            // 
            this.BreakPoints.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BreakPoints.FillWeight = 105F;
            this.BreakPoints.HeaderText = "BreakPoints";
            this.BreakPoints.Name = "BreakPoints";
            this.BreakPoints.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Linha
            // 
            this.Linha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Linha.HeaderText = "Linha";
            this.Linha.Name = "Linha";
            this.Linha.ReadOnly = true;
            this.Linha.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Instrução
            // 
            this.Instrução.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Instrução.HeaderText = "Instrução";
            this.Instrução.Name = "Instrução";
            this.Instrução.ReadOnly = true;
            this.Instrução.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Valor_1
            // 
            this.Valor_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Valor_1.HeaderText = "Valor_1";
            this.Valor_1.Name = "Valor_1";
            this.Valor_1.ReadOnly = true;
            this.Valor_1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Valor_2
            // 
            this.Valor_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Valor_2.HeaderText = "Valor_2";
            this.Valor_2.Name = "Valor_2";
            this.Valor_2.ReadOnly = true;
            this.Valor_2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Comentário
            // 
            this.Comentário.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Comentário.FillWeight = 200F;
            this.Comentário.HeaderText = "Comentário";
            this.Comentário.Name = "Comentário";
            this.Comentário.ReadOnly = true;
            this.Comentário.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BreakPoints,
            this.Linha,
            this.Instrução,
            this.Valor_1,
            this.Valor_2,
            this.Comentário});
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(694, 345);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // Índice
            // 
            this.Índice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Índice.HeaderText = "Índice";
            this.Índice.Name = "Índice";
            this.Índice.ReadOnly = true;
            this.Índice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Valor
            // 
            this.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Índice,
            this.Valor});
            this.dataGridView2.Location = new System.Drawing.Point(712, 27);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(222, 480);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.Text = "dataGridView2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem1.Text = "Arquivo";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem3.Text = "Inserir Arquivo";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem2.Text = "Ajuda";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 514);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BreakPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instrução;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentário;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Índice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}