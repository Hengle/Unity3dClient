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

        public void openFrame(int iId, FrameTypeID type, object userData)
        {
            this.frameId = iId;
            this.frameTypeId = type;
            this.iHashCode = UIManager.Instance().MakeFrameHashCode(iId, type);
            this.userData = userData;

            _OnOpenFrame();
        }

        public void closeFrame(int iHashCode)
        {
            _OnCloseFrame();
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
