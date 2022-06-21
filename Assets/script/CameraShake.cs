using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    private Camera _camera;
    public void StartShake()
    {
        _camera = this.GetComponent<Camera>();
        Shake(2f, 0.1f);
        Debug.Log("CameraShakeが呼ばれた");
    }
    public void Shake(float duration, float magnitude)
    {
        //durationが実行する時間
        StartCoroutine(DoShake(duration, magnitude));
    }

    private IEnumerator DoShake(float duration, float magnitude)
    {
        var pos = transform.localPosition;

        var elapsed = 0f;

        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-1f, 1f) * magnitude;
            var y = pos.y + Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, pos.z);
            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = pos;
    }
}