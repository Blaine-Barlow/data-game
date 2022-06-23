using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireFrameNode : MonoBehaviour, IClicked
{

    MeshRenderer mRenderer;
    private bool isSelected = false;
    private void Awake() {
        mRenderer = GetComponent<MeshRenderer>();

    }

    public void onClickAction()
    {
        if (isSelected)
        {
            mRenderer.material.color = Color.white;
        }
        else
        {
            mRenderer.material.color = Color.red;
        }
        isSelected = !isSelected;
    }
}
