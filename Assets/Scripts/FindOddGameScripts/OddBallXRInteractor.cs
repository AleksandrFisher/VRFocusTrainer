using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OddBallXRInteractor : MonoBehaviour
{
    private OddBallController oddBall;

    void Start()
    {
        //oddBall = GetComponent<OddBallController>();
        oddBall = GetComponentInParent<OddBallController>();
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (oddBall != null)
        {
            oddBall.OnClicked();
        }
    }
}
