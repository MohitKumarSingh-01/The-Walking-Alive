using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    private Image loadingBar;

    private void Awake()
    {
        loadingBar = GetComponent<Image>();
        loadingBar.fillAmount = 0;
    }

    private void Update()
    {
        loadingBar.fillAmount += 0.5f * Time.deltaTime;

        if(loadingBar.fillAmount >= 1)
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
