using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICWSession : MonoBehaviour
{
    int isCascade=0, isICW4Needed=0,master;
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numOfICWSessions = FindObjectsOfType<ICWSession>().Length;

        if (numOfICWSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void resetBoss()
    {
        Destroy(gameObject);
    }

    public void setCascade(int casc)
    {
        isCascade = casc;
    }
    public int getCascade()
    {
        return isCascade;
    }
    public void setMaster(int mastid)
    {
        master = mastid;
    }
    public int getMaster()
    {
        return master;
    }
    public void setIC4(int ic)
    {
        isICW4Needed = ic;
    }
    public int getIC4()
    {
        return isICW4Needed;
    }

}
