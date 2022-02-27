using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField]
    private InputListner _inputListner;
    [SerializeField]
    private LevelContainer _levelContainer;

    public void EnableMenu() 
    {
        _inputListner.enabled = false;
        gameObject.SetActive(true);
    }

    private void DisableMenu() 
    {
        _inputListner.enabled = true;
        gameObject.SetActive(false);
    }

    public void Restart() 
    {
        _levelContainer.StartLevel();
        DisableMenu();
    }
}
