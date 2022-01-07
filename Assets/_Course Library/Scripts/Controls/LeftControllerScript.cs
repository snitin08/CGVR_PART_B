using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class LeftControllerScript : XRRayInteractor
{
    public static XRBaseInteractable firstSelectedInteractable;
    public static XRBaseInteractable secondSelectedInteractable;
    // Boolean to check whether first object should be selected or second object should be selected
    public static bool flag = false;
    // Start is called before the first frame update
    protected override void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
