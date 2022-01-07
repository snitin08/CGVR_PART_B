using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
public class WireScript : XRBaseInteractable
{
    private UnityAction<SelectEnterEventArgs> destroyAction;
    // Start is called before the first frame update
    void Start()
    {
        destroyAction = new UnityAction<SelectEnterEventArgs>(destroyWire);
        selectEntered.AddListener(destroyAction);
    }

    private void destroyWire(SelectEnterEventArgs args)
    {
        Debug.Log("Destroy object called.");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
