using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class ConnectorScript : XRBaseInteractable
{
    // Start is called before the first frame update
    public GameObject inputObject;
    public GameObject connectorObject;
    private UnityAction<SelectEnterEventArgs> selectAction;
    void Start()
    {
        selectAction = new UnityAction<SelectEnterEventArgs>(selectFunc);
        selectEntered.AddListener(selectAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void selectFunc(SelectEnterEventArgs args)
    {
        if (args.interactor.name == "LeftHand Controller")
        {
            if (!LeftControllerScript.flag)
            {
                LeftControllerScript.firstSelectedInteractable = args.interactable;
                Debug.Log("First interactor : " + LeftControllerScript.firstSelectedInteractable.name);
                LeftControllerScript.flag = true;
            }
            else
            {
                LeftControllerScript.secondSelectedInteractable = args.interactable;
                Debug.Log("Second interactor : " + LeftControllerScript.secondSelectedInteractable.name);
                LeftControllerScript.flag = false;

                XRBaseInteractable firstInteractable = LeftControllerScript.firstSelectedInteractable, secondInteractable = LeftControllerScript.secondSelectedInteractable;

                LineRenderer wire;
                wire = new GameObject("Line").AddComponent<LineRenderer>();
                wire.startColor = Color.black;
                wire.endColor = Color.black;
                wire.startWidth = 0.01f;
                wire.endWidth = 0.01f;
                wire.positionCount = 2;
                wire.useWorldSpace = true;


                //For drawing line in the world space, provide the x,y,z values
                wire.SetPosition(0, firstInteractable.transform.position); //x,y and z position of the starting point of the line
                wire.SetPosition(1, secondInteractable.transform.position); //x,y and z position of the end point of the line  

                connectConnectors(firstInteractable, secondInteractable);
            }
        }
    }

    private void connectConnectors(XRBaseInteractable firstInteractable, XRBaseInteractable secondInteractable)
    {
        GameObject connector1 = firstInteractable.gameObject;
        GameObject connector2 = secondInteractable.gameObject;
        connector1.GetComponent<ConnectorScript>().connectorObject = connector2;
        connector2.GetComponent<ConnectorScript>().connectorObject = connector1;
        Debug.Log("Connected : " + firstInteractable.name + " - " + secondInteractable.name);
    }

    private void destroyWire(SelectEnterEventArgs args)
    {
        Debug.Log("Destroy object called.");
        Destroy(gameObject);
    }

    
}
