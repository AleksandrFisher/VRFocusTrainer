/*using UnityEngine;

public class OddBallController : MonoBehaviour
{
    private FindOddGameManager manager;
    private Material _mat;
    private bool isOdd = false;

    public void Initialize(FindOddGameManager gm, bool isOddBall)
    {
        manager = gm;
        _mat = GetComponent<Renderer>().material;

        isOdd = isOddBall;

        if (isOdd)
        {
            transform.localScale *= 1.3f;
            _mat.color = Color.yellow;
        }
    }

    void OnMouseDown()
    {
        if (manager != null)
            manager.OnBallClicked(gameObject);
    }
}
*/

using UnityEngine;

public class OddBallController : MonoBehaviour
{
    private FindOddGameManager manager;
    private Material _mat;
    private bool isOdd = false;

    public void Initialize(FindOddGameManager gm, bool isOddBall)
    {
        manager = gm;
        _mat = GetComponent<Renderer>().material;
        _mat.SetFloat("_Glossiness", 0.7f);

        isOdd = isOddBall;

        if (isOdd)
        {
            transform.localScale *= 1.1f;
            _mat.SetFloat("_Glossiness",0.4f);
            //_mat.color = Color.yellow;
        }
    }

    public void OnClicked()
    {
        if (manager != null)
        {
            manager.OnBallClicked(gameObject);
        }
    }
}
