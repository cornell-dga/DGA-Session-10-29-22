using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EverythingElse : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public float killzone = -50f;
    public TextMeshProUGUI scoreText;


    List<GameObject> pickups = new List<GameObject>();
    int pickedUp = 0;


    Vector3 cameraInitialPos;

    public void Register(GameObject pickup) {
        pickups.Add(pickup);
    }

    public void OnPickedUp() {
        ++pickedUp;
        UpdateScoreText();
    }
    
    void Awake() {
        cameraInitialPos = cam.transform.position;
    }

    void Start() {
        UpdateScoreText();
    }

    // restore all pickups, reset player state
    public void Reset() {
        player.transform.position = Vector3.zero;
        player.transform.rotation = Quaternion.identity;
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        cam.transform.position = cameraInitialPos;

        foreach(GameObject pickup in pickups) {
            pickup.SetActive(true);
        }
        pickedUp = 0;
        UpdateScoreText();
    }

    void UpdateScoreText() {
        scoreText.text = pickedUp.ToString() + "/" + pickups.Count.ToString();
    }

    void Update()
    {
        // if player falls to their death, reset game
        if(player.transform.position.y < killzone) {
            Reset();
        }
    }
}
