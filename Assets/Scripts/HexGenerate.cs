using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGenerate : MonoBehaviour

{
	void Start() {
    GenerateMap();
  
   }    	

   public GameObject HexPrefab;
   
   public Mesh MeshWater;
   public Mesh MeshFlat;
   public Mesh MeshHill;

   public Mesh MeshMountain;

   public Material MatOcean;
   public Material MatPlains;
   public Material MatGrassLand;
   public Material MatMountains;


   public int numRows = 30;
   public int numColumns = 60;

   //public Player[] Players;
   //int CurrentPlayerIndex = 0;
  //public Player CurrentPlayer {
//	get { return Players[CurrentPlayerIndex]; }
  // }

   private Hex[,] hexes;

   private Dictionary<Hex, GameObject> hexToGameObjectMap;
   
   [System.NonSerialized] public bool AllowWrapEastWest = true;
   [System.NonSerialized] public bool AllowWrapNorthSouth = false;
  
     public Vector3 GetHexPosition(int q, int r)
    {
        Hex hex = GetHexAt(q, r);

        return GetHexPosition(hex);
    }

    public Vector3 GetHexPosition(Hex hex) => hex.PositionFromCamera(Camera.main.transform.position, numRows, numColumns);

    public Hex GetHexAt(int x, int y) 
   {
	if(hexes == null)
        {
            Debug.LogError("Hexes array not yet instantiated.");
            return null;
        }

        // if(AllowWrapEastWest) 
        // {
        //     x = x % numColumns;
        //     if(x < 0)
        //     {
        //         x += numColumns;
        //     }
        // }
        // if (AllowWrapNorthSouth) {
        //     y = y % numRows;
        //     if(y < 0) 
        //     {
        //          y += numRows;
        //     }
        // }
            
            return hexes[x, y];
        }
   

    // Start is called before the first frame update
   virtual public void GenerateMap()
   {

	hexes = new Hex[numRows, numColumns];
	hexToGameObjectMap = new Dictionary<Hex, GameObject>();
	
   	for(int column = 0; column < numColumns; column++) 
   	{
   	   for(int row = 0; row < numRows; row++)
   	   {

   	   	Hex h = new Hex(column, row);
		h.Elevation = -1f;

        
		//hexes[column, row] = h;
		
	
   	   	Vector3 pos = h.PositionFromCamera(
   	   	Camera.main.transform.position,
   	   	numColumns,
   	   	numRows
   	   	);
   	   	
   	   	
   	   	GameObject hexGo = (GameObject)Instantiate(
   	   	HexPrefab, 
   	   	pos,
   	   	new Quaternion(1.0f, 0, 0, 1),
   	   	this.transform
   	   	);

		hexToGameObjectMap[h] = hexGo;

		hexGo.name = string.Format("HEX: {0},{1}, {2}", column, row, h.Elevation);
   	   	var collission = hexGo.AddComponent<BoxCollider>();

		MeshRenderer mr = hexGo.GetComponentInChildren<MeshRenderer>();

		mr.material = MatGrassLand;
	    
		//HexMaterials[Random.Range(0, HexMaterials.Length)];
   	  
   	    // StaticBatchingUtility.Combine( this.gameObject );
   	   }
   	}

	UpdateHexVisuals();
	
	
   	
   }

   public void UpdateHexVisuals()
   {
    for(int column = 0; column < numColumns; column++) 
   	{
   	   for(int row = 0; row < numRows; row++)
   	   {
		Hex h = hexes[column, row];
		GameObject hexGo = hexToGameObjectMap[h];
        MeshRenderer mr = hexGo.GetComponentInChildren<MeshRenderer>();
        MeshFilter mf = hexGo.GetComponentInChildren<MeshFilter>();

        if (h.Elevation >= 0) {
            mr.material = MatOcean;
        } else {
            mr.material = MatGrassLand;
        }   

		//MeshFilter mf = hexGo.GetComponentInChildren<MeshFilter>();
		//mf.mesh = MeshWater;


            }
       }
    }
}
