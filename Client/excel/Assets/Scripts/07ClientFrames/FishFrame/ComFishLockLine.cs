using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
    public class ComFishLockLine : MonoBehaviour
    {
        public const int ms_dis = 50;
        public Image lock_template;
        public List<Image> pool = new List<Image>();
        public GameObject recycle_root;
        public GameObject alive_root;
        public RectTransform[] cannons = new RectTransform[(int)FishConfig.fish_player_count];
        class LineInfo
        {
            public RectTransform target;
            public Vector2 pos;
            public int chairId;
            public List<Image> lockSprites = new List<Image>(8);
            public void OnRecycle(GameObject root,List<Image> pool)
            {
                for(int i = 0; i < lockSprites.Count; ++i)
                {
                    Utility.AttachTo(lockSprites[i].gameObject, root);
                    pool.Add(lockSprites[i]);
                }
                lockSprites.Clear();
            }
        };
        List<LineInfo> mLockLines = new List<LineInfo>();

        public void ClearLockLines()
        {
            for(int i = 0; i < mLockLines.Count; ++i)
            {
                mLockLines[i].OnRecycle(recycle_root,pool);
            }
            mLockLines.Clear();
        }

        public int FindTarget(RectTransform target,int chairId)
        {
            int iIndex = -1;
            for(int i = 0; i < mLockLines.Count;++i)
            {
                if(mLockLines[i].target == target && mLockLines[i].chairId == chairId)
                {
                    iIndex = i;
                    break;
                }
            }
            return iIndex;
        }

        public void RemoveTarget(RectTransform target, int chairId)
        {
            if(null != target)
            {
                var iIndex = FindTarget(target, chairId);
                if(-1 != iIndex)
                {
                    if(null != mLockLines[iIndex])
                    {
                        mLockLines[iIndex].OnRecycle(recycle_root, pool);
                        mLockLines.RemoveAt(iIndex);
                    }
                }
            }
        }

        public void AddTrace(RectTransform target,Vector2 orgPosition,int chairId)
        {
            if(null == target)
            {
                return;
            }
            if(chairId < 0 || chairId >= FishConfig.fish_player_count)
            {
                return;
            }
            int iIndex = FindTarget(target, chairId);
            if(-1 == iIndex)
            {
                LineInfo line = new LineInfo { target = target, pos = orgPosition , chairId = chairId};
                mLockLines.Add(line);
                iIndex = mLockLines.Count - 1;
            }
            else
            {
                mLockLines[iIndex].pos = orgPosition;
            }
        }

        private void Update()
        {
            for(int i = 0; i < mLockLines.Count; ++i)
            {
                var line = mLockLines[i];
                Vector2 dir = line.target.anchoredPosition - line.pos;
                var length = dir.magnitude;
                

                if(line.chairId >= 0 && line.chairId < cannons.Length)
                {
                    var cannon = cannons[line.chairId];
                    if(null != cannon)
                    {
                        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg + 270.0f;
                        cannon.transform.localEulerAngles = new Vector3(0.0f, 0.0f, angle);
                    }
                }

                dir = dir.normalized;

                int aliveCount = (int)(length / ms_dis) + 1;
                for(int j = 0; j < aliveCount; ++j)
                {
                    Vector2 cur_position = line.pos + ms_dis * j * dir;
                    if(j < line.lockSprites.Count)
                    {
                        line.lockSprites[j].rectTransform.anchoredPosition = cur_position;
                        line.lockSprites[j].CustomActive(true);
                    }
                    else
                    {
                        Image _lockSprite = null;
                        if(pool.Count > 0)
                        {
                            line.lockSprites.Add(pool[0]);
                            _lockSprite = pool[0];
                            pool.RemoveAt(0);
                        }
                        else
                        {
                            _lockSprite = GameObject.Instantiate(lock_template);
                            line.lockSprites.Add(_lockSprite);
                        }
                        Utility.AttachTo(_lockSprite.gameObject, alive_root);
                        _lockSprite.rectTransform.anchoredPosition = cur_position;
                        line.lockSprites[j].CustomActive(true);
                    }
                }

                for(int j = aliveCount; j < line.lockSprites.Count; ++j)
                {
                    line.lockSprites[j].CustomActive(false);
                }
            }
        }
    }
}