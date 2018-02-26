using System;
using ProtoTable;

namespace GameClient
{
	class TableList
	{
		protected static Type[] ms_table_types = new Type[0]
		{
		};
		public static Type[] Values
		{
			get { return ms_table_types; }
		}
	};
};
