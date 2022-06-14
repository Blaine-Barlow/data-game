using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FullGameStructure", menuName = "DataGame/FullGameStructure", order = 0)]
public class FullGameStructure : ScriptableObject {
    public Vector3[] layerLoc = {new Vector3(0,0,0), new Vector3(0,0,5), new Vector3(-5,0,5)};
}
