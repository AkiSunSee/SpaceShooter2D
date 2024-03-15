using UnityEngine;

public class ScreenShake : AkiBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 0f;
    public float shakeMagnitude = 0.8f;
    public float dampingSpeed = 0.6f;

    Vector3 initialPosition;

    protected override void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        initialPosition = cameraTransform.localPosition;
    }

    protected virtual void Update()
    {
        if(GameCtrl.Instance.IsGamePaused()) return;
        if (shakeDuration > 0)
        {
            cameraTransform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            cameraTransform.localPosition = initialPosition;
        }
    }

    public void TriggerShake(float duration)
    {
        shakeDuration = duration;
    }
}
