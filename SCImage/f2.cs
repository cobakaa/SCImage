
using System.Drawing;
using System.Windows.Forms;

namespace SCImage
{
    public class F2
    {
        public static void ShowImage(Image img)
        {
            var f2 = new Form();
            var pb = new PictureBox();
            pb.Image = img;
            f2.Size = img.Size;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            f2.Controls.Add(pb);
            f2.Show();
        }
    }
}