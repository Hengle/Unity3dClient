using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    public class ClientFrame : IFrame
    {
        public int getFrameId()
        {
            return frameId;
        }

        public FrameTypeID getFrameTypeId()
        {
            return frameTypeId;
        }

        public int getFrameHashCode()
        {
            return iHashCode;
        }

        public FrameLayer getLayer()
        {
            if(null == frameItem)
            {
                return FrameLayer.COUNT;
            }

            if(frameItem.Layer < (int)FrameLayer.BOTTOM || frameItem.Layer >= (int)FrameLayer.COUNT)
            {
                return FrameLayer.COUNT;
            }

            return (FrameLayer)frameItem.Layer;
        }

        public void openFrame(int iId, FrameTypeID type, object userData)
        {
            LogManager.Instance().LogProcessFormat(9000, "try open frame {0}!", type);

            this.frameId = iId;
            this.frameTypeId = type;
            this.iHashCode = UIManager.Instance().MakeFrameHashCode(iId, type);
            this.userData = userData;

            frameItem = TableManager.Instance().GetTableItem<ProtoTable.FrameTypeTable>((int)type);
            if(null == frameItem)
            {
                LogManager.Instance().LogProcessFormat(9100, "can not find frametype with type id = {0}", type);
                return;
            }

            if (frameItem.Layer < (int)FrameLayer.BOTTOM || frameItem.Layer >= (int)FrameLayer.COUNT)
            {
                LogManager.Instance().LogProcessFormat(9101, "layer = {0} is invlalid with type id = {1}", frameItem.Layer, type);
                return;
            }

            root = AssetManager.Instance().LoadResource<GameObject>(frameItem.Prefab);
            if(null == root)
            {
                LogManager.Instance().LogProcessFormat(9102, "load frame prefab failed : path = {0} typeid = {1}", frameItem.Prefab, type);
                return;
            }

            if(null == GlobalDataManager.Instance().uiConfig)
            {
                LogManager.Instance().LogProcessFormat(9103, "uiConfig is null , can not attach frame to parent ! typeid = {0}", type);
                return;
            }

            Utility.AttachTo(root, GlobalDataManager.Instance().uiConfig.goLayers[(int)getLayer()]);

            LogManager.Instance().LogProcessFormat(9001, "open {0} frame succeed !", frameItem.Desc);

            _OnOpenFrame();
        }

        public void closeFrame()
        {
            LogManager.Instance().LogProcessFormat(9000, "close frame {0} !", frameTypeId);

            _OnCloseFrame();

            if(null != root)
            {
                root.transform.SetParent(null);
                GameObject.Destroy(root);
                root = null;
            }
            userData = null;
            frameItem = null;
        }

        protected virtual void _OnOpenFrame()
        {

        }

        protected virtual void _OnCloseFrame()
        {

        }

        int frameId = -1;
        FrameTypeID frameTypeId = FrameTypeID.FTID_INVALID;
        int iHashCode = 0;
        protected object userData = null;
        protected GameObject root = null;
        protected ProtoTable.FrameTypeTable frameItem = null;

        public int FrameID
        {
            get
            {
                return frameId;
            }
        }

        public FrameTypeID FrameTypeID
        {
            get
            {
                return frameTypeId;
            }
        }

        public int FrameHashCode
        {
            get
            {
                return iHashCode;
            }
        }
    }
}
