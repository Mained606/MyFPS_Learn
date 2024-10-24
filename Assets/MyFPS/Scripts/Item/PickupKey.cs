using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class PickupKey : PickupItem
    {
        public GameObject hiddenKeyUI;
        protected override bool OnPickup()
        {
            //아이템 획득
            // PlayerStats.Instance.AddKey(true);

            //첫 번째 방 키 획득
            PlayerStats.Instance.AcquirePuzzleItem(PuzzleKey.ROOM01_KEY);
            hiddenKeyUI.SetActive(true);



            return true;
        }
    }
    
}
