using System;
using ProtoTable;

namespace GameClient
{
	class TableList
	{
		protected static Type[] ms_table_types = new Type[5]
		{
			typeof(BuffInfoTable),
			typeof(BuffTable),
			typeof(FrameTypeTable),
			typeof(HotFixTable),
			typeof(SoundTable),
		};
		public static Type[] Values
		{
			get { return ms_table_types; }
		}
	};
};
