using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer nextBall;     //the object to indicate our next ball
    public SpriteRenderer aimSprite;    //Image of aim
    public bool ableToControl;          //determine whether the player able to control
    //============================ PRIVATE VAR ============================
    private string[] _allBallID = new string[]   
    {
        "Apple",
        "Dragonfruit",
        "Olive",
        "Onion"
    };                      //all of the fruit ID so we can access it through pool

    private Camera _cam;    //camera so that we can convert from touch to game world position

    public int _currentFruitID;
    //============================ PRIVATE VAR ============================

    // Start is called before the first frame update
    void Start()
    {
        ControlerInitializer();
        Debug.Log(_allBallID.Length);
    }


    /// <summary>
    /// initializer for controller
    /// </summary>
    private void ControlerInitializer()
    {
        //set able to control to true
        ableToControl = true;
        //if camera is empty then get main camera
        if(_cam == null) _cam = Camera.main;
        //set default value for current fruit ID
        _currentFruitID = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if(ableToControl == false) return;
        FruitController();
    }


    /// <summary>
    /// function to handle all the in game control
    /// </summary>
    private void FruitController()
    {
        //if there is touch
        if(Input.touchCount > 0)
        {
            //get that touch
            Touch _touch = Input.GetTouch(0);
            //if the player just touch the screen
            if(_touch.phase == TouchPhase.Began)
            {
                //get new position from touch
                Vector2 _pos = _cam.ScreenToWorldPoint(_touch.position);
                //move the ball position to the touched position
                nextBall.transform.position = new Vector2(Mathf.Clamp(_pos.x,-1.5f,1.5f),nextBall.transform.position.y);
                //enable aim image
                if(aimSprite != null) aimSprite.enabled = true;
            }
            else if(_touch.phase == TouchPhase.Moved)
            {
                //get new position from touch
                Vector2 _pos = _cam.ScreenToWorldPoint(_touch.position);
                //move the ball position to the touched position
                nextBall.transform.position = new Vector2(Mathf.Clamp(_pos.x,-1.5f,1.5f),nextBall.transform.position.y);
            }
            else if(_touch.phase == TouchPhase.Ended)
            {
                //disable aim image
                if(aimSprite != null) aimSprite.enabled = false;
                FruitLauncher();
            }

        }
    }


    /// <summary>
    /// function to launch fruit down toward
    /// </summary>
    private void FruitLauncher()
    {
        //get ball from pool
        BallBehaviour _ballBehave = QuocAnhPoolManager.GetItem<BallBehaviour>(_allBallID[_currentFruitID]);
        //re locate ball to the correct position
       _ballBehave.transform.position = nextBall.transform.localPosition;
       //enable it
       _ballBehave.gameObject.SetActive(true);
       //increase the fruit id
       _currentFruitID = UnityEngine.Random.Range(0,4);
       //change the next fruit icon
       nextBall.sprite = QuocAnhPoolManager.GetItem<BallBehaviour>(_allBallID[_currentFruitID]).spriteRend.sprite;
       //set new suitable scale that base on next fruit to display for the player how big is the fruit
       nextBall.transform.localScale = new Vector2(QuocAnhPoolManager.GetItem<BallBehaviour>(_allBallID[_currentFruitID]).currentScale,
                                                    QuocAnhPoolManager.GetItem<BallBehaviour>(_allBallID[_currentFruitID]).currentScale);
    }
}
