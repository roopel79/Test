using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject[] bg;

    float original_Y = 0;

    float scrollSpeed = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for( int i = 0; i < 3; i++)
        {
            Vector3 pos = bg[i].transform.position;
            pos.y = pos.y - scrollSpeed * Time.deltaTime;
            bg[i].transform.position = pos;

            if (bg[i].transform.position.y < -20)
            {
                Vector3 pos2 = bg[i].transform.position;
                pos2.y = pos2.y + 36;
                bg[i].transform.position = pos2;
            }
        }
    }
}
