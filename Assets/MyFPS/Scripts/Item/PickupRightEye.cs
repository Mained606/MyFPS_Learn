using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class PickupRightEye : PickupPuzzleItem
    {
        #region Variables
        public GameObject fakeWall;
        public GameObject exitWall;
        public GameObject hiddenUiEyeGp;
        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());
            hiddenUiEyeGp.SetActive(true);

            ShowExitWall();
        }

        void ShowExitWall()
        {
            if(PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY) && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY))
            {
                fakeWall.SetActive(false);
                exitWall.SetActive(true);
            }
        }
    }
}
