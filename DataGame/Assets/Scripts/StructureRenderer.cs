using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureRenderer : MonoBehaviour
{
    public GameObject wireFrame; 
    public Transform layer0;
    public Transform layer1;

    private FullGameStructure _structure;

    private Vector3[] _layerLocations;

    private Vector3 extents;
    private Vector3 startLocation;

    private float offsetBound;

    private float _xOffset;
    private float _yOffset;
    private float _zOffset;

    // Layer 1 Variables
    [SerializeField] private float _layer1spacer = 2f;

    private int _sizeX = 0;
    private int _sizeY = 1;

    private int _lay1SizeX = 0;
    private int _lay1SizeY = 1;

    private void Start() {
        _structure = ScriptableObject.CreateInstance<FullGameStructure>();
        extents = wireFrame.GetComponent<MeshRenderer>().bounds.extents;
        _layerLocations = _structure.layerLoc;
    }

    public void storeSizeX(string s)
    {
        int.TryParse(s, out this._sizeX); 
    }

    public void storeSizeY(string s)
    {
        int.TryParse(s, out this._sizeY);  
    }

    public void storeLay1SizeX(string s)
    {
        int.TryParse(s, out this._lay1SizeX);  
    }
    public void storeLay1SizeY(string s)
    {
        int.TryParse(s, out this._lay1SizeY);  
    }

    public void DrawLayer0()
    {   
        int sizeX = _sizeX;
        int sizeY = _sizeY;
        DestroyLayer0();
        _xOffset = extents[0]*2;
        _yOffset = extents[1]*2;
        _zOffset = 0;
        startLocation = _layerLocations[0];
        // Debug.Log("Layer 0: x: " + _xOffset + " y: " + _yOffset + " z: " + _zOffset + " StartLocation: " + startLocation);
        Vector3 originalStart = startLocation;
        for (int row = 0; row < sizeX; row++ )
            {
            for (int col = 0; col < sizeY; col++)
                {
                    // make 3 layer game objects to place this as children.
                    GameObject newNode = Instantiate(wireFrame, startLocation, Quaternion.identity, layer0.transform);
                    startLocation += new Vector3(0, _yOffset, _zOffset);
                }
                startLocation = new Vector3(startLocation[0] + _xOffset, originalStart[1], originalStart[2]);
            }
        // Everytime draw a cube. just add _xoffset, _yOffset, _zOffset. simple loops.
    }

    public void DestroyLayer0()
    {
        foreach (Transform child in layer0.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }


    public void DrawLayer1()
    {
        int sizeX = _sizeX;
        int sizeY = _lay1SizeX;
        int sizeZ = _lay1SizeY;

        DestroyLayer1();
        startLocation = _layerLocations[1];
        float xStart = startLocation[0];
        float halfLength = extents[0];
        if (sizeX > 1)
        {
            Debug.Log((sizeX/2) % 2);
            if (sizeX == 2)
            {
                xStart += halfLength + halfLength * sizeX/2;
                xStart -= halfLength * 4;

            }
            else if (sizeX == 3)
            {
                xStart += halfLength * 2 + halfLength * sizeX/2;
                xStart -= halfLength * 3.5f + _layer1spacer;
            }
            else if ( sizeX > 3 && sizeX % 2 == 1)
            {
                xStart += halfLength * 2 + halfLength * sizeX/2;
                xStart -= halfLength * (3.5f + .5f*(sizeX/2)) + _layer1spacer * (sizeX/2);
            }
            else
            {   
                xStart += halfLength + halfLength * sizeX/2;
                xStart -=  halfLength * (4 + .5f * (sizeX/2))  + _layer1spacer * (sizeX/2 - 1);
            }

        }
        for (int x = 0; x < sizeX; x++)
        {
            layer1Helper(xStart, sizeY, sizeZ);
            xStart += _layer1spacer + extents[0] *2;
        }
    }

    private void layer1Helper(float xLoc, int sizeY, int sizeZ)
    {
        Vector3 start = new Vector3(xLoc, _layerLocations[1][1], _layerLocations[1][2]);
        float length = extents[0] * 2;
        Vector3 originalStart = start;
        for (int row = 0; row <sizeZ ; row++)
        {
            for (int col = 0; col < sizeY; col++)
            {
                GameObject newNode = Instantiate(wireFrame, start, Quaternion.identity, layer1.transform);
                start += new Vector3(0, length, 0);
            }
            start = new Vector3(xLoc, originalStart[1], start[2] + length);
        }

    }

    public void DestroyLayer1()
    {
        foreach (Transform child in layer1.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    
}
