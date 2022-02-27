using UnityEngine;

[CreateAssetMenu(fileName = "new Level", menuName = "Level")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private CardBundle[] _cardBundle;

    [SerializeField]
    private int _width, _height;

    public CardBundle[] CardBundle => _cardBundle;
    public int Width => _width;
    public int Height => _height;
}
