using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex {

public Hex (int q, int r) 
 {
   
 	this.Q = q;
 	this.R = r;
 	this.S = -(q + r);	
 }  
 

 public readonly int Q;// Colum
 public readonly int R;  // rOW
 public readonly int S;

bool AllowWrapEastWest = true;
bool AllowWrapNorthSouth = false;


// Mapa Generation and Game Effects
public float Elevation;
public float Moisture;
float radius = 1f;

public readonly HexGenerate HexGenerate;
	// Q + R +S = 0
	// S = - (Q + R)	
static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;	
	
	
 
 public Vector3 Position() 
 {
 	
	// Return the word Position 
	
	return new Vector3(
	HexHorizontalSpacing() * (this.Q + this.R/2f), 0, HexVerticalSpacing() * this.R	
	);
 } 
 
 public float HexHeight()
 {
 	return radius * 2;
 }
 
 public float HexWidth() 
 {
	return WIDTH_MULTIPLIER * HexHeight();
 }
 
 public float HexVerticalSpacing() 
 {
 	return HexHeight() * 0.75f;
 }
 
 public float HexHorizontalSpacing()
 {
 	return HexWidth();
 }
 
 
 
 
 public Vector3 PositionFromCamera(Vector3 cameraPosition, float numRows, float numColumns) 
{
        float mapHeight = numRows * HexVerticalSpacing();
        float mapWidth  = numColumns * HexHorizontalSpacing();

        Vector3 position = Position();
        float howManyWidthFromCamera = (position.x - cameraPosition.x ) / mapWidth;

        if(howManyWidthFromCamera > 0)
            howManyWidthFromCamera += 0.5f;
        else 
            howManyWidthFromCamera -= 0.5f;

        int howManyWidthToFix = (int)howManyWidthFromCamera;

        position.x -= howManyWidthToFix * mapWidth;
        return position;
    }

}
