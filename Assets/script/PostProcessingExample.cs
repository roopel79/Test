using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingExample : MonoBehaviour
{
    public PostProcessVolume volume;
    private ColorGrading colorGrading;

    void Start()
    {
        // PostProcessVolume에서 ColorGrading 설정 가져오기
        volume.profile.TryGetSettings(out colorGrading);

        // 색상 조정 효과 설정
        colorGrading.temperature.value = 10f; // 따뜻한 색조로 변경
        colorGrading.saturation.value = -50f;  // 채도 감소
    }
}
