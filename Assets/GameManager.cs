using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameStep Currentstep;
    [SerializeField] GameObject[] contensts;
    public enum GameStep
    {
        Title,
        Lobby,
        Main,
        Contents_0,
        Contents_1,
        Contents_2,
        Contents_3,
        Contents_4,
        Contents_5,
    }


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void MoveNextStep() 
    {
        Currentstep++;
        LoadAndUnLoadAllContents((int)Currentstep);
    }

    public void MoveStep(GameStep NewStep) 
    {
        Currentstep = NewStep;
        LoadAndUnLoadAllContents((int)Currentstep);
    }

    public void LoadTitle() 
    {
        Currentstep = GameStep.Title;

        for (int i = 0; i < contensts.Length; i++)
        {
            if (i == 0)
                contensts[i].SetActive(true);
            else
                contensts[i].SetActive(false);
        }
    }

    public void LoadMain() 
    {
        Currentstep = GameStep.Title;

        for (int i = 0; i < contensts.Length; i++)
        {
            if (i == 2)
                contensts[i].SetActive(true);
            else
                contensts[i].SetActive(false);
        }
    }

    void LoadAndUnLoadAllContents(int LoadIndex) 
    {
        for (int i = 0; i < contensts.Length; i++) 
        {
            if (i == LoadIndex)
                contensts[i].SetActive(true);
            else
                contensts[i].SetActive(false);
        }

    }

    
}
