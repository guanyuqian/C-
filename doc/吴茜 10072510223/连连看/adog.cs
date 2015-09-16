using System;
using System.Windows.Forms;
using System.Drawing;

namespace llk
{
	/// <summary>
	/// adog 的摘要说明。
	/// Class adog inherited from Button
	/// </summary>
	public class adog:System.Windows.Forms.Button
	{
		int i = 0;
		int j = 0;
		table container ;			
		int awidth,aheight;

		public adog(int url,int i, int j ,table tb1,ImageList imglist)
		{
			//this.imgurl = url;
			awidth = BasicSetting.ADOG_WIDTH;
			aheight = BasicSetting.ADOG_HEIGHT;
			this.i = i;
			this.j = j;
			this.container  =tb1;
			this.Size= new Size(awidth,aheight);
			this.Location= new Point(i*awidth , j*aheight);
			this.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.BackColor = this.BackColor = Color.LightBlue;
			//this.Text =url.ToString();;
			this.ImageList = imglist;
			this.ImageIndex = url;
			//this.imgurl = "/img/" + url + ".gif";				
			this.Click += new System.EventHandler(this.newclick);

		}		

		private void newclick(object sender, System.EventArgs e)
		{
			if(this.BackColor != Color.Aqua)
			{
				this.BackColor = Color.Aqua;
				//System.Console.WriteLine(this.table_number[i,j]);	
				this.container.is_adog_equal(new Point(i,j));			
			}
			else
			{
				this.BackColor = Color.LightBlue;
				this.container.reset_selected_point();			
			}
		}
	}
}
