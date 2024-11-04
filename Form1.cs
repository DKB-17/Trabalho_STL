using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_STL
{
    public partial class Form1 : Form
    {
        public class Triangulo
        {
            public Vector3d a { get;}
            public Vector3d b { get;}
            public Vector3d c { get;}

            public Triangulo(Vector3d a, Vector3d b, Vector3d c) 
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
        }

        public class Face
        {
            public List<Triangulo> face { get; }

            public Face()
            {
                face = new List<Triangulo>();
            }
        }

        public class Estrela
        {
            public List<Face> faces { get; set; }
            public Estrela() 
            { 
                faces = new List<Face>();
            }
        }

        int numeroDePontas;
        int altura;
        int raioInterno;
        int raioExterno;

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            numeroDePontas = (int)numericUpDown1.Value;
            altura = (int)numericUpDown3.Value;
            raioInterno = (int)numericUpDown2.Value;
            raioExterno = (int)numericUpDown4.Value;

            Estrela star = new Estrela();
            Face f = new Face();
            Triangulo t;
            float ge = ((360 / numeroDePontas)/2);
            // face inferior
            for (float gi = 0; ge <= 360; gi += (360 / numeroDePontas), ge += (360 / numeroDePontas))
            {
                double degInRad_gi = gi * 3.1415 / 180;
                double cos_gi = Math.Cos(degInRad_gi);
                double sin_gi = Math.Sin(degInRad_gi);
                double degInRad_ge = ge * 3.1415 / 180;
                double cos_ge = Math.Cos(degInRad_ge);
                double sin_ge = Math.Sin(degInRad_ge);
                double xb = cos_gi * raioInterno;
                double yb = sin_gi * raioInterno;
                double xc = cos_ge * raioExterno;
                double yc = sin_ge * raioExterno;

                t = new Triangulo(
                    new Vector3d(0, 0, 0),
                    new Vector3d(xb, yb, 0),
                    new Vector3d(xc, yc, 0)
                    );
                f.face.Add(t);

                float gip = gi + (360 / numeroDePontas);
                double degInRad_gip = gip * 3.1415 / 180;
                double cos_gip = Math.Cos(degInRad_gip);
                double sin_gip = Math.Sin(degInRad_gip);
                xb = cos_gip * raioInterno;
                yb = sin_gip * raioInterno;
                t = new Triangulo(
                    new Vector3d(0, 0, 0),
                    new Vector3d(xb, yb, 0),
                    new Vector3d(xc, yc, 0)
                    );
               
                f.face.Add(t);
            }
            star.faces.Add(f);
            f = new Face();

            ge = ((360 / numeroDePontas) / 2);
            // face superior
            for (float gi = 0; ge <= 360; gi += (360 / numeroDePontas), ge += (360 / numeroDePontas))
            {
                double degInRad_gi = gi * 3.1415 / 180;
                double cos_gi = Math.Cos(degInRad_gi);
                double sin_gi = Math.Sin(degInRad_gi);
                double degInRad_ge = ge * 3.1415 / 180;
                double cos_ge = Math.Cos(degInRad_ge);
                double sin_ge = Math.Sin(degInRad_ge);
                double xb = cos_gi * raioInterno;
                double yb = sin_gi * raioInterno;
                double xc = cos_ge * raioExterno;
                double yc = sin_ge * raioExterno;

                t = new Triangulo(
                    new Vector3d(0, 0, altura),
                    new Vector3d(xb, yb, altura),
                    new Vector3d(xc, yc, altura)
                    );
                f.face.Add(t);

                float gip = gi + (360 / numeroDePontas);
                double degInRad_gip = gip * 3.1415 / 180;
                double cos_gip = Math.Cos(degInRad_gip);
                double sin_gip = Math.Sin(degInRad_gip);
                xb = cos_gip * raioInterno;
                yb = sin_gip * raioInterno;
                t = new Triangulo(
                    new Vector3d(0, 0, altura),
                    new Vector3d(xb, yb, altura),
                    new Vector3d(xc, yc, altura)
                    );

                f.face.Add(t);
            }

            star.faces.Add(f);
            f = new Face();

            ge = ((360 / numeroDePontas) / 2);
            // face externa
            for (float gi = 0; ge <= 360; gi += (360 / numeroDePontas), ge += (360 / numeroDePontas))
            {
                double degInRad_gi = gi * 3.1415 / 180;
                double cos_gi = Math.Cos(degInRad_gi);
                double sin_gi = Math.Sin(degInRad_gi);
                double degInRad_ge = ge * 3.1415 / 180;
                double cos_ge = Math.Cos(degInRad_ge);
                double sin_ge = Math.Sin(degInRad_ge);
                double xb = cos_gi * raioInterno;
                double yb = sin_gi * raioInterno;
                double xc = cos_ge * raioExterno;
                double yc = sin_ge * raioExterno;

                t = new Triangulo(
                    new Vector3d(xb, yb, 0),
                    new Vector3d(xb, yb, altura),
                    new Vector3d(xc, yc, 0)
                    );
                f.face.Add(t);
                t = new Triangulo(
                    new Vector3d(xb, yb, altura),
                    new Vector3d(xc, yc, altura),
                    new Vector3d(xc, yc, 0)
                    );
                f.face.Add(t);

                float gip = gi + (360 / numeroDePontas);
                double degInRad_gip = gip * 3.1415 / 180;
                double cos_gip = Math.Cos(degInRad_gip);
                double sin_gip = Math.Sin(degInRad_gip);
                xb = cos_gip * raioInterno;
                yb = sin_gip * raioInterno;

                t = new Triangulo(
                    new Vector3d(xb, yb, 0),
                    new Vector3d(xb, yb, altura),
                    new Vector3d(xc, yc, 0)
                    );

                f.face.Add(t);
                t = new Triangulo(
                    new Vector3d(xb, yb, altura),
                    new Vector3d(xc, yc, altura),
                    new Vector3d(xc, yc, 0)
                    );
                f.face.Add(t);
            }

            star.faces.Add(f);

            criarArquivo(star);
        }

        public Vector3d getNormal(Vector3d a, Vector3d b, Vector3d c)
        {
            return Vector3d.Cross(a - c, b - c).Normalized();
        }

        public void criarArquivo(Estrela star)
        {
            if (star == null) return;
            Vector3d normal = new Vector3d();
            StreamWriter arquivo = new StreamWriter("estrela.stl");
            arquivo.WriteLine("solid estrela");
            foreach (Face f in star.faces)
            {
                foreach (Triangulo t in f.face)
                {
                    normal = getNormal(t.a, t.b, t.c);
                    arquivo.WriteLine("facet normal {0} {1} {2}", normal[0].ToString(CultureInfo.InvariantCulture.NumberFormat), normal[1].ToString(CultureInfo.InvariantCulture.NumberFormat), normal[2].ToString(CultureInfo.InvariantCulture.NumberFormat));
                    arquivo.WriteLine("     outer loop");
                    arquivo.WriteLine("         vertex {0} {1} {2}", t.a[0].ToString(CultureInfo.InvariantCulture.NumberFormat), t.a[1].ToString(CultureInfo.InvariantCulture.NumberFormat), t.a[2].ToString(CultureInfo.InvariantCulture.NumberFormat));
                    arquivo.WriteLine("         vertex {0} {1} {2}", t.b[0].ToString(CultureInfo.InvariantCulture.NumberFormat), t.b[1].ToString(CultureInfo.InvariantCulture.NumberFormat), t.b[2].ToString(CultureInfo.InvariantCulture.NumberFormat));
                    arquivo.WriteLine("         vertex {0} {1} {2}", t.c[0].ToString(CultureInfo.InvariantCulture.NumberFormat), t.c[1].ToString(CultureInfo.InvariantCulture.NumberFormat), t.c[2].ToString(CultureInfo.InvariantCulture.NumberFormat));
                    arquivo.WriteLine("     endloop");
                    arquivo.WriteLine("endfacet");

                }
            }
            arquivo.WriteLine("endsolid estrela");
            arquivo.Close();
            MessageBox.Show("Arquivo STL gerado.");
        }
    }
}
