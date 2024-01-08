using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    private float fps;
    [SerializeField] private TMP_Text FPSCounterText;

    void Start()
    {
        InvokeRepeating("FPSCounter", 1, 0.5f);
    }
    private void FPSCounter()
    {
        fps = (int) (1 / Time.unscaledDeltaTime);
        FPSCounterText.text = "FPS : " + fps.ToString(); 
    }
}
