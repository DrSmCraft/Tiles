using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Tiles
{
    public class Texture
    {
        public int texId;
        private Bitmap image;

        public Texture(Bitmap image, int texId)
        {
            this.image = image;
            this.texId = texId;
        }

        public Texture(string filename, int texId)
        {
            Console.Out.WriteLine("top");
            try
            {
                   image = new Bitmap(filename);
            }
            catch (FileNotFoundException e)
            {
                Console.Out.WriteLine("Cant find image texture");
            }

            this.texId = texId;
            Console.Out.WriteLine("bottom");

        }


//        public int load()
//        {
//            int texID = GL.GenTexture();
//
//            GL.BindTexture(TextureTarget.Texture2D, texID);
//            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
//                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
//
////            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
////                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
//
//            image.UnlockBits(data);
//
//            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0,
//                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
//
//            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
//
//            return texID;
//        }

        public void Load()
        {
            GL.Enable(EnableCap.Texture2D);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out texId);
            GL.BindTexture(TextureTarget.Texture2D, texId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            BitmapData data = image.LockBits(new System.Drawing.Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            image.UnlockBits(data);
        }
    }
}