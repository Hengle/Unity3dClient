using System;
using ProtoTable;

namespace GameClient
{
	class TableList
	{
		protected static Type[] ms_table_types = new Type[1]
		{
			typeof(WarpStone),
		};
		public static Type[] Values
		{
			get { return ms_table_types; }
		}
	};
};
