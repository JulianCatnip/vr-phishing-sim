using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Stamp : MonoBehaviour
{
    public GameObject stampImprint;
    public XRDirectInteractor l_directInteractor;
    public XRDirectInteractor r_directInteractor;

    // private void OnCollisionEnter(Collision other) {
    //     GameObject hitObject = other.gameObject;
    //     GameObject text = Instantiate(stampImprint);
    //     text.transform.SetParent(hitObject.transform);
    //     if (other.contactCount > 0) {
    //         text.transform.position = other.contacts[0].point + new Vector3(0, 0.001f, 0);
    //     }
    // }
    void OnTriggerEnter(Collider other) 
    {
        if(((l_directInteractor.selectTarget != null && l_directInteractor.selectTarget.transform == this.transform)
            || (r_directInteractor.selectTarget != null && r_directInteractor.selectTarget.transform == this.transform))
            && other.CompareTag("Stampable"))
        {
            GameObject hitObject = other.gameObject;
            GameObject text = Instantiate(stampImprint);
            text.transform.SetParent(hitObject.transform);
            text.transform.localPosition = new Vector3(0, 0.002f, 0);
        }
    }
}
