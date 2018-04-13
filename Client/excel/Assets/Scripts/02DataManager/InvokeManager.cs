using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using XLua;

namespace GameClient
{
    [LuaCallCSharp]
    public class InvokeManager : Singleton<InvokeManager>
    {
        const int InvokeOnce = (1 << 0);
        const int InvokeRepeated = (1 << 1);

        int mHandleID = -1;

        class InvokeItem
        {
            public object target = null;
            public int iHandleId = 0;
            public int flag = 0;
            public int times = 0;
            public int repeate = 0;
            public float delay = 0.0f;
            public float interval = 0.0f;
            public float start = 0.0f;
            public EAction onStart;
            public EAction onUpdate;
            public EAction onEnd;

            public void Reset()
            {
                target = null;
                iHandleId = 0;
                flag = 0;
                times = 0;
                repeate = 0;
                delay = 0.0f;
                interval = 0.0f;
                start = 0.0f;
                onStart = null;
                onUpdate = null;
                onEnd = null;
            }
        }

        List<InvokeItem> mCachedInvokeItems = new List<InvokeItem>(16);
        List<InvokeItem> mActivedInvokeItems = new List<InvokeItem>(16);

        public void Invoke(EAction action)
        {
            GameFrameWork.FrameWorkHandle.Invoke(action);
        }

        public int Invoke(object target, float delay, EAction callback)
        {
            InvokeItem invokeItem = null;
            if (mCachedInvokeItems.Count > 0)
            {
                invokeItem = mCachedInvokeItems[0];
                mCachedInvokeItems.RemoveAt(0);
            }
            else
            {
                invokeItem = new InvokeItem();
            }
            mActivedInvokeItems.Add(invokeItem);

            invokeItem.target = target;
            invokeItem.delay = delay;
            invokeItem.onStart = callback;
            invokeItem.flag |= InvokeOnce;
            invokeItem.start = Time.time;
            invokeItem.iHandleId = ++mHandleID;

            return invokeItem.iHandleId;
        }

        public int InvokeRepeate(object target,float delay,int repeat,float interval, EAction onStart, EAction onUpdate, EAction onEnd)
        {
            InvokeItem invokeItem = null;
            if (mCachedInvokeItems.Count > 0)
            {
                invokeItem = mCachedInvokeItems[0];
                mCachedInvokeItems.RemoveAt(0);
            }
            else
            {
                invokeItem = new InvokeItem();
            }
            mActivedInvokeItems.Add(invokeItem);

            invokeItem.target = target;
            invokeItem.delay = delay;
            invokeItem.onStart = onStart;
            invokeItem.onUpdate = onUpdate;
            invokeItem.onEnd = onEnd;
            invokeItem.flag |= InvokeRepeated;
            invokeItem.repeate = repeat;
            invokeItem.interval = interval;
            invokeItem.start = Time.time;
            invokeItem.iHandleId = ++mHandleID;

            return invokeItem.iHandleId;
        }

        public void RemoveInvoke(int iHandleId)
        {
            int iFindIndex = -1;
            for (int i = 0; i < mActivedInvokeItems.Count; ++i)
            {
                if (mActivedInvokeItems[i].iHandleId == iHandleId)
                {
                    iFindIndex = i;
                    break;
                }
            }

            if(-1 != iFindIndex)
            {
                mActivedInvokeItems[iFindIndex].Reset();
                mCachedInvokeItems.Add(mActivedInvokeItems[iFindIndex]);
                mActivedInvokeItems.RemoveAt(iFindIndex);
            }
        }

        public void RemoveInvoke(object target)
        {
            for (int i = 0; i < mActivedInvokeItems.Count; ++i)
            {
                if (mActivedInvokeItems[i].target == target)
                {
                    mActivedInvokeItems[i].Reset();
                    mCachedInvokeItems.Add(mActivedInvokeItems[i]);
                    mActivedInvokeItems.RemoveAt(i--);
                }
            }
        }

        public void Update()
        {
            for(int i = 0; i < mActivedInvokeItems.Count; ++i)
            {
                InvokeItem invokeItem = mActivedInvokeItems[i];

                if((InvokeOnce) == (invokeItem.flag & InvokeOnce))
                {
                    if(invokeItem.start + invokeItem.delay <= Time.time)
                    {
                        if(null != invokeItem.onStart)
                        {
                            invokeItem.onStart();
                        }
                        invokeItem.flag = 0;
                    }
                }
                else if((InvokeRepeated) == (invokeItem.flag & InvokeRepeated))
                {
                    if(invokeItem.times == 0)
                    {
                        if (invokeItem.start + invokeItem.delay <= Time.time)
                        {
                            invokeItem.start = Time.time;
                            invokeItem.times += 1;
                            if (null != invokeItem.onStart)
                            {
                                invokeItem.onStart();
                            }
                        }
                    }
                    else
                    {
                        if (invokeItem.repeate > 0)
                        {
                            if (invokeItem.start + invokeItem.interval <= Time.time)
                            {
                                invokeItem.start = Time.time;
                                invokeItem.repeate -= 1;
                                if (null != invokeItem.onUpdate)
                                {
                                    invokeItem.onUpdate();
                                }
                            }
                        }

                        if(invokeItem.repeate == 0)
                        {
                            if(null != invokeItem.onEnd)
                            {
                                invokeItem.onEnd();
                            }
                            invokeItem.flag = 0;
                        }
                    }
                }
            }

            for(int i = 0; i < mActivedInvokeItems.Count; ++i)
            {
                if(mActivedInvokeItems[i].flag == 0)
                {
                    mActivedInvokeItems[i].Reset();
                    mCachedInvokeItems.Add(mActivedInvokeItems[i]);
                    mActivedInvokeItems.RemoveAt(i--);
                }
            }
        }

        public bool Initialize()
        {
            Clear();
            return true;
        }

        public void Clear()
        {
            mCachedInvokeItems.Clear();
            mActivedInvokeItems.Clear();
            mHandleID = -1;
        }
    }
}