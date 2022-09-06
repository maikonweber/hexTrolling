using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject prefab;
    public int numPlayer = 2;
    // Start is called before the first frame update
    void Start()
    {


        GameObject newPlayer = (GameObject)Instantiate(
   	   	prefab, 
   	   	new Vector3(0, 10, 0),
   	   	Quaternion.identity
   	   	);

        newPlayer.AddComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
