using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour {

    public string areaToLoad;
    public string areaTransitionName;

    // Use this for initialization
    void Start () {
        Debug.Log("AreaExit script initialized.");
    }
    
    // Update is called once per frame
    void Update () {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Debug.Log("Player entered the trigger zone.");
            Debug.Log("Loading scene: " + areaToLoad);

            SceneManager.LoadScene(areaToLoad);

            PlayerController.instance.areaTransitionName = areaTransitionName;
            Debug.Log("Setting areaTransitionName to: " + areaTransitionName);
        }
    }
}
