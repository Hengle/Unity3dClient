﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace GameClient
{
    [ExecuteInEditMode]
    public class UINumber : MonoBehaviour
    {
        public string preFixed;
        public List<Image> imgPools = new List<Image>();
        bool bInitialize = false;
        public int iValue = 0;
        public int Value
        {
            get
            {
                return iValue;
            }
            set
            {
                iValue = value;
                m_bDirty = true;
            }
        }

        bool m_bDirty = true;

        void Start()
        {
            m_bDirty = true;
        }

        void Update()
        {
#if UNITY_EDITOR
            m_bDirty = true;
#endif
            if (!m_bDirty)
            {
                return;
            }
            m_bDirty = false;

            int iCurValue = iValue;
            for (int i = 0; i < imgPools.Count; ++i)
            {
                imgPools[imgPools.Count - i - 1].CustomActive(i == 0 || iCurValue > 0);
                // imgPools[imgPools.Count - i - 1].sprite = AssetLoader.Instance().LoadRes(string.Format("{0}{1:D2}", preFixed, iCurValue % 10),typeof(Sprite)).obj as Sprite;
                Image img = imgPools[imgPools.Count - i - 1];
                //ETCImageLoader.LoadSprite(ref img, string.Format("{0}{1:D2}", preFixed, iCurValue % 10));
                iCurValue /= 10;
            }
        }

        void OnDestroy()
        {
            imgPools.Clear();
        }
    }
}