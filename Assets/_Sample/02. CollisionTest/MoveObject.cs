using UnityEngine;

namespace MySample
{
    public class MoveObject : MonoBehaviour
    {
        #region 
        private Rigidbody rb;

        //좌우로 힘을 주어 이동
        [SerializeField] private float movePower = 5f;
        private float moveX;

        private Material material;
        private Color originColor;
        #endregion

        void Start()
        {
            //참조
            rb = GetComponent<Rigidbody>();
            material = GetComponent<Renderer>().material;

            //초기화
            originColor = material.color;
            MoveRightByForce();
        }

        void Update()
        {
            //입력식
            //moveX = Input.GetAxis("Horizontal");
        }

        void FixedUpdate()
        {
            //좌우로 힘을 주어 이동
            //rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);
        }

        public void MoveRightByForce()
        {
            rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);
        }
        public void MoveLeftByForce()
        {
            rb.AddForce(Vector3.left * movePower, ForceMode.Impulse);
        }

        public void ChangeRedColor()
        {
            material.color = Color.red;
        }
        public void ResetColor()
        {
            material.color = originColor;
        }

    }
}