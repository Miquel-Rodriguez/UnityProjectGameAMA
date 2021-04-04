using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform target;
    float maxSpeed;
    [SerializeField] float giroSpeed;
    [SerializeField] int maxHealth;
    private int actualHealth;
    [SerializeField] UIController uIController;
    private Transform chechPoint;

    void Start()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        maxSpeed = speed;
        actualHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        
        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, giroSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            StartCoroutine(moveAndWait(other));
            
        }
        
    }

    IEnumerator moveAndWait(Collider other)
    {
        yield return target = other.gameObject.GetComponent<WayPoint>().nextPoint;
        speed = 0;
        yield return new WaitForSeconds(5f);
        if (speed == 0)
        {
            speed += maxSpeed;
        }
       
    }

    private void TakeDamage(int damage)
    {
        actualHealth -= damage;
        //camiar barra de vida
        if (actualHealth<=0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        uIController.FadeIn();

        yield return new WaitForSeconds(uIController.fadeTime);
        gameObject.transform.position = chechPoint.position;
        actualHealth = maxHealth;
        uIController.FadeOut();
    }


}
