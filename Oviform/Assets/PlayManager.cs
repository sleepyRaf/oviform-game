using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartPlay() // tmeporary?
    {
        // subscribes player to input
        player.ListenForInput();
    }

    public void OnPlay()
    {

    }

    public void OnStopPlay() // tmeporary?
    {
        // subscribes player to input
        player.StopListening();
    }
}
