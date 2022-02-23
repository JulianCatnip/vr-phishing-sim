using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    public Animator handAnimator;
    public float animationFadeDuration = 0.05f;
    
    [System.Serializable]
    public enum Hand {
        Left,
        Right
    }
    public Hand handType;

    // private ActionBasedController controller;
    private XRDirectInteractor directInteractor;
    private InputDevice controller;
    private string output;
    private int lHandIndex;
    private int rHandIndex;

    private bool primaryButtonPressed;
    private Vector2 thumbstickUsed;
    private bool triggerPressed;
    private bool gripPressed;
    // private bool thumbTouched;

    void Start()
    {
        // xr controller input
        if(handType == Hand.Left){
            controller = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        } else if(handType == Hand.Right) {
            controller = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        } else {
            Debug.Log("Hand not assigned.");
        }

        directInteractor = GetComponent<XRDirectInteractor>();

        primaryButtonPressed = false;
        triggerPressed = false;
        gripPressed = false;
        //thumbTouched = false;
    }

    private void GetInput()
    {
        //controller.TryGetFeatureValue(CommonUsages.primaryButton, out this.primaryButtonPressed); // primary button touch
        //controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out this.thumbstickUsed); // thumbstick use
        //controller.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out this.thumbTouched); // thumbstick touch
        controller.TryGetFeatureValue(CommonUsages.triggerButton, out this.triggerPressed); // left trigger
        controller.TryGetFeatureValue(CommonUsages.gripButton, out this.gripPressed); // left grip
    }

    // Update is called once per frame
    void Update()
    {   
        GetInput();

        if(triggerPressed) {
            switch (handType) {
                case Hand.Left:
                    handAnimator.CrossFade("Okey Dokey", animationFadeDuration, lHandIndex);
                    break;
                case Hand.Right:
                    handAnimator.CrossFade("Okey Dokey", animationFadeDuration, rHandIndex);
                    break;
            }
        } else if (gripPressed) {
            switch (handType) {
                case Hand.Left:
                    handAnimator.CrossFade("Point 2", animationFadeDuration, lHandIndex);
                    break;
                case Hand.Right:
                    handAnimator.CrossFade("Point 2", animationFadeDuration, rHandIndex);
                    break;
            }
        }
    }

    public InputDevice GetController()
    {
        return this.controller;
    }

    public bool GetPrimaryButtonState()
    {
        return this.primaryButtonPressed;
    }

    public bool GetGripButtonState()
    {
        return this.gripPressed;
    }

    public bool GetTriggerButtonState()
    {
        return this.triggerPressed;
    }

    public bool GetThumbstickUseState()
    {
        if(this.thumbstickUsed.magnitude > 0)
        {
            return true;
        } else
        {
             return false;
        }
    }
}
