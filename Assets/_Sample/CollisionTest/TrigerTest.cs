using UnityEngine;
namespace MySample
{
    public class TrigerTest : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"OnTriggerEnter {other.name}");
            //오른쪽으로 힘을 주어 밀어내기
            MoveObject moveObject = other.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveRightByForce();
                moveObject.ChangeRedColor();
            }
        }
        private void OnTriggerStay(Collider other)
        {
            Debug.Log($"OnTriggerStay {other.name}");
        }
        private void OnTriggerExit(Collider other)
        {
            Debug.Log($"OnTriggerExit {other.name}");
            //오른쪽으로 힘을 주어 밀어내기
            MoveObject moveObject = other.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveRightByForce();
                moveObject.ResetColor();
            }
        }
    }
}
