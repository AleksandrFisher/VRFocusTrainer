using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusGameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public int ballCount = 6;
    public float radius = 3f;

    private List<BallController> balls = new List<BallController>();
    private BallController targetBall;

    public static bool selectionEnabled = false;

    public GameFlowManager gameFlowManager;

    private void Start()
    {
        SpawnBalls();
        StartCoroutine(GameSequence());
    }

    void SpawnBalls()
    {
        for (int i = 0; i < ballCount; i++)
        {
            Vector3 pos = transform.position + Random.insideUnitSphere * radius;
            pos.y = 0.5f;
            GameObject ball = Instantiate(ballPrefab, pos, Quaternion.identity, transform);
            BallController controller = ball.GetComponent<BallController>();
            balls.Add(controller);
        }
    }

    IEnumerator GameSequence()
    {
        yield return new WaitForSeconds(1f);

        // Выбор цели
        targetBall = balls[Random.Range(0, balls.Count)];
        targetBall.isTarget = true;
        targetBall.CorrectHighlight(true);

        yield return new WaitForSeconds(2f);
        targetBall.CorrectHighlight(false);

        // Старт движения
        foreach (var ball in balls)
            ball.StartMoving();

        yield return new WaitForSeconds(5f);

        // Остановка
        foreach (var ball in balls)
            ball.StopMoving();

        selectionEnabled = true;
    }

    public void OnBallSelected(BallController clickedBall)
    {
        if (!selectionEnabled) return;
        selectionEnabled = false;

        if (clickedBall == targetBall)
        {
            Debug.Log("Правильно!");
            clickedBall.CorrectHighlight(true);
        }
        else
        {
            Debug.Log("Неправильно!");
            clickedBall.WrongHighlight(true);
            targetBall.CorrectHighlight(true);
        }

        StartCoroutine(ShowResultThenSpawnCube());
    }

    IEnumerator ShowResultThenSpawnCube()
    {
        yield return new WaitForSeconds(2f); // Показываем подсветку
        if (gameFlowManager != null)
            gameFlowManager.SpawnNextCube();
    }
}
