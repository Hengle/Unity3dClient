using System;
using ProtoTable;

namespace GameClient
{
	class TableList
	{
		protected static Type[] ms_table_types = new Type[4]
		{
			typeof(BuffInfoTable),
			typeof(BuffTable),
			typeof(FrameInfoBinderTable),
			typeof(FrameTypeTable),
		};
		public static Type[] Values
		{
			get { return ms_table_types; }
		}
	};
};
