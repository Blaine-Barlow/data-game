using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureRendererv2 : MonoBehaviour
{
    public GameObject wireFrame; 
    public Transform layer0;
    public Transform layer1;
    public Transform lines;
    public GameObject referenceLine;


    // Next task To add reference lines from each cell in layer0 to cell in layer1
    private List<List<Vector3>> firstNodeLocations;

    private FullGameStructure _structure;

    private Vector3[] _layerLocations;

    private Vector3 startLocation;

    private float offsetBound;

    private float _cubeLength;
    // Layer 1 Variables
    [SerializeField] private float _layer1spacer = 2f;

    private int _sizeX = 0;
    private int _sizeY = 1;

    private int _lay1SizeX = 0;
    private int _lay1SizeY = 1;

    private void Start() {
        _structure = ScriptableObject.CreateInstance<FullGameStructure>();
        _cubeLength = wireFrame.GetComponent<MeshRenderer>().bounds.extents[0] * 2;
        _layerLocations = _structure.layerLoc;
        firstNodeLocations = new List<List<Vector3>>();
    }

    public void handleInputDataX(int value)
    {
        this._sizeX = value;
    }

    public void handleInputDataY(int value)
    {
        this._sizeY = value + 1;
    }

    // Outdated:
    // public void storeSizeX(string s)
    // {
    //     int.TryParse(s, out this._sizeX); 
    // }

    // public void storeSizeY(string s)
    // {
    //     int.TryParse(s, out this._sizeY);  
    // }

    public void handleInputData2ndX(int value)
    {
        this._lay1SizeX = value;
    }

    public void handleInputData2ndY(int value)
    {
        this._lay1SizeY = value + 1;
    }
    // Outdated
    // public void storeLay1SizeX(string s)
    // {
    //     int.TryParse(s, out this._lay1SizeX);  
    // }
    // public void storeLay1SizeY(string s)
    // {
    //     int.TryParse(s, out this._lay1SizeY);  
    // }

    public void DrawLayer0()
    {   
        int sizeX = _sizeX;
        int sizeY = _sizeY;
        DestroyLayer0();
        DestroyLayer1();
        startLocation = _layerLocations[0];
        Vector3 originalStart = startLocation;
        for (int row = 0; row < sizeX; row++ )
            {
            for (int col = 0; col < sizeY; col++)
                {
                    firstNodeLocations.Add(new List<Vector3>());
                    GameObject newNode = Instantiate(wireFrame, startLocation, Quaternion.identity, layer0.transform);
                    startLocation += new Vector3(0, _cubeLength, 0);
                }
                startLocation = new Vector3(startLocation[0] + _cubeLength, originalStart[1], originalStart[2]);
            }
    }

    public void DestroyLayer0()
    {
        foreach (Transform child in layer0.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        firstNodeLocations.Clear();
    }


    /*
    Draw the secondary layer which contains the arrays that the layer0 array of pointers point to.
    */
    public void DrawLayer1()
    {
        if (_lay1SizeX == 0) return;
        int sizeX = _sizeX;
        int sizeHeight = _sizeY; // 2D original height shows number of Z height
        int sizeY = _lay1SizeX;
        int sizeZ = _lay1SizeY;

        DestroyLayer1();
        float xStart = _layerLocations[1][0];
        float halfLength = _cubeLength/2;
        if (sizeX > 1)
        {
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
        float yStart = _layerLocations[1][1];
        float ySpacer = 0;
        if (sizeHeight > 1)
        {   
            if (sizeHeight == 2)
            {
                yStart += (halfLength*2) * sizeHeight/2 + halfLength; // put at centre
                yStart -= (halfLength*2) * sizeY - halfLength + _layer1spacer*(sizeHeight - 1);
            }
            else if (sizeHeight == 3)
            {
                yStart += (halfLength*3);
                yStart -= (sizeY/2 * (halfLength*2)) + halfLength + _layer1spacer + sizeY*(halfLength*2);
            }
            else if (sizeHeight > 3 && sizeHeight % 2 == 1) // odd
            {
                yStart += (halfLength * sizeHeight);
                yStart -= (sizeY/2 * (halfLength*2)) + halfLength + _layer1spacer + sizeY*(sizeHeight-1)*(halfLength*2);
            }
            else 
            {
                yStart += (halfLength * sizeHeight);
                yStart -= (sizeY * (halfLength*2)) + _layer1spacer + (sizeY -1)*(sizeHeight -1) * (halfLength*2);
            }

            // Spacer is what i need.
            ySpacer = halfLength + sizeY * _layer1spacer;
        }

        float originalXStart = xStart;
        for (int height = 0; height < sizeHeight; height++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                firstNodeLocations[height].Add(new Vector3(xStart,yStart, _layerLocations[1][2]));
                layer1Helper(xStart,yStart, sizeY, sizeZ);
                xStart += _layer1spacer + _cubeLength;
            }
            xStart = originalXStart;
            yStart += ySpacer;
        }
        drawLinkLines();
    }

    private void layer1Helper(float xLoc,float yLoc, int sizeY, int sizeZ)
    {
        Vector3 start = new Vector3(xLoc, yLoc, _layerLocations[1][2]);
        Vector3 originalStart = start;
        for (int row = 0; row <sizeZ ; row++)
        {
            for (int col = 0; col < sizeY; col++)
            {
                GameObject newNode = Instantiate(wireFrame, start, Quaternion.identity, layer1.transform);
                start += new Vector3(0, _cubeLength, 0);
            }
            start = new Vector3(xLoc, originalStart[1], start[2] + _cubeLength);
        }

    }

    private void drawLinkLines()
    {
        int sizeX = _sizeX;
        int sizeY = _sizeY;
        startLocation = _layerLocations[0];
        Vector3 originalStart = startLocation;
        for (int row = 0; row < sizeX; row++ )
            {
            for (int col = 0; col < sizeY; col++)
                {
                    GameObject newLine = Instantiate(referenceLine, startLocation, Quaternion.identity, lines.transform);
                    newLine.GetComponent<LineRenderer>().SetPosition(0, startLocation + new Vector3(0,0, .5f));
                    newLine.GetComponent<LineRenderer>().SetPosition(1, firstNodeLocations[col][row] + new Vector3(0,0,-.5f));
                    startLocation += new Vector3(0, _cubeLength, 0);
                }
                startLocation = new Vector3(startLocation[0] + _cubeLength, originalStart[1], originalStart[2]);
            }
    }

    public void DestroyLayer1()
    {
        GetComponent<GameManager>().deactivateLayer1();
        foreach (Transform child in layer1.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        // add in the line destroy
        for (int i = 0; i < firstNodeLocations.Count; i++)
        {
            firstNodeLocations[i].Clear();
        }

        foreach (Transform child in lines.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    
}

