using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] public int health;
        [SerializeField] public int maxHealth;
        [SerializeField] private InputController inputController;
        [SerializeField] private PlayerModel playerModel;

        private void Update()
        {
            playerModel.Move(inputController.Movement);
        }
        private void Start()
        {
            health = maxHealth;
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            Debug.Log("Damage= " + health);

            if (health <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Morido");
            }
        }
    }
}
