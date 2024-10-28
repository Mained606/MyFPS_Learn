using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace MyFPS
{
    public class FullExitEye : Interactive
    {
        public GameObject exitWall;
        private Animator animator;
        public MeshRenderer meshRenderer;
        public TextMeshProUGUI textBox;
        public Material fullEye;

        [SerializeField] private string sequence = "Not all eyes are found.";

        void Start()
        {
            animator = exitWall.GetComponent<Animator>();
        }

        protected override void DoAction()
        {
            if(PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY) && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY))
            {

                meshRenderer.material = fullEye;
                animator.SetBool("IsOpen", true);

                this.GetComponent<Collider>().enabled = false;
            }
            else
            {
                 StartCoroutine(NotFullEye());
            }
        }

        IEnumerator NotFullEye()
        {
            unInteractive = true;
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;
            yield return new WaitForSeconds(2f);

            textBox.gameObject.SetActive(false);
            textBox.text = "";

            unInteractive = false;
        }
    }
}
