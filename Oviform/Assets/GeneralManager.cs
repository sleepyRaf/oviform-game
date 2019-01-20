using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{

    public static GeneralManager instance;

    public PlayManager playManager;
    State state;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
            
    }

    // Start is called before the first frame update
    void Start()
    {
        state = State.StartPlay;
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
    }

    public void CheckState()
    {
        switch (state)
        {
            case State.StartPlay:
                playManager.OnStartPlay();
                state = State.Play;               
                break;
            case State.Play:
                playManager.OnPlay();
                break;
            case State.DonePlay:
                break;
        }
    }

    public enum State
    {
        StartPlay,
        Play,
        DonePlay
    }
}
