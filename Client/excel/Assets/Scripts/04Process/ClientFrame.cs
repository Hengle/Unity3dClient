using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
    public class ClientFrame : IFrame
    {
        public int getFrameId()
        {
            return frameId;
        }

        public int getFrameTypeId()
        {
            return frameTypeId;
        }

        public int getFrameHashCode()
        {
            return iHashCode;
        }

        public virtual string getPrefabPath()
        {
            return string.Empty;
        }

        public FrameLayer getLayer()
        {
            if(null == frameItem)
            {
                return FrameLayer.TOP;
            }

            if(frameItem.Layer < (int)FrameLayer.BOTTOM || frameItem.Layer >= (int)FrameLayer.COUNT)
            {
                return FrameLayer.TOP;
            }

            return (FrameLayer)frameItem.Layer;
        }

        public void openFrame(int iId = -1, int type = 1, object userData = null)
        {
            LogManager.Instance().LogProcessFormat(9000, "try open frame {0}!", type);

            this.frameId = iId;
            this.frameTypeId = type;
            this.iHashCode = UIManager.Instance().MakeFrameHashCode(iId, type);
            this.userData = userData;
            string prefabPath = getPrefabPath();

            if(string.IsNullOrEmpty(prefabPath))
            {
                frameItem = TableManager.Instance().GetTableItem<ProtoTable.FrameTypeTable>((int)type);
                if (null == frameItem)
                {
                    LogManager.Instance().LogProcessFormat(9000, "can not find frametype with type id = {0}", type);
                    return;
                }

                if (frameItem.Layer < (int)FrameLayer.BOTTOM || frameItem.Layer >= (int)FrameLayer.COUNT)
                {
                    LogManager.Instance().LogProcessFormat(9000, "layer = {0} is invlalid with type id = {1}", frameItem.Layer, type);
                    return;
                }

                prefabPath = frameItem.Prefab;
            }

            if (null == GlobalDataManager.Instance().uiConfig)
            {
                LogManager.Instance().LogProcessFormat(9000, "uiConfig is null , can not attach frame to parent ! typeid = {0}", type);
                return;
            }

            root = AssetLoader.Instance().LoadRes(prefabPath, typeof(GameObject)).obj as GameObject;
            if (null == root)
            {
                LogManager.Instance().LogProcessFormat(9000, "load frame prefab failed : path = {0} typeid = {1}", prefabPath, type);
                return;
            }

            Utility.AttachTo(root, GlobalDataManager.Instance().uiConfig.goLayers[(int)getLayer()]);

            mScriptBinder = root.GetComponent<ComScriptBinder>();
            mLuaBehavior = root.GetComponent<LuaBehaviour>();
            _InitScriptBinder();

            if (null != frameItem)
            {
                LogManager.Instance().LogProcessFormat(9000, "open {0} frame succeed !", frameItem.Desc);
            }
            else
            {
                LogManager.Instance().LogProcessFormat(9000, "open {0} frame succeed !", prefabPath);
            }

            if(null != mLuaBehavior)
            {
                mLuaBehavior.OnOpenFrame(this);
            }
            _OnOpenFrame();
        }

        public void closeFrame()
        {
            LogManager.Instance().LogProcessFormat(9000, "close frame {0} !", frameTypeId);

            _OnCloseFrame();
            if (null != mLuaBehavior)
            {
                mLuaBehavior.OnCloseFrame();
            }
            _AutoUnRegisterAllLuaEvents();
            _AutoUnRegisterAllEvents();
            _CancelAllInvokes();
            if(null != mScriptBinder)
            {
                mScriptBinder.StopAllCoroutines();
                mScriptBinder.DestroyWithFrame();
            }
            mScriptBinder = null;
            if (null != root)
            {
                GameObject.Destroy(root);
                root = null;
            }
            userData = null;
            frameItem = null;
			Resources.UnloadUnusedAssets ();
        }

        #region lua_event_wrap
        struct LuaEventBody
        {
            public int eventId;
            public LuaEvent handler;
        };
        List<LuaEventBody> mLuaEvents = new List<LuaEventBody>(8);
        public void RegisterEvent(int eventId, LuaEvent handler)
        {
            LuaEventManager.Instance().RegisterEvent(eventId, handler);
            mLuaEvents.Add(new LuaEventBody { eventId = eventId, handler = handler });
        }

        public void UnRegisterEvent(int eventId, LuaEvent handler)
        {
            LuaEventManager.Instance().UnRegisterEvent(eventId, handler);
            for(int i = 0; i < mLuaEvents.Count; ++i)
            {
                if(mLuaEvents[i].eventId == eventId && mLuaEvents[i].handler == handler)
                {
                    mLuaEvents.RemoveAt(i);
                    break;
                }
            }
        }

        public void SendEvent(int eventId, object argv)
        {
            LuaEventManager.Instance().SendEvent(eventId, argv);
        }

        private void _AutoUnRegisterAllLuaEvents()
        {
            for (int i = 0; i < mLuaEvents.Count; ++i)
            {
                LuaEventManager.Instance().UnRegisterEvent(mLuaEvents[i].eventId, mLuaEvents[i].handler);
            }
            mLuaEvents.Clear();
        }
        #endregion

        public void SetObjectStatus(string objName, int status)
        {
            if (null != mScriptBinder)
            {
                ComStateMachine stateMachine = mScriptBinder.GetObject(objName) as ComStateMachine;
                if (null != stateMachine)
                {
                    stateMachine.Key = status;
                }
            }
        }

        public void SetText(string objName, string value)
        {
            if (null != mScriptBinder)
            {
                Text text = mScriptBinder.GetObject(objName) as Text;
                if (null != text)
                {
                    text.text = value;
                }
            }
        }

        public void SetImage(string objName, string path)
        {
            if (null != mScriptBinder)
            {
                Image img = mScriptBinder.GetObject(objName) as Image;
                if (null != img)
                {
                    AssetInst inst = AssetLoader.Instance().LoadRes(path, typeof(Sprite));
                    if (null != inst && null != inst.obj)
                    {
                        img.sprite = inst.obj as Sprite;
                    }
                }
            }
        }

        public Object GetObject(string objName)
        {
            if(null != mScriptBinder)
            {
                return mScriptBinder.GetObject(objName);
            }
            return null;
        }

        protected virtual void _InitScriptBinder()
        {

        }

        protected virtual void _OnOpenFrame()
        {

        }

        protected virtual void _OnCloseFrame()
        {

        }

        #region event_wrapp
        protected void RegisterEvent(ClientEvent e, System.Action<object> handler)
        {
            EventManager.Instance().RegisterEvent(e, handler);
            mCachedEvents.Add(new EventBody
            {
                e = e,
                handler = handler,
            });
        }

        private void _AutoUnRegisterAllEvents()
        {
            for(int i = 0; i < mCachedEvents.Count; ++i)
            {
                EventManager.Instance().UnRegisterEvent(mCachedEvents[i].e, mCachedEvents[i].handler);
            }
            mCachedEvents.Clear();
        }

        struct EventBody
        {
            public ClientEvent e;
            public System.Action<object> handler;
        };
        List<EventBody> mCachedEvents = new List<EventBody>(8);
        #endregion
        #region invoke_wrapp
        protected void Invoke(int flag, float delay, UnityAction callback)
        {
            CancelInvoke(flag);
            int iHandleId = InvokeManager.Instance().Invoke(this, delay, callback);
            mInvokeHandles.Add(new InvokeBody { iFlag = flag, iInvokeHandle = iHandleId });
        }

        protected void InvokeRepeate(int flag, float delay, int repeat, float interval, UnityAction onStart, UnityAction onUpdate, UnityAction onEnd)
        {
            CancelInvoke(flag);
            int iHandleId = InvokeManager.Instance().InvokeRepeate(this, delay, repeat, interval,onStart,onUpdate,onEnd);
            mInvokeHandles.Add(new InvokeBody { iFlag = flag, iInvokeHandle = iHandleId });
        }

        protected void CancelInvoke(int flag)
        {
            int iFindIndex = _FindInvokeIndex(flag);
            if (-1 != iFindIndex)
            {
                InvokeManager.Instance().RemoveInvoke(mInvokeHandles[iFindIndex].iInvokeHandle);
                mInvokeHandles.RemoveAt(iFindIndex);
            }
        }

        private int _FindInvokeIndex(int flag)
        {
            int iFindIndex = -1;
            for(int i = 0; i < mInvokeHandles.Count; ++i)
            {
                if(mInvokeHandles[i].iFlag == flag)
                {
                    iFindIndex = i;
                    break;
                }
            }
            return iFindIndex;
        }

        private void _CancelAllInvokes()
        {
            InvokeManager.Instance().RemoveInvoke(this);
            mInvokeHandles.Clear();
        }

        struct InvokeBody
        {
            public int iInvokeHandle;
            public int iFlag;
        }
        List<InvokeBody> mInvokeHandles = new List<InvokeBody>(8);
        #endregion
        #region coroutine_wrapp
        protected Coroutine StartCoroutine(IEnumerator routine)
        {
            if(null != mScriptBinder)
            {
                return mScriptBinder.StartCoroutine(routine);
            }

            LogManager.Instance().LogErrorFormat("mScriptBinder is null !!!");
            return null;
        }
        protected void StopCoroutine(IEnumerator routine)
        {
            if(null != mScriptBinder)
            {
                mScriptBinder.StartCoroutine(routine);
            }
        }
        #endregion

        int frameId = -1;
        int frameTypeId = -1;
        int iHashCode = 0;
        protected object userData = null;
        protected GameObject root = null;
        protected ProtoTable.FrameTypeTable frameItem = null;
        protected ComScriptBinder mScriptBinder = null;
        protected LuaBehaviour mLuaBehavior = null;

        public int FrameID
        {
            get
            {
                return frameId;
            }
        }

        public int FrameTypeID
        {
            get
            {
                return frameTypeId;
            }
        }

        public int FrameHashCode
        {
            get
            {
                return iHashCode;
            }
        }
    }
}
