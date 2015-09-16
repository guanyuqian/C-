using System;

namespace llk
{
	/// <summary>
	/// BasicSetting 的摘要说明。
	/// </summary>
	public class BasicSetting
	{
		public static int ADOG_WIDTH = 60;
		public static int ADOG_HEIGHT = 50;
		public static int Matrix_Size = 8;		

		public static int ReDisplay_Count = 5;
		public static int ShowTip_Count = 6;
		public static int OVER_ALL_TIME = 240000;//ms（that is 4 minutes）

		public static int MAX_BENDED_NUM =3;


		public BasicSetting()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

	}


	#region enum SEARCH_DIRECTION for the searching process
	//SEARCH_Direction
	public enum SEARCH_DIRECTION{TOP =1,BOTTOM =2,LEFT=3,RIGHT=4,NO_DIRECTION =0}
		#endregion

}
