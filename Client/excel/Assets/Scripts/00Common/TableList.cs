using System;
using ProtoTable;

namespace GameClient
{
	class TableList
	{
		protected static Type[] ms_table_types = new Type[6]
		{
			typeof(FishTable),
			typeof(FrameTypeTable),
			typeof(HotFixTable),
			typeof(LocalSettingTable),
			typeof(SoundTable),
            typeof(CommonMessageTable),
		};
		public static Type[] Values
		{
			get { return ms_table_types; }
		}
	};
};
