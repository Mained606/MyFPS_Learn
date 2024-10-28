using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyFPS
{
    public class PickupPuzzleItem : Interactive
    {
        #region Variables
        public GameObject puzzileUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject puzzleItemGp;

        [SerializeField] private PuzzleKey puzzleKey;

        public Sprite itemSprite; //획득한 아이템 아이콘
        [SerializeField] private string puzzleStr = "Puzzle Text"; //아이템 획득 안내 텍스트

        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());
        }

        protected IEnumerator GainPuzzleItem()
        {
             //아이템 획득
            PlayerStats.Instance.AcquirePuzzleItem(puzzleKey);
            // Ui 연출
            if(puzzileUI != null)
            {   
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                puzzleItemGp.SetActive(false);

                puzzileUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);
                puzzileUI.SetActive(false);
            }

            //킬
            Destroy(this.gameObject);
        }
    }

}
