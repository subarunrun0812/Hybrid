using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotationSpotLight : MonoBehaviour
{
    public void Start()
    {
        this.transform.DOLocalRotate(new Vector3(this.transform.rotation.x, 360.0f, 0f), 0.5f)
                            .SetEase(Ease.Linear)
                            .SetRelative(true)
                            .SetLoops(-1);
    }
}
