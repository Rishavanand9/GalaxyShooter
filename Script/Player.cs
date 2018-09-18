using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public bool tripleShot;
    public bool SpeedBoost;
    public bool Shield;

    public int life = 3;

    


    [SerializeField]
    private GameObject lazerPrefab;

    [SerializeField]
    private GameObject shieldGameObject;


    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private float firerate = 0.25f;

    private float nextfire = 0.0f;

    [SerializeField]
    public float speed = 5.0f;


    private HUD _hud;
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private AudioSource audioSource;

	void Start ()
    {
        transform.position = new Vector3(0, 0, 0);
        _hud = GameObject.Find("Canvas").GetComponent<HUD>();

        if (_hud != null)
        {
            _hud.UpdateLives(life);
        }

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (spawnManager != null)
        {
            spawnManager.startSpawnRoutine();
        }

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update ()
    {
        movement();

        //spawn

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            shoot();
        }

    }


    private void shoot()
    {
        if (Time.time > nextfire)
        {
            audioSource.Play();
            if (tripleShot == true)
            {
                Instantiate(lazerPrefab, transform.position + new Vector3(-1.57f, - 0.61f, 0), Quaternion.identity);
                Instantiate(lazerPrefab, transform.position + new Vector3(0, 0.09f, 0), Quaternion.identity);
                Instantiate(lazerPrefab, transform.position + new Vector3(1.59f, - 0.48f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(lazerPrefab, transform.position + new Vector3(0, 0.09f, 0), Quaternion.identity);
            }
            nextfire = Time.time + firerate;
        }
    }


    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        if (SpeedBoost == true)
        {
            transform.Translate(Vector3.right * speed * 1.5f * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * speed * 1.5f * verticalInput * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        }
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, transform.position.z);
        }



        if (transform.position.x < -9)
        {
            transform.position = new Vector3(9, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 9)
        {
            transform.position = new Vector3(-9, transform.position.y, transform.position.z);
        }
    }

    public void damage()
    {
        if (Shield == true)
        {
            Shield = false;
            shieldGameObject.SetActive(true);

            return;
        }
        life--;
        
        if (life == -1)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            gameManager.gameOver = true;
            _hud.showTitle();

        }
        _hud.UpdateLives(life);


    }

    // POWER UPS ..........................................................................

    public void tripleShotOn()
    {
        tripleShot = true;
        StartCoroutine(TripleShotCool());
    }
    public IEnumerator TripleShotCool()
    {
        yield return new WaitForSeconds(5.0f);
        tripleShot = false;
    }

    public void SpeedBoostOn()
    {
        SpeedBoost = true;
        StartCoroutine(SpeedBoostOff());
    }

    public IEnumerator SpeedBoostOff()
    {
        yield return new WaitForSeconds(5.0f);
        SpeedBoost = false;
    }
    public void ShieldOn()
    {
        Shield = true;
        shieldGameObject.SetActive(true);
        
    }

}

