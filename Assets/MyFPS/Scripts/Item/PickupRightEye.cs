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
                exitWall.SetActive(true); // 모든 눈을 모았을 때 벽 변경
            }
        }
    }
}
