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

            public ProtoTable.FishTable fishItem;
            public GameObject self;
            public ComSpriteItems action;
            public FishActionFishMove moveAction;

            public void OnCreate(GameObject root)
            {
                Utility.AttachTo(self, root);
                self.CustomActive(true);
            }

            public void OnRecycle(GameObject root)
            {
                Utility.AttachTo(self, root);
                self.CustomActive(false);
            }

            public void SetPosition(Vector2 pos)
            {
                if(null != self && null != self.transform)
                {
                    (self.transform as RectTransform).anchoredPosition = pos;
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
            var fishItem = TableManager.Instance().GetTableItem<ProtoTable.FishTable>(data.fishItem.ID);
            if (null == fishItem)
            {
                LogManager.Instance().LogErrorFormat("can not create fish with resId = {0}", data.fishItem.ID);
                return;
            }

            GameObject goFish = AssetLoader.Instance().LoadRes(fishItem.Prefab, typeof(GameObject)).obj as GameObject;
            if (null == goFish)
            {
                LogManager.Instance().LogErrorFormat("can not create fish first frame res is null ! resId = {0} name = {1}", data.fishItem.ID, fishItem.Desc);
                return;
            }
            ComSpriteItems sprite = goFish.GetComponent<ComSpriteItems>();
            if (null == sprite)
            {
                LogManager.Instance().LogErrorFormat("can not create fish first frame ComSpriteItems is null ! resId = {0} name = {1}", data.fishItem.ID, fishItem.Desc);
                return;
            }

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
                fishBody = new FishBody();
                fishBody.self = goFish;
                Image img = sprite.sprite;
                img.raycastTarget = false;
                fishBody.action = sprite;
                fishBody.action.sprite = img;
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
                fishBody.action.Play();
                fishBody.action.loops = -1;
                fishBody.tag = data.tag;
                fishBody.tick_count = data.tick_count;
                fishBody.elapsed = data.elapsed;
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
                        Vector2 position = action.FishMoveTo(action.elapsed());
                        _actived[i].SetPosition(position);
                    }
                }
            }
        }
    }
}