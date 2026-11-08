using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CirclePictureBox : PictureBox
{
    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

        g.Clear(Parent?.BackColor ?? Color.White);

        var rect = new Rectangle(0, 0, Width - 1, Height - 1);
        using (var path = new GraphicsPath())
        {
            path.AddEllipse(rect);
            g.SetClip(path);

            if (Image != null)
                g.DrawImage(Image, GetCoverRect());
        }

        g.ResetClip();

        using (var pen = new Pen(Color.FromArgb(209, 213, 219), 1.5f))
            g.DrawEllipse(pen, rect);
    }

    private Rectangle GetCoverRect()
    {
        float ratioImg = (float)Image.Width / Image.Height;
        float ratioBox = (float)Width / Height;

        int w, h;
        if (ratioImg > ratioBox) { h = Height; w = (int)(Height * ratioImg); }
        else { w = Width; h = (int)(Width / ratioImg); }

        return new Rectangle((Width - w) / 2, (Height - h) / 2, w, h);
    }
}