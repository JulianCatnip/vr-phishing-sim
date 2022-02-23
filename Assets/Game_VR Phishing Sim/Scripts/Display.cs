using UnityEngine;

public class Display : MonoBehaviour
{
    void Start()
    {
        Transform content = transform.Find("Canvas/Content");

        if(content.childCount > 0)
        {
            foreach(Transform email in content)
            {
                email.gameObject.SetActive(false);
            }
        } 
        else
        {
            Debug.Log("Display has no email content.");
        }
    }

    public void DestroyEmail(int id)
    {
        Destroy(transform.Find("Canvas/Content/Email" + id).gameObject);
    }
}
