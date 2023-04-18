using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftZone : MonoBehaviour
{
    [SerializeField] private int itemToCraftId;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerModel = other.GetComponent<PlayerModel>();
        if (playerModel)
        {
            Craft();
        }
    }

    private void Craft()
    {
        // Buscar que receta tiene ese item (se busca con el ID)
        var recipe = GameManager.Instance.CraftDatabase.GetRecipe(itemToCraftId);
        // Guardar los items que son necesarios para la receta(estan en la receta)
        Dictionary<int, int> requiredItemsAmount = new();
        foreach (var required in recipe.RequiredItems)
        {
            if (requiredItemsAmount.ContainsKey(required))
            {
                requiredItemsAmount[required]++;
            }
            else
            {
                requiredItemsAmount.Add(required, 1);
            }
        }

        // Comprobar que el jugador tenga los items
        var gotItems = false;
        foreach (var itemRequiredKVP in requiredItemsAmount)
        {
            if (!GameManager.Instance.PlayerInventory.CheckItem(itemRequiredKVP.Key, itemRequiredKVP.Value))
            {
                gotItems = false;
                return;
            }

            gotItems = true;
        }

        // Remover los items del inventario del jugador
        if (gotItems)
        {
            foreach (var itemRequiredKVP in requiredItemsAmount)
            {
                GameManager.Instance.PlayerInventory.RemoveItem(itemRequiredKVP.Key, itemRequiredKVP.Value);
            }

            // Otorgarle el item deseado
            GameManager.Instance.PlayerInventory.AddItem(itemToCraftId, recipe.ItemResultQuantity);
            Debug.LogWarning("Crafteo satisfactorio");
        }
        else
        {
            // Avisar que el craft fallo
            Debug.LogWarning("Mensaje en pantalla que no tiene items requeridos para el craft");
        }
    }
}