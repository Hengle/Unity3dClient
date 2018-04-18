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

            public int tag;
            public float elapsed;
            public ulong tick_count;

            public FishSprite fishSprite;
            public ProtoTable.FishTable fishItem;
            public FishActionFishMove moveAction;

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