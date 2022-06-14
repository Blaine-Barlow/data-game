using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject node;

    private Vector3 _node_previous_pos;

    void Awake() {
        _node_previous_pos = Vector3.zero;
    }
    public void spawnNewNode()
    {
        var newNode = Instantiate(node, _node_previous_pos + new Vector3(1.5f,0,0), Quaternion.identity);
        _node_previous_pos = _node_previous_pos + new Vector3(1.5f,0,0);
    }
}
