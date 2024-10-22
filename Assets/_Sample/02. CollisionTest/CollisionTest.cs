using UnityEngine;
namespace MySample
{
    public class CollisionTest : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            //왼쪽으로 밀어내기
            Debug.Log($"OnCollisionEnter {collision.gameObject.name}");
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveLeftByForce();
            }
        }
        private void OnCollisionStay(Collision collision)
        {
            Debug.Log($"OnCollisionStay {collision.gameObject.name}");
        }
        private void OnCollisionExit(Collision collision)
        {
            //왼쪽으로 밀어내기
            Debug.Log($"OnCollisionExit {collision.gameObject.name}");
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveLeftByForce();
            }
        }
    }
}
