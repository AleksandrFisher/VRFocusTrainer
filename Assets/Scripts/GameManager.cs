using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject lobbyRoom;

    public GameObject focusGame;
    public GameObject memoryGame;
    public GameObject findOddGame;

    public GameObject focusRoom;
    public GameObject memoryRoom;
    public GameObject findOddRoom;

    public int gameNumber = 0;

    void Start()
    {
        //LaunchMiniGame(gameNumber); // 1 - CatchBall, 2 - Memory, 3 - FindOdd
    }

    public void LaunchMiniGame(int gameNumber)
    {
        focusGame.SetActive(false);
        memoryGame.SetActive(false);
        findOddGame.SetActive(false);

        focusRoom.SetActive(false);
        memoryRoom.SetActive(false);
        findOddRoom.SetActive(false);

        lobbyRoom.SetActive(false);

        switch (gameNumber)
        {
            case 1:
                focusGame.SetActive(true);
                focusRoom.SetActive(true);
                break;
            case 2:
                memoryGame.SetActive(true);
                memoryRoom.SetActive(true);
                break;
            case 3:
                findOddGame.SetActive(true);
                findOddRoom.SetActive(true);
                break;
        }
    }
    public void ReturnToLobby()
    {
        focusGame.SetActive(false);
        memoryGame.SetActive(false);
        findOddGame.SetActive(false);

        focusRoom.SetActive(false);
        memoryRoom.SetActive(false);
        findOddRoom.SetActive(false);

        lobbyRoom.SetActive(true);
    }

}
