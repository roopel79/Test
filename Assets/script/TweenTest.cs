using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TweenTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<RectTransform>().localPosition = new Vector3(605, 507, 0);
        GetComponent<RectTransform>().localScale = new Vector3(2, 2, 1);

        // 209, 507
        GetComponent<RectTransform>().DOAnchorPos(new Vector2(2, 507), 0.7f);
        GetComponent<RectTransform>().DOScale(3.0f, 0.7f);
    }

    private void OnEnable()
    {
        GetComponent<RectTransform>().localPosition = new Vector3(605, 507, 0);
        GetComponent<RectTransform>().localScale = new Vector3(2, 2, 1);

        GetComponent<RectTransform>().DOAnchorPos(new Vector2(2, 507), 0.7f);
        GetComponent<RectTransform>().DOScale(3.0f, 0.7f);
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
