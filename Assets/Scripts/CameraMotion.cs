using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
	oldPosition = this.transform.position;
	        
    }
    
    Vector3 oldPosition;

    // Update is called once per frame
    void Update()
    {
    
    // TODO : code to click and Drag Camera
    // WASD zooom in and out
        CheckIfCameraMoved();
    }
    
    public void PanToHex(Hex hex) 
    {
    
    	// Move Camera to Hex
    
    }
    
    public void CheckIfCameraMoved() 
    {
    	if(oldPosition != this.transform.position)
    	{
    		// Something Moved the camera
    		oldPosition = this.transform.position;
 HexComponent[] hexes = GameObject.FindObjectsOfType<HexComponent>();
    		
    		foreach(HexComponent hex in hexes)
    		{
    		hex.UpdatePosition();
    		}
    	}
    }
}
