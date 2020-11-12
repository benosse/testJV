using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPresence : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightCOntrollerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightCOntrollerCharacteristics, devices);

        foreach ( var item in devices) 
        {
            Debug.Log(item.name + item.characteristics);
       }
       if(devices.Count > 0) 
       {
       //    targetDevice = devices [0];
       }
    }

    // Update is called once per frame
    void Update()
    {
       // Ecoute un output d'un device type manette output de type bool float (triggerAxis) Vector2 pour le touchpad() 
   //   targetDevice.tryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) ; 
     
   //   targetDevice.tryGetFeatureValue(CommonUsages.trigger, out float triggerValue);

      //Valeur du joystick
   //   targetDevice.tryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
    }
}
