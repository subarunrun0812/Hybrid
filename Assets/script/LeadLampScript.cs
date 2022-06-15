using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadLampScript : MonoBehaviour
{
    [SerializeField] private GameObject leadLampObj;
    private void Start()
    {
        leadLampObj.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
    public void LeadLampFunction()//emmisionをおんにする
    {
        leadLampObj.SetActive(true);
        leadLampObj.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

}
