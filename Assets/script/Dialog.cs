using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text dialogueText;

    public float typingSpeed = 0.05f;

    private string currentDialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentDialogue = "조종사님, 저는 작전을 지원할 부사관입니다—이번 " +
            "목표는 적 항공기의 교란과 차단, 예상 교전 구역은 고도 10,000피트 상공입니다. " +
            "무사히 임무를 완수하시길 기원하겠습니다!!";

        StartCoroutine(TypeDialogue(currentDialogue));
    }

    IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";
        foreach( char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void CloseBtn()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
