using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeGestures : MonoBehaviour {

    public PlayerController playerController;

    private float startX, StartY, endX, endY;
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging;
    private Vector2 startTouch, swipeDelta;


    public void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0) {
            if (Input.touches[0].phase == TouchPhase.Began) {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                isDragging = false;
                Reset();
            }
        }
        #endregion

        swipeDelta = Vector2.zero;
        if (isDragging) {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0)) {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if (swipeDelta.magnitude > 50) {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            // Swipe Direction
            if(Mathf.Abs(x) > Mathf.Abs(y)) {
                // Left or Right
                if (x < 0) {
                    swipeLeft = true;

                    // For ShapeScape
                    playerController.movePlayer("left");
                }
                else {
                    swipeRight = true;

                    // For ShapeScape
                    playerController.movePlayer("right");
                }
            }
            else {
                // Up or Down
                if (y < 0) {
                    swipeDown = true;

                    // For ShapeScape
                    playerController.movePlayer("down");
                }
                else {
                    swipeUp = true;
                    // For ShapeScape
                    playerController.movePlayer("up");
                }
            }

            Reset();
        }
    }

    public void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

    // Getter Functions
    public Vector2 SwipeDelta {get {return swipeDelta;} }
    public bool SwipeLeft {get {return swipeLeft;} }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
}
