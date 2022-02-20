using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Hand")) {
            Debug.Log("Reload a");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Hand")) {
            Debug.Log("Reload");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        }
    }
}
