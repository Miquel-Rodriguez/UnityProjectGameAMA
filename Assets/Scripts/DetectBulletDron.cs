using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBulletDron : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int damage = 15;
    public DroneBehaviour drone;
    private void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (drone.life >= 0)
            {
                drone.LesslifeDrone(damage);
            }

        }
    }

}
