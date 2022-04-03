using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
    The GM Manages Game State, as well as handling any necessary data between scenes.
*/
public class GM : MonoBehaviour
{
    // Singleton Declaration
    private static GM _instance;
    public static GM Instance {get {return _instance;}}

    private void Awake() {
        if(_instance != null && _instance != this){
            Debug.Log("Destroyed duplicate instance of GM");
            Destroy(this.gameObject);
        }else{
            _instance = this;
            Reset();
        }
    }

    [SerializeField] private int strikes = 0;
    public event EventHandler ResetEvent;
    public event EventHandler FirstStrikeEvent;
    public event EventHandler SecondStrikeEvent;
    public event EventHandler ThirdStrikeEvent; // Effectively ends the game loop!

    // I want to trigger various behavioral changes based on game "state"...
    // So this should send out a "Message" right? As in a messaging system?
    // Essentially an "Event" to update the necessary processes to change behavior state!


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Strike(){
        strikes++;
        switch (strikes)
        {
            case 1:
                FirstStrikeEvent?.Invoke(this, EventArgs.Empty);
                break;
            case 2:
                SecondStrikeEvent?.Invoke(this, EventArgs.Empty);
                break;
            case 3:
                ThirdStrikeEvent?.Invoke(this, EventArgs.Empty);
                break;
            default:
                Debug.LogError("Invalid Strike Value!");
                break;
        }
        // Should send a message update whenever "Strikes" value is changed!
    }

    void Reset(){
        strikes = 0;
        ResetEvent?.Invoke(this, EventArgs.Empty);
        // Should send a message update whenever "Strikes" value is changed!
    }
}
