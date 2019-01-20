using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideInputManager : MonoBehaviour
{

    public static SlideInputManager instance;

    Vector2 TouchDownPos;   // cooridnates for when user touches down screen
    Vector2 TouchDragPos;   // coordinates of touch being dragged each frame
    Vector2 TouchUpPos;     // coordinates where user lifts finger from screen

    public event Action<Vector2> TouchDownEvent;
    public event Action<Vector2, Vector2> TouchDragEvent;
    public event Action<Vector2, Vector2> TouchUpEvent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            switch (Input.touches[0].phase)
            {
                case TouchPhase.Began:
                    Debug.Log("TouchPhase Began");
                    TouchDownPos = Input.touches[0].position;
                    if (TouchDownEvent != null) TouchDownEvent(TouchDownPos);
                    break;
                case TouchPhase.Moved:
                    Debug.Log("TouchPhase Moved");
                    TouchDragPos = Input.touches[0].position;
                    if (TouchDragEvent != null) TouchDragEvent(TouchDownPos, TouchDragPos);              
                    break;
                case TouchPhase.Ended:
                    Debug.Log("TouchPhase Ended");
                    TouchUpPos = Input.touches[0].position;
                    if (TouchUpEvent != null) TouchUpEvent(TouchDownPos, TouchUpPos);
                    break;
            }
        }
    }
}
