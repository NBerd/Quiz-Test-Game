using System.Collections.Generic;
using UnityEngine;

public class LevelDecision : MonoBehaviour
{
    public delegate void OnLevelComplite();
    public OnLevelComplite onLevelComplite;

    [SerializeField]
    private InputListner _inputListner;
    [SerializeField]
    private DecisionText _decisionText;
    public DecisionText DecisionText => _decisionText;

    private bool _levelComplite = false;
    private Card _levelCard;

    private List<CardData> _closedSolutions = new List<CardData>();

    private void Awake()
    {
        _inputListner.onClick += CheckDesicion;
    }

    public void SetDecision(Card[] cards) 
    {
        _levelCard = GetRandomCard(cards);
        _closedSolutions.Add(_levelCard.CardData);
        _decisionText.SetText(_levelCard.CardData.Identifier);
    }

    private Card GetRandomCard(Card[] cards) 
    {
        Card[] avaibleCards = GetAvaibleCards(cards);
        Card card = avaibleCards[Random.Range(0, avaibleCards.Length)];

        return card;
    }

    private Card[] GetAvaibleCards(Card[] cards) 
    {
        List<Card> allCards = new List<Card>(cards);
        List<Card> avaibleCards = allCards;

        for(int i = 0; i < allCards.Count; i++) 
        {
            Card card = allCards[i];

            if (_closedSolutions.Contains(card.CardData)) 
                avaibleCards.Remove(card);
        }

        avaibleCards = avaibleCards.Count > 0 ? avaibleCards : allCards;

        return avaibleCards.ToArray();
    }

    public void CheckDesicion(Card card) 
    {
        if (_levelComplite) return;

        if (card == _levelCard) 
        {
            card.CardAnimator.onAnimationEnd += LevelComplite;
            card.CardAnimator.OnCurrect();
            _levelComplite = true;
        }
        else 
            card.CardAnimator.OnWrong();
    }

    private void LevelComplite() 
    {
        onLevelComplite?.Invoke();
        _levelComplite = false;
    }
}