using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject sword;
    public GameObject gun;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Sword")&& Input.GetKeyDown(KeyCode.F)) {
            Debug.Log("Sword picked up!");
            sword.SetActive(true);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Gun") && Input.GetKeyDown(KeyCode.F)) {
            Debug.Log("Gun picked up!");
            gun.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
