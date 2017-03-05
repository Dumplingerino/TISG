using UnityEngine;

public class Interactable : MonoBehaviour {

    private string uiText = "Press E to interact";

    public string UiText
    {
        get
        {
            return uiText;
        }

        set
        {
            uiText = value;
        }
    }

    public virtual void Interact(PlayerInteractions player)
    {
        return;
    }
}
