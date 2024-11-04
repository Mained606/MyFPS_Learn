using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MyFPS
{
    public class PickupKey : PickupItem
    {
        #region Variables
        public GameObject hiddenKeyUI;
        public GameObject hiddenKeyGp;
        public GameObject puzzileUI;
        public TextMeshProUGUI puzzleText;
        public GameObject puzzleItemGp;
        public MeshRenderer keyMesh;
        public GameObject pickupEffect;
        public Image itemImage;
        [SerializeField] private PuzzleKey puzzleKey;
        public Sprite itemSprite; //획득한 아이템 아이콘
        [SerializeField] private string puzzleStr = "Puzzle Text"; //아이템 획득 안내 텍스트
        #endregion

        protected override void OnTriggerEnter(Collider other)
        {
             //플레이어 체크
            if(other.tag == "Player")
            {
                //아이템 획득
                if(OnPickup() == true)
                {
                    //성공효과, 사운드, 이펙트

                    //획득시 모습과 콜라이더, 파티클 비활성화
                    keyMesh.enabled = false;
                    pickupEffect.SetActive(false);
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    
                    //코루틴 종료후 3초 후 킬
                    Destroy(this.gameObject, 3f);
                }
            }
        }

        
        protected override bool OnPickup()
        {
            //아이템 획득
            // PlayerStats.Instance.AddKey(true);

            //첫 번째 방 키 획득
            StartCoroutine(GainPuzzleItem());
            return true;
        }

        IEnumerator GainPuzzleItem()
        {
             //아이템 획득
            PlayerStats.Instance.AcquirePuzzleItem(puzzleKey);
            // Ui 연출
            if(puzzileUI != null)
            {   
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                puzzleItemGp.SetActive(false);

                puzzileUI.SetActive(true);

                //아이템 이미지 크기 변경
                itemImage.rectTransform.sizeDelta = new Vector2(300f, 100f);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);
                puzzileUI.SetActive(false);
                hiddenKeyUI.SetActive(true);
                hiddenKeyGp.SetActive(true);

                //아이템 이미지 기본 사이즈로 초기화
                itemImage.rectTransform.sizeDelta = new Vector2(100f, 200f);
            }
        }
    }
}
