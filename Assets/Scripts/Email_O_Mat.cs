using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Email_O_Mat : MonoBehaviour
{
    public List<GameObject> currentlyEating;
    public Score_System scoreSystem;
    public Display display;
    private bool letterIsInHand;

    public void OnLetterSelectEnter()
    {
        letterIsInHand = true;
    }

    public void OnLetterSelectExit()
    {
        letterIsInHand = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Stampable") && !letterIsInHand) 
        {
            foreach(Transform stamp in other.transform) // durchsuche brief nach stempel
            {
                if(other.GetComponent<Letter>().isPhishing && stamp.gameObject.CompareTag("Phishing")) // phishing bemerkt
                {
                    scoreSystem.increaseCorrectRecognizedPhishingMails();
                    Debug.Log("increaseCorrectRecognizedPhishingMails");
                    break;
                } 
                else if(other.GetComponent<Letter>().isPhishing && stamp.gameObject.CompareTag("Standard")) // phishing nicht bemerkt
                {
                    scoreSystem.increaseNotRecognizedPhishingMails();
                    Debug.Log("increaseNotRecognizedPhishingMails");
                    break;
                }
                else if(!other.GetComponent<Letter>().isPhishing && stamp.gameObject.CompareTag("Phishing")) // falsch als phishing deklariert
                {
                    scoreSystem.increasedMisidentifiedNonPhishingMails();
                    Debug.Log("increasedMisidentifiedNonPhishingMails");
                    break;
                }
                else if(!other.GetComponent<Letter>().isPhishing && stamp.gameObject.CompareTag("Standard")) // is kein phishing und auch erkannt
                {
                    scoreSystem.increaseCorrectRecognizedNonPhishingMails();
                    Debug.Log("increaseCorrectRecognizedNonPhishingMails");
                    break;
                }
            }

            // delete mail
            display.DestroyEmail(other.gameObject.GetComponent<Letter>().emailId);
            Destroy(other.gameObject);

        }
    }
}
