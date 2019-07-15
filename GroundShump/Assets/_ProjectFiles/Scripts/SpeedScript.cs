using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float mySpeed;
    public float minSpeed;
    public float maxSpeed;
    public bool isRandom;

    void Awake() {
   if (isRandom) {
            mySpeed = Random.Range(minSpeed,maxSpeed);
        } else {
            mySpeed = maxSpeed;
        }
    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
