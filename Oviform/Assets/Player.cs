using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform guideOval;
    Vector2 origin;     // origin of oval
    float initAngle;    // intial angle of player on oval
    float halfOvalWidth;
    float halfOvalHeight;

    float swipeRange;   // world length required to be swiped for a full revolution
    float currAngle;    // current angle from + x-axis on oval
    float deltaAngle;   // angle to be moved along oval
    float destAngle;    // destination angle after moving along oval
    float moveFrac;     // fraction between swipe range and swipe delta
    float swipeDeltaX;  // displacement between initial touch and swipe coordinates on x

    const float SCREEN_FRAC = 2f/3f; // see FindSwipeRange() doc


	// Use this for initialization
	void Start ()
    {
        origin = new Vector2(0, 0);
        swipeRange = FindSwipeRange(SCREEN_FRAC);
        initAngle = 0;
        currAngle = initAngle;
        halfOvalWidth = guideOval.localScale.x / 2;
        halfOvalHeight = guideOval.localScale.y / 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ListenForInput()
    {
        // Subscribe to swipe input handler for movement
        SlideInputManager.instance.TouchDragEvent += ChangePos;
        SlideInputManager.instance.TouchUpEvent += SetNewPos;
    }

    public void StopListening()
    {
        // Unsubscribe to swipe input handler
        SlideInputManager.instance.TouchDragEvent -= ChangePos;
    }

    public void ChangePos(Vector2 downPos, Vector2 swipePos)
    {
        swipeDeltaX = swipePos.x - downPos.x;
        moveFrac = swipeDeltaX / swipeRange;
        deltaAngle = moveFrac * (2 * Mathf.PI);
        destAngle = currAngle - deltaAngle;
        gameObject.transform.position = new Vector2(
            origin.x + (halfOvalWidth * Mathf.Cos(destAngle)),
            origin.y + halfOvalHeight * Mathf.Sin(destAngle));
        Debug.Log("ChangePos Called");
    }

    public void SetNewPos(Vector2 downPos, Vector2 upPos)
    {
        currAngle = destAngle;
    }

    // finds the screen length to be swiped to be equivalent to a 360 degree
    // movement of the player along the oval, based on a percentage of the 
    // screen's width, passed as an argument.
    private float FindSwipeRange(float percentOfScreen)
    {
        return Screen.width * percentOfScreen;
    }

    
}
