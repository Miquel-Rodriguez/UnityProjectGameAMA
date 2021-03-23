using UnityEngine;

public class AtractorScript : MonoBehaviour
{

    public float AttractorSpeed;

    private GameObject player;
    public Transform target;


    private void Start()
    {
        player = GameObject.Find("Player");
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, AttractorSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Movement movement = other.gameObject.GetComponent<Movement>();
            movement.ShowMessage(gameObject.name);
        }
    }
}

