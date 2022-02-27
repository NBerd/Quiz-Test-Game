using UnityEngine;

public class Card : MonoBehaviour
{
    private CardData _cardData;
    public CardData CardData => _cardData;

    private CardAnimator _cardAnimator;
    public CardAnimator CardAnimator => _cardAnimator;

    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private SpriteRenderer _background;

    private void Awake()
    {
        _cardAnimator = GetComponent<CardAnimator>();
    }

    public void SetCard(CardData cardData) 
    {
        _cardData = cardData;
        _sprite.sprite = _cardData.Sprite;
        _background.color = _cardData.BackgroundColor;

        _sprite.transform.Rotate(new Vector3(0, 0, _cardData.StartRotation));
    }
}
