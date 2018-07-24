using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OpenTK.Graphics.OpenGL;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace Tiles
{
    public class Texture
    {
        private readonly Bitmap image;
        public int texId;

        public Texture(Bitmap image, int texId)
        {
            this.image = image;
            this.texId = texId;
        }

        public Texture(string filename, int texId)
        {
            try
            {
                image = new Bitmap(filename);
            }
            catch (FileNotFoundException e)
            {
                Console.Out.WriteLine("Cant find image texture");
            }

            this.texId = texId;
        }

        public void Load()
        {
            GL.Enable(EnableCap.Texture2D);

            GL.GenTextures(1, out texId);
            GL.BindTexture(TextureTarget.Texture2D, texId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int) TextureMagFilter.Linear);

            var data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            image.UnlockBits(data);
        }
    }
}