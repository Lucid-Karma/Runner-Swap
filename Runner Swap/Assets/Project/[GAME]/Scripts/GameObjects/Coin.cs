using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Coin SharedInstance;

    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;


    public Vector3 createPos;
    public Vector3 parentRefer;
    public Vector3 offset;
    public bool canMoveCoins;
    public int targetCoinCount;
    public int[] coinPosX;
    public int[] coinPosY;


    void Awake() 
    {
        SharedInstance = this;

        coinPosX = new int[] {-3, 0, 3};
        coinPosY = new int[] {1, 4};

        GetCoinFirstTime();
    }

    private void OnEnable()
    {
        EventManager.OnRightMove.AddListener(SpecificPosr);
        EventManager.OnLeftMove.AddListener(SpecificPosl);
        //EventManager.OnLevelStart.AddListener(GetCoinFirstTime);
        EventManager.OnPlayerStartedRunning.AddListener(() => canMoveCoins = true);
        EventManager.OnLevelFail.AddListener(() => canMoveCoins = false);
        TrackManager.OnTrackCreate += GetCoin;
    }

    private void OnDisable()
    {
        EventManager.OnRightMove.RemoveListener(SpecificPosr);
        EventManager.OnLeftMove.RemoveListener(SpecificPosl);
        //EventManager.OnLevelStart.RemoveListener(GetCoinFirstTime);
        EventManager.OnPlayerStartedRunning.RemoveListener(() => canMoveCoins = true);
        EventManager.OnLevelFail.RemoveListener(() => canMoveCoins = false);
        TrackManager.OnTrackCreate -= GetCoin;
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
        if (!canMoveCoins)
            return;

        MoveCoinObjects();
        ManageCoins();
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

    public void GetCoin()   
    {
        targetCoinCount = Random.Range(4, 10);
        createPos = GetCoinPosition();
        for (int i = 0; i < targetCoinCount; i++)
        {
            GameObject coin = GetPooledObject();

            if(coin != null)
            {
                coin.transform.position = createPos;
                createPos = createPos + new Vector3(0, 0, 2);
                coin.SetActive(true);
            }
        }
    }

    public Vector3 GetCoinPosition()
    {
        
        int x = Random.Range(0, 3);
        int y = Random.Range(0, 2);
        offset = new Vector3(coinPosX[x] + PosReferance.coinPosition.x, coinPosY[y], 115);//lastTracksPosition.z);
        return offset;
    }

    private float speed;
    public void MoveCoinObjects()
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

                    pooledObjects[i].transform.localPosition = pooledObjects[i].transform.position - new Vector3(3, 0, 0);
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

                    pooledObjects[i].transform.localPosition = pooledObjects[i].transform.position + new Vector3(3, 0, 0);
                }               
            }
            control --;
        }
    }

    public void ManageCoins()   
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                if(pooledObjects[i].transform.position.z < -35)
                {
                    DisposeCoin(i);
                }   
            }
        }
    }

    public void DisposeCoin(int coinObject)
    {
        pooledObjects[coinObject].SetActive(false);
    }

    public void DisposeOnTrigger(Collider coinCollider)
    {
        coinCollider.gameObject.SetActive(false);
    }

    public void GetCoinFirstTime()   
    {
        for (int j = 0; j < 4; j++)
        {
            targetCoinCount = Random.Range(4, 10);
            createPos = GetCoinPositionFirstTime();
            for (int i = 0; i < targetCoinCount; i++)
            {
                GameObject coin = GetPooledObject();

                if(coin != null)
                {
                    createPos = createPos + new Vector3(0, 0, 2);
                    coin.transform.position = createPos;
                    coin.SetActive(true);
                }
            }   
        }
    }

    public Vector3 GetCoinPositionFirstTime()
    {
        
        int x = Random.Range(0, 3);
        int y = Random.Range(0, 2);
        offset = new Vector3(coinPosX[x] + PosReferance.coinPosition.x, coinPosY[y], Random.Range(15, 115));//lastTracksPosition.z)); //Random.Range(15, 135));
        return offset;
    }
}
