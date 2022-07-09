using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public Transform layer0;
    public Transform layer1;

    private bool layer0Activated = false;
    private bool layer1Activated = false;
    // need to add stuff in canvas to choose data type and data
    private string datatype0;
    private string datatype1 = "Integer";
    private string data;

    public void setDataType0(string s)
    {
        datatype0 = s;
        updateNodeText(datatype0, "", "", 0);
    }

    public void setDataType1(string s)
    {
        datatype1 = s;
        updateNodeText(datatype1, "", "", 1);
    }
    public void Lay0Activated(bool value)
    {
        layer0Activated = value;
    }

    public void Lay1Activated(bool value)
    {
        layer1Activated = value;
        updateNodeText("Pointer", "", "", 0);
    }
    public void fillNodes(int layer)
    {
        // for testing purposes datatype = int, data = 0, reference = ""
        if (layer == 0 && layer0Activated)
        {
            foreach (Transform child in layer0)
            {   
                if (child.transform.childCount > 0)
                {
                    foreach (Transform ch in child.transform)
                    {
                        GameObject.Destroy(ch.gameObject);
                    }
                }
                child.GetComponent<WireFrameNode>().spawnNode(datatype1, "", "");
            }
            if (layer1Activated) updateNodeText("Pointer", "", "", 0);
        }

        else if (layer == 1 && layer1Activated)
        {
            foreach (Transform child in layer1)
            {
                if (child.transform.childCount > 0)
                {
                    foreach (Transform ch in child.transform)
                    {
                        GameObject.Destroy(ch.gameObject);
                    }
                }
                child.GetComponent<WireFrameNode>().spawnNode(datatype1, "", "");
            }
            updateNodeText("Pointer", "", "", 0);
        }
    }

    public void refreshNodeText0()
    {
        updateNodeText(datatype0, "", "", 0);
       
    }
    public void refreshNodeText1()
    {
         updateNodeText(datatype1, "", "", 1);
    }
    private void updateNodeText(string datatype, string data, string reference, int layer)
    {
       Transform theLayer = (layer == 0) ? layer0 : layer1;
            foreach (Transform child in theLayer)
            {
                if (child.transform.childCount > 0)
                {
                    foreach(Transform ch in child.transform)
                    {   
                        Node temp = ch.GetComponent<Node>();
                        temp.setDataType(datatype);
                        temp.setData(data);
                        temp.setReference(reference);
                        temp.updateNodeDisplay();
                    }
                }
            }
        
    }
}
