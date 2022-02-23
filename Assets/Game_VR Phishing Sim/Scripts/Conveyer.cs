using System.Collections.Generic;
using UnityEngine;

public class Conveyer : MonoBehaviour
{

    public float speed;
    public UnityEngine.Vector3 direction;
    public List<GameObject> onBelt;

    void FixedUpdate()
    {
        foreach (var item in onBelt) {
            item.GetComponent<Rigidbody>().velocity = speed * direction * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other) {
        onBelt.Add(other.gameObject);
    }

    private void OnCollisionExit(Collision other) {
        onBelt.Remove(other.gameObject);
    }
}
