using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LobbyButton : MonoBehaviour
{
    public int gameIndex; // 0 - CatchBall, 1 - Memory, 2 - FindOdd

    public void OnSelected()
    {
        GameFlowManager flow = FindObjectOfType<GameFlowManager>();
        if (flow != null)
        {
            flow.LaunchGame(gameIndex);
        }
    }
}
