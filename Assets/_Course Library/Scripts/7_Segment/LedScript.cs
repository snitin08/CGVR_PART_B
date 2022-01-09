using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Material offMaterial;
    public Material onMaterial;
    public GameObject connectorObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject inputConnector = this.connectorObject.GetComponent<ConnectorScript>().connectorObject;
        if (inputConnector != null)
        {
            bool on = inputConnector.GetComponent<ConnectorScript>().inputObject.GetComponent<pushButtonScript>().on;
            setMaterial(on);
        }
    }

    private void setMaterial(bool on)
    {
        Material material;
        if (on)
            material = onMaterial;
        else
            material = offMaterial;
        this.GetComponent<Renderer>().material = material;
    }
}
