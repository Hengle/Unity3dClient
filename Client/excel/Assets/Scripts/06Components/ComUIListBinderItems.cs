using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.UI;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
    public class ComUIListBinderItems : MonoBehaviour
    {
        [CSharpCallLua]
        public delegate void OnListElementVisible(int elementIndex, ComScriptBinder binder);
        [CSharpCallLua]
        public delegate void OnListElementSelected(int elementIndex, ComScriptBinder binder);
        [CSharpCallLua]
        public delegate void OnListElementChangeDisplay(int elementIndex, ComScriptBinder binder,bool bSelected);

        public ComUIListScript comUiListScript = null;

        [HideInInspector]
        [CSharpCallLua]
        public OnListElementVisible mOnListElementVisible = null;
        [HideInInspector]
        [CSharpCallLua]
        public OnListElementSelected mOnListElementSelected = null;
        [HideInInspector]
        [CSharpCallLua]
        public OnListElementChangeDisplay mOnListElementChangeDisplay = null;

        int mElementCount = 0;

        public void Initialize()
        {
            if(null != comUiListScript)
            {
                comUiListScript.Initialize();

                comUiListScript.onBindItem = (GameObject go) =>
                {
                    if(null != go)
                    {
                        return go.GetComponent<ComScriptBinder>();
                    }
                    return null;
                };

                comUiListScript.onItemVisiable = (ComUIListElementScript item) =>
                {
                    if(null != item && item.m_index >= 0 && item.m_index < mElementCount)
                    {
                        ComScriptBinder binder = item.gameObjectBindScript as ComScriptBinder;
                        if (null != binder)
                        {
                            if(null != mOnListElementVisible)
                            {
                                mOnListElementVisible.Invoke(item.m_index, binder);
                            }
                        }
                    }
                };

                comUiListScript.onItemSelected = (ComUIListElementScript item) =>
                {
                    if (null != item && item.m_index >= 0 && item.m_index < mElementCount)
                    {
                        ComScriptBinder binder = item.gameObjectBindScript as ComScriptBinder;
                        if (null != binder)
                        {
                            if (null != mOnListElementSelected)
                            {
                                mOnListElementSelected.Invoke(item.m_index, binder);
                            }
                        }
                    }
                };

                comUiListScript.onItemChageDisplay = (ComUIListElementScript item, bool bSelected) =>
                {
                    if (null != item && item.m_index >= 0 && item.m_index < mElementCount)
                    {
                        ComScriptBinder binder = item.gameObjectBindScript as ComScriptBinder;
                        if (null != binder)
                        {
                            if (null != mOnListElementChangeDisplay)
                            {
                                mOnListElementChangeDisplay.Invoke(item.m_index, binder, bSelected);
                            }
                        }
                    }
                };
            }
        }

        public void SetElementAmount(int elementCount, List<Vector2> elementsSize = null)
        {
            mElementCount = elementCount;
            if(null != comUiListScript)
            {
                comUiListScript.SetElementAmount(mElementCount, elementsSize);
            }
        }

        public void UnInitialize()
        {
            if(null != comUiListScript)
            {
                comUiListScript.onBindItem = null;
                comUiListScript.onItemVisiable = null;
                comUiListScript.onItemSelected = null;
                comUiListScript.onItemChageDisplay = null;
                comUiListScript = null;
            }
            mElementCount = 0;
        }
    }
}