using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace llk
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuhard2;
		private System.Windows.Forms.MenuItem menuhard3;
        private System.Windows.Forms.MenuItem menuhard4;
		private System.Windows.Forms.MenuItem menuhard1;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.PictureBox pic_color;
		private System.Windows.Forms.Panel p_timer;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Timer timer1;
        private MenuItem menuItem10;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuhard1 = new System.Windows.Forms.MenuItem();
            this.menuhard2 = new System.Windows.Forms.MenuItem();
            this.menuhard3 = new System.Windows.Forms.MenuItem();
            this.menuhard4 = new System.Windows.Forms.MenuItem();
            this.pic_color = new System.Windows.Forms.PictureBox();
            this.p_timer = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pic_color)).BeginInit();
            this.p_timer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem7,
            this.menuItem5});
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3,
            this.menuItem4});
            this.menuItem2.Text = "点我(&F)";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "我准备好了(&R)";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "我不玩了(&X)";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem9});
            this.menuItem7.Text = "帮你(&T)";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.menuItem8.Text = "让我悄悄地告诉你(&S)";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Shortcut = System.Windows.Forms.Shortcut.F6;
            this.menuItem9.Text = "让我们重头再来(&R)";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6});
            this.menuItem5.Text = "商量一下(A)";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuhard1,
            this.menuhard2,
            this.menuhard3,
            this.menuhard4,
            this.menuItem10});
            this.menuItem6.Text = "难度(&H)";
            // 
            // menuhard1
            // 
            this.menuhard1.Index = 0;
            this.menuhard1.Text = "1(&1)";
            this.menuhard1.Click += new System.EventHandler(this.menuhard_Click);
            // 
            // menuhard2
            // 
            this.menuhard2.Checked = true;
            this.menuhard2.Index = 1;
            this.menuhard2.Text = "2(&2)";
            this.menuhard2.Click += new System.EventHandler(this.menuhard_Click);
            // 
            // menuhard3
            // 
            this.menuhard3.Index = 2;
            this.menuhard3.Text = "3(&3)";
            this.menuhard3.Click += new System.EventHandler(this.menuhard_Click);
            // 
            // menuhard4
            // 
            this.menuhard4.Index = 3;
            this.menuhard4.Text = "4(&4)";
            this.menuhard4.Click += new System.EventHandler(this.menuhard_Click);
            // 
            // pic_color
            // 
            this.pic_color.BackColor = System.Drawing.Color.Tomato;
            this.pic_color.Location = new System.Drawing.Point(0, 16);
            this.pic_color.Name = "pic_color";
            this.pic_color.Size = new System.Drawing.Size(8, 272);
            this.pic_color.TabIndex = 0;
            this.pic_color.TabStop = false;
            // 
            // p_timer
            // 
            this.p_timer.BackColor = System.Drawing.SystemColors.Control;
            this.p_timer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_timer.Controls.Add(this.pic_color);
            this.p_timer.Location = new System.Drawing.Point(16, 32);
            this.p_timer.Name = "p_timer";
            this.p_timer.Size = new System.Drawing.Size(8, 296);
            this.p_timer.TabIndex = 1;
            this.p_timer.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "200796113881563.jpg");
            this.imageList1.Images.SetKeyName(1, "200796113881564.jpg");
            this.imageList1.Images.SetKeyName(2, "200796113881565.jpg");
            this.imageList1.Images.SetKeyName(3, "200796113881562.jpg");
            this.imageList1.Images.SetKeyName(4, "7.png");
            this.imageList1.Images.SetKeyName(5, "8.png");
            this.imageList1.Images.SetKeyName(6, "9.png");
            this.imageList1.Images.SetKeyName(7, "10.png");
            this.imageList1.Images.SetKeyName(8, "11.png");
            this.imageList1.Images.SetKeyName(9, "12.png");
            this.imageList1.Images.SetKeyName(10, "1.png");
            this.imageList1.Images.SetKeyName(11, "3.png");
            this.imageList1.Images.SetKeyName(12, "4.png");
            this.imageList1.Images.SetKeyName(13, "5.png");
            this.imageList1.Images.SetKeyName(14, "6.png");
            this.imageList1.Images.SetKeyName(15, "200796113881566.jpg");
            this.imageList1.Images.SetKeyName(16, "200796113881567.jpg");
            this.imageList1.Images.SetKeyName(17, "200796113881568.jpg");
            this.imageList1.Images.SetKeyName(18, "200796113881569.jpg");
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 4;
            this.menuItem10.Text = "5(&5)";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(410, 339);
            this.Controls.Add(this.p_timer);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "当c#遇到了连连看";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_color)).EndInit();
            this.p_timer.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Form f1 = new Form1();
			Application.Run(f1);
		}

		
		private table t_main; 
		private Panel panel_for_path;
		double times;
		double wid =0;

		private void Form1_Load(object sender, System.EventArgs e)
		{
			if(sender ==null)
			{
				int n = BasicSetting.Matrix_Size;
				this.Size = new Size((n+2) * BasicSetting.ADOG_WIDTH  ,BasicSetting.ADOG_HEIGHT *(n+3));
				t_main = new table(n ,this.imageList1);
				p_timer.Height = this.Height - BasicSetting.ADOG_HEIGHT * 3;
				p_timer.Width = 8;
				p_timer.Location =new Point(BasicSetting.ADOG_HEIGHT/3 ,BasicSetting.ADOG_HEIGHT);
				p_timer.Visible =true;
				this.pic_color.Width = p_timer.Width ;
				this.pic_color.Height = p_timer.Height;
                
				this.pic_color.Location = new Point(0,0);
				times = BasicSetting.OVER_ALL_TIME / timer1.Interval;
				wid = p_timer.Height/times;

				panel_for_path = new Panel();
				panel_for_path.Size = t_main.Size;
				panel_for_path.Location = t_main.Location;
				
				this.Controls.Add(p_timer);
				this.Controls.Add(t_main);	
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e)//dor the menu "开始"
		{
			//t_main = new table(Matrix_Size);
			//Form f = (Form)this.Parent.Container;
			//f.Controls.Add(t_main);
			try{t_main.Dispose();}				
			catch{}
			Form1_Load(null,null);
			timer1.Enabled =true;
			timer1.Start();			
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void menuhard_Click(object sender, System.EventArgs e)
		{
			MenuItem m = (MenuItem)sender;
			int hardness = int.Parse(m.Text.Substring(0,1));
			
			DialogResult result =MessageBox.Show(this,"要使设置立刻生效，需要重启游戏！现在重新启动游戏？","更改游戏难度",MessageBoxButtons.YesNoCancel);
			if(result==DialogResult.Cancel)
				return;
			else
			{
				menuhard1.Checked =false;
				menuhard2.Checked =false;
				menuhard3.Checked =false;
				menuhard4.Checked =false;
				//menuhard5.Checked =false;
				if(result==DialogResult.Yes)
				{
					BasicSetting.Matrix_Size = (hardness+2) * 2;
					menuItem1_Click(null,null);
					m.Checked =true;
				}
				else if(result==DialogResult.No)
				{
					BasicSetting.Matrix_Size = (hardness+2) * 2;
					m.Checked =true;
				}
			}
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			try
			{
				int i =this.t_main.show_tip();
				if( i == -1)
					MessageBox.Show("已无牌可消，游戏结束！");
			}
			catch{}
		}
			
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			//the overall time for one play is 240 seconds(4 nimutes)	
			double pheight = pic_color.Height;
			pic_color.Height = (int)(pheight - wid);
			if(pic_color.Height<p_timer.Height /2){pic_color.BackColor =Color.DeepPink;}
			if(pic_color.Height<p_timer.Height /4){pic_color.BackColor = Color.Red;}
			if(pic_color.Height<=0)
			{				
				timer1.Stop();				
				timer1.Enabled =false;
				MessageBox.Show(this,"设定时间到！");
				this.t_main.Dispose();
				p_timer.Visible =false;
			}
		}

		private void menuItem9_Click(object sender, System.EventArgs e)		
		{		
			try
			{
				if(!t_main.re_dispaly_card())
					MessageBox.Show(this,"不能再洗牌！");
			}
			catch{}
		}

       

        
		
	}	
}