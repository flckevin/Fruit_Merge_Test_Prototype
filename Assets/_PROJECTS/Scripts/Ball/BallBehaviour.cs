using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public SpriteRenderer spriteRend;   //sprite renderer so the player can access the sprite
    public float currentScale;          //store the current scale so the indicator can change size
                                        //disclamer i only do this because i don't have art with dynamic size
    public int ballID;                  //ball ID so it can identify whether it hit another has the same ID

    void Awake()
    {
        //setting this object tag to ball
        this.gameObject.tag = "Ball";
    }

    // Start is called before the first frame update
    void Start()
    {
        BallInitializer();
    }

    /// <summary>
    /// function to initialize ball behaviour
    /// </summary>
    private void BallInitializer()
    {
        //================ GET ================
        spriteRend = GetComponent<SpriteRenderer>();
        currentScale = this.transform.localScale.x;
        //================ GET ================

        //================ SET ================
        //================ SET ================
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if the ball collided with a ball has tag ball
        if(collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("SHIT HIT TAG");
            //get that ball behaviour class
            BallBehaviour _collidedBall = collision.gameObject.GetComponent<BallBehaviour>();
            //if the ball collided with a ball has same id
            if(ballID < BallDataManager.Instance.maxBall && ballID == _collidedBall.ballID)
            {
                Debug.Log("SHIT HIT ID");
                //tell that ball to upgrade
                _collidedBall.UpgradeBall();
                //self deactivate
                this.gameObject.SetActive(false);
            }
        }
    }


    /// <summary>
    /// function to upgrade the ball
    /// </summary>
    private void UpgradeBall()
    {
        //increase ball id
        ballID++;

        spriteRend.sprite = BallDataManager.Instance.BallBehaviourPrefabData[ballID].spriteRend.sprite;
        currentScale = BallDataManager.Instance.BallBehaviourPrefabData[ballID].currentScale;
        this.transform.localScale = new Vector2(currentScale,currentScale);
    }


}
