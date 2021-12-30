namespace SCImage
{
  partial class Form1
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.button1 = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.файлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.открытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.сохранитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.выходToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.button2 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.numericUpDown2)).BeginInit();
      this.SuspendLayout();
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button1.Location = new System.Drawing.Point(12, 416);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(77, 22);
      this.button1.TabIndex = 2;
      this.button1.Text = "Применить";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox1.Location = new System.Drawing.Point(12, 27);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(679, 375);
      this.pictureBox1.TabIndex = 3;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
      this.pictureBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragEnter);
      this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
      this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
      this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.файлToolStripMenuItem1, this.toolStripMenuItem1});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(800, 24);
      this.menuStrip1.TabIndex = 5;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // файлToolStripMenuItem1
      // 
      this.файлToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.открытьToolStripMenuItem1, this.toolStripSeparator3, this.сохранитьToolStripMenuItem1, this.toolStripSeparator4, this.выходToolStripMenuItem1});
      this.файлToolStripMenuItem1.Name = "файлToolStripMenuItem1";
      this.файлToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
      this.файлToolStripMenuItem1.Text = "&Файл";
      // 
      // открытьToolStripMenuItem1
      // 
      this.открытьToolStripMenuItem1.Image = ((System.Drawing.Image) (resources.GetObject("открытьToolStripMenuItem1.Image")));
      this.открытьToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
      this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
      this.открытьToolStripMenuItem1.Text = "&Открыть";
      this.открытьToolStripMenuItem1.Click += new System.EventHandler(this.открытьToolStripMenuItem1_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(130, 6);
      // 
      // сохранитьToolStripMenuItem1
      // 
      this.сохранитьToolStripMenuItem1.Image = ((System.Drawing.Image) (resources.GetObject("сохранитьToolStripMenuItem1.Image")));
      this.сохранитьToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.сохранитьToolStripMenuItem1.Name = "сохранитьToolStripMenuItem1";
      this.сохранитьToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
      this.сохранитьToolStripMenuItem1.Text = "&Сохранить";
      this.сохранитьToolStripMenuItem1.Click += new System.EventHandler(this.сохранитьToolStripMenuItem1_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(130, 6);
      // 
      // выходToolStripMenuItem1
      // 
      this.выходToolStripMenuItem1.Name = "выходToolStripMenuItem1";
      this.выходToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
      this.выходToolStripMenuItem1.Text = "Вы&ход";
      this.выходToolStripMenuItem1.Click += new System.EventHandler(this.выходToolStripMenuItem1_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.WorkerReportsProgress = true;
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
      this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.numericUpDown1.Location = new System.Drawing.Point(113, 416);
      this.numericUpDown1.Maximum = new decimal(new int[] {4096, 0, 0, 0});
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(76, 20);
      this.numericUpDown1.TabIndex = 6;
      // 
      // numericUpDown2
      // 
      this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.numericUpDown2.Location = new System.Drawing.Point(204, 416);
      this.numericUpDown2.Maximum = new decimal(new int[] {4096, 0, 0, 0});
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new System.Drawing.Size(76, 20);
      this.numericUpDown2.TabIndex = 6;
      // 
      // progressBar1
      // 
      this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.progressBar1.Location = new System.Drawing.Point(310, 416);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(202, 18);
      this.progressBar1.TabIndex = 7;
      // 
      // button2
      // 
      this.button2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button2.Location = new System.Drawing.Point(529, 415);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(89, 23);
      this.button2.TabIndex = 8;
      this.button2.Text = "GrayImage";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.numericUpDown2);
      this.Controls.Add(this.numericUpDown1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.menuStrip1);
      this.KeyPreview = true;
      this.Location = new System.Drawing.Point(15, 15);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
      ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.numericUpDown2)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    private System.Windows.Forms.ProgressBar progressBar1;

    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.NumericUpDown numericUpDown2;

    private System.ComponentModel.BackgroundWorker backgroundWorker1;

    private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem1;


    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.OpenFileDialog openFileDialog1;

    private System.Windows.Forms.MenuStrip menuStrip1;

    #endregion

    private Controller controller = new Controller();
  }
}

