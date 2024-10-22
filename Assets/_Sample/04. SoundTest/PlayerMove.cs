using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MySample
{
    public class PlayerMove : MonoBehaviour
    {
        #region Variables

        private Rigidbody rb;
        // private PlayerInput playerInput;
       // private Vector2 input; 
        [SerializeField]private float moveSpeed = 20f;
        [SerializeField]private float sideSpeed = 5f;

        #endregion
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            // playerInput = GetComponent<PlayerInput>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            // 전방 이동
            rb.AddForce(0f, 0f, moveSpeed, ForceMode.Acceleration);
            // rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);


            // 좌우 입력 - 구 인풋 시스템
            float moveHorizontal = Input.GetAxis("Horizontal");
            rb.AddForce(moveHorizontal * sideSpeed, 0f, 0f, ForceMode.Acceleration);

            // // 뉴 인풋 시스템
            // Vector3 dir = new Vector3(input.x, 0f, input.y);
            // rb.AddForce(dir * sideSpeed, ForceMode.Acceleration);
        }

        // 뉴 인풋 시스템 이벤트 함수
        // public void OnMove(InputAction.CallbackContext context)
        // {
        //     input = context.ReadValue<Vector2>();
        // }
    }

}
