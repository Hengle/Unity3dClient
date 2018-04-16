using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    public class FishDataManager
    {
        protected static FishDataManager ms_handle = null;

        public static FishDataManager Instance()
        {
            if (null == ms_handle)
            {
                ms_handle = new FishDataManager();
            }
            return ms_handle;
        }

        public void Initialize()
        {
            chairId = 0;
        }

        public int chairId
        {
            get;set;
        }
    }
}