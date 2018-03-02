using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scripts.UI;

namespace GameClient
{
    public class LoginFrame : ClientFrame
    {
        const int Invoke_Fly = 1000;
        const int Invoke_Fly_Repeated = 1001;
        List<string> mValue = new List<string>();

        Scripts.UI.ComUIListScript mItemListScript;

        protected override void _InitScriptBinder()
        {
            mItemListScript = mScriptBinder.GetObject("ItemListScript") as Scripts.UI.ComUIListScript;
        }

        protected override void _OnOpenFrame()
        {
            Button btnClose = Utility.FindComponent<Button>(root, "Close");
            if(null != btnClose)
            {
                btnClose.onClick.AddListener(_OnClickCloseFrame);
            }

            RegisterEvent(ClientEvent.CE_LOGIN_TEST, _OnLoginTest);

            _InitItemListScript();
            _UpdateItems();

            mScriptBinder.SetAction("lose");
        }

        void _InitItemListScript()
        {
            if (null != mScriptBinder)
            {
                mItemListScript = mScriptBinder.GetObject("ItemListScript") as Scripts.UI.ComUIListScript;
                if (null != mItemListScript)
                {
                    mItemListScript.Initialize();

                    mItemListScript.onBindItem = (GameObject go) =>
                    {
                        if (null != go)
                        {
                            return go.GetComponent<ComItem>();
                        }
                        return null;
                    };

                    mItemListScript.onItemVisiable = (ComUIListElementScript element) =>
                    {
                        if (null != element && element.m_index >= 0 && element.m_index <= mValue.Count)
                        {
                            var script = element.gameObjectBindScript as ComItem;
                            if (null != script)
                            {
                                script.OnItemVisible(mValue[element.m_index]);
                            }
                        }
                    };
                }
            }
        }

        void _UpdateItems()
        {
            mValue.Clear();
            for(int i = 0; i < 15; ++i)
            {
                mValue.Add("Fuck" + i);
                mValue.Add("Your" + i);
                mValue.Add("Mother" + i);
            }

            if(null != mItemListScript)
            {
                mItemListScript.SetElementAmount(mValue.Count);
            }
        }

        protected void _OnLoginTest(object param)
        {
            LogManager.Instance().LogFormat("on recv loginTest !!!");
        }

        protected void _OnClickCloseFrame()
        {
            AudioManager.Instance().PlaySound(1001);
        }

        protected override void _OnCloseFrame()
        {
            if(null != mItemListScript)
            {
                mItemListScript.onBindItem = null;
                mItemListScript.onItemVisiable = null;
                mItemListScript = null;
            }
        }
    }
}