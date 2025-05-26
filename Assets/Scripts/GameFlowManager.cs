using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public GameManager gameManager;
    public Transform spawnPointForNextCube;
    public GameObject nextCubePrefab;

    private int currentGameIndex = 0;

    void Start()
    {
        //LaunchGame(currentGameIndex);
    }

    public void LaunchGame(int index)
    {
        gameManager.LaunchMiniGame(index + 1); // 1-based
    }

    public void NextGame()
    {
        currentGameIndex++;
        if (currentGameIndex > 2)
        {
            Debug.Log("Все мини-игры завершены.");
            return;
        }

        LaunchGame(currentGameIndex);
    }

    public void SpawnNextCube()
    {
        Instantiate(nextCubePrefab, spawnPointForNextCube.position, Quaternion.identity);
    }
}
