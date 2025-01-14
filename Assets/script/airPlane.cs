using UnityEngine;

public class airPlane : MonoBehaviour
{
    public VariableJoystick variableJoystick;

    float speed = 3f;

    public Camera mainCamera;
    public RectTransform ui_hp_bar;

    public TableTest table_test;

	void Aweak()
	{
		
	}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        //Debug.Log( "TableTest c: " + table_test.c);
    }

    // Update is called once per frame
    void Update()
    {
        if (variableJoystick.Direction.x != 0
            || variableJoystick.Direction.y != 0)
        {
            Debug.Log("Current Value: " + variableJoystick.Direction);
            Vector3 pos = transform.position;
            pos.x = pos.x + variableJoystick.Direction.x* speed * Time.deltaTime;
            pos.y = pos.y + variableJoystick.Direction.y* speed * Time.deltaTime;
            transform.position = pos;
        }

        // 내 비행기의 위치가 UI 좌표 어딘가로 위치한다.
        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);
        screenPos.y += 80.0f; 
        ui_hp_bar.position = screenPos;
    }
}
