using UnityEngine;

namespace MyFPS
{
    public class LookAtMouse : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Vector3 worldPosition;
        #endregion

        void Update()
        {
            worldPosition = ScreenToWorld();
            transform.LookAt(worldPosition);
        }

        Vector3 ScreenToWorld()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 3f;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            return worldPos;
        }

        Vector3 RayToWorld()
        {
            Vector3 worldPos = Vector3.zero;
            Vector3 mousePos = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                worldPos = hit.point;
            }

            return worldPos;
        }
    }
}