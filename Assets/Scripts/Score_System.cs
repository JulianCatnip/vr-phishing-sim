using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_System : MonoBehaviour {

    public List<GameObject> collectibles;
    public List<GameObject> destructions;

    public GameObject explosion;

    public int correctRecognizedNonPhishingMails = 0;
    public int misidentifiedNonPhishingMails = 0;
    public int correctRecognizedPhishingMails = 0;
    public int notRecognizedPhishingMails = 0;

    public int milestoneStepDestruciton0 = 1;
    public int milestoneStepDestruciton1 = 2;
    public int milestoneStepDestruciton2 = 3;
    public int milestoneStepDestruciton3 = 4;
    public int milestoneStepDestruciton4 = 5;

    public int milestoneStepCollectible0 = 2;
    public int milestoneStepCollectible1 = 4;
    public int milestoneStepCollectible2 = 6;
    public int milestoneStepCollectible3 = 8;
    public int milestoneStepCollectible4 = 10;


    public bool collectible_0_done = false;
    public bool collectible_1_done = false;
    public bool collectible_2_done = false;
    public bool collectible_3_done = false;
    public bool collectible_4_done = false;

    public bool destruction_0_done = false;
    public bool destruction_1_done = false;
    public bool destruction_2_done = false;
    public bool destruction_3_done = false;
    public bool destruction_4_done = false;

    // Update is called once per frame
    void Update() {
        if (notRecognizedPhishingMails == milestoneStepDestruciton0 && !destruction_0_done) {
            destruction_0_done = true;
            Instantiate(explosion, destructions[0].transform);
        }
        if (notRecognizedPhishingMails == milestoneStepDestruciton1 && !destruction_1_done) {
            destruction_1_done = true;
            Instantiate(explosion, destructions[1].transform);
        }
        if (notRecognizedPhishingMails == milestoneStepDestruciton2 && !destruction_2_done) {
            destruction_2_done = true;
            Instantiate(explosion, destructions[2].transform);
        }
        if (notRecognizedPhishingMails == milestoneStepDestruciton3 && !destruction_3_done) {
            destruction_3_done = true;
            Instantiate(explosion, destructions[3].transform);
        }
        if (notRecognizedPhishingMails == milestoneStepDestruciton4 && !destruction_4_done) {
            destruction_4_done = true;
            Instantiate(explosion, destructions[4].transform);
        }


        if (correctRecognizedPhishingMails == milestoneStepCollectible0 && !collectible_0_done) {
            collectible_0_done = true;
            collectibles[0].SetActive(true);
        }
        if (correctRecognizedPhishingMails == milestoneStepCollectible1 && !collectible_1_done) {
            collectible_1_done = true;
            collectibles[1].SetActive(true);
        }
        if (correctRecognizedPhishingMails == milestoneStepCollectible2 && !collectible_2_done) {
            collectible_2_done = true;
            //do-something
        }
        if (correctRecognizedPhishingMails == milestoneStepCollectible3 && !collectible_3_done) {
            collectible_3_done = true;
            //do-something
        }
        if (correctRecognizedPhishingMails == milestoneStepCollectible4 && !collectible_4_done) {
            collectible_4_done = true;
            //do-something
        }
        
    }

    public void increaseCorrectRecognizedNonPhishingMails() {
        correctRecognizedNonPhishingMails += 1;
    }

    public void increasedMisidentifiedNonPhishingMails() {
        misidentifiedNonPhishingMails += 1;
    }

    public void increaseCorrectRecognizedPhishingMails() {
        correctRecognizedPhishingMails += 1;
    }

    public void increaseNotRecognizedPhishingMails() {
        notRecognizedPhishingMails += 1;
    }
}
