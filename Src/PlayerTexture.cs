using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace Tiles
{
    public class PlayerTexture : Texture
    {
        private readonly Bitmap back;
        private readonly Bitmap front;
        private readonly Bitmap left;
        private readonly Bitmap right;
        private int frontId, backId, leftId, rightId;

        public PlayerTexture(Bitmap front, int frontId, Bitmap back, int backId, Bitmap left, int leftId, Bitmap right,
            int rightId) : base(front, frontId)
        {
            this.front = front;
            this.back = back;
            this.left = left;
            this.right = right;

            this.frontId = frontId;
            this.backId = backId;
            this.leftId = leftId;
            this.rightId = rightId;
        }

        public PlayerTexture(string front, int frontId, string back, int backId, string left, int leftId, string right,
            int rightId) : base(front, frontId)
        {
            this.front = new Bitmap(front);
            this.back = new Bitmap(back);
            this.left = new Bitmap(left);
            this.right = new Bitmap(right);

            this.frontId = frontId;
            this.backId = backId;
            this.leftId = leftId;
            this.rightId = rightId;
        }

        public void LoadFront()
        {
            GL.Enable(EnableCap.Texture2D);

            GL.GenTextures(1, out frontId);
            GL.BindTexture(TextureTarget.Texture2D, frontId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int) TextureMagFilter.Linear);

            var data = front.LockBits(new Rectangle(0, 0, front.Width, front.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            front.UnlockBits(data);
        }

        public void LoadBack()
        {
            GL.Enable(EnableCap.Texture2D);

            GL.GenTextures(1, out backId);
            GL.BindTexture(TextureTarget.Texture2D, backId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int) TextureMagFilter.Linear);

            var data = back.LockBits(new Rectangle(0, 0, back.Width, back.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            back.UnlockBits(data);
        }

        public void LoadLeft()
        {
            GL.Enable(EnableCap.Texture2D);

            GL.GenTextures(1, out leftId);
            GL.BindTexture(TextureTarget.Texture2D, leftId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int) TextureMagFilter.Linear);

            var data = left.LockBits(new Rectangle(0, 0, left.Width, left.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            left.UnlockBits(data);
        }

        public void Loadright()
        {
            GL.Enable(EnableCap.Texture2D);

            GL.GenTextures(1, out rightId);
            GL.BindTexture(TextureTarget.Texture2D, rightId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int) TextureMagFilter.Linear);

            var data = right.LockBits(new Rectangle(0, 0, right.Width, right.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            right.UnlockBits(data);
        }
    }
}