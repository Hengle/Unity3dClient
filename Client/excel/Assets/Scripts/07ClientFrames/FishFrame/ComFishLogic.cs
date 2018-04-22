using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
    public class ComFishLogic : MonoBehaviour
    {
        public GameObject recycleRoot = null;
        public GameObject fishLayer = null;

        class FishBody
        {
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
                fishBody.guid = (ulong)data.fish_id;
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
                        if(fishData.isVisible())
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

                        lock_fish_kind = (FishKind)(fishData.fishItem.ID - 1);
                        action_fish = fishData.moveAction;
                        return true;
                    }
                }
            }
            return false;
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

            /*
            this->removeChildByTag(9000 + ChairID);
            for (int j = 0; j < 20; ++j)
            {
                m_FishLockLinespr[ChairID][j]->setPosition(Vec2(USERPOINT[ChairID][0], USERPOINT[ChairID][1]));
                m_FishLockLinespr[ChairID][j]->setVisible(false);
            }
            */

            FishDataManager.Instance().SetLockedFishId(ChairID, Fishid);

            //CCFishCommonLayer* fishcommonlayer = (CCFishCommonLayer*)this->getParent()->getChildByTag(998);

            //fishcommonlayer->LockFishImg(ChairID, Fishid, fishkind);
            //if (Fishid == -1)
            //{
            //    action_lock_fish_[ChairID] = 0;
            //    action_lock_line_[ChairID] = 0;
            //    this->removeChildByTag(9000 + ChairID, true);
            //    return;
            //}
            //action_lock_fish_[ChairID] = action;
            //if (action_lock_fish_[ChairID] != 0)
            //{
            //    hgeVector fish_pos = action_lock_fish_[ChairID]->position();
            //    hgeVector fish_target_pos = static_cast<FishActionFishMove*>(action_lock_fish_[ChairID])->FishMoveTo(0.5f);
            //    action_lock_line_[ChairID] = new FishActionMoveTo(0.5f, hgeVector(USERPOINT[ChairID][0], USERPOINT[ChairID][1]), fish_target_pos);

            //}

            //m_UserLockFishKind[ChairID] = fishkind;
            /////////////////////////////
            //char string[128] = { 0 };
            //sprintf(string, "lock%d.png", ChairID + 1);
            //SpriteFrameCache* cache = SpriteFrameCache::getInstance();
            //Sprite* m_SuoSprite = Sprite::createWithSpriteFrame(cache->getSpriteFrameByName(string));
            //m_SuoSprite->setPosition(Vec2(100, 100));
            //m_SuoSprite->setTag(9000 + ChairID);
            //this->addChild(m_SuoSprite, 10000);
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
    }
}