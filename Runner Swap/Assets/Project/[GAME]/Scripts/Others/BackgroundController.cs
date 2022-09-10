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
        EventManager.OnCenterMove.AddListener(Center);
        EventManager.OnLeftMove.AddListener(Left);
        EventManager.OnRightMove.AddListener(Right);

    }
    void OnDisable()
    {
        EventManager.OnCenterMove.RemoveListener(Center);
        EventManager.OnLeftMove.RemoveListener(Left);
        EventManager.OnRightMove.RemoveListener(Right);
    }

    void Start()
    {
        MainCamera.clearFlags = CameraClearFlags.SolidColor;
    }

    private void Center()
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
    }
}
