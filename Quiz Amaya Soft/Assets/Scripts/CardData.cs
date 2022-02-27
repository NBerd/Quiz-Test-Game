using UnityEngine;

[System.Serializable]
public class CardData
{
    [SerializeField]
    private float _startRotation;
    [SerializeField]
    private string _identifier;
    [SerializeField]
    private Sprite _sprite;
    [SerializeField]
    private Color _backgroundColor;

    public float StartRotation => _startRotation;
    public string Identifier => _identifier;
    public Sprite Sprite => _sprite;
    public Color BackgroundColor => _backgroundColor;
}
