using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton Declaration
    private static AudioManager _instance;
    public static AudioManager Instance {get {return _instance;}}

    private void Awake() {
        if(_instance != null && _instance != this){
            Debug.Log("Destroyed duplicate instance of AudioManager");
            Destroy(this.gameObject);
        }else{
            _instance = this;
            Reset();
        }
    }
}
