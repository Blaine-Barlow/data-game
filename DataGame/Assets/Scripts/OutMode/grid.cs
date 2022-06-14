using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{

    public int minX;
    public int maxX;
    public int minY;
    public int maxY;
    public int minZ;
    public int maxZ; 

    private float offset = .5f;

    void OnDrawGizmos() {
        Gizmos.color = Color.white;
    
        for (int height = minZ; height < maxZ; height++){
            Vector3 pos0 = new Vector3();
            Vector3 pos1 = new Vector3();
            for (int i = -minX; i < maxX; i++)
            {
                pos0.x = i + offset;
                // pos0.z = -minY;
                pos0.y = -minY +offset;
                // pos0.y = height;
                pos1.x = i + offset;
                // pos1.z = maxY;
                pos1.y = maxY + offset;
                // pos1.y = height;
                Gizmos.DrawLine(pos0,pos1);
            }

            for (int i = -minY; i < maxY; i++)
            {
                pos0.x = -minX + offset;
                pos0.y = i + offset;
                // pos0.z = i;
                pos1.x = maxX +offset;
                // pos1.z = i;
                pos1.y = i + offset;
                Gizmos.DrawLine(pos0,pos1);
            }
        }
    }
} 

