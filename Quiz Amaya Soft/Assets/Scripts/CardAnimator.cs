using UnityEngine;
using DG.Tweening;

public class CardAnimator : MonoBehaviour
{
    [SerializeField]
    private Vector3 _startScale;
    [SerializeField]
    private ParticleSystem _starParticle;
    [SerializeField]
    private Transform _spriteTransform;
    [SerializeField]
    private float _stength;
    [SerializeField]
    private float _animationDuration;
    private Tween _animation = null;

    public delegate void OnAnimationEnd();
    public OnAnimationEnd onAnimationEnd;

    public void ToAppear() 
    {
        transform.localScale = _startScale;
        _animation = transform.DOScale(Vector3.one, _animationDuration).SetEase(Ease.OutBounce);
    }

    public void OnCurrect() 
    {
        _starParticle.Play();
        Shake(Vector2.up);
    }

    public void OnWrong() 
    {
        Shake(Vector2.right);
    }

    private void Shake(Vector2 diraction) 
    {
        if (_animation != null) 
            ResetAnimation();

        _animation = _spriteTransform.DOPunchPosition(diraction * _stength, _animationDuration).OnComplete(() => onAnimationEnd?.Invoke());
    }

    private void ResetAnimation() 
    {
        _animation.Kill();
        _animation = null;
        _spriteTransform.localPosition = Vector2.zero;
    }
}
