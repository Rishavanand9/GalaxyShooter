using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{

    public float speed =2.5f;
    [SerializeField]
    private int powerupId;

    [SerializeField]
    private AudioClip audioClip;
    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }



    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -8)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with :" + other.name);
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (powerupId == 0)
                {
                    AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
                    player.tripleShotOn();
                }
                else if (powerupId == 1)
                {
                    AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
                    player.SpeedBoostOn();
                }
                else if (powerupId == 2)
                {
                    AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
                    player.ShieldOn();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
