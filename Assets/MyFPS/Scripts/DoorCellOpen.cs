using UnityEngine;
using TMPro;

namespace MyFPS
{
    public class DoorCellOpen : MonoBehaviour
    {
        #region Variables
        private float theDistance;

        //action UI
        public GameObject actionUi;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Press E to Open";
        public GameObject extraCross;

        //action
        private Animator animator;
        private Collider m_collide;
        public AudioSource audioSource;
        // private bool isOpen = false;
        #endregion
  
        void Start()
        {
            animator = GetComponent<Animator>();
            m_collide = GetComponent<Collider>();
        }

        void Update()
        {
            //플레이어와 문의 거리를 계산
            theDistance = PlayerCasting.distanceFormTarget;

            // 거리가 2 이하일 때 문을 연다
            // if (Input.GetKeyDown(KeyCode.E) && theDistance <= 2f)
            // {
            //     OpenDoor();
            // }

        }
        //마우스를 가져가면 액션 UI를 보여준다
        private void OnMouseOver()
        {
            //거리가 2이하 일 때
            if (theDistance <= 2f)
            {
                actionUi.SetActive(true);
                actionText.text = action;
                extraCross.SetActive(true);

                if(Input.GetButtonDown("Action")/*&& isOpen == false)*/)
                {
                    HideActionUI();

                    animator.SetBool("isOpen", true);
                    m_collide.enabled = false;
                    audioSource.Play();

                    //도어 열림
                    // OpenDoor();
                    // isOpen = true;
                }
                // else if(Input.GetButtonDown("Action")&& isOpen == true)
                // {
                //     CloseDoor();
                // }
            }
            else
            {
                HideActionUI();
            }   
        }

        //마우스가 벗어나면 액션 UI를 숨긴다.
        private void OnMouseExit()
        {
            HideActionUI();
        }

        private void HideActionUI()
        {
            actionUi.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }

        //마우스가 벗어나면 액션 UI를 숨긴다
        // private void OnMouseExit()
        // {
        //     if (theDistance >= 2f)
        //     {
        //         actionUi.SetActive(false);
        //     }
        // }
        // private void OpenDoor()
        // {
        //     // animator.SetBool("isOpen", true);
        //     // collide.enabled = false;
        //     // isOpen = true;
        // }
        // private void CloseDoor()
        // {
        //     animator.SetBool("isOpen", false);
        //     collide.enabled = true;
        //     isOpen = false;
        // }
    }
}
