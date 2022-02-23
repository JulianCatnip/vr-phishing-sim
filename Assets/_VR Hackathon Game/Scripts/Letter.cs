using UnityEngine;

public class Letter : MonoBehaviour
{
    public GameObject display;
    public int emailId;
    private Transform currentEmail;

    public bool isPhishing;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            DisplayEmail();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            DisplayEmail();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            HideEmail();
        }
    }

    void DisplayEmail()
    {
        if(display.transform.Find("Canvas/Content/Email" + emailId) != null)
        {
            currentEmail = display.transform.Find("Canvas/Content/Email" + emailId);
            currentEmail.gameObject.SetActive(true);
        } 
        else
        {
            Debug.Log("E-Mail Object not found.");
        }
    }

    void HideEmail()
    {
        if(currentEmail != null)
        {
            currentEmail.gameObject.SetActive(false);
            currentEmail = null;
        }
    }
}
