using UnityEngine;
using UnityEngine.UI;

public class health_num : MonoBehaviour
{
    public Text th;
    public void UpdateHealth(int health, int guys)
    {
        th.text = "Health: " + health.ToString();
    }
}
