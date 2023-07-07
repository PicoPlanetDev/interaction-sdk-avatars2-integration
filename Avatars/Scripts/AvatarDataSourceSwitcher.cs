using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;
using Oculus.Avatar2;
using Oculus.Interaction.AvatarIntegration;

public class AvatarDataSourceSwitcher : MonoBehaviour
{
    // For now these are all private, at some point there may be a need for them to be public but not yet
    [Tooltip("The avatar entity that will be switched between hand and controller tracking")]
    [SerializeField] OvrAvatarEntity avatar;

    [Tooltip("The left hand tracking hand")]
    [SerializeField] Hand leftHand;
    [Tooltip("The right hand tracking hand")]
    [SerializeField] Hand rightHand;

    [Tooltip("The left controller hand")]
    [SerializeField] Hand leftControllerHand;
    [Tooltip("The right controller hand")]
    [SerializeField] Hand rightControllerHand;

    [Tooltip("The HandTrackingInputManager that will be used when hand tracking is active")]
    [SerializeField] HandTrackingInputManager handTrackingInputManager;
    [Tooltip("The HandTrackingInputManager that will be used when controllers are active")]
    [SerializeField] HandTrackingInputManager controllerTrackingInputManager;

    enum TrackingMode
    {
        Hand,
        Controller,
    }
    TrackingMode currentTrackingMode = TrackingMode.Hand; // Defaulted to hand because that's what I set in the avatar entity inspector

    void Update()
    {
        UpdateTrackingMode(); // This probably doesn't need to be called every frame, but it's fine for now
    }

    void UpdateTrackingMode()
    {
        // Get the current validity of the hand and controller tracking
        bool isHandTracking = leftHand.IsTrackedDataValid || rightHand.IsTrackedDataValid;
        bool isControllerTracking = leftControllerHand.IsTrackedDataValid || rightControllerHand.IsTrackedDataValid;

        if (isHandTracking && !isControllerTracking)
        {
            // If we need to switch to hand tracking
            if (currentTrackingMode != TrackingMode.Hand)
            {
                currentTrackingMode = TrackingMode.Hand; // Remember that we are now in hand tracking mode
                avatar.SetBodyTracking(handTrackingInputManager); // Set the avatar to use the HandTrackingInputManager with references to the hands
            }
        }
        else if (!isHandTracking && isControllerTracking)
        {
            // If we need to switch to controller tracking
            if (currentTrackingMode != TrackingMode.Controller)
            {
                currentTrackingMode = TrackingMode.Controller; // Remember that we are now in controller tracking mode
                avatar.SetBodyTracking(controllerTrackingInputManager); // Set the avatar to use the HandTrackingInputManager with references to the controllers
            }
        }
        // In an else case, there is BOTH a hand and a controller being tracked, or NEITHER is being tracked.
        // In such cases, we will just keep the current tracking mode.
    }
}
