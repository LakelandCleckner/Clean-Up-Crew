using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }


    public float moveSpeed;

    [SerializeField] private Animator animator; // Now manually assignable in Inspector

    private Vector3 moveInput;

    public float pickupRange = 1.5f;

    //public Weapon activeWeapon;

    public List<Weapon> unassignedWeapons, assignedWeapons;

    public int maxWeapons = 3;

    [HideInInspector]
    public List<Weapon> fullyLeveledWeapons = new List<Weapon>();

    void Start()
    {
        if (assignedWeapons.Count == 0)
        {
            AddWeapon(Random.Range(0, unassignedWeapons.Count));
        }
        
        
        
        if (animator == null) // Ensure it’s assigned
        {
            animator = GetComponent<Animator>();
        }

       
    }

    void Update()
    {
        // Get movement input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        // Move the player
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        // Animation handling
        bool isMoving = moveInput.sqrMagnitude > 0;
        animator.SetBool("IsMoving", true);

        //Debug.Log("IsMoving value in Animator: " + animator.GetBool("IsMoving"));

        // Flip sprite left/right
        Transform spriteTransform = transform.Find("Sprite");
        if (spriteTransform != null)
        {
            if (moveInput.x > 0)
                spriteTransform.localScale = new Vector3(-1, 1, 1); // Face right
            else if (moveInput.x < 0)
                spriteTransform.localScale = new Vector3(1, 1, 1); // Face left
        }
    }

    public void AddWeapon(int weaponNumber)
    {
        if (weaponNumber < unassignedWeapons.Count)
        {
            assignedWeapons.Add(unassignedWeapons[weaponNumber]);

            unassignedWeapons[weaponNumber].gameObject.SetActive(true);
            unassignedWeapons.RemoveAt(weaponNumber);
        }
    }

    public void AddWeapon(Weapon weaponToAdd)
    {
        weaponToAdd.gameObject.SetActive(true);
        assignedWeapons.Add(weaponToAdd);
        unassignedWeapons.Remove(weaponToAdd);
    }
}
