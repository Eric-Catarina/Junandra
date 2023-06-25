using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public Animator animator;
    public AnimationCurve freadaDoSpawnCurve;
    void Start()
    {
        animator = GetComponent<Animator>();
        
        Sequence sequence = DOTween.Sequence();
        // Spawna Descendo
        transform.DOScale(0.1f, 0).SetEase(Ease.Linear);
        sequence.Append(transform.DOMoveY(-16, 2.5f).SetEase(freadaDoSpawnCurve));
        sequence.Join(transform.DOMoveX(4, 2.5f).SetEase(freadaDoSpawnCurve));

        // Sobe Crescendo e em zig-zag
        sequence.Append(transform.DOMoveY(12, 6f).SetEase(Ease.Linear));
        sequence.Join(transform.DOScale(0.25f, 6f).SetEase(Ease.Linear));
        // Make it move in sine zig-zag pattern horizontally with dotween
        sequence.Join(transform.DOMoveX(4.5f, 0f).SetEase(Ease.InOutSine));
        sequence.Join(transform.DOMoveX(-4.5f, 1.5f).SetEase(Ease.InOutSine).SetLoops(4, LoopType.Yoyo)).SetDelay(1f);
        sequence.Append(transform.DOMoveX(0, 1f).SetEase(Ease.InOutSine));

        sequence.OnComplete(() => {
            StartDisparoCO();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisparoBoss(){
        transform.DOMoveX(-9, 2f).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo);
    }

    public void TerminouDisparo(){
        StartCoroutine(StartDisparo(2f));
    }

    public void StartDisparoCO(float timeToStart = 0){
        StartCoroutine(StartDisparo(timeToStart));
    }
    public IEnumerator StartDisparo(float timeToStart = 0){
        yield return new WaitForSeconds(timeToStart);
        transform.DOMoveX(9, 4f).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo);
        animator.SetTrigger("Disparo");
    }
}
