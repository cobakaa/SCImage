using System;
using System.Drawing;

namespace SCImage
{
    public class ImgMask
    {
        public int[,] Data;
        private int dataWidth;
        private int dataHeight;

        public ImgMask(Image img)
        {
            CreateData(img);
        }

        public ImgMask(int[,] mask)
        {
            Data = mask;
        }

        public Size GetDataSize()
        {
            return new Size(dataWidth, dataHeight);
        }
 
        public void CreateData(Image img)
        {
            Data = new int[img.Height, img.Width];
            dataHeight = img.Height;
            dataWidth = img.Width;
            for (int i = 0; i < img.Height; ++i)
            {
                for (int j = 0; j < img.Width; ++j)
                {
                    Data[i, j] = 0;
                }
            }
        }

        public ImgMask Clone()
        {
            var tmpData = new int[dataHeight, dataWidth];
            for (int i = 0; i < dataHeight; ++i)
            {
                for (int j = 0; j < dataWidth; ++j)
                {
                    tmpData[i, j] = Data[i, j];
                }
            }

            var res = new ImgMask(tmpData);
            res.dataHeight = dataHeight;
            res.dataWidth = dataWidth;

            return res;
        }

        public int[,] GetData()
        {
            return Data;
        }
        
        public static ImgMask GetZeroData(Image img)
        {
            
            var zeroData = new int[img.Height, img.Width];
            var dataHeight = img.Height;
            var dataWidth = img.Width;
            for (int i = 0; i < img.Height; ++i)
            {
                for (int j = 0; j < img.Width; ++j)
                {
                    zeroData[i, j] = 0;
                }
            }

            var res = new ImgMask(zeroData);
            res.dataHeight = dataHeight;
            res.dataWidth = dataWidth;

            return res;
        }

        public void AddRectangle(Point pc, int width, int height)
        {
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    Data[Math.Min(Math.Max(0, pc.Y + j), dataHeight), Math.Min(Math.Max(0, pc.X + i), dataWidth)] = 1;
                }
            }
        }

        public bool IsDataEmpty()
        {
            for (int i = 0; i < dataHeight; ++i)
            {
                for (int j = 0; j < dataWidth; ++j)
                {
                    if (Data[i, j] == 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int GetDeletedWidth()
        {
            int res = 0;
            
            for (int i = 0; i < dataWidth; ++i)
            {
                for (int j = 0; j < dataHeight; ++j)
                {
                    if (Data[j, i] == 1)
                    {
                        res++;
                        break;
                    }
                }
            }

            return res;
        }
        
        public int GetDeletedHeight()
        {
            int res = 0;
            
            for (int i = 0; i < dataHeight; ++i)
            {
                for (int j = 0; j < dataWidth; ++j)
                {
                    if (Data[i, j] == 1)
                    {
                        res++;
                        break;
                    }
                }
            }

            return res;
        }
    }
}