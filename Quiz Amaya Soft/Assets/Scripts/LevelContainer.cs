using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    [SerializeField]
    private EndMenu _endMenu;
    [SerializeField]
    private LevelGenerator _levelGenerator;
    [SerializeField]
    private LevelDecision _levelDecision;

    [SerializeField]
    private LevelData[] _levels;
    public LevelData[] Levels => _levels;

    private LevelData _currentLevel;
    private int _currentLevelID = 0;

    private void Awake()
    {
        _levelDecision.onLevelComplite += ChangeLevel;
    }

    private void Start()
    {
        Invoke(nameof(StartLevel), 1f);
    }

    public void StartLevel() 
    {
        _currentLevel = _levels[_currentLevelID];
        Card[] _levelCards= _levelGenerator.GenerateLevel(_currentLevel.Width, _currentLevel.Height, GetRandomCardBundle());
        _levelDecision.SetDecision(_levelCards);

        if (_currentLevelID == 0) 
            SetStartAnimation(_levelCards);
    }

    private void SetStartAnimation(Card[] levelCard) 
    {
        for(int i = 0; i < levelCard.Length; i++) 
        {
            levelCard[i].CardAnimator.ToAppear();
        }
    }

    private CardBundle GetRandomCardBundle() 
    {
        CardBundle[] cardBundles = _currentLevel.CardBundle;
        return cardBundles[Random.Range(0, cardBundles.Length)];
    }

    public void ChangeLevel() 
    {
        _currentLevelID++;

        if (_currentLevelID >= _levels.Length) 
        {
            _currentLevelID = 0;
            _endMenu.EnableMenu();
            return;
        }

        StartLevel();
    }
}
