using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Sign : PlayerInteractable
    {
        public override void DialogInteraction()
        {
            base.DialogInteraction();
            dialogTextObject.text = dialogText;
            canInteract = isInteracting = false;
            ActivateDialogBox();
        }
    }
}