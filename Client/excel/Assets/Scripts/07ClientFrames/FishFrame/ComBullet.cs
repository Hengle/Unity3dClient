using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
    public class ComBullet : MonoBehaviour
    {
        public Image _bulletImg;
        public int kind_id;
        public ProtoTable.BulletTable bulletItem;
        BulletData _data = null;
        public BulletData Value
        {
            get
            {
                return _data;
            }
        }

        public static List<ComBullet> mActivedBullets = new List<ComBullet>(160);
        public static List<ComBullet> mRecycledBullets = new List<ComBullet>(160);

        static ComBullet CreateFromPool(int kind_id,GameObject goAlive)
        {
            if(mRecycledBullets.Count > 0)
            {
                ComBullet comBullet = mRecycledBullets[0];
                mRecycledBullets.RemoveAt(0);
                return comBullet;
            }
            return null;
        }

        public static void ThrowToPool(ComBullet comBullet)
        {
            if(null != comBullet)
            {
                comBullet.CustomActive(false);
                mActivedBullets.Remove(comBullet);
                mRecycledBullets.Add(comBullet);
            }
        }

        public static ComBullet Create(int kind_id,GameObject goAlive)
        {
            ProtoTable.BulletTable bulletItem = TableManager.Instance().GetTableItem<ProtoTable.BulletTable>(kind_id);
            if(null == bulletItem)
            {
                return null;
            }

            ComBullet comBullet = CreateFromPool(kind_id, goAlive);
            if(null == comBullet)
            {
                GameObject goBullet = AssetLoader.Instance().LoadRes(bulletItem.Prefab, typeof(GameObject)).obj as GameObject;
                if (null == goBullet)
                {
                    return null;
                }

                Utility.AttachTo(goBullet, goAlive);

                comBullet = goBullet.GetComponent<ComBullet>();
            }

            if (null == comBullet)
            {
                return null;
            }

            comBullet.kind_id = kind_id;
            comBullet.bulletItem = bulletItem;

            mActivedBullets.Add(comBullet);
            comBullet.CustomActive(true);

            return comBullet;
        }

        public void SetData(BulletData data)
        {
            _data = data;
            if(null != bulletItem)
            {
                _data.bullet_speed_ = bulletItem.Speed * 0.001f;
            }
            if(null != _data)
            {
                (transform as RectTransform).anchoredPosition = new Vector2(FishConfig.USERPOINT[_data.m_SendChairID][0], FishConfig.USERPOINT[_data.m_SendChairID][1]);
            }
            if(null != _data.action_bullet_move_)
            {
                _data.action_bullet_move_.Start();
            }
        }

        public void SetAngle(float angle)
        {
            var rect = (transform as RectTransform);
            if (null != rect)
            {
                rect.localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg);
            }
        }

        public void SetPosition(Vector2 pos)
        {
            var rect = (transform as RectTransform);
            if (null != rect)
            {
                rect.anchoredPosition = pos;
            }
        }
    }
}
