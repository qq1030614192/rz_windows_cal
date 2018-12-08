using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace cal
{
    public partial class Form1 : Form
    {
        //dll的导入
        [DllImport("Dll1.dll")]
        public static extern double add(double a, double b);
        [DllImport("Dll1.dll")]
        public static extern double subtract(double a, double b);
        [DllImport("Dll1.dll")]
        public static extern double multiply(double a, double b);
        [DllImport("Dll1.dll")]
        public static extern double divide(double a, double b);

        private string o;//运算符
        private double x, y;//运算数
        private Button btn;//按钮对象
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label1.Text = "";
        }
        private void Buttonop_Click(object sender, EventArgs e)//运算符点击事件
        {
            btn = (Button)sender;
            if (btn.Name!="button3")//点击四则运算按钮
            {
                o = btn.Name;
                switch (o)//显示运算符
                {
                    //+
                    case "button13":
                        textBox3.Text = "+";
                        break;
                    //-
                    case "button9":
                        textBox3.Text = "-";
                        break;
                    //*
                    case "button5":
                        textBox3.Text = "×";
                        break;
                    ///
                    case "button4":
                        textBox3.Text = "÷";
                        break;

                }
                //确保可以转化为double类型且不为空字符串
                bool xtodouble = Regex.IsMatch(textBox1.Text, @"^[+-]?\d*[.]?\d*$");
                bool ytodouble = Regex.IsMatch(textBox2.Text, @"^[+-]?\d*[.]?\d*$");
                if (xtodouble&& ytodouble&& textBox1.Text!=""&& textBox2.Text!="") {
                    x = Convert.ToDouble(textBox1.Text);
                    y = Convert.ToDouble(textBox2.Text);
                }
                else
                {
                    label1.Text = "请输入正确数值";
                    textBox4.Text = "!";
                }
               
            }
            else//点击“=”按钮
            {
                //同上检验
                bool xtodouble = Regex.IsMatch(textBox1.Text, @"^[+-]?\d*[.]?\d*$");
                bool ytodouble = Regex.IsMatch(textBox2.Text, @"^[+-]?\d*[.]?\d*$");
                if (xtodouble && ytodouble && textBox1.Text != "" && textBox2.Text != "")
                {
                    x = Convert.ToDouble(textBox1.Text);
                    y = Convert.ToDouble(textBox2.Text);
                    switch (o)
                    {
                        //+
                        case "button13":
                            textBox4.Text = (add(x,y).ToString());
                            label1.Text = "";
                            break;
                        //-
                        case "button9":
                            textBox4.Text = (subtract(x,y)).ToString();
                            label1.Text = "";
                            break;
                        //*
                        case "button5":
                            textBox4.Text = (multiply(x,y)).ToString();
                            label1.Text = "";
                            break;
                        ///
                        case "button4":
                            if (y == 0)
                            {
                                label1.Text = "请输入正确数值";
                                textBox4.Text = "!";
                            }
                            else
                            {
                                textBox4.Text = (divide(x,y)).ToString();
                                label1.Text = "";
                            }
                            break;

                    }
                }
                else
                {
                    label1.Text = "请输入正确数值";
                    textBox4.Text = "!";
                }
            }
        }
        private void Re_Click(object sender, EventArgs e)
        {
            //全部清零
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
