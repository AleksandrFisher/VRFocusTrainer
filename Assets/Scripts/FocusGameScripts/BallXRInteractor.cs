using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallXRInteractor : MonoBehaviour
{
    private BallController ball;

    private void Awake()
    {
        //ball = GetComponent<BallController>();
        ball = GetComponentInParent<BallController>();
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!FocusGameManager.selectionEnabled) return;

        FocusGameManager manager = FindObjectOfType<FocusGameManager>();
        if (manager != null)
        {
            manager.OnBallSelected(ball);
        }
    }
}
