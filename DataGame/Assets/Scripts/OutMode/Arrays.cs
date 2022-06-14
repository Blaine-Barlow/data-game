using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour
{
    private int _sizeX = 0;
    private int _sizeY = 1;
    private Transform tm;
    public List<GameObject> contents = new List<GameObject>();
    public GameObject node;
    public LineRenderer gridLine;

    private bool gridCreated = false;
    public GameObject fullGrid;
    public GameObject cubeStorage;


    void Start() {
        tm = this.GetComponent<Transform>();
    }

    public void storeSizeX(string s)
    {
        int.TryParse(s, out this._sizeX); 
        if(this._sizeX == 0)
        {
            // do something
        }
    }

    public void storeSizeY(string s)
    {
        int.TryParse(s, out this._sizeY);  
        if(this._sizeY == 0)
        {
            // do something
        }
    }


    /*
    Purpose: to create the structure of the empty array
    */
    public void createEmptyArray()
    {   
        destroyGrid();
        /* create lines for the size of the array. 
           Need block size, 
           position,
           *-----*-----*-----*
           |     |     |     |
           *-----*-----*-----*
           draw grid. 

           After Grid, intialize contents.
           Each cube is .8 scale size. to centre position of cube need array structure centre. 
        */
        if (this._sizeX != 0 && !gridCreated){
            Vector3 startingPos = new Vector3(0,0,0);
            for(int i = 0; i <_sizeY ; i++){
                
                generate2dCells(true, startingPos);
                generate2dCells(false, startingPos);
                startingPos += new Vector3(0,1.5f,0);
            }
        }
    }

    public void createNonEmptyArray()
    {
        destroyGrid();
        if (this._sizeX !=0 && !gridCreated)
        {   
            Vector3 startingPos = new Vector3(0,0,0);
            for(int i = 0; i <_sizeY ; i++){   
                generate2dCells(true, startingPos);
                generate2dCells(false, startingPos);
                startingPos += new Vector3(0,1.5f,0);
            }
        }
        Vector3 cubeStart = new Vector3(.75f, -.75f, .75f);
        for (int i = 0 ; i < _sizeX; i++)
        {
            // Generate Cubes;
            GameObject newNode = Instantiate(node, cubeStart, Quaternion.identity, cubeStorage.transform);
            contents.Add(newNode);

            Vector3 Ystart = new Vector3(cubeStart[0], cubeStart[1] + 1.5f, cubeStart[2]);
            for (int j = 1; j < _sizeY; j++)
            {
                GameObject newNode2 = Instantiate(node, Ystart, Quaternion.identity, cubeStorage.transform);
                contents.Add(newNode);
                Ystart += new Vector3(0, 1.5f,0);
            }
            cubeStart += new Vector3(1.5f, 0, 0);
        }
    }

    /*
    Purpose: to generate lines for a shape of the array, if front will create the full array shape with lines to connect to the back position. 
    Param: Bool front: if true, generate front cells and connection lines, if false generate only back array
    */
    private void generate2dCells(bool front, Vector3 startPos)
    {       
            Vector3 offset = new Vector3(0,0,1.5f);
            if (front) offset = new Vector3(0,0,0);
            gridCreated = true;
            LineRenderer topline = Instantiate(gridLine, startPos + offset, Quaternion.identity, fullGrid.transform);
            topline.SetPosition(0, startPos + offset);
            topline.SetPosition(1, startPos + new Vector3(_sizeX*1.5f,0,0)+ offset);
            LineRenderer botLine = Instantiate(gridLine, topline.transform.position+ offset, Quaternion.identity, fullGrid.transform);
            botLine.SetPosition(0, startPos + new Vector3(startPos[0], -1.5f, 0)+ offset);
            botLine.SetPosition(1, startPos + new Vector3(_sizeX*1.5f, -1.5f, 0)+ offset);
            
            float posx = startPos[0];
            float posy = startPos[1];
            for (int i = 0; i <_sizeX + 1; i++)
            {
                LineRenderer verticalLine = Instantiate(gridLine, new Vector3(posx, posy, 0)+ offset, Quaternion.identity, fullGrid.transform);
                verticalLine.SetPosition(0, new Vector3(posx, posy, 0) + offset);
                verticalLine.SetPosition(1, new Vector3(posx, posy - 1.5f, 0)+ offset);
                

                // do connection bars
                if (front)
                {
                    LineRenderer connectionLine = Instantiate(gridLine, new Vector3(posx, posy,0), Quaternion.identity, fullGrid.transform);
                    connectionLine.SetPosition(0, new Vector3(posx, posy,0));
                    connectionLine.SetPosition(1, new Vector3(posx, posy, 1.5f));
                    LineRenderer connectionLine2 = Instantiate(gridLine, new Vector3(posx, posy -1.5f, 0), Quaternion.identity, fullGrid.transform);
                    connectionLine2.SetPosition(0, new Vector3(posx, posy -1.5f, 0));
                    connectionLine2.SetPosition(1, new Vector3(posx,posy -1.5f, 1.5f));
                }
                posx += 1.5f;
            }
    }

    private void destroyGrid()
    {
        if (fullGrid)
        {
            foreach (Transform child in fullGrid.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        gridCreated = false;
        if (cubeStorage)
        {
            foreach(Transform child in cubeStorage.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        if (contents.Count > 0)
        {
            contents.Clear();
        }
    }

}
