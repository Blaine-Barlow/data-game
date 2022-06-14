using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public GameObject bottomConn;
    public GameObject topConn;
    public GameObject leftConn;
    public GameObject rightConn;
    public GameObject backConn;
    

    public GameObject line;

    private string _dataType;
    private string _data;
    private string _reference;

    private Transform _referenceCell;

    public void setDataType(string s)
    {
        _dataType = s;
    }

    public void setData(string s)
    {
        _data = s;
    }

    public void setReference(string s)
    {
        _reference = s;
    }

    public void setReferenceCell(Transform tm)
    {
        _referenceCell = tm;
    }

    public string getNodeData()
    {
        return "DataType: " + _dataType + "\nData: " + _data + "\n_reference: " + _reference;
    }
}
