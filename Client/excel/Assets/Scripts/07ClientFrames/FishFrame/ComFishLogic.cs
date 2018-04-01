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

            public ProtoTable.FishTable fishItem;
            public GameObject self;
            public ComSpriteList action;

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
        }
        List<FishBody> _recycles = new List<FishBody>(16);
        List<FishBody> _actived = new List<FishBody>(16);

        public void createFish(ulong guid,int iResId)
        {
            var fishItem = TableManager.Instance().GetTableItem<ProtoTable.FishTable>(iResId);
            if (null == fishItem)
            {
                LogManager.Instance().LogErrorFormat("can not create fish with resId = {0}", iResId);
                return;
            }

            if (fishItem.FrameCount <= 0)
            {
                LogManager.Instance().LogErrorFormat("can not create fish with resId = {0} frameCount = {1} is less than 1 ", iResId, fishItem.FrameCount);
                return;
            }

            string res = string.Format(fishItem.Prefab, 1);
            Sprite sprite = AssetLoader.Instance().LoadRes(res, typeof(Sprite)).obj as Sprite;
            if (null == sprite)
            {
                LogManager.Instance().LogErrorFormat("can not create fish first frame res is null ! resId = {0} name = {1}", iResId, fishItem.Desc);
                return;
            }

            int findIndex = -1;
            for (int i = 0; i < _recycles.Count; ++i)
            {
                if (_recycles[i].resId == iResId)
                {
                    findIndex = i;
                    break;
                }
            }

            FishBody fishBody = null;
            if (-1 == findIndex)
            {
                fishBody = new FishBody();
                fishBody.self = new GameObject(fishItem.Desc);
                Image img = fishBody.self.AddComponent<Image>();
                img.raycastTarget = false;
                fishBody.action = fishBody.self.AddComponent<ComSpriteList>();
                fishBody.action.sprite = img;
                fishBody.action.LoadRes(fishItem.Prefab, fishItem.FrameCount);
                fishBody.action.interval = fishItem.Interval;
                fishBody.guid = guid;
                fishBody.OnCreate(fishLayer);
            }
            else
            {
                fishBody = _recycles[findIndex];
                _recycles.RemoveAt(findIndex);
                fishBody.guid = guid;
                fishBody.OnCreate(fishLayer);
            }
            _actived.Add(fishBody);

            if (null != fishBody)
            {
                fishBody.SetPosition(new Vector2(UnityEngine.Random.Range(-20, 20), UnityEngine.Random.Range(-20, 20)));
                fishBody.action.Play();
                fishBody.action.loops = -1;
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}