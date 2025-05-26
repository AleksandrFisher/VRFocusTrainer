/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MemoryBallController : MonoBehaviour
{
    public bool clickable = false;
    private MemoryGameManager gameManager;
    private Material _mat;
    private Color _defaultColor;

    void Start()
    {
        _mat = GetComponent<Renderer>().material;
        _defaultColor = _mat.color;
    }

    public void Highlight(Color color)
    {
        _mat.color = color;
    }

    public void Unhighlight()
    {
        _mat.color = _defaultColor;
    }

    public void SetGameManager(MemoryGameManager mgr)
    {
        gameManager = mgr;
    }

    void OnMouseDown()
    {
        if (clickable && gameManager != null)
        {
            gameManager.OnBallClicked(this);
        }
    }
}
*/

using UnityEngine;

public class MemoryBallController : MonoBehaviour
{
    public bool clickable = false;
    private MemoryGameManager gameManager;
    private Material _mat;
    private Color _defaultColor;

    void Start()
    {
        _mat = GetComponent<Renderer>().material;
        _defaultColor = _mat.color;
    }

    public void Highlight(Color color)
    {
        _mat.color = color;
    }

    public void Unhighlight()
    {
        _mat.color = _defaultColor;
    }

    public void SetGameManager(MemoryGameManager mgr)
    {
        gameManager = mgr;
    }

    public void OnClicked()
    {
        if (clickable && gameManager != null)
        {
            gameManager.OnBallClicked(this);
        }
    }
}
