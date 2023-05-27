using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> coinSound;

    AudioSource audio;

    bool canSound = true;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void AddCoinSound(int index)
    {
        audio.PlayOneShot(coinSound[index]);
    }

    public void BoulderFallSound(int index)
    {
        if (canSound == true)
        {
            audio.PlayOneShot(coinSound[index]);
            canSound = false;
            StartCoroutine("SoundRate");
        }
    }

    IEnumerator SoundRate()
    {
        yield return new WaitForSeconds(3f);
        canSound = true;
    }
}
