using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample    
{
    public class AnimatorBlendTest : MonoBehaviour
    {
        #region Variables
        //이동
        [SerializeField] private float moveSpeed = 5f;

        //입력값
        private float moveX;
        private float moveY;

        //컴포넌트
        private Animator animator;
        #endregion

        private void Start()
        {
            if(animator == null)
            {
                animator = GetComponent<Animator>();
            }
        }

        void Update()
        {
            //앞, 뒤, 좌, 우 입력값 처리
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");

            //이동 방향, 속도
            Vector3 dir = new Vector3(moveX, 0f, moveY);

            //이동 처리
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

            //애니메이션 처리
            //AnimatorStateTest();
            AnimationBlendTest();
        }

        //애니메이션 블렌드 테스트
        void AnimationBlendTest()
        {
            animator.SetFloat("MoveX", moveX);
            animator.SetFloat("MoveY", moveY);
        }

        //애니메이션 스테이트 테스트
        void AnimatorStateTest()
        {
            //앞으로 이동
            if (moveY > 0)
            {
                animator.SetInteger("MoveState", 1);
            }
            //뒤로 이동
            else if (moveY < 0)
            {
                animator.SetInteger("MoveState", 2);
            }
            //좌로 이동
            else if (moveX < 0)
            {
                animator.SetInteger("MoveState", 3);
            }
            //우로 이동
            else if (moveX > 0)
            {
                animator.SetInteger("MoveState", 4);
            }
            //정지
            else
            {
                animator.SetInteger("MoveState", 0);
            }
        }
    }
}
