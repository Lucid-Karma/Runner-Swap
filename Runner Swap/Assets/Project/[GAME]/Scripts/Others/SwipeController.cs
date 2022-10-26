using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwipeController : MonoBehaviour
{
    private Rigidbody rigidb;
	public Rigidbody Rigidb 
	
	{
        get
        {
            if(rigidb == null)
			{
				rigidb = GetComponent<Rigidbody>();
			}

            return rigidb;
        }
    }


    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private float heightChange;
    private float differance;

    public static bool isItRight, isItLeft, isItCenter, isItUp;

    void Awake()
    {
        isItRight = false;
        isItLeft = false;
        isItCenter = true;
        isItUp = false;
    }

    public Vector3 jump;
    public float jumpForce = 2.0f;
    void Start()
    {
        DOTween.Init();

        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    public Vector2 direction;
    void Update()
    {

        if(transform.position.y <= 0f)
        {
            transform.position = Vector3.zero;
        }

        if(GameManager.Instance.IsLevelStarted)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startTouchPosition = touch.position;
                        break;

                    case TouchPhase.Moved:
                        direction = touch.position - startTouchPosition;
                        break;

                    case TouchPhase.Ended:
                        endTouchPosition = touch.position;
                        heightChange = endTouchPosition.y - startTouchPosition.y;
                        differance = endTouchPosition.x - startTouchPosition.x;

                        if(differance >= 100 && heightChange < 150.0f)
                        {
                            if(isItCenter)
                            {
                                isItCenter = false;
                                isItLeft = false;
                                isItRight = true;
                                //EventManager.OnRightMove.Invoke();
                            }
                            else if(isItLeft)
                            {
                                isItRight = false;
                                isItLeft = false;
                                isItCenter = true;
                                //EventManager.OnCenterMove.Invoke();
                            }

                            EventManager.OnRightMove.Invoke();
                        }
                        else if(differance <= -100 && heightChange < 150.0f)
                        {
                            if(isItCenter)
                            {
                                isItCenter = false;
                                isItRight = false;
                                isItLeft = true;
                                //EventManager.OnLeftMove.Invoke();
                            }
                            else if(isItRight)
                            {
                                isItRight = false;
                                isItLeft = false;
                                isItCenter = true;
                                //EventManager.OnCenterMove.Invoke();
                            }

                            EventManager.OnLeftMove.Invoke();
                        }

                        if(heightChange >= 150.0f && transform.position.y == 0)
                        {
                            duration = 1.2f;
                            EventManager.OnCharacterJump.Invoke();
                            Jump(duration);
                            //Jumpp();
                            //transform.DOLocalMove(new Vector3(0, 4, 0), .6f);//.OnComplete(()=> {transform.DOLocalMove(new Vector3(0, 1, 0), .3f);});
                        }
                        break;
                }
            }
        }
    
    }

    public float duration;
    public Tween Jump(float s)
    {
        return transform.DOJump(new Vector3(0, 0.5f, 0), 4.0f, 1, s).SetEase(Ease.InOutSine)//;//1.2f power and 1.2f duration
                    .OnPlay(()=>{transform.DOLocalMove(transform.position + Vector3.zero, .25f);});
    }

    /*public float jumpforce;
    void Jumpp()
    {
        Vector3 jumpPos = new Vector3(0, 4, 0);
        float t = .1f;
        //Rigidb.AddForce(jump * jumpForce, ForceMode.Impulse);
        //Rigidb.AddForce(0, jumpforce * Time.deltaTime, 0, ForceMode.Impulse);
        transform.position = Vector3.Lerp(Vector3.zero, jumpPos, t);
    }*/
}
