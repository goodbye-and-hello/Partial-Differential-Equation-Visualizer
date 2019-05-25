using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDEForm
{
    public partial class Form1 : Form
    {
        public const int MAX = 50; //배열 크기
        public PDE pdeObject = new PDE();

        public Form1()
        {
            InitializeComponent();
            this.groundPanel.Location = new Point(ClientSize.Width / 2 - groundPanel.Size.Width / 2,
                ClientSize.Height / 2 - groundPanel.Size.Height / 2);

            MakeColorTile();
            

        }


        private void MakeColorTile() // 처음 색깔 타일(배열갯수만큼) 만들어주는 함수
        {
            
            for(int i = 0; i < MAX; i++)
            {
                for(int j = 0; j < MAX; j++)
                {
                    System.Windows.Forms.Panel colorPanel = new System.Windows.Forms.Panel();

                    colorPanel.Location = new System.Drawing.Point(i * 400/MAX, j * 400/MAX);
                    colorPanel.Name = "panel" + i + j;
                    colorPanel.Size = new System.Drawing.Size(400/MAX-1, 400/MAX-1);
                    colorPanel.TabIndex = 0;
                    //colorPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    colorPanel.BackColor = Color.FromArgb(255, 0, 0);
                    this.groundPanel.Controls.Add(colorPanel);
                }
            }
            
        }

        private void ChangeColor() // 배열값에 따라 색깔 바꿔주는 함수
        {
            Control.ControlCollection panelCollection = groundPanel.Controls;

            pdeObject.pde(pdeObject.m);
            
            for (int i = 0; i < MAX; i++)
            {
                for (int j = 0; j < MAX; j++)
                {
                    int red = (255 / 100) * pdeObject.m[i, j];
                    int blue = (255 / 100) * (100 - pdeObject.m[i, j]);
                    //int red = 100;
                    //int blue = 200;


                    if (red<=255 && blue <= 255)
                    {
                        ((Panel)panelCollection[MAX * i + j]).BackColor = Color.FromArgb(red, 0, blue);
                    }
                   
                }
            }
            
            
        }
        
        private void button1_Click(object sender, EventArgs e) //시작 버튼
        {
            timer1.Start();
            timer1.Interval = 5; // 0.005초 주기로 타이머 함수 실행
            
        }

        private void timer1_Tick_1(object sender, EventArgs e) // 타이머 일정주기마다 실행
        {
            ChangeColor();
        }
    }

    
}
