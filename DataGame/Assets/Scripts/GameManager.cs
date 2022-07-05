using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private WireFrameNode selectedNode;
    private string[] dataTypes = {"Integer", "Float", "Double", "Char", "String","Boolean", "Pointer", "Generic<T>"};

    private NodeManager NM;
    
    private void Start() {
        NM = GetComponent<NodeManager>();
    }

    public void setInitialNodeDataType(int choice)
    {
        Debug.Log(dataTypes[choice]);
        NM.setDatatype0(dataTypes[choice]);
    }
    public void activateLayer0()
    {
        NM.Lay0Activated(true);
    }

    public void deactivateLayer0()
    {
        NM.Lay0Activated(false);
    }

    public void activateLayer1()
    {
        NM.Lay1Activated(true);
    }

    public void deactivateLayer1()
    {
        NM.Lay1Activated(false);
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
        NM.fillNodes(0);
    }

    public void fillNodesLayer1()
    {
        NM.fillNodes(1);
    }
    
    

}
