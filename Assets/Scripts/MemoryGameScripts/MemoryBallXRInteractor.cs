using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MemoryBallXRInteractor : MonoBehaviour
{
    private MemoryBallController memoryBall;

    void Start()
    {
        memoryBall = GetComponent<MemoryBallController>();
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (memoryBall != null)
        {
            memoryBall.OnClicked();
        }
    }
}
