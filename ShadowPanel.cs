using System;
using System.Drawing;
using System.Windows.Forms;

public class ShadowPanel : Panel
{
    private int shadowOffset = 5;
    private int shadowOpacity = 50;

    public int ShadowOffset
    {
        get { return shadowOffset; }
        set
        {
            shadowOffset = value;
            Invalidate(); // Redraw when the property changes
        }
    }

    public int ShadowOpacity
    {
        get { return shadowOpacity; }
        set
        {
            shadowOpacity = Math.Max(0, Math.Min(255, value)); // Keep within valid range
            Invalidate(); // Redraw when the property changes
        }
    }

    public ShadowPanel()
    {
        // Make the background transparent so we can see the shadow
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.ResizeRedraw |
                      ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Draw the shadow first
        using (Brush shadowBrush = new SolidBrush(Color.FromArgb(shadowOpacity, 0, 0, 0)))
        {
            e.Graphics.FillRectangle(shadowBrush, shadowOffset, shadowOffset,
                                    Width - shadowOffset, Height - shadowOffset);
        }

        // Then draw the panel itself
        using (Brush panelBrush = new SolidBrush(this.BackColor))
        {
            e.Graphics.FillRectangle(panelBrush, 0, 0, Width - shadowOffset, Height - shadowOffset);
        }

        // Call base.OnPaint at the end (or not at all if you want complete custom painting)
        base.OnPaint(e);
    }
}