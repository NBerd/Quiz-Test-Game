using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private Card _cardPrefab;
    [SerializeField]
    private SpriteRenderer _levelBackground;
    [SerializeField]
    private Vector2 _backgroundBorder;
    private GameObject _levelCards;

    public Card[] GenerateLevel(int width, int height, CardBundle cardBundle)
    {
        if (_levelCards != null)
            Destroy(_levelCards);

        _levelCards = new GameObject("LevelCards");
        _levelCards.transform.SetParent(transform);

        List<CardData> _cardData = new List<CardData>(cardBundle.CardData);
        List<Card> _levelCardData = new List<Card>();

        for(int y = 0; y < height; y++) 
        {
            for(int x = 0; x < width; x++) 
            {
                CardData cardData = GetRandomCard(_cardData);
                Card card = Instantiate(_cardPrefab, new Vector2(x, y), Quaternion.identity);
                card.SetCard(cardData);
                card.transform.SetParent(_levelCards.transform);
                _levelCardData.Add(card);
                _cardData.Remove(cardData);
            }
        }

        SetLevelToCenter(width, height);

        return _levelCardData.ToArray();
    }

    private CardData GetRandomCard(List<CardData> cardData) 
    {
        return cardData[Random.Range(0, cardData.Count)];
    }

    private void SetLevelToCenter(float width, float height) 
    {
        _levelBackground.enabled = true;
        _levelBackground.size = new Vector2(width, height) + _backgroundBorder;
        _levelCards.transform.position -= GetCenterOfLevel(width, height);
    }

    private Vector3 GetCenterOfLevel(float width, float height) 
    {
        float widthCenter = (width / 2) - .5f;
        float heightCenter = (height / 2) - .5f;

        return new Vector3(widthCenter, heightCenter);
    }
}
