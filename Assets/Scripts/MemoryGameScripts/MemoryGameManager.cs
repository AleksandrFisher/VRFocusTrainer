using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MemoryGameManager : MonoBehaviour
{
    public List<MemoryBallController> balls;
    public int numberToHighlight = 3;
    public float highlightDuration = 2f;

    private List<MemoryBallController> targetBalls = new List<MemoryBallController>();

    public GameObject roomInteriorObject;

    void Start()
    {
        StartCoroutine(GameSequence());
    }

    IEnumerator GameSequence()
    {
        yield return new WaitForSeconds(1f);

        // ����� ��������� �����
        targetBalls.Clear();
        List<MemoryBallController> pool = new List<MemoryBallController>(balls);

        for (int i = 0; i < numberToHighlight; i++)
        {
            int index = Random.Range(0, pool.Count);
            MemoryBallController selected = pool[index];
            pool.RemoveAt(index);

            targetBalls.Add(selected);
            selected.Highlight(Color.yellow); // ���������
        }

        yield return new WaitForSeconds(highlightDuration);

        // ������� ��������� � ��� ����� ������
        foreach (var b in targetBalls)
            b.Unhighlight();

        EnableClicking(true);
    }

    void EnableClicking(bool enable)
    {
        foreach (var b in balls)
        {
            b.clickable = enable;
            b.SetGameManager(this);
        }
    }

    public void OnBallClicked(MemoryBallController ball)
    {
        if (!ball.clickable) return;

        if (targetBalls.Contains(ball))
        {
            ball.Highlight(Color.green);
            Debug.Log("���������!");
        }
        else
        {
            ball.Highlight(Color.red);
            Debug.Log("������!");
        }

        ball.clickable = false;

        if (AllTargetsFound())
        {
            Debug.Log("����� ��������!");
            StartCoroutine(EndGameSequence());
        }

    }

    bool AllTargetsFound()
    {
        foreach (var b in targetBalls)
            if (b.clickable) return false;

        return true;
    }


    IEnumerator EndGameSequence()
    {
        yield return new WaitForSeconds(1.5f); 

        Destroy(roomInteriorObject);

        GameFlowManager flow = FindObjectOfType<GameFlowManager>();
        if (flow != null)
            flow.SpawnNextCube();
    }

}
