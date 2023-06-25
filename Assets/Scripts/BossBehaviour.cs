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
        //EntradaDramatica();
        StartDisparoCO(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EntradaDramatica()
    {
        Sequence sequence = DOTween.Sequence();
        // Spawna Descendo
        transform.DOScale(0.05f, 0).SetEase(Ease.Linear);
        sequence.Append(transform.DOMoveY(-16, 4f).SetEase(freadaDoSpawnCurve));
        sequence.Join(transform.DOMoveX(4, 4f).SetEase(freadaDoSpawnCurve));

        // Sobe Crescendo e em zig-zag
        sequence.Append(transform.DOMoveY(7, 6f).SetEase(Ease.Linear));
        sequence.Join(transform.DOScale(0.15f, 6f).SetEase(Ease.Linear));
        // Make it move in sine zig-zag pattern horizontally with dotween
        sequence.Join(transform.DOMoveX(4.5f, 0f).SetEase(Ease.InOutSine));
        sequence.Join(transform.DOMoveX(-4.5f, 1.5f).SetEase(Ease.InOutSine).SetLoops(4, LoopType.Yoyo)).SetDelay(1f);
        sequence.Append(transform.DOMoveX(0, 1f).SetEase(Ease.InOutSine));

        sequence.OnComplete(() =>
        {
            StartDisparoCO();
        });
    }
    public void DisparoBoss()
    {
        //transform.DOMoveX(-9, 2f).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo);
    }

    public void TerminouDisparo()
    {
        transform.DOShakePosition(1f, 0.2f, 10, 90, false,true, ShakeRandomnessMode.Harmonic);
        StartDisparoCO(1);
    }

    public void StartDisparoCO(float timeToStart = 0)
    {
        StartCoroutine(StartDisparo(timeToStart));
    }
    public IEnumerator StartDisparo(float timeToStart = 0)
    {
        yield return new WaitForSeconds(timeToStart);
        animator.SetTrigger("Disparo");

        Sequence sequence = DOTween.Sequence();
        // Carrega o tiro indo pra direita
        sequence.Append(transform.DOMoveY(6.3f, 6.5f).SetEase(Ease.InOutSine));
        sequence.Join(transform.DOMoveX(12.6f, 6.5f).SetEase(Ease.InOutSine));

        // Dispara o tiro indo pra esquerda e voltando
        sequence.Append(transform.DOMoveX(-12.6f, 1.5f).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo));
        
        // Volta pra esquerda
        sequence.Append(transform.DOMoveY(7.2f, 2f).SetEase(Ease.InOutSine));
        sequence.Join(transform.DOMoveX(-6.5f, 2f).SetEase(Ease.InOutSine));

    }
}
