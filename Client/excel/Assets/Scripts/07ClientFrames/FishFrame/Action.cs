using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    public class FishAction
    {
        protected static float M_PI = Mathf.PI;
        protected static float M_PI_2 = Mathf.PI * 0.50f;
        protected static Dictionary<System.Type, List<FishAction>> mActionPools = new Dictionary<System.Type, List<FishAction>>();
        public static T CreateActionFromPool<T>(int count = 100) where T : FishAction ,new()
        {
            if(count < 0)
            {
                count = 8;
            }

            var type = typeof(T);

            if (!mActionPools.ContainsKey(type))
            {
                mActionPools.Add(type, new List<FishAction>(count));
            }

            FishAction action = null;

            var pool = mActionPools[type];
            if(pool.Count > 0)
            {
                action = pool[0];
                pool.RemoveAt(0);
            }
            else
            {
                action = new T();
            }

            return action as T;
        }
        public static void ThrowActionToPoll(FishAction action)
        {
            if(null == action)
            {
                return;
            }

            System.Type type = action.GetType();
            if (!mActionPools.ContainsKey(type))
            {
                return;
            }

            var actions = mActionPools[type];
            if (null != actions)
            {
                actions.Add(action);
            }
        }

        public static float fmodf(float x, float y)
        {
            if (y < 1e-6)
            {
                return float.NaN;
            }

            float f1 = x < 0.0f ? -x : x;
            float f2 = y < 0.0f ? -y : y;

            while (f1 >= f2)
            {
                f1 -= f2;
            }

            return x <= 0.0f ? -f1 : f1;
        }

        public FishAction()
        {
            data_ptr_ = null;
            tag_ = 0;
            speed_ = 1.0f;
            angle_ = 0.0f;
            scale_ = new Vector2(1.0f, 1.0f);
            color_ = 0xffffffff;
        }

        public void Destroy()
        {
            OnDestroy();
            data_ptr_ = null;
            tag_ = 0;
            speed_ = 1.0f;
            angle_ = 0.0f;
            scale_ = new Vector2(1.0f, 1.0f);
            color_ = 0xffffffff;
        }

        public virtual void OnDestroy()
        {

        }

        public void set_data_ptr(object data_ptr)
        {
            data_ptr_ = data_ptr;
        }

        public object data_ptr()
        {
            return data_ptr_;
        }

        public void set_tag(int tag)
        {
            tag_ = tag;
        }

        public int tag()
        {
            return tag_;
        }

        public virtual bool IsDone()
        {
            return true;
        }

        public virtual void Start()
        {

        }

        public virtual void Stop()
        {

        }

        public virtual void Step(float dt)
        {

        }

        public virtual void Update(float time)
        {

        }

        public virtual float speed()
        {
            return 1.0f;
        }

        public virtual void set_speed(float speed)
        {

        }

        public Vector2 position()
        {
            return position_;
        }

        public void set_position(Vector2 position)
        {
            position_ = position;
        }

        public float angle()
        {
            return angle_;
        }

        public void set_angle(float angle)
        {
            angle_ = angle;
        }

        public Vector2 scale()
        {
            return scale_;
        }

        public void set_scale(float scale_x, float scale_y)
        {
            scale_.x = scale_x;
            scale_.y = scale_y;
        }

        public uint color()
        {
            return color_;
        }

        public void set_color(uint color)
        {
            color_ = color;
        }

        protected object data_ptr_;
        protected int tag_;
        protected float speed_;
        protected Vector2 position_;
        protected float angle_;
        protected Vector2 scale_;
        protected uint color_;
    };

    //------------------------------------------------------------------------------
    //扩展了一个duration
    public class FishActionFinitTime : FishAction
    {
        public FishActionFinitTime(float duration) : base()
        {
            this.duration_ = duration;
        }

        public virtual float duration() { return duration_; }
        public virtual void set_duration(float duration) { duration_ = duration; }

        protected float duration_;
    };
    //------------------------------------------------------------------------------

    public class FishActionInterval : FishActionFinitTime
    {
        public FishActionInterval(float duration) : base(duration)
        {
            elapsed_ = 0.0f;
            stop_ = false;
        }

        //virtual ~FishActionInterval();

        public override bool IsDone()
        {
            return (elapsed_ >= duration_ || stop_);
        }

        public override void Stop()
        {
            stop_ = true;
        }

        public override void Start()
        {
            elapsed_ = 0;
            stop_ = false;
            base.Start();
        }

        public override void Step(float dt)
        {
            elapsed_ += dt * speed_;
            float _tt = Mathf.Min(1.0f, elapsed_ / duration_);
            Update(_tt);
        }

        public virtual void Stepbut(float dt, int butid, long ftime, long etime)
        {
            elapsed_ += dt * speed_;
            float _tt = Mathf.Min(1.0f, elapsed_ / duration_);
            Update(_tt);
        }

        public override void Update(float time)
        {

        }

        public override float speed()
        {
            return speed_;
        }

        public override void set_speed(float speed)
        {
            speed_ = speed;
        }

        public virtual float elapsed()
        {
            return elapsed_;
        }

        public virtual void set_elapsed(float elapsed)
        {
            elapsed_ = elapsed;
        }

        protected float elapsed_;
        protected bool stop_;
    };

    //------------------------------------------------------------------------------
    class FishActionDelay : FishActionInterval
    {
        public FishActionDelay(float duration) : base(duration)
        {

        }
    };

    //------------------------------------------------------------------------------

    class FishActionFlash : FishActionInterval
    {
        public FishActionFlash(float duration, float flash_interval) : base(duration)
        {
            flash_interval_ = flash_interval;
            flash_elapsed_ = 0;
            visible_ = true;
        }
        //virtual ~FishActionFlash();

        public override void Start()
        {
            base.Start();
            flash_elapsed_ = 0.0f;
            visible_ = true;
        }

        public override void Step(float dt)
        {
            elapsed_ += dt * speed_;
            flash_elapsed_ += dt;
            if (flash_elapsed_ >= flash_interval_)
            {
                flash_elapsed_ -= flash_interval_;
                visible_ = !visible_;
            }
            float _tt = Mathf.Min(1.0f, elapsed_ / duration_);
            Update(_tt);
        }

        public bool visible()
        {
            return visible_;
        }

        private float flash_interval_;
        private float flash_elapsed_;
        private bool visible_;
    };

    //------------------------------------------------------------------------------
    class FishActionMoveTo : FishActionInterval
    {
        public FishActionMoveTo(float duration, Vector2 start, Vector2 end) : base(duration)
        {
            position_ = start_;
            delta_ = end - start;
            float length = delta_.magnitude;
            float rote;
            if (length > 0)
            {
                if (delta_.y >= 0)
                {
                    rote = Mathf.Acos(delta_.x / length);
                }
                else
                {
                    rote = -Mathf.Acos(delta_.x / length);
                }
                angle_ = rote;
            }
        }
        //virtual ~FishActionMoveTo();

        public override void Start()
        {
            position_ = start_;
            delta_ = end_ - start_;
            float length = delta_.magnitude;
            float rote;
            if (length > 0)
            {
                if (delta_.y >= 0)
                {
                    rote = Mathf.Acos(delta_.x / length);
                }
                else
                {
                    rote = -Mathf.Acos(delta_.x / length);
                }
                angle_ = rote - M_PI_2;
            }
            base.Start();
        }

        public override void Update(float time)
        {
            position_.x = start_.x + delta_.x * time;
            position_.y = start_.y + delta_.y * time;
        }

        protected Vector2 start_;
        protected Vector2 end_;
        protected Vector2 delta_;
    };
    //------------------------------------------------------------------------------
    class FishActionMoveBy : FishActionMoveTo
    {
        public FishActionMoveBy(float duration, Vector2 start, Vector2 delta) : base(duration, start, Vector2.zero)
        {
            delta_ = delta;
        }
        //virtual ~FishActionMoveBy();

        public override void Start()
        {
            Vector2 temp = delta_;
            base.Start();
            delta_ = temp;
        }
    };
    //------------------------------------------------------------------------------
    class FishActionBezierBy : FishActionInterval
    {
        public FishActionBezierBy(float duration, Vector2 start, Vector2 c1, Vector2 c2, Vector2 end) : base(duration)
        {
            start_ = start;
            end_ = end;
            control1_ = c1;
            control2_ = c2;
            position_ = start_;
        }
        //virtual ~FishActionBezierBy();

        public override void Start()
        {
            base.Start();
            position_ = start_;
        }

        static float bezierat(float a, float b, float c, float d, float t)
        {
            return Mathf.Pow(1 - t, 3.0f) * a + 3 * t * (Mathf.Pow(1 - t, 2)) * b + 3 * Mathf.Pow(t, 2) * (1 - t) * c + Mathf.Pow(t, 3) * d;
        }

        public override void Update(float time)
        {
            float x = bezierat(start_.x, control1_.x, control2_.x, end_.x, time);
            float y = bezierat(start_.y, control1_.y, control2_.y, end_.y, time);

            Vector2 tv = new Vector2(x - position_.x, y - position_.y);
            float length = tv.magnitude;
            float rote;
            if (length > 0)
            {
                if (tv.y >= 0)
                {
                    rote = Mathf.Acos(tv.x / length);
                }
                else
                {
                    rote = -Mathf.Acos(tv.x / length);
                }
                angle_ = rote - M_PI_2;
            }
            position_.x = x;
            position_.y = y;
        }

        private Vector2 start_;
        private Vector2 end_;
        private Vector2 control1_;
        private Vector2 control2_;
    };

    //------------------------------------------------------------------------------

    class FishActionRorateTo : FishActionInterval
    {
        public FishActionRorateTo(float duration, float start, float end) : base(duration)
        {
            start_angle_ = start;
            end_angle_ = end;
            angle_ = start;
            if (start_angle_ > 0)
            {
                start_angle_ = fmodf(start_angle_, M_PI);
            }
            else
            {
                start_angle_ = fmodf(start_angle_, -M_PI);
            }
            diff_angle_ = end_angle_ - start_angle_;
            if (diff_angle_ > M_PI_2)
                diff_angle_ -= M_PI;
            if (diff_angle_ < -M_PI_2)
                diff_angle_ += M_PI;
        }
        // virtual ~FishActionRorateTo();

        public override void Start()
        {
            base.Start();
            start_angle_ = angle_;
            if (start_angle_ > 0)
            {
                start_angle_ = fmodf(start_angle_, M_PI);
            }
            else
            {
                start_angle_ = fmodf(start_angle_, -M_PI);
            }
            diff_angle_ = end_angle_ - start_angle_;
            if (diff_angle_ > M_PI_2)
                diff_angle_ -= M_PI;
            if (diff_angle_ < -M_PI_2)
                diff_angle_ += M_PI;
        }

        public override void Update(float time)
        {
            angle_ = start_angle_ + diff_angle_ * time;
        }


        private float start_angle_;
        private float end_angle_;
        private float diff_angle_;
    };

    //------------------------------------------------------------------------------
    class FishActionRorateBy : FishActionInterval
    {
        public FishActionRorateBy(float duration, float start, float angle) : base(duration)
        {
            start_angle_ = start;
            rotate_angle_ = angle;
            angle_ = start;
        }
        //virtual ~FishActionRorateBy();

        public override void Start()
        {
            base.Start();
        }

        public override void Update(float time)
        {
            angle_ = start_angle_ + rotate_angle_ * time;
        }

        private float start_angle_;
        private float rotate_angle_;
    };

    //------------------------------------------------------------------------------
    class FishActionRorateRepeatForever : FishActionInterval
    {
        public FishActionRorateRepeatForever(float start, float angle) : base(0)
        {
            start_angle_ = start;
            rotate_angle_ = angle;
        }
        //public virtual ~FishActionRorateRepeatForever();

        public override bool IsDone()
        {
            return false;
        }

        public override void Start()
        {
            base.Start();
            start_angle_ = angle_;
        }

        public override void Update(float time)
        {
            angle_ += rotate_angle_;
        }

        private float start_angle_;
        private float rotate_angle_;
    };

    //------------------------------------------------------------------------------

    class FishActionFadeOut : FishActionInterval
    {
        public FishActionFadeOut(float duration) : base(duration)
        {

        }
        //virtual ~FishActionFadeOut();

        public override void Update(float time)
        {
            long color = color_;
            byte alpha = (byte)(255 * (1.0f - time));
        }
    };

    //------------------------------------------------------------------------------

    class FishActionFadeIn : FishActionInterval
    {
        public FishActionFadeIn(float duration) : base(duration)
        {

        }

        //public virtual ~FishActionFadeIn()
        //{

        //}

        public override void Update(float time)
        {
            long color = color_;
            byte alpha = (byte)(255 * time);
        }
    };

    //------------------------------------------------------------------------------
    class FishActionScaleTo : FishActionInterval
    {
        public FishActionScaleTo(float duration, float start_scale_x, float start_scale_y, float scale) : base(duration)
        {
            start_scale_x_ = start_scale_x;
            start_scale_y_ = start_scale_y;
            end_scale_x_ = scale;
            end_scale_y_ = scale;
            scale_.x = start_scale_x;
            scale_.y = start_scale_y;
            delta_x_ = end_scale_x_ - start_scale_x_;
            delta_y_ = end_scale_y_ - start_scale_y_;
        }

        public FishActionScaleTo(float duration, float start_scale_x, float start_scale_y, float scale_x, float scale_y) : base(duration)
        {
            start_scale_x_ = start_scale_x;
            start_scale_y_ = start_scale_y;
            end_scale_x_ = scale_x;
            end_scale_y_ = scale_y;
            scale_.x = start_scale_x;
            scale_.y = start_scale_y;
            delta_x_ = end_scale_x_ - start_scale_x_;
            delta_y_ = end_scale_y_ - start_scale_y_;
        }

        //virtual ~FishActionScaleTo();

        public override void Start()
        {
            base.Start();
            delta_x_ = end_scale_x_ - start_scale_x_;
            delta_y_ = end_scale_y_ - start_scale_y_;
        }

        public override void Update(float time)
        {
            scale_.x = start_scale_x_ + delta_x_ * time;
            scale_.y = start_scale_y_ + delta_y_ * time;
        }

        protected float start_scale_x_;
        protected float start_scale_y_;
        protected float end_scale_x_;
        protected float end_scale_y_;
        protected float delta_x_;
        protected float delta_y_;
    };

    //------------------------------------------------------------------------------
    class FishActionScaleBy : FishActionScaleTo
    {
        public FishActionScaleBy(float duration, float start_scale_x, float start_scale_y, float scale_x, float scale_y) : base(duration, start_scale_x, start_scale_y, scale_x, scale_y)
        {
            delta_x_ = scale_x;
            delta_y_ = scale_y;
        }
        //virtual ~FishActionScaleBy();

        public override void Start()
        {
            base.Start();
            delta_x_ = end_scale_x_;
            delta_y_ = end_scale_y_;
        }
    };

    //------------------------------------------------------------------------------
    class FishActionSequence : FishActionInterval
    {
        class Sequence : FishActionInterval
        {
            public Sequence(FishAction act1, FishAction act2) : base(0)
            {
                last_ = -1;
                actions_[0] = act1 as FishActionFinitTime;
                actions_[1] = act2 as FishActionFinitTime;
                duration_ = actions_[0].duration() + actions_[1].duration();
                split_ = actions_[0].duration() / duration_;
                position_ = actions_[0].position();
                angle_ = actions_[0].angle();
                scale_ = actions_[0].scale();
                color_ = actions_[0].color();
            }

            //virtual ~Sequence();

            public override void Start()
            {
                base.Start();
                if (null != actions_[0] && null != actions_[1])
                    duration_ = actions_[0].duration() + actions_[1].duration();
                if (null != actions_[0])
                    split_ = actions_[0].duration() / duration_;
                last_ = -1;
            }

            public override void Update(float time)
            {
                int found = 0;
                float new_t = 0.0f;
                if (time >= split_)
                {
                    found = 1;
                    if (split_ == 1)
                    {
                        new_t = 1;
                    }
                    else
                    {
                        new_t = (time - split_) / (1 - split_);
                    }
                }
                else
                {
                    found = 0;
                    if (split_ != 0)
                    {
                        new_t = time / split_;
                    }
                    else
                    {
                        new_t = 1;
                    }
                }

                if (last_ == -1 && found == 1)
                {
                    position_ = actions_[found].position();
                    angle_ = actions_[found].angle();
                    scale_ = actions_[found].scale();
                    color_ = actions_[found].color();
                    actions_[0].Start();
                    actions_[0].Update(1.0f);
                    actions_[0].Stop();
                }

                if (last_ != found)
                {
                    if (last_ != -1)
                    {
                        actions_[last_].Update(1.0f);
                        actions_[last_].Stop();
                    }
                    position_ = actions_[found].position();
                    angle_ = actions_[found].angle();
                    scale_ = actions_[found].scale();
                    color_ = actions_[found].color();
                    actions_[found].Start();
                }

                actions_[found].Update(new_t);
                position_ = actions_[found].position();
                angle_ = actions_[found].angle();
                scale_ = actions_[found].scale();
                color_ = actions_[found].color();
                last_ = found;
            }

            public override void Stop()
            {
                for (int i = 0; i < actions_.Length; ++i)
                {
                    if (null != actions_[i])
                    {
                        actions_[i].Stop();
                    }
                }

                base.Stop();
            }

            private FishActionFinitTime[] actions_ = new FishActionFinitTime[2];
            private float split_;
            private int last_;
        };

        public FishActionSequence(FishAction act1, params object[] argv) : base(0)
        {
            FishActionFinitTime prev = act1 as FishActionFinitTime;
            if (null != prev && argv.Length > 0)
            {
                for (int i = 0; i < argv.Length; ++i)
                {
                    var now = argv[i] as FishActionFinitTime;
                    if (null != now)
                    {
                        prev = new Sequence(prev, argv[i] as FishAction);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (null != prev)
            {
                duration_ = prev.duration();
                sequence_ = prev as Sequence;
                position_ = sequence_.position();
                angle_ = sequence_.angle();
                scale_ = sequence_.scale();
                color_ = sequence_.color();
            }
        }

        public override void OnDestroy()
        {

        }

        public override void Start()
        {
            base.Start();
            sequence_.Start();
        }

        public override void Stop()
        {
            sequence_.Stop();
            base.Stop();
        }

        public override void Update(float time)
        {
            sequence_.Update(time);
            position_ = sequence_.position();
            angle_ = sequence_.angle();
            scale_ = sequence_.scale();
            color_ = sequence_.color();
        }

        private Sequence sequence_;
    };

    //------------------------------------------------------------------------------
    class FishActionRepeatForever : FishAction
    {
        public FishActionRepeatForever(FishAction action)
        {
            stop_ = false;
            action_ = action;
        }
        //virtual ~FishActionRepeatForever();

        public override bool IsDone()
        {
            return stop_;
        }

        public override void Start()
        {
            base.Start();
            action_.Start();
        }

        public override void Stop()
        {
            if (null != action_)
            {
                action_.Stop();
            }
            stop_ = true;
        }

        public override void Step(float dt)
        {
            action_.Step(dt);
            if (action_.IsDone())
            {
                action_.Stop();
                action_.Start();
            }
        }

        private bool stop_;
        private FishAction action_;
    };

    //------------------------------------------------------------------------------

    class FishActionInstant : FishActionFinitTime
    {
        public FishActionInstant() : base(0)
        {

        }
        //virtual ~FishActionInstant() { }

        public override void Step(float dt)
        {
            Update(1.0f);
        }
    };

    //------------------------------------------------------------------------------
    class FishActionFunc : FishActionInstant
    {
        public delegate void SlotFunc();

        public FishActionFunc(SlotFunc slot)
        {
            slot_func_ = slot;
        }

        public override void Start()
        {
            base.Start();
            slot_func_();
        }

        private SlotFunc slot_func_;
    };

    //------------------------------------------------------------------------------
    class FishActionFunc1 : FishActionInstant
    {
        public delegate void SlotFunc1(object argv);

        public FishActionFunc1(SlotFunc1 slot)
        {
            slot_func_ = slot;
        }

        public override void Start()
        {
            base.Start();
            slot_func_(data_ptr());
        }

        private SlotFunc1 slot_func_;
    };

    //------------------------------------------------------------------------------
    class FishActionFunc2 : FishActionInstant
    {
        public delegate void SlotFunc2(object argv, int tag);

        public FishActionFunc2(SlotFunc2 slot)
        {
            slot_func_ = slot;
        }

        public override void Start()
        {
            base.Start();
            slot_func_(data_ptr(), tag());
        }

        private SlotFunc2 slot_func_;
    };
}