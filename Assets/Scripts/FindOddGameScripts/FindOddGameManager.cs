using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FindOddGameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public List<Transform> spawnPoints;

    public GameObject roomInteriorObject;

    private List<GameObject> spawnedBalls = new List<GameObject>();
    private GameObject oddOne;

    void Start()
    {
        SpawnBalls();
    }

    void SpawnBalls()
    {
        if (spawnPoints.Count < 1)
        {
            Debug.LogError("Spawn points not assigned!");
            return;
        }

        int oddIndex = Random.Range(0, spawnPoints.Count);

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            Transform spawnPoint = spawnPoints[i];

            GameObject newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity, roomInteriorObject != null ? roomInteriorObject.transform : null);

            OddBallController ctrl = newBall.GetComponent<OddBallController>();
            if (ctrl == null)
                ctrl = newBall.AddComponent<OddBallController>();

            ctrl.Initialize(this, i == oddIndex);

            spawnedBalls.Add(newBall);

            if (i == oddIndex)
                oddOne = newBall;
        }
    }

    public void OnBallClicked(GameObject clicked)
    {
        if (clicked == oddOne)
        {
            Debug.Log("Ты нашёл отличающегося!");
            clicked.GetComponent<Renderer>().material.color = Color.green;
            StartCoroutine(EndGameSequence());

        }
        else
        {
            Debug.Log("Не тот. Попробуй ещё.");
            clicked.GetComponent<Renderer>().material.color = Color.red;
        }

    }

    IEnumerator EndGameSequence()
    {
        yield return new WaitForSeconds(1.5f);

        if (roomInteriorObject != null)
            Destroy(roomInteriorObject);

        GameFlowManager flow = FindObjectOfType<GameFlowManager>();
        if (flow != null)
            flow.SpawnNextCube();
    }

}