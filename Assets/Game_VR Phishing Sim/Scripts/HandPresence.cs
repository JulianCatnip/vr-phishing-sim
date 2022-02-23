using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristic;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    void Start() {
        TryInitialize();
    }

    void TryInitialize() {
        List<InputDevice> devices = new List<InputDevice>();
        while(devices.Count == 0) {
            InputDevices.GetDevicesWithCharacteristics(controllerCharacteristic, devices);

            foreach (var item in devices){
                Debug.Log(item.name + item.characteristics);
            }

            if (devices.Count > 0) {
                spawnedHandModel = Instantiate(handModelPrefab, transform);
                handAnimator = spawnedHandModel.GetComponent<Animator>();
            }
        }
    }

    void UpdateHandAnimation() {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) {
            handAnimator.SetFloat("Trigger", triggerValue);
        } else {
            handAnimator.SetFloat("Trigger", 0);
        }

        if(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue)) {
            handAnimator.SetFloat("Grip", gripValue);
        } else {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    // Update is called once per frame
    void Update() {
        if(!targetDevice.isValid) {
            TryInitialize();
        } 
        else {
            //Different input options
            targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
            if (primaryButtonValue) {
                Debug.Log("Pressing Primary Button");
            }
            targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);

            if (triggerValue > 0.1f) {
                Debug.Log("Trigger pressed: " + triggerValue);
            }

            targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
            if (primary2DAxisValue != Vector2.zero) {
                Debug.Log("Primary Touchpas: " + primary2DAxisValue);
            }
            
            UpdateHandAnimation();
        }
    }
}
