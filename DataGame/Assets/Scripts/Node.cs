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

    void Start() {
        // GameObject line1 = Instantiate(line, bottomConn.transform.position, Quaternion.identity, this.transform);
        // LineRenderer lRend = line1.GetComponent<LineRenderer>();
        // lRend.SetPosition(0, backConn.transform.position);
        // lRend.SetPosition(1, backConn.transform.position + new Vector3(0,0,2));
    }
}
