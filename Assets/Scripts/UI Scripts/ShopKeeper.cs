using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] List<GameObject> thingsToShow;
    [SerializeField] GameObject interact;
    private bool interactIsActive;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactIsActive = true;
            //This has to be specific
            thingsToShow[0].SetActive(true);
            interact.SetActive(false);
            AudioManager.instance.PlayOneshotSFX(AudioManager.AudioSamples.shopKeeperHum);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       
            if (!interactIsActive && collision.tag.Equals("Player"))
            {
                interact.SetActive(true);
                interactIsActive = true;
            }
        
      
     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject go in thingsToShow)
        {
            go.SetActive(false);
        }
        interact.SetActive(false);
        interactIsActive = false;
    }

}

