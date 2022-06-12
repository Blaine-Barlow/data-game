using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour
{

    private int _sizeX = 0;
    private int _sizeY = 0;
    // private int _dimensions = 0;
    private Transform tm;
    private GameObject[] contents;

    public LineRenderer gridLine;

    private bool gridCreated = false;
    public GameObject fullGrid;

    void Start() {
        tm = this.GetComponent<Transform>();
        // fullGrid = Instantiate(new GameObject("Array Grid"), new Vector3(0,0,0), Quaternion.identity);
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
    Param: dimensions: int 1,2 for 1D or 2D array
    Param: sizeX length in the X direction of array
    Param: sizeY length in the Y direction of array
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
        // GameObject line1 = Instantiate(line, bottomConn.transform.position, Quaternion.identity, this.transform);
        // LineRenderer lRend = line1.GetComponent<LineRenderer>();
        // lRend.SetPosition(0, bottomConn.transform.position);
        // lRend.SetPosition(1, bottomConn.transform.position + new Vector3(0,-1,0));
        // create a line from (0,0,0) to end of array. 
        if (this._sizeX != 0 && !gridCreated){
            generate2dCells(true);
            generate2dCells(false);
        }
    }

    private void generate2dCells(bool front)
    {       
            Vector3 offset =new Vector3(0,0,1.5f);
            if (front) offset = new Vector3(0,0,0);
            gridCreated = true;
            LineRenderer topline = Instantiate(gridLine, new Vector3(0,0,0) + offset, Quaternion.identity, fullGrid.transform);
            topline.SetPosition(0, fullGrid.transform.position+ offset);
            topline.SetPosition(1, fullGrid.transform.position + new Vector3(_sizeX*1.5f,0,0)+ offset);
            LineRenderer botLine = Instantiate(gridLine, topline.transform.position+ offset, Quaternion.identity, fullGrid.transform);
            botLine.SetPosition(0, fullGrid.transform.position + new Vector3(fullGrid.transform.position.x, -1.5f, 0)+ offset);
            botLine.SetPosition(1, fullGrid.transform.position + new Vector3(_sizeX*1.5f, -1.5f, 0)+ offset);
            
            float posx = fullGrid.transform.position.x;
            float posy = fullGrid.transform.position.y;
            for (int i = 0; i <_sizeX + 1; i++)
            {


                LineRenderer verticalLine = Instantiate(gridLine, new Vector3(posx,0,0)+ offset, Quaternion.identity, fullGrid.transform);
                verticalLine.SetPosition(0, new Vector3(posx, 0,0)+ offset);
                verticalLine.SetPosition(1, new Vector3(posx, -1.5f, 0)+ offset);
                

                // do connection bars
                if (front)
                {
                    LineRenderer connectionLine = Instantiate(gridLine, new Vector3(posx,0,0), Quaternion.identity, fullGrid.transform);
                    connectionLine.SetPosition(0, new Vector3(posx, 0,0));
                    connectionLine.SetPosition(1, new Vector3(posx, 0, 1.5f));
                    LineRenderer connectionLine2 = Instantiate(gridLine, new Vector3(posx, -1.5f, 0), Quaternion.identity, fullGrid.transform);
                    connectionLine2.SetPosition(0, new Vector3(posx, -1.5f, 0));
                    connectionLine2.SetPosition(1, new Vector3(posx, -1.5f, 1.5f));
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
    }

    public void createInitializedArray(int size, GameObject type)
    {
        contents = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            contents[i] = type;
        }
    }
}
