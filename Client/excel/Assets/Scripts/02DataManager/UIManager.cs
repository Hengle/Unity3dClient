using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
    public enum FrameTypeID
    {
        FTID_INVALID = -1,
        FTID_LOGIN = 1,
        FTID_HOTFIX = 2,
		FTID_LOBBY = 3,
		FTID_SETTING = 4,
    }

    class UIManager : Singleton<UIManager>
    {
        public int MakeFrameHashCode(int frameId, int frameTypeId)
        {
            return (frameId & 0xFFFF) | ((frameTypeId & 0xFFFF) << 16);
        }

        public IFrame OpenFrame<T>(int frameTypeId,object userData = null,int frameId = -1,GameObject parent = null) where T : IFrame , new()
        {
            int iKey = MakeFrameHashCode(frameId, frameTypeId);
            IFrame frame = null;
            if (mActiveFrames.ContainsKey(iKey))
            {
                frame = mActiveFrames[iKey];
                frame.closeFrame();
            }
            else if(mCachedFrames.ContainsKey(iKey))
            {
                frame = mCachedFrames[iKey];
                mCachedFrames.Remove(iKey);
                mActiveFrames.Add(iKey, frame);
            }
            else
            {
                frame = new T();
                mActiveFrames.Add(iKey, frame);
            }
            frame.openFrame(frameId, frameTypeId, userData, parent);
            return frame;
        }

        public IFrame OpenFrameLua(int frameTypeId, object userData = null, int frameId = -1, GameObject parent = null)
        {
            int iKey = MakeFrameHashCode(frameId, frameTypeId);
            IFrame frame = null;
            if (mActiveFrames.ContainsKey(iKey))
            {
                frame = mActiveFrames[iKey];
                frame.closeFrame();
            }
            else if (mCachedFrames.ContainsKey(iKey))
            {
                frame = mCachedFrames[iKey];
                mCachedFrames.Remove(iKey);
                mActiveFrames.Add(iKey, frame);
            }
            else
            {
                frame = new ClientFrame();
                mActiveFrames.Add(iKey, frame);
            }
            frame.openFrame(frameId, frameTypeId, userData, parent);
            return frame;
        }

        public void CloseFrameLua(int frameTypeId, int frameId = -1)
        {
            int iHashCode = MakeFrameHashCode(frameId, frameTypeId);
            if(mActiveFrames.ContainsKey(iHashCode))
            {
                IFrame frame = mActiveFrames[iHashCode];
                if(frame.getFrameState() != FrameState.FS_CLOSED)
                {
                    mActiveFrames.Remove(iHashCode);
                    mCachedFrames.Add(iHashCode, frame);
                    frame.closeFrame();
                }
            }
        }

        public void CloseFrame<T>(T frame) where T : IFrame, new()
        {
            if(null != frame && frame.getFrameState() != FrameState.FS_CLOSED)
            {
                int iHashCode = frame.getFrameHashCode();
                mActiveFrames.Remove(iHashCode);
                mCachedFrames.Add(iHashCode,frame);
                frame.closeFrame();
            }
        }

        public void CloseAllFrames()
        {
            var framePools = GamePool.ListPool<IFrame>.Get();

            var enumerator = mActiveFrames.GetEnumerator();
            while(enumerator.MoveNext())
            {
                framePools.Add(enumerator.Current.Value);
            }
            for(int i = 0; i < framePools.Count; ++i)
            {
                IFrame frame = framePools[i];
                if (null != frame && frame.getFrameState() != FrameState.FS_CLOSED)
                {
                    int iHashCode = frame.getFrameHashCode();
                    mCachedFrames.Add(iHashCode, frame);
                    frame.closeFrame();
                }
            }

            GamePool.ListPool<IFrame>.Release(framePools);

            framePools.Clear();
            if (mActiveFrames.Count > 0)
            {
                enumerator = mActiveFrames.GetEnumerator();
                while(enumerator.MoveNext())
                {
                    var frame = enumerator.Current.Value;
                    LogManager.Instance().LogErrorFormat("<color=#ff0000>frame has not been closed yet ! type id = {0} !!", frame.getFrameTypeId());
                    framePools.Add(frame);
                }
            }
            mActiveFrames.Clear();

            GamePool.ListPool<IFrame>.Release(framePools);
        }

        protected Dictionary<int, IFrame> mActiveFrames = new Dictionary<int, IFrame>();
        protected Dictionary<int, IFrame> mCachedFrames = new Dictionary<int, IFrame>();
    }
}