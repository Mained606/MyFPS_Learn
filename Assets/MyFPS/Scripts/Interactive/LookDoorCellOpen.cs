using System.Collections;
using UnityEngine;
using TMPro;

namespace MyFPS
{
    public class LookDoorCellOpen : Interactive
    {
        #region Variables
        private Animator animator;
        private Collider m_collide;

        public TextMeshProUGUI textBox;
        [SerializeField] private string sequence = "You Need the Key";
        #endregion

        void Start()
        {
            animator = GetComponent<Animator>();
            m_collide = GetComponent<Collider>();
        }
        protected override void DoAction()
        {
            if(!PlayerStats.Instance.HasPuzzleItem(PuzzleKey.ROOM01_KEY))
            {
                StartCoroutine(LookedDoor());
            }
            else
            {
                OpenDoor();
            }

            // ===============================================
            // 다른 방법 시도 후 삭제한 코드
            // 프로퍼티 사용시 보유 키 확인 및 도어 오픈 기능
            // if(!PlayerStats.Instance.HiddenKey)
            // {
            //     AudioManager.Instance.Play("DoorLocked");
            // }
            // else
            // {
            //     animator.SetBool("isOpen", true);
            //     m_collide.enabled = false;
            //     AudioManager.Instance.Play("CreakyDoor");
            // }
            // ===============================================
        }
        void OpenDoor()
        {
            animator.SetBool("isOpen", true);
            m_collide.enabled = false;
            AudioManager.Instance.Play("CreakyDoor");
        }

        IEnumerator LookedDoor()
        {
            unInteractive = true; //인터렉티브 기능 정지

            AudioManager.Instance.Play("DoorLocked");
            yield return new WaitForSeconds(1f);
            

            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            yield return new WaitForSeconds(2f);

            textBox.gameObject.SetActive(false);
            textBox.text = "";

            unInteractive = false;
            
            // ===============================================
            // 다른 방법 시도 후 삭제한 코드
            // this.GetComponent<BoxCollider>().enabled = false;
            // actionUI.SetActive(false);
            // ===============================================

            // ===============================================
            // 다른 방법 시도 후 삭제한 코드
            // this.GetComponent<BoxCollider>().enabled = true;
            // actionUI.SetActive(true);
            // ===============================================
        }
    }

}
