using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class PendulumBody : MonoBehaviour
{
    private float time = 2f;//振り子の移動時間
    void Start()
    {
        Pendulum();
    }
    int count = 0;

    private void Pendulum()
    {
        DOTween.Sequence()
       .Append(this.transform.DOLocalMoveX(-0.3f, time))
       .Append(this.transform.DOLocalMoveX(0.3f, time))
       .Append(this.transform.DOLocalMoveX(-0.3f, time))
       .Append(this.transform.DOLocalMoveX(0.3f, time))
       .Append(this.transform.DOLocalMoveX(-0.3f, time))
       .Append(this.transform.DOLocalMoveX(0.3f, time))
       .Append(this.transform.DOLocalMoveX(-0.3f, time))
       .Append(this.transform.DOLocalMoveX(0.3f, time))
       .Append(this.transform.DOLocalMoveX(-0.3f, time))
       .Append(this.transform.DOLocalMoveX(0.3f, time))
       .Append(this.transform.DOLocalMoveX(-0.3f, time))
       .Append(this.transform.DOLocalMoveX(0.3f, time))
       .Append(this.transform.DOLocalMoveX(0f, time));
    }
}
