using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CoroutineTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GetRequest("https://jsonplaceholder.typicode.com/posts/1"));

        Debug.Log("2");
    }

    private IEnumerator GetRequest(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest(); // 웹서버로 요청

        Debug.Log("1");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
