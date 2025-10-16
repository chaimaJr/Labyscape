using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int damage = 1;
    public HealthController _healthController;
    private Animator anim;

    void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        if (_healthController == null)
        {
            Debug.LogError("HealthController is not assigned on " + gameObject.name);
            return;
        }

        _healthController.playerHealth -= damage;
        _healthController.UpdateHealth();

    }


}
