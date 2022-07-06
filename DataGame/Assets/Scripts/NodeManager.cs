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
    private string datatype1;
    private string data;

    public void setDatatype0(string s)
    {
        datatype0 = s;
        updateNodeText(datatype0, "", "");
    }
    public void Lay0Activated(bool value)
    {
        layer0Activated = value;
    }

    public void Lay1Activated(bool value)
    {
        layer1Activated = value;
        updateNodeText("Pointer", "", "");
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
                child.GetComponent<WireFrameNode>().spawnNode(datatype0, "", "");
            }
            if (layer1Activated) updateNodeText("Pointer", "", "");
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
                child.GetComponent<WireFrameNode>().spawnNode(datatype0, "", "");
            }
            updateNodeText("Pointer", "", "");
        }
    }

    private void updateNodeText(string datatype, string data, string reference)
    {
            foreach (Transform child in layer0)
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
