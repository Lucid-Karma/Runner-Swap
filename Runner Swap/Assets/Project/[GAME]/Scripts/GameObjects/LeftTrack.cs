using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrack : TrackBase
{
    public int control;
    public override void CreateTrack()
    {
        createPos.x = PosReferance.mainPosition.x - 97f;
        createPos.z = TrackManager.Instance.Tracks[index].transform.position.z;
        GameObject t = GetTrack();

        if(currentTracks != null && control != 0)
        {
            createPos += Vector3.forward * 50f;
        }
        else if(currentTracks != null && control == 0)
        {
            createPos.z = 0;
        }

        createPos.y = 0;
        t.transform.position = createPos;
        t.SetActive(true);
        control = 1;
    }

    public override void MoveTrackObjects()
    {
        speed = TrackManager.Instance.speed;

        parentRefer = new Vector3(PosReferance.mainPosition.x - 97, PosReferance.mainPosition.y, PosReferance.mainPosition.z);
        for (int i = 0; i < subsidiaryTracks.Count; i++)
        {
            subsidiaryTracks[i].transform.position += Vector3.back * speed * Time.deltaTime;
            parentRefer.z = subsidiaryTracks[i].transform.position.z;

            subsidiaryTracks[i].transform.position = parentRefer;

        }
    }

    public override GameObject GetTrack()
    {
        index = TrackManager.Instance.index;
        int current;

        if(index >= 0 && index <= 4)//a
        {
            current = Random.Range(0, 19);
            //Current(subsidiaryTracks[current]);
            if (!subsidiaryTracks[current].activeInHierarchy) 
            return subsidiaryTracks[current];
            else
            {
                while(subsidiaryTracks[current].activeInHierarchy)
                {
                    current = Random.Range(120, 124);
                }
                return subsidiaryTracks[current];
            }
        }
        else if(index >= 5 && index <= 9)//b
        {
            current = Random.Range(20, 29);
            //Current(subsidiaryTracks[current]);
            if (!subsidiaryTracks[current].activeInHierarchy) 
            return subsidiaryTracks[current];
            else
            {
                while(subsidiaryTracks[current].activeInHierarchy)
                {
                    current = Random.Range(120, 124);
                }
                return subsidiaryTracks[current];
            }
        }
        else if(index >= 10 && index <= 14)//c
        {
            current = Random.Range(30, 49);
            //Current(subsidiaryTracks[current]);
            if (!subsidiaryTracks[current].activeInHierarchy) 
            return subsidiaryTracks[current];
            else
            {
                while(subsidiaryTracks[current].activeInHierarchy)
                {
                    current = Random.Range(120, 124);
                }
                return subsidiaryTracks[current];
            }
        }
        else if(index >= 15 && index <= 19)//d
        {
            current = Random.Range(50, 59);
            //Current(subsidiaryTracks[current]);
            if (!subsidiaryTracks[current].activeInHierarchy) 
            return subsidiaryTracks[current];
            else
            {
                while(subsidiaryTracks[current].activeInHierarchy)
                {
                    current = Random.Range(120, 124);
                }
                return subsidiaryTracks[current];
            }
        }
        else if(index >= 20 && index <= 24)//e
        {
            current = Random.Range(60, 79);
            //Current(subsidiaryTracks[current]);
            if (!subsidiaryTracks[current].activeInHierarchy) 
            return subsidiaryTracks[current];
            else
            {
                while(subsidiaryTracks[current].activeInHierarchy)
                {
                    current = Random.Range(120, 124);
                }
                return subsidiaryTracks[current];
            }
        }
        else if(index >= 25 && index <= 29)//f
        {
            current = Random.Range(80, 99);
            //Current(subsidiaryTracks[current]);
            if (!subsidiaryTracks[current].activeInHierarchy) 
            return subsidiaryTracks[current];
            else
            {
                while(subsidiaryTracks[current].activeInHierarchy)
                {
                    current = Random.Range(120, 124);
                }
                return subsidiaryTracks[current];
            }
        }
        else if(index >= 30 && index <= 34)//g
        {
            current = Random.Range(100, 119);
            //Current(subsidiaryTracks[current]);
            if (!subsidiaryTracks[current].activeInHierarchy) 
            return subsidiaryTracks[current];
            else
            {
                while(subsidiaryTracks[current].activeInHierarchy)
                {
                    current = Random.Range(120, 124);
                }
                return subsidiaryTracks[current];
            }
        }
        else if(index >= 35 && index <= 39)//h
        {
            current = Random.Range(120, 124);
            //Current(subsidiaryTracks[current]);
            if (!subsidiaryTracks[current].activeInHierarchy) 
            return subsidiaryTracks[current];
            else
            {
                while(subsidiaryTracks[current].activeInHierarchy)
                {
                    current = Random.Range(120, 124);
                }
                return subsidiaryTracks[current];
            }
        }
        else
            return null;
    }

    public void Current(GameObject g)
    {
        currentTracks.Add(g);
    }
}
