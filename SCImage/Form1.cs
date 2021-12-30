using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp.Extensions;

namespace SCImage
{
  public partial class Form1 : Form
  {
    private Size deltaPb_Form1;
    // private Pen pen = new Pen(Color.Red);
    private Brush brush = new SolidBrush(Color.Red);
    public Form1()
    {
      InitializeComponent();

      openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
      controller.ChangeImage += OnChangeImage;
    }

    private void OnChangeImage(object sender, string filename)
    {
      pictureBox1.Image = Image.FromFile(filename);
      pictureBox1.Size = pictureBox1.Image.Size;
      Size = pictureBox1.Size + deltaPb_Form1;

      numericUpDown1.Value = pictureBox1.Width;
      numericUpDown2.Value = pictureBox1.Height;
      controller.LoadImage((Bitmap) pictureBox1.Image.Clone());
      controller.CreateMask(pictureBox1.Image);
      // bmp = (Bitmap)pictureBox1.Image;

    }
    private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
      {
        return;
      }
      controller.OpenFile(openFileDialog1.FileName);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      deltaPb_Form1 = new Size(this.Size.Width - pictureBox1.Size.Width, Size.Height - pictureBox1.Size.Height);
      pictureBox1.AllowDrop = true;
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
      var size = Size - deltaPb_Form1;
      pictureBox1.Size = size;

    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (backgroundWorker1.IsBusy)
        MessageBox.Show("Worker is working", "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      else
      {
        progressBar1.Visible = true;
        // lWait.Visible = true;
        progressBar1.Value = 0;
        backgroundWorker1.RunWorkerAsync();
      }
    }
    

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker bg = sender as BackgroundWorker;
      
      e.Result = new Bitmap(controller.DeleteLines(controller.GetImage(), (int)numericUpDown1.Value, 
        (int)numericUpDown2.Value, bg));
      
    }
    
    private int Clamp(int i)
    {
      if (i > 100)
        return 100;
      return i;
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar1.Value = Clamp(e.ProgressPercentage);
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Bitmap b = (Bitmap) e.Result;
      pictureBox1.Image = b;
      numericUpDown1.Value = b.Width;
      numericUpDown2.Value = b.Height;

      pictureBox1.Size = b.Size;
      Size = b.Size + deltaPb_Form1;

      controller.LoadImage((Bitmap) pictureBox1.Image.Clone());
      controller.CreateMask(pictureBox1.Image);
      progressBar1.Visible = false;
    }

    private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        pictureBox1.Image.Save(saveFileDialog1.FileName);
      }
    }

    private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void pictureBox1_DragDrop(object sender, DragEventArgs e)
    {
      string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
      controller.OpenFile(file[0]);
    }

    private void pictureBox1_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {

      if (pictureBox1.Image == null || backgroundWorker1.IsBusy)
      {
        return;
      }
      
      if ((e.Button & MouseButtons.Left) != 0)
      {
        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
        {
          g.FillRectangle(brush, e.X - 4, e.Y - 4, 9, 9);
          controller.AddRectangle(new Point(e.X - 4, e.Y - 4), 9, 9);
        }
        pictureBox1.Invalidate();
      }
    }

    public void DrawMap(ImgMask mask)
    {
      using (Graphics g = Graphics.FromImage(pictureBox1.Image))
      {
        for (int i = 0; i < mask.GetDataSize().Width; ++i)
        {
          for (int j = 0; j < mask.GetDataSize().Height; ++j)
          {
            if (mask.Data[j, i] == 1)
              g.FillRectangle(brush, i, j, 1, 1);

          }
        }
      }
      pictureBox1.Invalidate();
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
      
      if (pictureBox1.Image == null) return;
      
      pictureBox1.Image = (Bitmap)controller.GetImage().Clone();
      controller.LoadMask((Bitmap)pictureBox1.Image.Clone());
      
      DrawMap(controller.GetMask());

    }
    
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (pictureBox1.Image == null) return;
      if(e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
      {
        controller.Undo();
        
        pictureBox1.Image = (Bitmap)controller.GetImage().Clone();
        if (pictureBox1.Image != null)
        {
          DrawMap(controller.GetMask());
        }
        
      } else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.U)
      {
        controller.Redo();
        
        pictureBox1.Image = (Bitmap)controller.GetImage().Clone();
        DrawMap(controller.GetMask());
       
      }
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      if (pictureBox1.Image == null) return;
      
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (pictureBox1.Image == null) return;
      F2.ShowImage(controller.GetGrayImage(pictureBox1.Image));
    }
  }
  
}
