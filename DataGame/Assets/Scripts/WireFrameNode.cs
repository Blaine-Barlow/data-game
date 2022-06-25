using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireFrameNode : MonoBehaviour, IClicked
{

    MeshRenderer mRenderer;
    private void Awake() {
        mRenderer = GetComponent<MeshRenderer>();

    }

    public void onClickAction()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().highlightNode(this);
    }

    public void highlight()
    {
        mRenderer.material.color = Color.red;
    }

    public void unHighlight()
    {
        mRenderer.material.color = Color.white;
    }

    public void selectedTraverse()
    {
        mRenderer.material.color = Color.green;
    }

    public void deselectTraverse()
    {
        unHighlight();
    }

}
