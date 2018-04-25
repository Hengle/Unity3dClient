using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
    public class ComPanelFade : MonoBehaviour
    {
        public CanvasGroup canvas = null;
        public float delay = 0.0f;
        public float duration = 1.0f;
        public float from = 1.0f;
        public float to = 0.0f;
        public AnimationCurve curve = null;
        public bool playOnAwake = false;
        public UnityEvent onComplete = null;
        bool start = false;
        float time = -1.0f;
        float _duration = 0.0f;

        void Start()
        {
            if(duration <= 0.0f)
            {
                _duration = -1.0f;
            }
            else
            {
                _duration = 1.0f / duration;
            }
            
            Play();
        }

        public void Play()
        {
            start = true;
            time = Time.time;
            if (null != canvas)
            {
                canvas.alpha = from;
            }
        }

        void Update()
        {
            if (!start)
            {
                return;
            }

            if (null == curve || null == canvas || _duration < 0.0f)
            {
                start = false;
                return;
            }

            if(Time.time <= time + delay)
            {
                return;
            }

            float length = Mathf.Min(Time.time - (time + delay), duration);
            float value = curve.Evaluate(length * _duration) * (to-from) + from;
            canvas.alpha = value;

            if(Time.time - (time + delay) >= duration)
            {
                canvas.alpha = to;
                start = false;
                if(null != onComplete)
                {
                    onComplete.Invoke();
                }
            }
        }

        void OnDestroy()
        {
            if(null != onComplete)
            {
                onComplete.RemoveAllListeners();
                onComplete.Invoke();
                onComplete = null;
            }
        }
    }
}