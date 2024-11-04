using System.Collections;
using UnityEngine;
using TMPro;

namespace MyFPS
{
    public class FullExitEye : Interactive
    {
        #region Variables
        public GameObject exitWall;
        private Animator animator;
        public MeshRenderer meshRenderer;
        public TextMeshProUGUI textBox;
        public Material fullEye;

        [SerializeField] private string sequence = "Not all eyes are found.";
        #endregion

        void Start()
        {
            animator = exitWall.GetComponent<Animator>();
        }

        protected override void DoAction()
        {
            if(PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY) && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY))
            {
                meshRenderer.material = fullEye; // 눈이 모두 모였을 때 머테리얼 변경
                animator.SetBool("IsOpen", true); // 문 열림 애니메이션
                this.GetComponent<Collider>().enabled = false; // 충돌 기능 정지
            }
            else
            {
                 StartCoroutine(NotFullEye());
            }
        }

        IEnumerator NotFullEye()
        {
            unInteractive = true; //인터렉티브 기능 정지
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;
            yield return new WaitForSeconds(2f);

            textBox.gameObject.SetActive(false);
            textBox.text = "";

            unInteractive = false;
        }
    }
}
