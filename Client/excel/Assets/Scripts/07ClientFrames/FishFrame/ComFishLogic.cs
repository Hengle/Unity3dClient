using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace GameClient
{
    public class ComFishLogic : MonoBehaviour
    {
        public GameObject recycleRoot = null;
        public GameObject fishLayer = null;
        public GameObject fishLockNumberRoot = null;
        public GameObject bulletLayer = null;
        public GameObject recycled_bulletLayer = null;
        public Image[] mCannonSprites = new Image[FishConfig.fish_player_count];
        public Image[] mLockedFishImages = new Image[FishConfig.fish_player_count];
        public DOTweenAnimation[] mLockedAnimations = new DOTweenAnimation[FishConfig.fish_player_count];
        public ComFishLockLine mFishLockLine;
        public ComUINumber[] mLockedNumber = new ComUINumber[FishConfig.fish_player_count];
        public Ease fire_forwardEase = Ease.Linear;
        public Ease fire_backforwardEase = Ease.Linear;
        public float fire_interval = 0.18f;
        public float fire_distance = 15.0f;

        Vector2[] mCannonPosition = new Vector2[FishConfig.fish_player_count];

        public class FishBody
        {
            public int locked_flag;
            public ulong guid;
            public int resId;

            public int status;
            public int tag;
            public float elapsed;
            public ulong tick_count;

            public FishSprite fishSprite;
            public ProtoTable.FishTable fishItem;
            public FishActionFishMove moveAction;

            public bool isVisible()
            {
                return null != fishSprite && null != fishSprite.self && fishSprite.self.activeSelf;
            }

            public bool inScreen()
            {
                if(null != fishSprite && null != fishSprite.self)
                {
                    RectTransform rect = fishSprite.self.transform as RectTransform;
                    if(null != rect)
                    {
                        if(rect.anchoredPosition.x <= -rect.sizeDelta.x || rect.anchoredPosition.x > FishConfig.kScreenWidth)
                        {
                            return false;
                        }

                        if(rect.anchoredPosition.y <= -rect.sizeDelta.y || rect.anchoredPosition.y > FishConfig.kScreenHeight)
                        {
                            return false;
                        }
                        return true;
                    }
                }
                return false;
            }

            public void OnCreate(GameObject root)
            {
                Utility.AttachTo(fishSprite.self, root);
                fishSprite.self.CustomActive(true);
            }

            public void OnRecycle(GameObject root)
            {
                Utility.AttachTo(fishSprite.self, root);
                fishSprite.self.CustomActive(false);
            }

            public void SetPosition(Vector2 pos)
            {
                if(null != fishSprite.self && null != fishSprite.self.transform)
                {
                    (fishSprite.self.transform as RectTransform).anchoredPosition = pos;
                }
            }

            public void SetAngle(float angle)
            {
                if (null != fishSprite.self && null != fishSprite.self.transform)
                {
                    (fishSprite.self.transform as RectTransform).localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg);
                }
            }

            public void Update()
            {
                if(null != moveAction)
                {
                    moveAction.Step(Time.deltaTime);
                }
            }

            public void MoveTo()
            {
                if (null != moveAction)
                {
                    moveAction.FishMoveTo(elapsed);
                }
            }
        }
        List<FishBody> _recycles = new List<FishBody>(16);
        List<FishBody> _actived = new List<FishBody>(16);

        public void createFish(FishData data)
        {
            int findIndex = -1;
            for (int i = 0; i < _recycles.Count; ++i)
            {
                if (_recycles[i].resId == data.fishItem.ID)
                {
                    findIndex = i;
                    break;
                }
            }

            FishBody fishBody = null;
            if (-1 == findIndex)
            {
                var fishSprite = FishScene.createFishFromPool(data.fishItem.ID);
                if (null == fishSprite)
                {
                    return;
                }

                fishBody = new FishBody();
                fishBody.fishSprite = fishSprite;
                Image img = fishSprite.action.sprite;
                img.raycastTarget = false;
                fishBody.OnCreate(fishLayer);
            }
            else
            {
                fishBody = _recycles[findIndex];
                _recycles.RemoveAt(findIndex);
                fishBody.guid = (ulong)data.fish_id;
                fishBody.OnCreate(fishLayer);
            }

            if (null != fishBody)
            {
                fishBody.locked_flag = 0;
                fishBody.guid = (ulong)data.fish_id;
                fishBody.fishItem = data.fishItem;
                fishBody.resId = data.fishItem.ID;
                fishBody.fishSprite.action.Play();
                fishBody.fishSprite.action.loops = -1;
                fishBody.tag = data.tag;
                fishBody.tick_count = data.tick_count;
                fishBody.elapsed = data.elapsed;
                fishBody.moveAction = data.action;
                fishBody.moveAction.Start();
                _actived.Add(fishBody);
            }
        }

        void Awake()
        {
            EventManager.Instance().RegisterEvent(ClientEvent.CE_CREATE_FISH, _OnCreateFish);

            for(int i = 0; i < mCannonPosition.Length; ++i)
            {
                mCannonPosition[i] = (mCannonSprites[i].transform as RectTransform).anchoredPosition;
            }
        }

        private void OnDestroy()
        {
            EventManager.Instance().UnRegisterEvent(ClientEvent.CE_CREATE_FISH, _OnCreateFish);
            _recycles.Clear();
            _actived.Clear();
        }

        protected void _OnCreateFish(object argv)
        {
            FishData data = argv as FishData;
            if(null != data)
            {
                createFish(data);

                FishDataManager.Instance().Release(data);
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        public void RecycleAllFish()
        {
            for(int i = 0; i < _actived.Count; ++i)
            {
                if(null != _actived[i])
                {
                    _actived[i].OnRecycle(recycleRoot);
                    FishAction.ThrowActionToPoll(_actived[i].moveAction);
                    _actived[i].moveAction = null;
                    _recycles.Add(_actived[i]);
                    _actived.RemoveAt(i--);
                }
            }
        }

        public bool LockFishInfo(int lock_fish_id,ref FishKind lock_fish_kind,ref FishActionInterval action_fish)
        {
            for(int i = 0; i < _actived.Count; ++i)
            {
                var fishData = _actived[i];
                if(null != fishData || null == fishData.fishItem)
                {
                    if((int)fishData.guid == lock_fish_id)
                    {
                        if(!fishData.isVisible())
                        {
                            return false;
                        }
                        if(1 == fishData.status)
                        {
                            return false;
                        }
                        if(2 == fishData.status)
                        {
                            return false;
                        }
                        if(!fishData.inScreen())
                        {
                            return false;
                        }

                        if(null == fishData.fishItem)
                        {
                            return false;
                        }

                        lock_fish_kind = (FishKind)(fishData.fishItem.ID - 1);
                        action_fish = fishData.moveAction;
                        return true;
                    }
                }
            }
            return false;
        }
        public void LockFishImg(int charid, int fishid, int fishkind)
        {
            if (fishid == -1)
            {
                mLockedFishImages[charid].CustomActive(false);
            }
            else
            {
                mLockedFishImages[charid].CustomActive(true);
                if(null != mLockedFishImages[charid])
                {
                    var fishItem = TableManager.Instance().GetTableItem<ProtoTable.FishTable>((int)fishkind + 1);
                    if(null != fishItem)
                    {
                        mLockedFishImages[charid].sprite = AssetLoader.Instance().LoadRes(fishItem.TraceFrame, typeof(Sprite)).obj as Sprite;
                    }
                    else
                    {
                        mLockedFishImages[charid].sprite = null;
                    }
                }
                if(null != mLockedAnimations[charid])
                {
                    mLockedAnimations[charid].DORestartById("action_1");
                }
            }
        }

        public FishBody GetLockedFish(int fishId)
        {
            for(int i = 0; i < _actived.Count; ++i)
            {
                if((int)_actived[i].guid == fishId)
                {
                    return _actived[i];
                }
            }
            return null;
        }

        public void SetLockFish(int ChairID, int Fishid, FishKind fishkind, FishActionInterval action)
        {
            if (action == null)
            {
                Fishid = -1;
            }

            if (Fishid == FishDataManager.Instance().GetLockedFishId(ChairID))
            {
                return;
            }

            int curLockedFishId = FishDataManager.Instance().GetLockedFishId(ChairID);
            var preLockedFish = GetLockedFish(curLockedFishId);
            if (null != mFishLockLine)
            {
                if(null != preLockedFish)
                {
                    preLockedFish.locked_flag &= ~(1 << ChairID);
                    mLockedNumber[ChairID].CustomActive(false);
                    Utility.AttachTo(mLockedNumber[ChairID].gameObject, fishLockNumberRoot);
                    mFishLockLine.RemoveTarget(preLockedFish.fishSprite.self.transform as RectTransform,ChairID);
                }
            }

            var curTarget = GetLockedFish(Fishid);
            if(null != curTarget)
            {
                curTarget.locked_flag |= (1 << ChairID);
                FishDataManager.Instance().SetLockedFishId(ChairID, Fishid);
                //播放锁定动画
                LockFishImg(ChairID, Fishid, (int)fishkind);

                Utility.AttachTo(mLockedNumber[ChairID].gameObject, curTarget.fishSprite.self);
                mLockedNumber[ChairID].Value = ChairID + 1;
                (mLockedNumber[ChairID].transform as RectTransform).anchoredPosition = Vector2.zero;
                mLockedNumber[ChairID].transform.SetAsLastSibling();
                mLockedNumber[ChairID].CustomActive(true);

                if (null != mFishLockLine)
                {
                    if (null != curTarget)
                    {
                        mFishLockLine.AddTrace(curTarget.fishSprite.self.transform as RectTransform, new Vector2(FishConfig.USERPOINT[ChairID][0], FishConfig.USERPOINT[ChairID][1]), ChairID);
                    }
                }
            }
            else
            {
                LockFishImg(ChairID, -1, (int)FishKind.FISH_KIND_COUNT);
                Utility.AttachTo(mLockedNumber[ChairID].gameObject, fishLockNumberRoot);
                mLockedNumber[ChairID].CustomActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            for(int i = 0; i < _actived.Count; ++i)
            {
                if(null != _actived[i])
                {
                    var action = _actived[i].moveAction;
                    if(null != action)
                    {
                        action.Step(Time.deltaTime);
                        //Vector2 position = action.FishMoveTo(action.elapsed());
                        _actived[i].SetPosition(action.position());
                        _actived[i].SetAngle(action.angle());
                    }

                    if(action.IsDone())
                    {
                        _RemoveLockedFishFlags(_actived[i]);
                        _actived[i].OnRecycle(recycleRoot);
                        FishAction.ThrowActionToPoll(_actived[i].moveAction);
                        _actived[i].moveAction = null;
                        _recycles.Add(_actived[i]);
                        _actived.RemoveAt(i--);
                        continue;
                    }
                }
            }
        }

        void _RemoveLockedFishFlags(FishBody fish)
        {
            if(null != fish && fish.locked_flag != 0)
            {
                if (null != mFishLockLine)
                {
                    for(int i = 0; i < FishConfig.fish_player_count; ++i)
                    {
                        if((1 << i) == (fish.locked_flag & (1 << i)))
                        {
                            SetLockFish(i, -1,FishKind.FISH_KIND_COUNT, null);
                        }
                    }
                }
            }
        }

        void _OnMoveForward(int nChairID, float angle)
        {
            Vector2 localPosition = mCannonPosition[nChairID];
            Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
            dir = dir.normalized;
            Vector2 p1 = localPosition + dir * fire_distance;
            mCannonSprites[nChairID].transform.DOLocalMove(p1, fire_interval).SetEase(fire_forwardEase).OnComplete(() => { _OnMoveBackward(nChairID, angle); });
        }

        void _OnMoveBackward(int nChairID, float angle)
        {
            Vector2 localPosition = mCannonPosition[nChairID];
            Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
            dir = dir.normalized;
            Vector2 p1 = localPosition - dir * fire_distance;
            mCannonSprites[nChairID].transform.DOLocalMove(p1, fire_interval).SetEase(fire_backforwardEase).OnComplete(() => { _OnMoveForward(nChairID, angle); });
        }

        public void Shoot(int nChairID, float nRotation, long nBulletID, bool IsAndroid, long userAndroidCharId,float bullet_speed, int lock_fish_id, FishActionInterval action_fish_move)
        {
            mCannonSprites[nChairID].transform.localScale = Vector3.one;
            float ro = (float)(nRotation * Mathf.Rad2Deg);
            mCannonSprites[nChairID].transform.eulerAngles = new Vector3(0.0f, 0.0f, nRotation + 270.0f);

            _OnMoveBackward(nChairID, ro);

            if (nChairID == FishDataManager.Instance().chairId && !IsAndroid)
            {
                AddBullet(nChairID, nRotation, nBulletID, IsAndroid, false, FishDataManager.Instance().GetBulletType(nChairID), FishDataManager.Instance().GetBulletPower(nChairID), bullet_speed, lock_fish_id, action_fish_move);
            }
            else
            {
                if (IsAndroid && (userAndroidCharId == FishDataManager.Instance().chairId))
                {
                    int fire = UnityEngine.Random.Range(0, 2);
                    if (fire == 1)
                    {
                        AddBullet(nChairID, nRotation, nBulletID, IsAndroid, false, FishDataManager.Instance().GetBulletType(nChairID), FishDataManager.Instance().GetBulletPower(nChairID), bullet_speed, lock_fish_id, action_fish_move);
                    }
                }
                else
                {
                    AddBullet(nChairID, nRotation, nBulletID, IsAndroid, true, FishDataManager.Instance().GetBulletType(nChairID), FishDataManager.Instance().GetBulletPower(nChairID), bullet_speed, lock_fish_id, action_fish_move);
                }
            }
        }

        float BulletMoveDuration(Vector2 start, Vector2 end, float bullet_speed)
        {
            Vector2 delta = new Vector2(end.x - start.x, start.x - start.y);
            float length = Mathf.Sqrt(delta.x * delta.x + delta.y * delta.y);
            return length / bullet_speed;
        }

        public void AddBullet(int nChairID, float fRotation, long nBulletID, bool IsAndroid, bool bBadBullet,int m_ButtleType, int bullet_mulriple, float bullet_speed, int lock_fish_id = -1, FishActionInterval action_fish_move = null)
        {
            BulletData data = BulletData.Create();
            data.m_SendChairID = nChairID;

            if (lock_fish_id != -1 && action_fish_move != null)
            {
                Vector2 fish_pos = action_fish_move.position();
                float elapsed = BulletMoveDuration(new Vector2(FishConfig.USERPOINT[nChairID][0], FishConfig.USERPOINT[nChairID][1]), fish_pos, bullet_speed);
                Vector2 fish_target_pos1 = (action_fish_move as FishActionFishMove).FishMoveTo(elapsed);
                Vector2 fish_target_pos = new Vector2(fish_target_pos1.x, fish_target_pos1.y);
                if (fish_target_pos.x >= 0 && fish_target_pos.x <= FishConfig.kScreenWidth && fish_target_pos.y >= 0 && fish_target_pos.y <= FishConfig.kScreenHeight)
                {
                    FishActionFunc func = FishAction.CreateActionFromPool<FishActionFunc>();
                    func.Create(data.CancelLock);
                    func.set_position(fish_target_pos);
                    func.set_angle(fRotation);

                    var action1 = FishAction.CreateActionFromPool<FishActionBulletMoveTo>();
                    action1.Create(new Vector2(FishConfig.USERPOINT[nChairID][0], FishConfig.kScreenHeight - FishConfig.USERPOINT[nChairID][1]), fish_target_pos, fRotation, bullet_speed);

                    var action = FishAction.CreateActionFromPool<FishActionSequence>();
                    action.Create(action1, func, 0);
                    data.ResetBulletActionMove(action);
                }
                else
                {
                    if (fish_pos.x >= 0 && fish_pos.x <= FishConfig.kScreenWidth && FishConfig.kScreenHeight - fish_pos.y >= 0 && FishConfig.kScreenHeight - fish_pos.y <= FishConfig.kScreenHeight)
                    {
                        FishActionFunc func = FishAction.CreateActionFromPool<FishActionFunc>();
                        func.Create(data.CancelLock);
                        func.set_position(fish_pos);
                        func.set_angle(fRotation);

                        var action1 = FishAction.CreateActionFromPool<FishActionBulletMoveTo>();
                        action1.Create(new Vector2(FishConfig.USERPOINT[nChairID][0], FishConfig.kScreenHeight - FishConfig.USERPOINT[nChairID][1]), fish_pos, fRotation, bullet_speed);
                        
                        var action = FishAction.CreateActionFromPool<FishActionSequence>();
                        action.Create(action1, func, 0);

                        data.ResetBulletActionMove(action);
                    }
                    else
                    {
                        lock_fish_id = -1;
                        var action = FishAction.CreateActionFromPool<FishActionBulletMove>();
                        action.Create(new Vector2(FishConfig.USERPOINT[nChairID][0], FishConfig.kScreenHeight - FishConfig.USERPOINT[nChairID][1]), fRotation, bullet_speed);
                        data.ResetBulletActionMove(action);
                    }
                }
            }
            else
            {
                var action = FishAction.CreateActionFromPool<FishActionBulletMove>();
                action.Create(new Vector2(FishConfig.USERPOINT[nChairID][0], FishConfig.kScreenHeight - FishConfig.USERPOINT[nChairID][1]), fRotation, bullet_speed);
                data.ResetBulletActionMove(action);
            }

            //CCdsnhFishBaseLayer* fishbaselayer = (CCdsnhFishBaseLayer*)this->getParent();
            data.bounding_radius_ = 5.0f;
            //m_Bullet->bounding_radius_ = CCGameMyData::GetManager()->GetFishGameConfig().bullet_bounding_radius[m_ButtleType - 2];
            data.bullet_mulriple = bullet_mulriple;
            data.bullet_speed_ = bullet_speed;
            data.m_lockfish = lock_fish_id;
            /*
            char str[100] = { 0 };
            if (m_ButtleType > 4)
                sprintf(str, "Supperbullet%d_%d.png", m_ButtleType, 1);
            else sprintf(str, "bullet%d_%d_%d.png", nChairID, m_ButtleType, 1);

            m_Bullet->m_Buttleimg0 = Sprite::createWithSpriteFrame(cache->getSpriteFrameByName(str));
            this->addChild(m_Bullet->m_Buttleimg0);
            */

            data.m_sendtime = 0;
            data.m_HitFishID = 0;
            data.m_SendChairID = nChairID;
            data.m_ButtleID = nBulletID;
            data.m_IsAndroid = IsAndroid;
            data.m_Status = 0;
            data.m_ButtleType = m_ButtleType;
            data.m_IsSupperButtle = m_ButtleType > 4;
            if (bBadBullet)
            {
                data.m_bIsBadButtle = true;
            }

            ComBullet comBullet = ComBullet.Create(1, bulletLayer);
            comBullet.SetData(data);

            if(data.m_IsSupperButtle)
            {
                AudioManager.Instance().PlaySound(2105);
            }
            else
            {
                AudioManager.Instance().PlaySound(2106);
            }
        }
    }
}