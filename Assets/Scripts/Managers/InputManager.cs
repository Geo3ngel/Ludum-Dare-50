using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Singleton Declaration
    private static InputManager _instance;
    public static InputManager Instance {get {return _instance;}}
    
    private void Awake() {
        if(_instance != null && _instance != this){
            Debug.Log("Destroyed duplicate instance of InputManager");
            Destroy(this.gameObject);
        }else{
            _instance = this;
            Reset();
        }
    }
}
