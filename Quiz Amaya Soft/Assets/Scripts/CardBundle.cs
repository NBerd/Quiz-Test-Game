using UnityEngine;

[CreateAssetMenu(fileName = "new Card Bundle", menuName = "Card Bundle")]
public class CardBundle : ScriptableObject
{
    [SerializeField]
    private CardData[] _cardData;
    public CardData[] CardData => _cardData;
}
