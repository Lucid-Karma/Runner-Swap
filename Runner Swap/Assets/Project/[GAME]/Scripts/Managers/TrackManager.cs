using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random=UnityEngine.Random;

public class TrackManager : Singleton<TrackManager>
{
    public GameObject[] mainTracks;
    public List<GameObject> Tracks = new List<GameObject>();

    private float startTime;
    public float speed;
    [SerializeField]
    private bool canMoveTracks;
    public bool isLevelStarted;
    public Vector3 createPos;
    public Vector3 offset;
    public Vector3 parentRefer;


    public int index;
    public int amountToTrackPool;

    public static Action OnTrackCreate;
    


    private void OnEnable()
    {
        //EventManager.OnLevelStart.AddListener(CreateTrackFirst);
        EventManager.OnPlayerStartedRunning.AddListener(() => canMoveTracks = true);
        EventManager.OnLevelFail.AddListener(() => canMoveTracks = false);
        EventManager.OnGameStart.AddListener(() => Debug.Log("has been started"));
    }

    private void OnDisable()
    {
        //EventManager.OnLevelStart.RemoveListener(CreateTrackFirst);
        EventManager.OnPlayerStartedRunning.RemoveListener(() => canMoveTracks = true);
        EventManager.OnLevelFail.RemoveListener(() => canMoveTracks = false);
        EventManager.OnGameStart.RemoveListener(() => Debug.Log("has been started"));
    }


    void Awake()
    {
        for (int i = 0; i < 8; i++) 
        {
            for (int j = 0; j < amountToTrackPool; j++)
            {
                GameObject obj = (GameObject)Instantiate(mainTracks[i]);
                obj.SetActive(false); 
                Tracks.Add(obj);   
            }
        }

        CreateTrackFirst();
        isLevelStarted = true;
    }

    void Start()
    {
        speed = 20f;
    }

    private bool isItFirst = true;
    public GameObject GetRandomPooledTrack()
    {
        for (int i = 0; i < Tracks.Count; i++) 
        {
            index = Random.Range(0, Tracks.Count);
            if (!Tracks[index].activeInHierarchy) 
            {
                try
                {
                    if (isItFirst)
                    {
                        index = 39;
                        isItFirst = false;
                        return Tracks[index];
                    }
                    return Tracks[index];
                }
                catch (System.Exception ex)
                {
                    Debug.LogError("Can't find a track prefab " + ex.ToString());
                    return null;
                }
            }
        }
        
        return null;
    }

    public void RestartIndex()
    {
        index = 7;
    }

    private void Update()
    {
        if (!canMoveTracks)
            return;

        MoveTrackObjects();
        ManageTracks();
    }
    //public float speed;
    private void MoveTrackObjects()
    {
        parentRefer = PosReferance.mainPosition;

        for(int i = 0; i < Tracks.Count; i++)
        {
            Tracks[i].transform.position += Vector3.back * speed * Time.deltaTime;
            parentRefer.z = Tracks[i].transform.position.z;

            Tracks[i].transform.position = parentRefer;
        }
    }

    private void ManageTracks()
    {
        for (int i = 0; i < Tracks.Count; i++)
        {
            if (Tracks[i].activeInHierarchy)
            {
                if(Tracks[i].transform.position.z < -35)
                {
                    DisposeTrack(i);
                    CreateTrack();
                }   
            }
        }
    }
    public void DisposeTrack(int trackObject)
    {
        Tracks[trackObject].SetActive(false);
    }

    public void CreateTrack()
    {
        parentRefer.x = PosReferance.mainPosition.x;
        parentRefer.z = Tracks[index].transform.position.z;
        GameObject t = GetRandomPooledTrack();

            if(Tracks != null)
            {
                if (Tracks.Count > 0)
                {
                    createPos = parentRefer + Vector3.forward * 50f;
                }
            }

            createPos.y = 0;
            t.transform.position = createPos;
            t.SetActive(true);    
            OnTrackCreate?.Invoke();     
    }

    public void CreateTrackFirst()
    {
        createPos = Vector3.zero;//Vector3.down;

        for (int i = 0; i < 5; i++)
        {
           GameObject t = GetRandomPooledTrack();

            if(Tracks != null)
            {
                if (Tracks.Count > 0 && i != 0)
                {
                    createPos = createPos + Vector3.forward * 50f;
                }
            }

            createPos.y = 0;
            t.transform.position = createPos;
            t.SetActive(true); 
            EventManager.OnIndexLoad.Invoke();
        }
    }
}
