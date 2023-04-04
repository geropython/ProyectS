using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputController inputController;
        [SerializeField] private PlayerModel playerModel;

        private void Update()
        {
            playerModel.Move(inputController.Movement);
        }
    }
}
