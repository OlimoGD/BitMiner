using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MouseArea : MonoBehaviour
{
    public delegate void OnMouseHoverEnteredDelegate(int zOrder);
    ///<summary>The frame the mouse entered the area.</summary>
    ///<param name="zOrder">0 if this is the top-most MouseArea of the ones the mouse is over, 
    ///1 if this is the second top-most etc.</param>
    public event OnMouseHoverEnteredDelegate OnMouseHoverEntered;

    public delegate void OnMouseHoverDelegate(int zOrder);
    ///<summary>Called every frame the mouse is in the area.</summary>
    ///<param name="zOrder">0 if this is the top-most MouseArea of the ones the mouse is over, 
    ///1 if this is the second top-most etc.</param>
    public event OnMouseHoverDelegate OnMouseHover;

    public delegate void OnMouseHoverExitedDelegate();
    ///<summary>The frame the mouse left the area.</summary>
    public event OnMouseHoverExitedDelegate OnMouseHoverExited;

    public delegate void OnMousePrimaryButtonPressedDelegate(int zOrder);
    ///<summary>The frame the primary mouse button was pressed while in the area.</summary>
    public event OnMousePrimaryButtonPressedDelegate OnMousePrimaryButtonPressed;

    public delegate void OnMousePrimaryButtonHoldingDelegate();
    ///<summary>Called every frame while the primary mouse button that was pressed in the area
    /// is held down. Called even if the mouse already left the area.</summary>
    public event OnMousePrimaryButtonHoldingDelegate OnMousePrimaryButtonHolding;

    public delegate void OnMousePrimaryButtonReleasedDelegate();
    ///<summary>Called the frame the primary mouse button that was pressed in the area
    /// is released. Called even if the mouse already left the area.</summary>
    public event OnMousePrimaryButtonReleasedDelegate OnMousePrimaryButtonReleased;

    public delegate void OnMouseSecondaryButtonPressedDelegate(int zOrder);
    ///<summary>The frame the secondary mouse button was pressed while in the area.</summary>
    ///<param name="zOrder">0 if this is the top-most MouseArea of the ones the mouse is over, 
    ///1 if this is the second top-most etc.</param>
    public event OnMouseSecondaryButtonPressedDelegate OnMouseSecondaryButtonPressed;

    public delegate void OnMouseSecondaryButtonHoldingDelegate();
    ///<summary>Called every frame while the secondary mouse button that was pressed in the area
    /// is held down. Called even if the mouse already left the area.</summary>
    public event OnMouseSecondaryButtonHoldingDelegate OnMouseSecondaryButtonHolding;

    public delegate void OnMouseSecondaryButtonReleasedDelegate();
    ///<summary>Called the frame the secondary mouse button that was pressed in the area
    /// is released. Called even if the mouse already left the area.</summary>
    public event OnMouseSecondaryButtonReleasedDelegate OnMouseSecondaryButtonReleased;

    public void MouseHoverEntered(int zOrder)
    {
        OnMouseHoverEntered?.Invoke(zOrder);
    }

    public void MouseHover(int zOrder)
    {
        OnMouseHover?.Invoke(zOrder);
    }
    
    public void MouseHoverExited()
    {
        OnMouseHoverExited?.Invoke();
    }

    public void MouseButtonPressed(int button, int zOrder)
    {
        if(button == 0)
        {
            OnMousePrimaryButtonPressed?.Invoke(zOrder);
        }
        else if(button == 1)
        {
            OnMouseSecondaryButtonPressed?.Invoke(zOrder);
        }
    }

    public void MouseButtonHolding(int button)
    {
        if(button == 0)
        {
            OnMousePrimaryButtonHolding?.Invoke();
        }
        else if(button == 1)
        {
            OnMouseSecondaryButtonHolding?.Invoke();
        }
    }

    public void MouseButtonReleased(int button)
    {
        if(button == 0)
        {
            OnMousePrimaryButtonReleased?.Invoke();
        }
        else if(button == 1)
        {
            OnMouseSecondaryButtonReleased?.Invoke();
        }
    }
}
