using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class IrregularForm : Form
{
    public IrregularForm()
    {
        this.cmdClose = new System.Windows.Forms.Button();
        this.SuspendLayout();

        this.cmdClose.Location = new System.Drawing.Point(94, 231);
        this.cmdClose.Size = new System.Drawing.Size(75, 23);
        this.cmdClose.Text = "Close";
        this.cmdClose.UseVisualStyleBackColor = true;
        this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);

        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(295, 270);
        this.Controls.Add(this.cmdClose);
        this.Text = "Irregular Form";
        this.Load += new System.EventHandler(this.IrregularForm_Load);
        this.ResumeLayout(false);

    }

    private void IrregularForm_Load(object sender, EventArgs e)
    {
        GraphicsPath path = new GraphicsPath();

        Point[] pointsA = new Point[] { new Point(0, 0), new Point(40, 60), new Point(this.Width - 100, 10) };
        path.AddCurve(pointsA);

        Point[] pointsB = new Point[]{
                new Point(this.Width - 40, this.Height - 60), 
                new Point(this.Width, this.Height),
                new Point(10, this.Height)
            };
        path.AddCurve(pointsB);

        path.CloseAllFigures();

        this.Region = new Region(path);
    }

    private void cmdClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private System.Windows.Forms.Button cmdClose;

    //[STAThread]
    //static void Main()
    //{
    //    Application.EnableVisualStyles();
    //    Application.SetCompatibleTextRenderingDefault(false);
    //    Application.Run(new IrregularForm());
    //}

}