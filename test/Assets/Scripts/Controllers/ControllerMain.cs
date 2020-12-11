using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerMain : MonoBehaviour
{

    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private string actionMapName;
    [SerializeField] private string actionNameTrigger;
    [SerializeField] private string actionNameGrip;

    

    private InputActionMap actionMap;
    private InputAction inputActionTrigger;
    private InputAction inputActionGrip;


    private void Awake() {
        //récupère Action map
        this.actionMap = this.inputActionAsset.FindActionMap(this.actionMapName);

        //récupère les actions
        this.inputActionGrip = this.actionMap.FindAction(this.actionNameGrip);
        this.inputActionTrigger = this.actionMap.FindAction(this.actionNameTrigger);

        //affecte les delegate
        this.inputActionGrip.performed += this.Grip;
        this.inputActionTrigger.performed += this.Trigger;
    }
    
    private void OnEnable() {
        this.inputActionGrip.Enable();
        this.inputActionTrigger.Enable();
    }

    private void OnDisable() {
        this.inputActionGrip.Disable();
        this.inputActionTrigger.Disable();
        this.actionMap.Disable();
    }


    private void Grip(InputAction.CallbackContext context)
    {
        Debug.Log("callback grip");
    }

    private void Trigger(InputAction.CallbackContext context)
    {
        Debug.Log("callback trigger");
    }


}
