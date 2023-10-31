using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.PackageManager;

public class PlayerShooting : MonoBehaviour
{
    
    [SerializeField] GameObject crossHair;

    [SerializeField] int maxAmmoInMag;
    [SerializeField] int ammoInMag;
    [SerializeField] int ammoTotal;
    [SerializeField] float reloadTime;

    [SerializeField] GameObject gunBarrel;
    [SerializeField] ParticleSystem explosion;

    [SerializeField] GameObject playerBarrel;

    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] GameObject glassText;


    bool gunAcquired = false;

    // Start is called before the first frame update
    void Start()
    {
        crossHair.SetActive(false);
        UpdateAmmoText();

        explosion.Stop();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(ammoInMag > 0 && gunAcquired && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

      // Ray ray = new Ray(playerBarrel.transform.position, transform.forward);
      // Debug.DrawRay(ray.origin, ray.direction * 10f, Color.green);
    }

    void Shoot()
    {
        ammoInMag -= 1;
        ammoTotal-= 1;
        UpdateAmmoText();

        //RayCast ray = new Ray();

        //RaycastHit hit;
        //
        //if(Physics.Raycast(playerBarrel.transform.forward, transform.forward, out hit))
        //{
        //    GameObject hitObject = hit.collider.gameObject;
        //
        //    if(hitObject.tag == "Head")
        //    {
        //        print("Headshot!");
        //    }
        //
        //    print("Hit this " + hit.collider.gameObject.name);
        //
        //}

        Ray ray = new Ray(playerBarrel.transform.position, playerBarrel.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Head"))
            {
                Transform currentTransform = hitObject.transform.parent;
                while (currentTransform.gameObject.tag != "Zombie")
                {
                    currentTransform = currentTransform.parent;
                }
                GameObject zombie = currentTransform.gameObject;

                GameObject modelZombie = zombie.transform.Find("man_zombie").gameObject;
                modelZombie = modelZombie.transform.GetChild(0).gameObject;
                modelZombie = modelZombie.transform.GetChild(0).gameObject;
                StartCoroutine(ZombieTurnsRed(modelZombie));

                StartCoroutine(zombie.GetComponent<ZombieHp>().HeadShot());
            }

            if (hitObject.CompareTag("Body"))
            {
                Transform currentTransform = hitObject.transform.parent;
                while (currentTransform.gameObject.tag != "Zombie")
                {
                    currentTransform = currentTransform.parent;
                }
                GameObject zombie = currentTransform.gameObject;

                GameObject modelZombie = zombie.transform.Find("man_zombie").gameObject;
                modelZombie = modelZombie.transform.GetChild(0).gameObject;
                modelZombie = modelZombie.transform.GetChild(0).gameObject;
                StartCoroutine(ZombieTurnsRed(modelZombie));

                zombie.GetComponent<ZombieHp>().BodyShot();

                
            }

            if (hitObject.CompareTag("Glass"))
            {
                if(glassText != null)
                    Destroy(glassText);
                Destroy(hitObject);
            }

            print("Hit this " + hitObject.name);
        }

        StartCoroutine(ShotFx());
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        int curMag = 0;

        if(ammoTotal >= maxAmmoInMag)
        {
            curMag = ammoInMag;
            ammoInMag = maxAmmoInMag;
        }
        else
        {
            ammoInMag = ammoTotal;
        }

       // print("Total ammo: " + ammoTotal + " ammo in mag: " + ammoInMag);

        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammoInMag.ToString() + " / " + (ammoTotal - ammoInMag).ToString();
    }

    IEnumerator ShotFx()
    {
        explosion.Play();
        yield return new WaitForSeconds(0.3f);
        explosion.Stop();
    }

    public void GunAcquired()
    {
        gunAcquired= true;
        crossHair.SetActive(true);

    }

    public void GainAmmo(int ammo)
    {
        ammoTotal += ammo;
        UpdateAmmoText();
    }

    IEnumerator ZombieTurnsRed(GameObject model)
    {
        SkinnedMeshRenderer renderer = model.GetComponent<SkinnedMeshRenderer>();
        Color old = renderer.material.color;
        Color col = Color.red;
        renderer.material.color = col;
        yield return new WaitForSeconds(0.5f);
        if(renderer !=null)
            renderer.material.color = old;  
    }
}
