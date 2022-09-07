using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrackBase : MonoBehaviour
{
    public GameObject[] groupA;
    public GameObject[] groupB;
    public GameObject[] groupC;
    public GameObject[] groupD;
    public GameObject[] groupE;
    public GameObject[] groupF;
    public GameObject[] groupG;
    public GameObject[] groupH;
    public List<GameObject> subsidiaryTracks = new List<GameObject>();
    public List<GameObject> currentTracks = new List<GameObject>();

    public float startTime;
    [SerializeField]
    public bool canMoveTracks;
    public Vector3 createConstantPos;
    public Vector3 createPos;
    public Vector3 offset;
    public Vector3 parentRefer;

    public int amountToTrackPool;
    public int index;


    private void OnEnable()
    {
        EventManager.OnIndexLoad.AddListener(CreateTrack);
        EventManager.OnPlayerStartedRunning.AddListener(() => canMoveTracks = true);
        EventManager.OnPreLevelFail.AddListener(() => canMoveTracks = false);
    }

    private void OnDisable()
    {
        EventManager.OnIndexLoad.RemoveListener(CreateTrack);
        EventManager.OnPlayerStartedRunning.RemoveListener(() => canMoveTracks = true);
        EventManager.OnPreLevelFail.RemoveListener(() => canMoveTracks = false);
    }

    void Awake()
    {
        GameObject obj;
        for (int i = 0; i < amountToTrackPool; i++) 
        {
            for (int a = 0; a < groupA.Length; a++)
            {
                obj = (GameObject)Instantiate(groupA[a]);
                obj.SetActive(false); 
                subsidiaryTracks.Add(obj);   
            }
        }
        for (int i = 0; i < amountToTrackPool; i++) 
        {
            for (int b = 0; b < groupB.Length; b++)
            {
                obj = (GameObject)Instantiate(groupB[b]);
                obj.SetActive(false); 
                subsidiaryTracks.Add(obj);   
            }
        }
        for (int i = 0; i < amountToTrackPool; i++) 
        {
            for (int c = 0; c < groupC.Length; c++)
            {
                obj = (GameObject)Instantiate(groupC[c]);
                obj.SetActive(false); 
                subsidiaryTracks.Add(obj);   
            }
        }
        for (int i = 0; i < amountToTrackPool; i++) 
        {
            for (int d = 0; d < groupD.Length; d++)
            {
                obj = (GameObject)Instantiate(groupD[d]);
                obj.SetActive(false); 
                subsidiaryTracks.Add(obj);   
            }
        }
        for (int i = 0; i < amountToTrackPool; i++) 
        {
            for (int e = 0; e < groupE.Length; e++)
            {
                obj = (GameObject)Instantiate(groupE[e]);
                obj.SetActive(false); 
                subsidiaryTracks.Add(obj);   
            }
        }
        for (int i = 0; i < amountToTrackPool; i++) 
        {
            for (int f = 0; f < groupF.Length; f++)
            {
                obj = (GameObject)Instantiate(groupF[f]);
                obj.SetActive(false); 
                subsidiaryTracks.Add(obj);   
            }
        }
        for (int i = 0; i < amountToTrackPool; i++) 
        {
            for (int g = 0; g < groupG.Length; g++)
            {
                obj = (GameObject)Instantiate(groupG[g]);
                obj.SetActive(false); 
                subsidiaryTracks.Add(obj);   
            }
        }
        for (int i = 0; i < amountToTrackPool; i++) 
        {
            for (int h = 0; h < groupH.Length; h++)
            {
                obj = (GameObject)Instantiate(groupH[h]);
                obj.SetActive(false); 
                subsidiaryTracks.Add(obj);   
            }
        }
    }

    
    private void Update()
    {
        if (!canMoveTracks)
            return;

        MoveTrackObjects();
    }

    void LateUpdate() 
    {
        if (!canMoveTracks)
            return;

        ManageTracks();
    }

    private float speed;
    public void MoveTrackObjects()
    {
        speed = TrackManager.Instance.speed;

        parentRefer = new Vector3(PosReferance.mainPosition.x + 97, PosReferance.mainPosition.y, PosReferance.mainPosition.z);
        for (int i = 0; i < subsidiaryTracks.Count; i++)
        {
            subsidiaryTracks[i].transform.position += Vector3.back * speed * Time.deltaTime;
            parentRefer.z = subsidiaryTracks[i].transform.position.z;

            subsidiaryTracks[i].transform.position = parentRefer;

        }
    }

    public void ManageTracks()
    {
        for (int i = 0; i < subsidiaryTracks.Count; i++)
        {
            if(subsidiaryTracks[i].activeInHierarchy)
            {
                if(subsidiaryTracks[i].transform.position.z < -35)
                {
                    DisposeTrack(i);
                    CreateTrack();
                }
            }
        }
    }

    public void DisposeTrack(int trackObject)
    {
        subsidiaryTracks[trackObject].SetActive(false);
    }

    public virtual void CreateTrack()
    {
        offset = Vector3.zero;//Vector3.down;
        createPos = PosReferance.mainPosition + offset;
        GameObject t = GetTrack();

            if(subsidiaryTracks != null)
            {
                if (subsidiaryTracks.Count > 0)
                {
                    createPos = createPos + Vector3.forward * 50f;
                }
            }

            createPos.y = 0;
            t.transform.position = createPos;
            t.SetActive(true);
    }

    public abstract GameObject GetTrack();
}
