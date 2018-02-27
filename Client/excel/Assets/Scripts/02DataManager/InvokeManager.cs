using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace GameClient
{
    public class InvokeManager : Singleton<InvokeManager>
    {
        const int InvokeOnce = (1 << 0);
        const int InvokeRepeated = (1 << 1);

        class InvokeItem
        {
            public object target = null;
            public int flag = 0;
            public float delay = 0.0f;
            public float interval = 0.0f;
            public float start = 0.0f;
            public UnityAction onStart;
            public UnityAction onUpdate;
            public UnityAction onEnd;

            public void Reset()
            {
                target = null;
                flag = 0;
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

        public void Invoke(object target, float delay, UnityAction callback)
        {
            int iFindIndex = -1;
            for (int i = 0; i < mActivedInvokeItems.Count; ++i)
            {
                if (mActivedInvokeItems[i].target == target && callback == mActivedInvokeItems[i].onStart)
                {
                    iFindIndex = i;
                    break;
                }
            }

            InvokeItem invokeItem = null;
            if (-1 != iFindIndex)
            {
                invokeItem = mActivedInvokeItems[iFindIndex];
                invokeItem.Reset();
            }
            else
            {
                if(mCachedInvokeItems.Count > 0)
                {
                    invokeItem = mCachedInvokeItems[0];
                    mCachedInvokeItems.RemoveAt(0);
                }
                else
                {
                    invokeItem = new InvokeItem();
                }
                mActivedInvokeItems.Add(invokeItem);
            }

            invokeItem.target = target;
            invokeItem.delay = delay;
            invokeItem.onStart = callback;
            invokeItem.flag |= InvokeOnce;
            invokeItem.start = Time.time;
        }

        public void RemoveInvoke(object target,UnityAction callback)
        {
            int iFindIndex = -1;
            for (int i = 0; i < mActivedInvokeItems.Count; ++i)
            {
                if (mActivedInvokeItems[i].target == target && callback == mActivedInvokeItems[i].onStart)
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
    }
}