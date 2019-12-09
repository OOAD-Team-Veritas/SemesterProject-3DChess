using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//overly complicated faw to rotate the board using Quaternions...
public class RotateBoard : MonoBehaviour
{
    private Quaternion from;     //Previous Quaternion
    private Quaternion to;       //The New Quaternion
    public bool rotate;         //Toggles the rotation
    private bool waitTillFinished;  //When set to true, waits until rotation is done        
    private float time;
    public int frameCount;      //How many frames to rotate

    // Start is called before the first frame update
    void Start()
    {
        rotate = false;
        waitTillFinished = false;
        frameCount = 0;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotate)
        {
            rotate = false;
            to = Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y + 180f, gameObject.transform.rotation.eulerAngles.z);
            from = Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z);
            waitTillFinished = true;
        }

        if(waitTillFinished == true)
        {
            rotateBoard();
            frameCount++;
            time += 300*Time.deltaTime;
            if (frameCount > 50)
            {
                waitTillFinished = false;
                time = 0;
                frameCount = 0;
            }
        }
    }

    private void rotateBoard()
    {
        transform.rotation = Quaternion.RotateTowards(from, to, time);
    }

    public void rotateAction()
    {
        rotate = true;
    }
}
