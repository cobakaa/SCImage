using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Size = OpenCvSharp.Size;

namespace SCImage
{
    public class LiquidResize
    {
        private Mat image;
        private int[,] energy;
        private int[,] sum;
        private int[,] hsum;

        private ImgMask mask;

        public LiquidResize(Image img, ImgMask mask)
        {
            image = BitmapConverter.ToMat((Bitmap)img);
            energy = new int[image.Height, image.Width];
            sum = new int[image.Height, image.Width];
            hsum = new int[image.Height, image.Width];
            if (mask == null)
            {
                this.mask = ImgMask.GetZeroData(img);
            } else this.mask = mask.Clone();
        }

        private void Allocate()
        {
            energy = new int[image.Height, image.Width];
            sum = new int[image.Height, image.Width];
            hsum = new int[image.Height, image.Width];
            mask = new ImgMask(new int[image.Height, image.Width]);
        }
        
        private void FindEnergy()
        {
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    energy[i, j] = 0;
                    
                    for (int k = 0; k < 3; k++)
                    {
                        int sum = 0, count = 0;

                        // Если пиксел не крайний снизу, то добавляем в sum разность между текущим
                        // пикселом и соседом снизу
                        if (i != image.Height - 1)
                        {
                            count++;
                            sum += Math.Abs(image.At<Vec3b>(i, j)[k] - image.At<Vec3b>(i + 1, j)[k]);
                        }

                        // Если пиксел не крайний справа, то добавляем в sum разность между поточным
                        // пикселом и соседом справа
                        if (j != image.Width - 1)
                        {
                            count++;
                            sum += Math.Abs(image.At<Vec3b>(i, j)[k] - image.At<Vec3b>(i, j + 1)[k]);
                        }

                        // В массив energy добавляем среднее арифметическое разностей пикселя с соседями
                        // по k-той компоненте (то есть по R, G или B)
                        if (count != 0)
                            energy[i, j] += sum / count;
                    }
                }
            }

            for (int i = 0; i < image.Height; ++i)
            {
                for (int j = 0; j < image.Width; ++j)
                {
                    if (mask.Data[i, j] == 1)
                    {
                        energy[i, j] = -Math.Max(image.Height, image.Width);
                    }
                }
            }
        }
        
        private void FindSum()
        {
            FindEnergy();
            // Для верхней строчки значение sum и energy будут совпадать
            for (int j = 0; j < image.Width; j++)
                sum[0, j] = energy[0, j];

            // Для всех остальных пикселей значение элемента (i,j) массива sum будут равны
            //  energy[i,j] + MIN ( sum[i-1, j-1], sum[i-1, j], sum[i-1, j+1])
            for (int i = 1; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    sum[i, j] = sum[i - 1, j];
                    if (j > 0 && sum[i - 1, j - 1] < sum[i, j]) sum[i, j] = sum[i - 1, j - 1];
                    if (j < image.Width - 1 && sum[i - 1, j + 1] < sum[i, j]) sum[i, j] = sum[i - 1, j + 1];

                    sum[i, j] += energy[i, j];
                }
            }
        }
        
        private void FindHSum()
        {
            FindEnergy();
            // Для верхней строчки значение sum и energy будут совпадать
            for (int j = 0; j < image.Height; j++)
                hsum[j, 0] = energy[j, 0];
            
            
            for (int i = 1; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    hsum[j, i] = hsum[j, i - 1];
                    if (j > 0 && hsum[j - 1, i - 1] < hsum[j, i]) hsum[j, i] = hsum[j - 1, i - 1];
                    if (j < image.Height - 1 && hsum[j + 1, i - 1] < hsum[j, i]) hsum[j, i] = hsum[j + 1, i - 1];

                    hsum[j, i] += energy[j, i];
                }
            }
        }
        
        private int[] FindVerticalPixels()
        {
            FindSum();
            // Номер последней строчки
            int last = image.Height - 1;
            // Выделяем память под массив результатов
            int[] res = new int[image.Height];

            // Ищем минимальный элемент массива sum, который находиться в нижней строке
            // и записываем результат в res[last]
            res[last] = 0;
            for (int j = 1; j < image.Width; j++)
            {
                if (sum[last, j] < sum[last, res[last]])
                    res[last] = j;
            }
            
            // Теперь вычисляем все элементы массива от предпоследнего до первого.
            for (int i = last - 1; i >= 0; i--)
            {
                // prev - номер пикселя цепочки из предыдущей строки
                // В этой строке пикселями цепочки могут быть только (prev-1), prev или (prev+1),
                // поскольку цепочка должна быть связанной
                int prev = res[i + 1];
          
                // Здесь мы ищем, в каком элементе массива sum, из тех, которые мы можем удалить,
                // записано минимальное значение и присваиваем результат переменной res[i]
                res[i] = prev;
                if (prev > 0 && sum[i, res[i]] > sum[i, prev - 1]) res[i] = prev - 1;
                if (prev < image.Width - 1 && sum[i, res[i]] > sum[i, prev + 1]) res[i] = prev + 1;
            }

            return res;
        }

        private int[] FindHorizontalPixels()
        {
            FindHSum();
            
            int last = image.Width - 1;
            
            int[] res = new int[image.Width];

            
            res[last] = 0;
            for (int j = 1; j < image.Height; j++)
            {
                if (hsum[j, last] < hsum[res[last], last])
                    res[last] = j;
            }
            
            
            for (int i = last - 1; i >= 0; i--)
            {
                
                int prev = res[i + 1];
          
                
                res[i] = prev;
                if (prev > 0 && hsum[res[i], i] > hsum[prev - 1, i]) res[i] = prev - 1;
                if (prev < image.Height - 1 && hsum[res[i], i] > hsum[ prev + 1, i]) res[i] = prev + 1;
            }

            return res;
        }

        private void RemoveVerticalSeam(int[] col)
        {
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = col[i]; j < image.Width; j++)
                {
                    image.At<Vec3b>(i, j) = image.At<Vec3b>(i, j + 1);
                    mask.Data[i, j] = mask.Data[i, Math.Min(j + 1, image.Width - 1)];
                }
            }
            
            image = image.ColRange(0, image.Width - 1);
        }
        
        private void RemoveHorizontalSeam(int[] row)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = row[i]; j < image.Height - 1; j++)
                {
                    image.At<Vec3b>(j, i) = image.At<Vec3b>(j + 1, i);
                    mask.Data[j, i] = mask.Data[Math.Min(j + 1, image.Height), i];
                }
            }

            image = image.RowRange(0, image.Height - 1);
        }

        internal Image Retarget(int nwidth, int nheight, System.ComponentModel.BackgroundWorker bg)
        {
            int hdiff = image.Width - nwidth;
            int vdiff = image.Height - nheight;
            int steps = 0;
            int step = 0;

            if (hdiff == 0 && vdiff == 0)
            {
                return image.ToBitmap();
            }

            while (hdiff < 0)
            {
                int newWidth = (int) (image.Width * 1.1);
                // int newHeight = (int) (image.Height * 1.1);
                image = image.Resize(new Size(newWidth, image.Height), 0, 0).Clone();
                hdiff = image.Width - nwidth;
                // vdiff = image.Height - nheight;
                Allocate();
            }
            
            while (vdiff < 0)
            {
                // int newWidth = (int) (image.Width * 1.1);
                int newHeight = (int) (image.Height * 1.1);
                image = image.Resize(new Size(image.Width, newHeight), 0, 0).Clone();
                // hdiff = image.Width - nwidth;
                vdiff = image.Height - nheight;
                Allocate();
            }
            
            
            
            steps += Math.Abs(hdiff);
            steps += Math.Abs(vdiff);
            
            

            if (hdiff > 0)
            {
                while (hdiff-- > 0)
                {
                    
                    RemoveVerticalSeam(FindVerticalPixels());
                    ++step;

                    if (bg != null)
                        bg.ReportProgress(step * 100 / steps);
                }
            }

            if (vdiff > 0)
            {
                while (vdiff-- > 0)
                {
                    RemoveHorizontalSeam(FindHorizontalPixels());
                    
                    ++step;

                    if (bg != null)
                        bg.ReportProgress(step * 100 / steps);
                }
            }
            
            if (bg != null)
                bg.ReportProgress(100);
            
            

            return image.ToBitmap();
        }


        public Image GrayMap()
        {
            FindEnergy();
            var bitmap = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppRgb);

            for (int y = 0; y < image.Width; y++)
            for (int x = 0; x < image.Height; x++)
            {
                int red = (energy[x, y] >= 0) ? energy[x, y] % 256 : 0; // read from array
                int green = (energy[x, y] >= 0) ? energy[x, y] % 256 : 0; // read from array
                int blue = (energy[x, y] >= 0) ? energy[x, y] % 256 : 0; // read from array
                bitmap.SetPixel(y, x, Color.FromArgb(0, red, green, blue));
            }

            return bitmap;
        }
    }
}