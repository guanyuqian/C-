using System;
using System.Drawing;
namespace llk
{
	/// <summary>
	/// search_step 的摘要说明。
	/// class search_step used to record every step of searching process
	/// </summary>
	//class search_step is used to record every step of searching process		
	class Search_Step
	{
		//int table_number_value=0;
		public Search_Step(Point this_pos)
		{
			this.this_position = new Point(this_pos.X,this_pos.Y);			
		}
		public Search_Step(int x,int y)
		{
			this.this_position = new Point(x,y);			
		}
		bool search_top = false;
		bool search_bottom = false;
		bool search_left = false;
		bool search_right = false;
		Point this_position;
		Point path_prev_pos = new Point(-1,-1);
		public Point get_path_prev_pos()
		{
			return path_prev_pos;
		}
		public void set_used_direction(SEARCH_DIRECTION sd)
		{
			switch(sd)
			{
				case SEARCH_DIRECTION.TOP:this.search_top =true;break;
				case SEARCH_DIRECTION.BOTTOM:this.search_bottom =true;break;
				case SEARCH_DIRECTION.LEFT:this.search_left =true;break;
				case SEARCH_DIRECTION.RIGHT:this.search_right =true;break;
			}
		}
		public void set_path_prev_pos(int X,int Y)
		{
			this.path_prev_pos.X =X;
			this.path_prev_pos.Y =Y;
			set_path_prev_pos_direction();
		}

		public void set_path_prev_pos(Point p)
		{
			this.path_prev_pos.X =p.X;
			this.path_prev_pos.Y =p.Y;
			set_path_prev_pos_direction();
		}
		private void set_path_prev_pos_direction()
		{
			if(this_position.X ==this.path_prev_pos.X )
			{
				if(this_position.Y > this.path_prev_pos.Y )
					this.search_top =true;
				else this.search_bottom =true;
			}
			if(this_position.Y ==this.path_prev_pos.Y )
			{
				if(this_position.X > this.path_prev_pos.X )
					this.search_left =true;
				else this.search_right =true;
			}
		}
		public SEARCH_DIRECTION next_direction()
		{
			if(!this.search_top)return SEARCH_DIRECTION.TOP ;
			else if(!this.search_left)return SEARCH_DIRECTION.LEFT ;
			else if(!this.search_right)return SEARCH_DIRECTION.RIGHT ;
			else if(!this.search_bottom)return SEARCH_DIRECTION.BOTTOM ;
			else return SEARCH_DIRECTION.NO_DIRECTION ;
		}
	}
}
