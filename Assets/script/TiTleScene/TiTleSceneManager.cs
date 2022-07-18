using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiTleSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject mainObj;
    [SerializeField] private GameObject creditsObj;
    // Start is called before the first frame update
    void Start()
    {
        mainObj.SetActive(true);
        creditsObj.SetActive(false);
    }

    public void CreditsDisplay()
    {
        mainObj.SetActive(false);
        creditsObj.SetActive(true);
    }
    public void QuitCreditsDisplay()
    {
        mainObj.SetActive(true);
        creditsObj.SetActive(false);
    }
}
