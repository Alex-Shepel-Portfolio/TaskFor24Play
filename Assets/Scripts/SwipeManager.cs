using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeManager : Singleton<SwipeManager>
{
    public float swipeDelta;
    private Vector2 startTouch;

   private Vector2 TouchPosition() { return Input.mousePosition; }

    public delegate void MoveDelegate(float dir);
    public MoveDelegate MoveEvent;

    bool TouchBegan() { return Input.GetMouseButtonDown(0); }

    bool GetTouch() { return Input.GetMouseButton(0); }

    private void Update()
    {
        swipeDelta = 0;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (TouchBegan())
        { 
            startTouch = TouchPosition();

        }
        else if (GetTouch())
        {
            
                swipeDelta = TouchPosition().x - startTouch.x;
                SendSwipe();
            
            
        }
    }

    private void SendSwipe()
    {
        Debug.Log("Swipe = " + swipeDelta);
        MoveEvent?.Invoke(swipeDelta);
        ResetToch();
    }

    private void ResetToch()
    {
        startTouch = Vector2.zero;
        swipeDelta = 0;
    }
}
