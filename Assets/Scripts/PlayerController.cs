using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private int life;
    [SerializeField] private int actualLife;
    [SerializeField] private MoveGunWithMouse moveGunWithMouse;
    [SerializeField] private Scene2Controller scene2Controller;
    [SerializeField] private HealthBar healthBar;
    private bool dead;
    private bool unavez = true;
    private Vector3 vector1;
    [SerializeField] private float medidaAgacharse = 0.7f;

    void Start()
    {
        actualLife = life;
        healthBar.SetMaxHealth(life);
    }

    
    void Update()
    {
        if (!dead)
        {
            if (Input.GetKey("space"))
            {
                
                if (unavez)
                {                  
                    vector1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    unavez = false;
                }
                else
                {
                    if (!transform.position.y.Equals(vector1.y - medidaAgacharse))
                    {
                        Vector3 v= new Vector3(vector1.x, vector1.y- medidaAgacharse, vector1.z);
                        transform.position = Vector3.MoveTowards(transform.position,v , 2* Time.deltaTime);
    
                    }
                   
                }

            }
            else if(!unavez)
            {

                if (!transform.position.y.Equals(vector1.y + medidaAgacharse))
                {
                    transform.position = Vector3.MoveTowards(transform.position, vector1, 2 * Time.deltaTime);
                }
            }

        }
        else
        {
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!dead)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                if (!Input.GetKey("space"))
                {
                    LessLife(1);
                }
                    

            }
        }
    }


    private void LessLife(int damage)
    {
        actualLife -= damage;
        healthBar.SetHealth(actualLife);
        if (actualLife <= 0)
        {
            dead = true;
            moveGunWithMouse.enabled = false;
            StartCoroutine(scene2Controller.ShowDeadGUI());
            print("muerto");
        }
    }

    private IEnumerator CambiarDeEscena()
    {
        yield return new WaitForSeconds(0.5f);
        scene2Controller.SceneSwitcher(1);
    }

}
