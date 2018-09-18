using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private GameObject explosionPrefab;
    private float speed = 5.0f;

    private HUD _hud;
    [SerializeField]
    private AudioClip audioClip;
    private AudioSource _audioSource;

    private void Start()
    {
        _hud = GameObject.Find("Canvas").GetComponent<HUD>();
        _audioSource = GetComponent<AudioSource>();

    }


    void Update ()
    {
        transform.Translate(Vector3.down*speed  * Time.deltaTime);
        if(transform.position.y<-7 || transform.position.y > 7)
        {
            transform.position = new Vector3(Random.Range(-7, 7), 7,0);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            _hud.UpdateScore();
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
          
        }
        else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position,1f);
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                player.damage();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }


}
