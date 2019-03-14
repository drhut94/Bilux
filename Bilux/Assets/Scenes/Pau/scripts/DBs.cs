using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class DBs : MonoBehaviour
{
    GridBrushBase brush;
    public Tilemap dbs; 
    public GridLayout gridLayout;
    public Mov player;

    public Vector3 location;
    Vector3Int pos;
    public Vector3Int locCell;
    
    // Use this for initialization
	void Start () {
    }
        
    // Update is called once per frame
    void Update () {        
        //Debug.Log(pos);
        //Debug.Log("loc"+ location);
        Debug.Log(player.transform.position);
	}
        
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
        gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        pos = gridLayout.WorldToCell(player.transform.position);
        location = gridLayout.CellToWorld(pos);
        locCell = Vector3Int.FloorToInt(location);
        brush.Erase(gridLayout, dbs.gameObject, locCell);
        }
            
    }


}
