using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuadratnoeUravnenie
{
    public partial class Form1 : Form
    {
        double a;
        double b;
        double c;
        double x1;
        double x2;

        void Quadratic()
        {
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            c = Convert.ToDouble(textBox3.Text);
        }
        double Discriminant(double a, double b, double c)
        {
            return b*b - 4*a*c;
        }
        byte Solve(double d)
        {
            if (d > 0)
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
                return 2;
            }
            else if (d == 0)
            {
                x1 = -b / (2 * a);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        DialogResult Message(byte solve)
        {
            switch (solve)
            {
                case 2:
                    return MessageBox.Show($"Уравнение имеет два корня: \n x1 = {x1}; x2 = {x2}", "Решение", MessageBoxButtons.OK);
                case 1:
                    return MessageBox.Show($"Уравнение имеет один корень: \n x = {x1}", "Решение", MessageBoxButtons.OK);
                case 0:
                    return MessageBox.Show($"Уравнение не имеет корней!", "Решение", MessageBoxButtons.OK);
                default:
                    return 0;
            }
        }
        void button1_Click(object sender, EventArgs e)
        {
            Quadratic();
            Message(Solve(Discriminant(a, b, c)));
        }
    }
}
