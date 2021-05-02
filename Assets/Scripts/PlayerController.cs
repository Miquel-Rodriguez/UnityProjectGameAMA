using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private int life;
    [SerializeField] private int actualLife;
    [SerializeField] private MoveGunWithMouse moveGunWithMouse;
    [SerializeField] private Scene2Controller scene2Controller;
    [SerializeField] private HealthBar healthBar;

    [SerializeField] private Weapon defaultWeapon;
    [SerializeField] private Weapon secondWeapon;

    private bool dead;
    public bool unavez = true;
    private Vector3 vector1;
    [SerializeField] private float medidaAgacharse = 0.7f;
    [SerializeField] private int numCuras;
    [SerializeField] private int numGranades;
    [SerializeField] private int numLightGrandades;

    [SerializeField] private TextMeshProUGUI textCuras;
    [SerializeField] private TextMeshProUGUI textGranade;
    [SerializeField] private TextMeshProUGUI textLightGranade;


    [SerializeField] private float throwForce = 20f;
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private GameObject LightgrenadePrefab;

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
                if (transform.position.y.Equals(vector1.y))
                {
                    unavez = true;
                }

                
            }

            if (Input.GetKeyDown("1"))
            {
                if(!(numCuras<=0))
                {
                    Healing(50);
                    numCuras--;
                    CambiarTextos();
                }
                
            }

            if (Input.GetKeyDown("2"))
            {
               if (!(numGranades <= 0))
                {
                    ThrowGrenade(1);
                    numGranades--;
                    CambiarTextos();
                }
               
            }

            if (Input.GetKeyDown("3"))
            {
                if (!(numLightGrandades <= 0))
                {
                    ThrowGrenade(0);
                    numLightGrandades--;
                    CambiarTextos();
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
                if (!Input.GetKey("space"))
                {
                    LessLife(1);
                }
                print(collision.gameObject.tag);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Cura"))
            {
                numCuras++;
                CambiarTextos();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("LittleAmmo"))
            {
                int i = collision.gameObject.GetComponent<QuantitiLoot>().NumQuantityLoot;
                secondWeapon.AddBullets(i);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("BigAmmo"))
            {
                int i = collision.gameObject.GetComponent<QuantitiLoot>().NumQuantityLoot;
                defaultWeapon.AddBullets(i);
                Destroy(collision.gameObject);
                print("quiero añadir balas" + 1);
            }
            else if (collision.gameObject.CompareTag("Granade"))
            {
                numGranades++;
                CambiarTextos();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("LightGranade"))
            {
                numLightGrandades++;
                CambiarTextos();
                Destroy(collision.gameObject);
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

    private void Healing(int healing)
    {
        actualLife += healing;
        if (actualLife > 300)
        {
            actualLife = 300;
        }
        healthBar.SetHealth(actualLife);
    }

    private void CambiarTextos()
    {
        textCuras.SetText(numCuras.ToString());
        textGranade.SetText(numGranades.ToString());
        textLightGranade.SetText(numLightGrandades.ToString());
    }

    void ThrowGrenade(int num)
    {
        GameObject grenade;
        if (num == 1)
        {
            grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        }
        else
        {
            grenade = Instantiate(LightgrenadePrefab, transform.position, transform.rotation);
        }
      
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

}
