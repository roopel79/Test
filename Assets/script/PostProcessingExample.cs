using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingExample : MonoBehaviour
{
    public PostProcessVolume volume;
    private ColorGrading colorGrading;

    void Start()
    {
        // PostProcessVolume���� ColorGrading ���� ��������
        volume.profile.TryGetSettings(out colorGrading);

        // ���� ���� ȿ�� ����
        colorGrading.temperature.value = 10f; // ������ ������ ����
        colorGrading.saturation.value = -50f;  // ä�� ����
    }
}
