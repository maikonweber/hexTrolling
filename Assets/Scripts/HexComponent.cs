using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexComponent : MonoBehaviour
{
    // Start is called before the first frame update
    public Hex Hex;
    public HexGenerate HexGenerate;
    
    public void UpdatePosition() 
    {
    	this.transform.position = Hex.PositionFromCamera(
    		Camera.main.transform.position,
    		HexGenerate.numRows, 
    		HexGenerate.numColumns
    	);
    }
}
