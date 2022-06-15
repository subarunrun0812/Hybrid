using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThankYouForPlaying : MonoBehaviour
{
    [SerializeField] private GameObject thanksObj;
    private void Start()
    {
        thanksObj.SetActive(false);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.tag == "Player")
        {
            thanksObj.SetActive(true);
        }
    }
}
