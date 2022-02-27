using UnityEngine;

public class InputListner : MonoBehaviour
{
    public delegate void OnClick(Card card);
    public OnClick onClick;

    [SerializeField]
    private LayerMask _layer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPos, Vector2.zero, 100, _layer);

            if (hit)
            {
                Card card = hit.collider.GetComponent<Card>();
                onClick?.Invoke(card);
            }
        }
    }
}
