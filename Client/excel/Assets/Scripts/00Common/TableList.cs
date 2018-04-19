using System;
using ProtoTable;

namespace GameClient
{
	class TableList
	{
		protected static Type[] ms_table_types = new Type[]
		{
			typeof(FishTable),
			typeof(FrameTypeTable),
			typeof(HotFixTable),
			typeof(LocalSettingTable),
			typeof(SoundTable),
            typeof(CommonMessageTable),
            typeof(SceneTable),
        };
		public static Type[] Values
		{
			get { return ms_table_types; }
		}
	};
};
