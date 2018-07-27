using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
		[SerializeField] private Inventory inventory;

    int health = 80;
    int max_health = 100;

    float speed = 2; // Units per sec.
    float mouse_sensivity = 4;
    float jump_power = 300;
    Rigidbody rb;
    int jump_max = 3;
    int jump_count = 0;
	
    bool play_in_2D = false;

		//Inventory inventory = new Inventory();

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Triggered: " + collider.name);

        // If it's a MedKit increase health.
        MedKit kit = collider.GetComponent<MedKit>();
				Item item = collider.GetComponent<Item>();

				if(item != null)
				{
					inventory.InsertItem(item);
				}

				if (kit != null)
				{
					UpdateHealth(kit.HealingPower);
					// Find the inventory, find and empy slot,
					// shove an item at it
					//inventory.InsertItem(kit);
				}
            

    }

    private void UpdateHealth(int amount)
    {
        health += amount;
        healthBar.value = health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided.");
        jump_count = 0;
    }

    private void Start()
    {
        healthBar.maxValue = max_health;
        healthBar.value = health;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Testing.
        



        if (play_in_2D)
        {
            if (Input.GetKey(KeyCode.A))
                transform.position -= transform.forward * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.D))
                transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        { 
            float y_rotation = Input.GetAxis("Horizontal");
            transform.Rotate(new Vector3(0, y_rotation / mouse_sensivity, 0));

            if (Input.GetKey(KeyCode.W))
                transform.position += transform.forward * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.S))
                transform.position -= transform.forward * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.A))
                transform.position -= transform.right * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.D))
                transform.position += transform.right * speed * Time.deltaTime;

        }

        if (Input.GetKeyDown(KeyCode.Space) && jump_count < jump_max)
        {
            jump_count++;
            rb.AddForce(Vector3.up * jump_power);
        }
    }
}