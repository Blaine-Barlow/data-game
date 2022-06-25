using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private WireFrameNode selectedNode;

    public void highlightNode(WireFrameNode newNode)
    {
        if (selectedNode)
        {
            selectedNode.unHighlight();
        }
        selectedNode = newNode;
        selectedNode.highlight();
    }


}
