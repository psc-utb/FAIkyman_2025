using UnityEngine;
using UnityEngine.Events;

public class DragonEyes : MonoBehaviour
{
    public UnityEvent<bool> PlayerIsVisible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerIsVisible?.Invoke(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerIsVisible?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerIsVisible?.Invoke(false);
    }
}
