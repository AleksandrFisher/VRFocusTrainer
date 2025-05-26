using UnityEngine;

public class NextCubeController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            GameFlowManager flowManager = FindObjectOfType<GameFlowManager>();
            GameManager gManager = FindObjectOfType<GameManager>();

            if (flowManager != null && gManager != null)
            {
                gManager.ReturnToLobby();
                Destroy(gameObject);
            }
        }
    }
}
