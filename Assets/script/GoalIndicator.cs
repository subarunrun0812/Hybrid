using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalIndicator : MonoBehaviour
{

    private RectTransform myRectTfm;

    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
    }

    void Update()
    {
        // 自身の向きをカメラに向ける
        myRectTfm.LookAt(Camera.main.transform);
    }
}
