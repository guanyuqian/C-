using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace llk
{
	/// <summary>
	/// table 的摘要说明。
	/// </summary>
	//Class table contains adogs
	public class table:System.Windows.Forms.Panel
	{
		private int n =0;
		private Label l_info1,l_info2;

		private adog[,] tables;
		private int[,] table_number;
		private Search_Step[,] table_for_search;
		private int[,] adog_value;
        private String[] question = { "foreach语句，用于对集合进行操作吗？ ", "汽车和学生是类吗？", "静态成员在内存中只有一份吗？", "构造函数总是和类名相同吗？",
                                        "字段是在调用对象实例的构造函数之前初始化的吗？","return语句只能返回一个值吗？","属性是限制对类成员访问的方法吗？",
                                    "在派生类中使用关键字 base 以调用基类的非缺省构造函数吗？ ","不能从密封类派生吗？",
                                    "Delegate是一个对象类型，它封装了带有特定参数和返回类型的一类方法吗？"};
			
		Point point_reset = new Point(-1 ,-1);
		Point selected_p1 =new Point(-1 ,-1);
		Point selected_p2 =new Point(-1 ,-1);

		Timer timer_for_drawing_del = new Timer();
		int draw_path_style =0;

		Picture_as_drawing_path[] preserved_path;
		ImageList imglist;
            
		private int ReDisplay_Count ;
		private int ShowTip_Count ;
		private int ADOG_WIDTH;
		private int ADOG_HEIGHT;   	
		private int MAX_BENDED_NUM ;//The max bended number for the search path
		//private PlaySound PlaySoundInstance;


		public table(int count , ImageList iml)
		{
			this.n = count;
			if(n<2){n=2;}
			if(n %2 !=0){n = n -1;}

			this.ReDisplay_Count = BasicSetting.ReDisplay_Count;
			this.ShowTip_Count = BasicSetting.ShowTip_Count;
			this.ADOG_WIDTH = BasicSetting.ADOG_WIDTH;
			this.ADOG_HEIGHT = BasicSetting.ADOG_HEIGHT;
			this.MAX_BENDED_NUM =  BasicSetting.MAX_BENDED_NUM;

			//initialize the property of the panel itself
			//this.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BackColor = Color.DarkGoldenrod;
			this.Location = new Point(0,0);
			this.Size =  new Size((n+2) * ADOG_WIDTH ,ADOG_HEIGHT * (n+2));
			//generate the buttons that in the panel			
			tables = new adog[n+2,n+2];
			table_number = new int[n+2,n+2];
			table_for_search = new Search_Step[n+2,n+2];
			adog_value = new int[2,n*n/2];

			timer_for_drawing_del.Interval = 100;
			timer_for_drawing_del.Enabled = true;
			timer_for_drawing_del.Stop();
			timer_for_drawing_del.Tick +=  new System.EventHandler(this.TimerTick_for_draw_path_del);
			//these pictures are used for select path
			preserved_path= new Picture_as_drawing_path[3];
			preserved_path[0] = new Picture_as_drawing_path();
			preserved_path[1] = new Picture_as_drawing_path();
			preserved_path[2] = new Picture_as_drawing_path();                
			this.Controls.AddRange(preserved_path);

			this.imglist = iml;
			//the for loop behind is used to generate the numbers that is used to fill the table 
			//there are n*n/2 numbers(that is:each number will be used twice).
			//the MAX_VALUE is the "n*n/3" in the prorgam, and it can be tuned
			Random ran = new Random();
			int MAX_VALUE = n*n/3;
			for(int i =0;i <n*n/2;i++)
			{
				adog_value[0 , i] =ran.Next(MAX_VALUE) + 1 ;
			}

			for(int i=1;i<=n;i++)
			{
				for(int j=1;j<=n;j++)
				{
					int temp = ran.Next(n*n/2) ;  //i * n +j;
					while(adog_value[1 , temp] == 2)
					{
						temp = ran.Next(n*n/2);
					}
					adog_value[1 , temp]  += 1;
					table_number[i,j] = adog_value[0 , temp];
					tables[i,j] = new adog(table_number[i,j] , i ,j ,this,iml);
					this.Controls.Add(tables[i,j]);
				}
			} 
			l_info1= new Label();l_info2= new Label();
			l_info1.Text ="洗牌："+ReDisplay_Count.ToString();
			l_info1.Location = new Point(20,10);
			l_info1.Size = new Size(60,25);
            l_info1.ForeColor = Color.Black;
			this.Controls.Add(l_info1);
			l_info2.Text ="提示："+ShowTip_Count.ToString();
			l_info2.Location = new Point(90,10);
			l_info2.Size = new Size(60,25);
			l_info2.ForeColor= Color.Black;
			this.Controls.Add(l_info2);

			//PlaySoundInstance = new PlaySound();

		}
		/*//initialize part of the matrix table_for_search
				//the others will be initialize in the playing process
				for(int i=0;i<n+2;i++)
				{
					table_for_search[i,0] = new Search_Step();
					table_for_search[i,n+1] = new Search_Step();
				}
				for(int j=0;j<n+2;j++)
				{
					table_for_search[0,j] = new Search_Step();
					table_for_search[n+1,j] = new Search_Step();
				}*/			

			
		private void draw_path()
		{
			switch(draw_path_style)
			{
				case 1:						
					draw_one_line(selected_p1,selected_p2,0);
					break;
				case 2:
					draw_one_line(selected_p1,bend_points[0],0);
					draw_one_line(bend_points[0],selected_p2,1);
					break;
				case 3:
					draw_one_line(selected_p1,bend_points[0],0);
					draw_one_line(bend_points[1],bend_points[0],1);
					draw_one_line(bend_points[1],selected_p2,2);
					break;
			}
		}
		//Method draw_one_line is sub method used by draw_path
		private void draw_one_line(Point p1,Point p2,int line_i)
		{
			if(p1.X==p2.X)
			{
				preserved_path[line_i].Location = new Point(p1.X * ADOG_WIDTH + ADOG_WIDTH/2,Math.Min(p1.Y,p2.Y) * ADOG_HEIGHT+ADOG_HEIGHT/2);
				preserved_path[line_i].Height = (Math.Max(p1.Y,p2.Y) - Math.Min(p1.Y,p2.Y)) * ADOG_HEIGHT ;
				preserved_path[line_i].Width =6;
				if(line_i ==1)preserved_path[line_i].Height +=6;
			}
			else
			{
				preserved_path[line_i].Location = new Point(Math.Min(p1.X,p2.X) * ADOG_WIDTH  + ADOG_WIDTH/2,p1.Y * ADOG_HEIGHT+ADOG_HEIGHT/2);
				preserved_path[line_i].Width = (Math.Max(p1.X,p2.X) - Math.Min(p1.X,p2.X)) * ADOG_WIDTH ;
				preserved_path[line_i].Height =6;
				if(line_i ==1)preserved_path[line_i].Width +=6;
			}
		}


		private void TimerTick_for_draw_path_del(object sender, System.EventArgs e)
		{
			for(int i =0;i<this.preserved_path.Length;i++)
				preserved_path[i].Location = new Point(-100,-100);
			this.tables[selected_p1.X,selected_p1.Y].Dispose();
			this.tables[selected_p2.X,selected_p2.Y].Dispose();
			table_number[selected_p1.X,selected_p1.Y] = table_number[selected_p2.X,selected_p2.Y] = 0;
			reset_selected_point();				
			timer_for_drawing_del.Stop();

			if(find_match_adogs()== null)
			{
				if(is_finished())
				{
					MessageBox.Show(this,"游戏结束！请进入下一难度等级！");
                    
				}
				else if(!re_dispaly_card())
					//that is no card to match and no chance to redisplay
					MessageBox.Show(this,"已经无牌可消，游戏结束！");
			}				
		}

		public void reset_selected_point()
		{
			selected_p1 = selected_p2 =point_reset;
		}

		//When the player select the first adogs, this method is used to record the adog's point
		//When the player select the second adogs, this method is used to induldge weather or they are equal to each other 
		//this method is triggered by the adog class
		public void is_adog_equal(Point p)
		{
			if(selected_p1.Equals(point_reset))
			{
				selected_p1 = p;
				//this.PlaySoundInstance.play_sound1();
			}
			else
			{
				selected_p2 = p;
				if(selected_p1.Equals(selected_p2))
				{//do nothing	
					reset_selected_point();//
				}
				else if(table_number[selected_p1.X,selected_p1.Y] == table_number[selected_p2.X,selected_p2.Y] && search_path(selected_p1,selected_p2))
				{						
					//only when the adog are disposed, the corresponding Search_Step will be initialized for Path searching
					draw_path();
					timer_for_drawing_del.Start();
				}
				else
				{
					tables[selected_p1.X,selected_p1.Y].BackColor = tables[selected_p2.X,selected_p2.Y].BackColor =  Color.LightBlue;
					reset_selected_point();
				}			
			}
		}

		//This method is used to find if there is a resonable path between the two adogs noted by selected_p1 and selected_p2
		//This method is only called by method "is_adog_equal"
		private bool search_path(Point p1 ,Point p2)
		{				
			if(p1.Equals(p2)) return false;
			draw_path_style =0;
			if(is_neighbors(p1,p2))
			{
				//draw a line between the two adogs
				draw_path_style =1;					
				return true;
			}
			else if(is_exposed(p1) && is_exposed(p2))
			{
				if(there_is_a_straight_path(p1,p2))
				{
					//draw a line between the two adogs
					draw_path_style =1;
					return true;
				}
				else if(there_is_a_rec_path(p1,p2))
				{
					//draw a path between the two adogs
					draw_path_style =2;
					return true;
				}
				else if(there_is_other_path(p1,p2))
				{
					//draw a path between the two adogs
					draw_path_style =3;
					return true;
				}
			}
			return false;
		}
			
		private bool is_neighbors(Point p1,Point p2)
		{
			int x1 = p1.X;
			int y1 = p1.Y;
			int x2 = p2.X;
			int y2 = p2.Y;
			if((Math.Abs(x1 - x2) + Math.Abs(y1 - y2)) == 1)
			{
				return true;
			}
			return false;
		}
		private bool is_exposed(Point p)
		{
			int x1 = p.X;
			int y1 = p.Y;
			if(table_number[x1-1,y1] * table_number[x1+1,y1] * table_number[x1,y1-1] * table_number[x1,y1+1] ==0) return true; 
			else return false;
		}
		private bool there_is_a_straight_path()//reload one
		{
			int x1 = selected_p1.X;
			int y1 = selected_p1.Y;
			int x2 = selected_p2.X;
			int y2 = selected_p2.Y;
			if(y1==y2)
			{
				for(int i=Math.Min(x1,x2)+1;i<Math.Max(x1,x2); i++)
				{
					if(table_number[i,y1] != 0) return false;
				}
				return true;
			}
			else if(x1==x2)
			{
				for(int i=Math.Min(y1,y2)+1;i<Math.Max(y1,y2); i++)
				{
					if(table_number[x1,i] != 0) return false;
				}
				return true;
			}
			return false;
		}
		private bool there_is_a_straight_path(Point p1,Point p2)//reload two
		{
			int x1 = p1.X;
			int y1 = p1.Y;
			int x2 = p2.X;
			int y2 = p2.Y;
			if(y1==y2)
			{
				for(int i=Math.Min(x1,x2)+1;i<Math.Max(x1,x2); i++)
				{
					if(table_number[i,y1] != 0) return false;
				}
				return true;
			}
			else if(x1==x2)
			{
				for(int i=Math.Min(y1,y2)+1;i<Math.Max(y1,y2); i++)
				{
					if(table_number[x1,i] != 0) return false;
				}
				return true;
			}
			return false;
		}

		private bool there_is_a_rec_path(Point p1,Point p2)
		{
			int x1 = p1.X;
			int y1 = p1.Y;
			int x2 = p2.X;
			int y2 = p2.Y;
			int mark =0;
			bend_points = new Point[1];
				#region if((x1-x2) * (y1-y2)<0)
			if((x1-x2) * (y1-y2)<0)
			{
				int min_x= Math.Min(x1,x2);
				int min_y= Math.Min(y1,y2);
				for(int i=Math.Min(x1,x2);i<=Math.Max(x1,x2);i++)
				{
					if(table_number[i,min_y] == 0) mark ++;
					else if((i!=x1) && (i!=x2))break;
				}
				if(mark == Math.Abs(x1-x2))
				{
					mark =0;
					for(int j=Math.Min(y1,y2);j<=Math.Max(y1,y2);j++)
					{
						if(table_number[min_x,j] == 0) mark ++;
						else if((j!=y1) && (j!=y2))break;
					}
					if(mark == Math.Abs(y1-y2) )
					{
						bend_points[0] = new Point(min_x,min_y);
						return true;
					}
				}


				int max_x= Math.Max(x1,x2);
				int max_y= Math.Max(y1,y2);
				for(int i=Math.Min(x1,x2);i<=Math.Max(x1,x2);i++)
				{
					if(table_number[i,max_y] == 0) mark ++;
					else if((i!=x1) && (i!=x2))break;
				}
				if(mark == Math.Abs(x1-x2))
				{
					mark =0;
					for(int j=Math.Min(y1,y2);j<=Math.Max(y1,y2);j++)
					{
						if(table_number[max_x,j] == 0) mark ++;
						else if((j!=y1) && (j!=y2))break;
					}
					if(mark == Math.Abs(y1-y2))
					{
						bend_points[0] = new Point(max_x,max_y);
						return true;
					}
				}
				return false;
			}
				#endregion
				
				#region if((x1-x2) * (y1-y2)>0)
			if((x1-x2) * (y1-y2)>0)
			{
				int min_x= Math.Min(x1,x2);
				int max_y= Math.Max(y1,y2);
				for(int i=Math.Min(x1,x2);i<=Math.Max(x1,x2);i++)
				{
					if(table_number[i,max_y] == 0) mark ++;
					else if((i!=x1) && (i!=x2))break;
				}
				if(mark == Math.Abs(x1-x2))
				{
					mark =0;
					for(int j=Math.Min(y1,y2);j<=Math.Max(y1,y2);j++)
					{
						if(table_number[min_x,j] == 0) mark ++;
						else if((j!=y1) && (j!=y2))break;
					}
					if(mark == Math.Abs(y1-y2) )
					{
						bend_points[0] = new Point(min_x,max_y);
						return true;
					}
				}


				int max_x= Math.Max(x1,x2);
				int min_y= Math.Min(y1,y2);					
				for(int i=Math.Min(x1,x2);i<=Math.Max(x1,x2);i++)
				{
					if(table_number[i,min_y] == 0) mark ++;
					else if((i!=x1) && (i!=x2))break;
				}
				if(mark == Math.Abs(x1-x2))
				{
					mark =0;
					for(int j=Math.Min(y1,y2);j<=Math.Max(y1,y2);j++)
					{
						if(table_number[max_x,j] == 0) mark ++;
						else if((j!=y1) && (j!=y2))break;
					}
					if(mark == Math.Abs(y1-y2))
					{
						bend_points[0] = new Point(max_x,min_y);
						return true;
					}
				}
				return false;
			}
				#endregion
			return false;
		}			
			
		//variables used in the method of there_is_other_path()
		SEARCH_DIRECTION current_direction;
		//Point current_position = new Point(0,0);				
		//bend_points is ued to record the path bend points,then use this points to draw the path.
		Point[] bend_points ;
		int bended_count =0;			
		private bool there_is_other_path(Point p1,Point p2)
		{
			int x1 = p1.X;
			int y1 = p1.Y;
			int x2 = p2.X;
			int y2 = p2.Y;		
	
			bend_points = new Point[MAX_BENDED_NUM];
			bended_count =0;
			current_direction = SEARCH_DIRECTION.TOP;
			//current_position = selected_p1;//search from the position "selected_p1"
			table_for_search[x1,y1] =  new Search_Step(x1,y1);
			table_for_search[x2,y2] =  new Search_Step(x2,y2);

			while(x1!=x2 || y1!=y2)
			{					
				if(bended_count<MAX_BENDED_NUM -1)
				{
						#region if bended_count<MAX_BENDED_NUM -1,then do sth.
					switch(current_direction)
					{
						case SEARCH_DIRECTION.LEFT:
							table_for_search[x1,y1].set_used_direction(SEARCH_DIRECTION.LEFT);
							if((x1>0)&&table_number[x1-1,y1]==0)
							{
								table_for_search[x1-1,y1] = new Search_Step(x1-1,y1);
								table_for_search[x1-1,y1].set_path_prev_pos(x1,y1);
								x1--;
							}
							else
							{//start to bend
								record_bend_points(x1,y1,p1);
								current_direction = table_for_search[x1,y1].next_direction();//change direction
								continue;//continue the while loop
							}
							break;
						case SEARCH_DIRECTION.RIGHT:
							table_for_search[x1,y1].set_used_direction(SEARCH_DIRECTION.RIGHT);							
							if((x1<n+1)&&table_number[x1+1,y1]==0)
							{
								table_for_search[x1+1,y1] = new Search_Step(x1+1,y1);
								table_for_search[x1+1,y1].set_path_prev_pos(x1,y1);
								x1++;
							}
							else
							{//start to bend
								record_bend_points(x1,y1,p1);
								current_direction = table_for_search[x1,y1].next_direction();//change direction
								continue;//continue the while loop
							}break;
						case SEARCH_DIRECTION.TOP:
							table_for_search[x1,y1].set_used_direction(SEARCH_DIRECTION.TOP);							
							if((y1>0)&&table_number[x1,y1-1]==0)
							{
								table_for_search[x1,y1-1] = new Search_Step(x1,y1-1);
								table_for_search[x1,y1-1].set_path_prev_pos(x1,y1);
								y1--;
							}
							else
							{//start to bend
								record_bend_points(x1,y1,p1);
								current_direction = table_for_search[x1,y1].next_direction();//change direction
								continue;//continue the while loop
							}break;
						case SEARCH_DIRECTION.BOTTOM:
							table_for_search[x1,y1].set_used_direction(SEARCH_DIRECTION.BOTTOM);							
							if((y1<n+1)&&table_number[x1,y1+1]==0)
							{
								table_for_search[x1,y1+1] = new Search_Step(x1,y1+1);
								table_for_search[x1,y1+1].set_path_prev_pos(x1,y1);
								y1++;
							}
							else
							{//start to bend
								record_bend_points(x1,y1,p1);
								current_direction = table_for_search[x1,y1].next_direction();//change direction
								continue;//continue the while loop
							}break;
						case SEARCH_DIRECTION.NO_DIRECTION:
							//if current position isn't the initiate position, replace current position with it's prev position
							if(x1 != p1.X || y1 != p1.Y)
							{
								Point tempp =table_for_search[x1,y1].get_path_prev_pos();
								x1 = tempp.X;
								y1 = tempp.Y;
								record_bend_points(x1,y1,p1);
								current_direction = table_for_search[x1,y1].next_direction();//change direction
								continue;//continue the while loop
							}
							else return false;//the current position is the initiate position,and there's no direction for search
					}//end switch
						#endregion
				}
				else if(bended_count == MAX_BENDED_NUM -1)
				{
						#region if bended_count = MAX_BENDED_NUM -1,then do some other thing
					switch(current_direction)
					{
						case SEARCH_DIRECTION.LEFT:
							table_for_search[x1,y1].set_used_direction(SEARCH_DIRECTION.LEFT);
							if((x1>0)&&table_number[x1-1,y1]==0)
							{
								if(x1-1 > x2)
								{
									table_for_search[x1 - 1,y1] = new Search_Step(x1-1,y1);
									table_for_search[x1 - 1,y1].set_path_prev_pos(x1,y1);
									x1--;continue;
								}
								else //if(x1-1 == x2)//bend for the last time
								{
									if(there_is_a_straight_path(new Point(x1-1,y1),p2))
									{
										record_bend_points(x1-1,y1,p1);
										return true;
									}
									else//back to the last bend point and search continue
									{
										x1 = bend_points[bended_count -1].X;
										y1 = bend_points[bended_count -1].Y;
										//bended_count --;//go back to the bend point,and for this bend point,bended path is also necessary
										//  behind the same
										current_direction = table_for_search[x1,y1].next_direction();
										continue;
									}
								}
							}
							else
							{
								x1 = bend_points[bended_count -1].X;
								y1 = bend_points[bended_count -1].Y;
								//bended_count --;
								current_direction = table_for_search[x1,y1].next_direction();
								continue;
							}
						case SEARCH_DIRECTION.RIGHT:
							table_for_search[x1,y1].set_used_direction(SEARCH_DIRECTION.RIGHT);							
							if((x1<n+1)&&table_number[x1+1,y1]==0)
							{
								if(x1+1 < x2)
								{
									table_for_search[x1 + 1,y1] = new Search_Step(x1+1,y1);
									table_for_search[x1 + 1,y1].set_path_prev_pos(x1,y1);
									x1++;continue;
								}
								else //if(x1+1 == x2)//bend for the last time
								{
									if(there_is_a_straight_path(new Point(x1+1,y1),p2))
									{
										record_bend_points(x1+1,y1,p1);
										return true;
									}
									else//back to the last bend point and search continue
									{
										x1 = bend_points[bended_count -1].X;
										y1 = bend_points[bended_count -1].Y;
										//bended_count --;
										current_direction = table_for_search[x1,y1].next_direction();
										continue;
									}
								}
							}
							else
							{
								x1 = bend_points[bended_count -1].X;
								y1 = bend_points[bended_count -1].Y;
								//bended_count --;
								current_direction = table_for_search[x1,y1].next_direction();
								continue;
							}
						case SEARCH_DIRECTION.TOP:
							table_for_search[x1,y1].set_used_direction(SEARCH_DIRECTION.TOP);							
							if((y1 > 0)&&table_number[x1,y1 - 1]==0)
							{
								if(y1 - 1 > y2)
								{
									table_for_search[x1,y1 -1] = new Search_Step(x1,y1 -1);
									table_for_search[x1,y1 -1].set_path_prev_pos(x1,y1);
									y1--; continue;
								}
								else //if(y1-1 == y2)//bend for the last time
								{
									if(there_is_a_straight_path(new Point(x1,y1 -1),p2))
									{
										record_bend_points(x1,y1-1,p1);
										return true;
									}
									else//back to the last bend point and search continue
									{
										x1 = bend_points[bended_count -1].X;
										y1 = bend_points[bended_count -1].Y;
										//bended_count --;
										current_direction = table_for_search[x1,y1].next_direction();
										continue;
									}
								}
							}
							else
							{
								x1 = bend_points[bended_count -1].X;
								y1 = bend_points[bended_count -1].Y;
								//bended_count --;
								current_direction = table_for_search[x1,y1].next_direction();
								continue;
							}							
						case SEARCH_DIRECTION.BOTTOM:
							table_for_search[x1,y1].set_used_direction(SEARCH_DIRECTION.BOTTOM);							
							if((y1 < n+1)&&table_number[x1,y1 + 1]==0)
							{
								if(y1 + 1 < y2)
								{
									table_for_search[x1,y1 +1] = new Search_Step(x1,y1 +1);
									table_for_search[x1,y1 +1].set_path_prev_pos(x1,y1);
									y1++; continue;
								}
								else //if(y1+1 == y2)//bend for the last time
								{
									if(there_is_a_straight_path(new Point(x1,y1 +1),p2))
									{
										record_bend_points(x1,y1+1,p1);
										return true;
									}
									else//back to the last bend point and search continue
									{
										x1 = bend_points[bended_count -1].X;
										y1 = bend_points[bended_count -1].Y;
										//bended_count --;
										current_direction = table_for_search[x1,y1].next_direction();
										continue;
									}
								}
							}
							else
							{
								x1 = bend_points[bended_count -1].X;
								y1 = bend_points[bended_count -1].Y;
								//bended_count --;
								current_direction = table_for_search[x1,y1].next_direction();
								continue;
							}break;
						case SEARCH_DIRECTION.NO_DIRECTION:
							//if current position isn't the initiate position, replace current position with the last bend point and search continue
							if(x1 != p1.X || y1 != p1.Y)
							{
								x1 = bend_points[bended_count -1].X;
								y1 = bend_points[bended_count -1].Y;
								bended_count --;
								current_direction = table_for_search[x1,y1].next_direction();
								continue;
							}
							else return false;
					}//end switch
						#endregion
				}//end if
			}//end while
			return false;
		}//end the method there_is_other_path()

		private void record_bend_points(int x,int y, Point initiate_p)
		{   //if the current position isn't the initiate position,then record it as a bend_point
			if(x != initiate_p.X || y != initiate_p.Y)
			{
				bended_count ++;
				bend_points[bended_count -1]= new Point(x,y);
			}
		}// end method record_bend_points()
		public bool re_dispaly_card()
		{
			if(ReDisplay_Count>0)
			{
				reDispaly();
				ReDisplay_Count --;
				this.l_info1.Text = "洗牌："+ReDisplay_Count.ToString();
				while(find_match_adogs()==null)reDispaly();			
				return true;
			}
			return false;
		}
		private void reDispaly()
		{
				
			ArrayList al1 = new ArrayList();
			ArrayList al2 = new ArrayList();
			int i,j,k;
				
			for(i=1;i<=n;i++)
			{
				for(j=1;j<=n;j++)
				{					
					if(table_number[i,j]!=0)
					{
						//remember all the available position and corresponding value.
						al1.Add(new Point(i,j));
						al2.Add(table_number[i,j]);
						tables[i,j].Dispose();
					}
				}
			}

			Random ran = new Random();
			Point tempp;
			int alindex;
			for(k=0;k<al2.Count;k++)
			{
				alindex = ran.Next(0,al1.Count-1);
				tempp =  (Point)al1[alindex];
				al1.RemoveAt(alindex);
				table_number[tempp.X,tempp.Y] = (int)al2[k];
				tables[tempp.X,tempp.Y] = new adog(table_number[tempp.X,tempp.Y] , tempp.X ,tempp.Y ,this,this.imglist);
				this.Controls.Add(tables[tempp.X,tempp.Y]);
			}
					
		}
			
		public int show_tip()
		{
			if(ShowTip_Count>0)
			{
				Point[] p = find_match_adogs();
				if(p!=null)
				{
                    Random r = new Random();
                    int n ;
                    n = r.Next(0,9);
                    DialogResult result = MessageBox.Show(this, question[n], "想要提示吗？回答问题吧~~", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Cancel||result ==DialogResult .No)
                        return 0;
                    if (result == DialogResult.Yes)
                    {
                        this.tables[p[0].X, p[0].Y].BackColor = tables[p[1].X, p[1].Y].BackColor = Color.LightCoral;
                        ShowTip_Count--;
                        l_info2.Text = "提示：" + ShowTip_Count.ToString();
                        return 1;
                    }
				}
				else return -1;
			}
			return 0;
		}
		public Point[] find_match_adogs()
		{
			int i,j;
			int i1,j1;
			int temp_value;
			Point[] p = new Point[2];
			for(i=1;i<=n;i++)
			{
				for(j=1;j<=n;j++)
				{					
					if(table_number[i,j]!=0)
					{
						temp_value = table_number[i,j];
						p[0] = new Point(i,j);
						for(i1=1;i1<=n;i1++)
						{
							for(j1=1;j1<=n;j1++)
							{					
								if(table_number[i1,j1]==temp_value)
								{
									p[1] = new Point(i1,j1);
									if(search_path(p[0],p[1]))//search path for p1 and p2
									{											
										return p;
									}
								}
							
							}
						} 							
					}
				}
			}
			//MessageBox.Show("已无牌可消，游戏结束！");
			return null;
		}//end method show_tip()

		private bool is_finished()
		{
			int i,j;
			for(i=1;i<=n;i++)
			{
				for(j=1;j<=n;j++)
					if(table_number[i,j]!=0)return false;
			}
			return true;
		}
	}
	//end Class table
	
	
	#region Picture used as drawing path
	class Picture_as_drawing_path :System.Windows.Forms.PictureBox
	{
		public Picture_as_drawing_path()
		{
			this.BackColor = Color.Gold;
			this.Width = 6;	
			this.Height = 6;
			this.Location = new Point(-100,-100);
		}
	}
	#endregion 
}
