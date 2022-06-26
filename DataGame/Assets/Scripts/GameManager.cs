using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private WireFrameNode selectedNode;
    public Transform layer0;
    public Transform layer1;

    private bool layer0Activated = false;
    private bool layer1Activated = false;

    public void activateLayer0()
    {
        layer0Activated = true;
    }

    public void deactivateLayer0()
    {
        layer0Activated = false;
    }

    public void activateLayer1()
    {
        layer1Activated = true;
    }

    public void deactivateLayer1()
    {
        layer1Activated = false;
    }

    public void highlightNode(WireFrameNode newNode)
    {
        if (selectedNode)
        {
            selectedNode.unHighlight();
        }
        selectedNode = newNode;
        selectedNode.highlight();
    }

    public void fillNodesLayer0()
    {
        fillNodes(0);
    }

    public void fillNodesLayer1()
    {
        fillNodes(1);
    }
    
    // need to add stuff in canvas to choose data type and data
    private void fillNodes(int layer)
    {
        // for testing purposes datatype = int, data = 0, reference = ""
        if (layer == 0 && layer0Activated)
        {
            foreach (Transform child in layer0)
            {
                child.GetComponent<WireFrameNode>().spawnNode("int", "0", "");
            }
        }

        else if (layer == 1 && layer1Activated)
        {
            foreach (Transform child in layer1)
            {
                child.GetComponent<WireFrameNode>().spawnNode("int", "0", "");
            }
        }
    }

}
