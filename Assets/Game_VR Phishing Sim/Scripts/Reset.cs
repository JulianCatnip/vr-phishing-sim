using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
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
