using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
