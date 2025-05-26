using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    private Material _mat;
    private Color _originalColor;
    private Color _hoverColor = Color.cyan;


    public bool isTarget = false;
    private Vector3 moveDirection;
    private float speed;
    private bool moving = false;

    private Vector3 waveOffset;


    void Start()
    {
        _mat = GetComponent<Renderer>().material;
        _originalColor = _mat.color;
/*        _mat = Instantiate(GetComponent<Renderer>().material);
        GetComponent<Renderer>().material = _mat;*/

    }


    public void StartMoving()
    {
        moving = true;
        StartCoroutine(ChangeDirectionRoutine());
    }

    public void StopMoving()
    {
        moving = false;
        StopAllCoroutines();
    }

    void Update()
    {
        // Пульсация работает всегда
        float pulse = 1f + Mathf.Sin(Time.time * 4f) * 0.05f;
        transform.localScale = new Vector3(pulse, pulse, pulse);

        // Движение - только если шар "живой"
        if (!moving) return;

        float waveX = Mathf.Sin(Time.time * Random.Range(2f, 9f)) * 0.2f;
        float waveZ = Mathf.Cos(Time.time * Random.Range(2f, 9f)) * 0.2f;

        Vector3 wavyMovement = moveDirection + new Vector3(waveX, 0, waveZ);
        transform.position += wavyMovement.normalized * speed * Time.deltaTime;
    }


    IEnumerator ChangeDirectionRoutine()
    {
        while (moving)
        {
            moveDirection = Random.insideUnitSphere;
            moveDirection.y = 0;
            speed = Random.Range(1f, 7f);
            yield return new WaitForSeconds(Random.Range(0.4f, 1.2f));
        }
    }

    public void CorrectHighlight(bool active)
    {
        GetComponent<Renderer>().material.color = active ? Color.green : Color.black;
    }

    public void WrongHighlight(bool active)
    {
        GetComponent<Renderer>().material.color = active ? Color.red : Color.black;
    }
}
