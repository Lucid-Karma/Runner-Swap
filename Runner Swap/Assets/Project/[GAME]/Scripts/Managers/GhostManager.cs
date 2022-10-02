using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : Singleton<GhostManager>
{
    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;


    public Vector3 createPos;
    public Vector3 parentRefer;
    public Vector3 offset;
    public bool canMoveGhost;


    private void OnEnable()
    {
        EventManager.OnRightMove.AddListener(SpecificPosr);
        EventManager.OnLeftMove.AddListener(SpecificPosl);
        EventManager.OnPlayerStartedRunning.AddListener(() => canMoveGhost = true);
        EventManager.OnLevelFail.AddListener(() => canMoveGhost = false);
    }

    private void OnDisable()
    {
        EventManager.OnRightMove.RemoveListener(SpecificPosr);
        EventManager.OnLeftMove.RemoveListener(SpecificPosl);
        EventManager.OnPlayerStartedRunning.RemoveListener(() => canMoveGhost = true);
        EventManager.OnLevelFail.RemoveListener(() => canMoveGhost = false);
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++) 
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }

        control = 0;
    }

    void Update()
    {
        if (!canMoveGhost)
            return;

        MoveGhostObjects();
        ManageGhosts();
    }

    public GameObject GetPooledObject() 
    {
        for (int i = 0; i < pooledObjects.Count; i++) 
        {
            if (!pooledObjects[i].activeInHierarchy) 
            {
                return pooledObjects[i];
            }
        }
        
        return null;
    }

    public void GetGhost(Vector3 GhostPos)   
    {
        createPos = GhostPos;
        GameObject ghost = GetPooledObject();

        if(ghost != null)
        {
            ghost.transform.position = createPos;
            ghost.SetActive(true);
        }
    }

    private float speed;
    public void MoveGhostObjects()
    {
        speed = TrackManager.Instance.speed;

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            pooledObjects[i].transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }

    public int control;
    private void SpecificPosr()
    {
        if(control != 1)
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {             
                if(pooledObjects[i].activeInHierarchy)
                {
                    float xPosOfCoin = pooledObjects[i].transform.position.x;

                    pooledObjects[i].transform.localPosition = pooledObjects[i].transform.position - new Vector3(100, 0, 0);
                }               
            }
            control ++;
        }
    }
    private void SpecificPosl()
    {
        if(control != -1)
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if(pooledObjects[i].activeInHierarchy)
                {
                    float xPosOfCoin = pooledObjects[i].transform.position.x;

                    pooledObjects[i].transform.localPosition = pooledObjects[i].transform.position + new Vector3(100, 0, 0);
                }               
            }
            control --;
        }
    }

    public void ManageGhosts()   
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                if(pooledObjects[i].transform.position.z < -35)
                {
                    DisposeGhost(i);
                }   
            }
        }
    }

    public void DisposeGhost(int ghostObject)
    {
        pooledObjects[ghostObject].SetActive(false);
    }
}
