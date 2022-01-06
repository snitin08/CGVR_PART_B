using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class pushButtonScript : XRBaseInteractable
{

    public Material onMaterial;
    public Material offMaterial;
    public bool on = false;
    private UnityAction<SelectEnterEventArgs> toggleAction;
    // Start is called before the first frame update
    void Start()
    {
        toggleAction = new UnityAction<SelectEnterEventArgs> (toggleOnOff);
        selectEntered.AddListener(toggleAction);
        Debug.Log("Event added");        
    }

    private void Update()
    {
        
    }

    private void toggleOnOff(SelectEnterEventArgs args)
    {
        Debug.Log(args.interactable.name);
        Debug.Log(args.interactor.name);
        Debug.Log(isSelected);
        if (isSelected)
        {
            Debug.Log("Toggle ...");
            on = !on;
            Material material;
            if (on)
                material = onMaterial;
            else
                material = offMaterial;
            this.GetComponent<Renderer>().material = material;
        }
    }

}
