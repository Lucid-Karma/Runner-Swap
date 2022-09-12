using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Camera mainCamera;
	public Camera MainCamera 
	
	{
        get
        {
            if(mainCamera == null)
			{
				mainCamera = GetComponent<Camera>();
			}

            return mainCamera;
        }
    }

    void OnEnable()
    {
        //EventManager.OnCenterMove.AddListener(Center);
        EventManager.OnLeftMove.AddListener(Color);
        EventManager.OnRightMove.AddListener(Color);

    }
    void OnDisable()
    {
        //EventManager.OnCenterMove.RemoveListener(Center);
        EventManager.OnLeftMove.RemoveListener(Color);
        EventManager.OnRightMove.RemoveListener(Color);
    }

    void Start()
    {
        /*centerColor = new Color(178, 52, 61, 1);
        leftColor = new Color(19, 19, 19, 1);
        rightColor = new Color(61, 121, 167, 1);*/
        MainCamera.clearFlags = CameraClearFlags.SolidColor;
    }

    /*private void Center()
    {
        MainCamera.backgroundColor = new Color(178, 52, 61, 1);
    }
    private void Left()
    {
        MainCamera.backgroundColor = new Color(19, 19, 19, 1);
    }
    private void Right()
    {
        MainCamera.backgroundColor = new Color(61, 121, 167, 1);
    }*/

    private void Color()
    {
        if(SwipeController.isItRight)
        {
            MainCamera.backgroundColor = rightColor;
        }
        else if(SwipeController.isItLeft)
        {
            MainCamera.backgroundColor = leftColor;
        }
        else if(SwipeController.isItCenter)
        {
            MainCamera.backgroundColor = centerColor;
        }
    }

    public Color centerColor;
    public Color leftColor;
    public Color rightColor;
}
