using UnityEngine;

public class Attack : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = soundClip;

        //audioSource.Play();
    }

    public void PlaySound()
    {
        if (audioSource != null)
            audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
