using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadsMoving : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Material leftTread;
    [SerializeField] private Material rightTread;
    private float leftTreadYOffsetPos = 0f;
    private float rightTreadYOffsetPos = 0f;
    

    private void Update()
    {
        if (leftTread == null || rightTread == null) {return;}

        int leftTreadDir = 0;
        int rightTreadDir = 0;

        if (Input.GetKey(KeyCode.W))
        {
          leftTreadDir = -1;
          rightTreadDir = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
          leftTreadDir = 1;
          rightTreadDir = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
          leftTreadDir = 1;
          rightTreadDir = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
          leftTreadDir = -1;
          rightTreadDir = 1;
        }

        TrackScrolling(leftTreadDir, rightTreadDir);
    }
     
    private void TrackScrolling(int leftDir, int rightDir) 
    { 
      leftTreadYOffsetPos = (leftTreadYOffsetPos + (speed*Time.deltaTime * leftDir)) % 1; 
      rightTreadYOffsetPos = (rightTreadYOffsetPos + (speed*Time.deltaTime * rightDir)) % 1; 
      // If you use Build-in pipeline use this code:
      leftTread.mainTextureOffset = new Vector2(0, leftTreadYOffsetPos);  //Comment this if you use URP pipeline
      rightTread.mainTextureOffset = new Vector2(0, rightTreadYOffsetPos);  //Comment this if you use URP pipeline
      // If you use URP pipeline use this code:
      //leftTread.SetVector("_UvOffset", new Vector2(0, leftTreadYOffsetPos));  //Uncomment this if you use URP pipeline
      //rightTread.SetVector("_UvOffset", new Vector2(0, rightTreadYOffsetPos));  //Uncomment this if you use URP pipeline
    } 
}
