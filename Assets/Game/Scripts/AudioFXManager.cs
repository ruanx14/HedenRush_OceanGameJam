using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFXManager : MonoBehaviour
{ 
    public static AudioFXManager Instance;
    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip spaceShipSound;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayJump()
    {
        var newGameObject = new GameObject();
        var audioSource = newGameObject.AddComponent<AudioSource>();
        audioSource.clip = jumpSound;
        audioSource.volume = 0.3f;
        audioSource.Play();
        Destroy(newGameObject, jumpSound.length);
    }
    public void PlayDeath()
    {
        var newGameObject = new GameObject();
        var audioSource = newGameObject.AddComponent<AudioSource>();
        audioSource.clip = deathSound;
        audioSource.volume = 0.6f;
        audioSource.Play();
        Destroy(newGameObject, deathSound.length);
    }
    public void PlaySpaceShipSound()
    {
        var newGameObject = new GameObject();
        var audioSource = newGameObject.AddComponent<AudioSource>();
        audioSource.clip = spaceShipSound;
        audioSource.volume = 0.7f;
        audioSource.Play();
        //Debug.Log(spaceShipSound.length);
        Destroy(newGameObject, spaceShipSound.length/3);
    }
}
