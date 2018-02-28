using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
    public class ComItem : MonoBehaviour
    {
        public Text itemName;

        public void OnItemVisible(string value)
        {
            if(null != itemName)
            {
                itemName.text = value;
            }
        }
    }
}