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
        public GameObject coin_prefab = null;
        public GameObject coin_active_layer = null;
        public GameObject coin_recycle_layer = null;

        class CoinItem
        {
            public ComSpriteItems coinSprite;
        }
        List<CoinItem> actived_coins = new List<CoinItem>();
        List<CoinItem> recycle_coins = new List<CoinItem>();
        CoinItem CreateCoin()
        {
            if(recycle_coins.Count > 0)
            {
                CoinItem coinItem = recycle_coins[0];
                Utility.AttachTo(coinItem.coinSprite.gameObject, coin_active_layer);
                recycle_coins.RemoveAt(0);
                actived_coins.Add(coinItem);
                return coinItem;
            }
            else
            {
                GameObject coin = AssetLoader.Instance().LoadRes("UI/Prefabs/Bullets/Coin_001").obj as GameObject;
                if(null == coin)
                {
                    return null;
                }
                ComSpriteItems coinSprite = coin.GetComponent<ComSpriteItems>();
                if(null == coinSprite)
                {
                    return null;
                }
                CoinItem coinItem = new CoinItem { coinSprite = coinSprite };
                Utility.AttachTo(coinItem.coinSprite.gameObject, coin_active_layer);
                actived_coins.Add(coinItem);
                return coinItem;
            }
        }

        void Recycle(CoinItem coin)
        {
            if(null != coin && actived_coins.Contains(coin))
            {
                actived_coins.Remove(coin);
                recycle_coins.Add(coin);
                Utility.AttachTo(coin.coinSprite.gameObject, coin_recycle_layer);
            }
        }

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
                if(null != fishSprite && null != fishSprite.self && null != fishSprite.self.transform)
                {
                    (fishSprite.self.transform as RectTransform).anchoredPosition = pos;
                }
            }

            public Vector2 GetPosition()
            {
                if (null != fishSprite && null != fishSprite.self && null != fishSprite.self.transform)
                {
                    return (fishSprite.self.transform as RectTransform).anchoredPosition;
                }
                return Vector2.zero;
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

            //InvokeManager.Instance().InvokeRepeate(this, 0.0f, 9999, 0.35f, _AddBulletTest, _AddBulletTest, null,false);
        }

        void _AddBulletTest()
        {
            AddBullet(0, 45, 10055, false, false, 1, 1, 2000, -1, null);
        }

        private void OnDestroy()
        {
            InvokeManager.Instance().RemoveInvoke(this);
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

        public void SetDeadFish(int fishID, int KillChairid, int Winscore, int fishKindScore)
        {
            for (int i = 0; i < _actived.Count; ++i)
            {
                var fishData = _actived[i];
                if(null != fishData && (int)fishData.guid == fishID && fishData.status != 1)
                {
                    fishData.status = 1;
                    int FishScore = Winscore;
                    int CoinNum = fishKindScore;
                    Vector2 position = fishData.GetPosition();

                    AddDeadFishScroe(position.x, position.y, FishScore, CoinNum, KillChairid);
                    //TODO:
                    //要有个鱼爆炸的特效
                    //AddParticle(m_FishData->m_FishImg->getPositionX(), m_FishData->m_FishImg->getPositionY(), m_FishData->m_FishType);
                    break;
                }
            }
        }

        public void AddDeadFishScroe(float Xpos, float Ypos, int fishScore, int fishKindScore, int ChairID)
        {
            //CCdsnhFishNumberLayer* m_UpScore = new CCdsnhFishNumberLayer();
            //m_UpScore->setPosition(Vec2(Xpos, Ypos));
            //if (ChairID >= 3)
                //m_UpScore->setRotation(180);
            //m_UpScore->Render(fishScore, "FishGame/Fish/Union/Num/SceneScoreNum.png", 1);
            //m_UpScore->setTag(ChairID);
            //m_UpScore->setLocalZOrder(fishKindScore);
            //this->addChild(m_UpScore);
            //1 加载金币翻动的图片
            //2 设置起始位置在鱼死亡的位置
            //3 若座位号4 5 6则设置旋转角度为180
            //4 向上移动
            //ActionInterval* moveToActionUp = MoveTo::create(0.13f, Vec2(m_UpScore->getPositionX(), m_UpScore->getPositionY() + 30));
            //5 向下移动
            //ActionInterval* moveToActionDown = MoveTo::create(0.13f, Vec2(m_UpScore->getPositionX(), m_UpScore->getPositionY() - 30));
            //6 设置透明度 1.5
            //ActionInterval* FadeOut = FadeOut::create(1.5f);
            //7 回收硬币精灵
            //FiniteTimeAction* AlphaScroeLayerChild = CallFuncN::create(CC_CALLBACK_1(CCdsnhFishButtleLayer::AlphaScroeLayerChild, this));
            //FiniteTimeAction* RemoveScroeLayerChild = CallFuncN::create(CC_CALLBACK_1(CCdsnhFishButtleLayer::RemoveScroeLayerChild, this));
            //m_UpScore->runAction(Sequence::create(moveToActionUp, moveToActionDown, DelayTime::create(0.4f), AlphaScroeLayerChild, DelayTime::create(0.25f), RemoveScroeLayerChild, NULL));
            //8 播放金币获得音效
            //PlayEffect("FishGame/Fish/Sound/Effect/GetMoney.ogg", 3);
        }

        public void AddWinCoin(int CoinNum, int m_FishScore_, int chairID)
        {
            //1 加载金币翻滚动画
            float Xops = 250.0f;
            AddCoin(CoinNum, m_FishScore_, chairID);
            //tempCoinLayer->AddCoin(CoinNum, m_FishScore_, chairID);
            //float Xdes = 31 * 0.9f;
            //if (chairID >= 3) Xdes = -31 * 0.9f;
            //ActionInterval* moveToActionOver = MoveTo::create(0.3f, Vec2(tempCoinLayer->getPositionX() + Xdes, tempCoinLayer->getPositionY()));
            //FiniteTimeAction* MoveChild = CallFuncN::create(CC_CALLBACK_1(CCFishCommonLayer::MoveChild, this));
            //FiniteTimeAction* RemoveMoveChild = CallFuncN::create(CC_CALLBACK_1(CCFishCommonLayer::RemoveMoveChild, this));
            //if (canMove)
            //{
            //for (int i = 0; i < 4; i++)
            //{
            //m_CoinLayer[chairID][i]->stopAllActions();
            //}
            //tempCoinLayer->runAction(Sequence::create(DelayTime::create(2.0), MoveChild, RemoveMoveChild, NULL));
            //}
        }

        public void AddCoin(int CoinNum, int m_FishScore_, int chairID)
        {
            int NumDesc = 5;
            List<CoinItem> cachedCoins = GamePool.ListPool<CoinItem>.Get();
            for (int i = 0; i < CoinNum + 1; i++)
            {
                CoinItem coinItem = CreateCoin();
                RectTransform rectTransform = (coinItem.coinSprite.transform as RectTransform);
                cachedCoins.Add(coinItem);

                if (i == CoinNum)
                {
                    rectTransform.localScale = new Vector2(0.75f, 0.75f);
                    rectTransform.anchoredPosition = new Vector2(0, 20);
                    coinItem.coinSprite.Play();
                    rectTransform.DOLocalMove(new Vector2(0, 20 + i * NumDesc), 0.02f * i).OnComplete(() =>
                     {
                         for(int j = 0; j < cachedCoins.Count; ++j)
                         {
                             Recycle(cachedCoins[j]);
                         }
                         GamePool.ListPool<CoinItem>.Release(cachedCoins);
                     });
                }
                else
                {
                    coinItem.coinSprite.Reset();
                    rectTransform.anchoredPosition = Vector2.zero;
                    rectTransform.localScale = new Vector2(0.9f, 0.9f);
                    rectTransform.DOLocalMove(new Vector2(0, i * NumDesc), 0.02f * i);
                }
            }
        }

        void ReomveScreenCoin()
        {
            //1 张数字背景
            //char str[100] = { 0 };
            //sprintf(str, "numberbg%d.png", (((this->getTag() - 800) % 10) % 3) + 1);
            //SpriteFrameCache* cache = SpriteFrameCache::getInstance();
            //Sprite* m_NumBgimg = Sprite::createWithSpriteFrame(cache->getSpriteFrameByName(str));
            //sprintf(str, "%d", m_FishScore);
            //2 创建数字文字集 UINumber组件
            //LabelAtlas* m_AddScore = LabelAtlas::create(str, "FishGame/Fish/Union/Num/BulletNum.png", 12, 16, '0');
            //m_AddScore->setAnchorPoint(Vec2(0.5, 1.0));
            int NumDesc = 13;
            //m_AddScore->setPosition(0, pSender->getPositionY() - 4);
            //m_NumBgimg->setPosition(Vec2(pSender->getPositionX(), pSender->getPositionY() - NumDesc));
            //float xBili = m_NumBgimg->getContentSize().width;
            //m_NumBgimg->setScaleY(1.4f);
            //this->addChild(m_NumBgimg);
            //float NumWidth = m_AddScore->getContentSize().width;
            //m_NumBgimg->setScaleX(NumWidth / (xBili - 1));
            //this->addChild(m_AddScore);
            //this->removeChild(pSender, true);
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

            for (int i = 0; i < ComBullet.mActivedBullets.Count; ++i)
            {
                var bullet = ComBullet.mActivedBullets[i];
                if (null == bullet)
                {
                    continue;
                }

                var bulletData = bullet.Value;
                if (null == bulletData)
                {
                    continue;
                }

                if (null != bulletData.action_bullet_move_)
                {
                    bulletData.action_bullet_move_.Step(Time.deltaTime);
                    bullet.SetAngle(bulletData.action_bullet_move_.angle());
                    bullet.SetPosition(bulletData.action_bullet_move_.position());
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
            if(null != comBullet)
            {
                comBullet.SetData(data);
            }

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