using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DronemovwmentTest : MonoBehaviour
{
    public Text SpeedTxt;
    public DroneMovement_ConfigData data;
    public CharacterController DroneCharaCtrl;

    // Movement 
    Vector3 OldDirection = Vector3.zero;
    Vector3 CurrentDirection = new Vector3();
    //#########

    // Rotation
    float mouseX;
    public float RotationHorSpeed;
    //#########

    // Camera Rotation
    public Transform TiltCamera;
    public Transform _Camera;

    public float MinAngle;
    public float MaxAngle;
    public float CameraSpeed;
    float mouseY;
    //################


    // Update is called once per frame
    void Update()
    {
        Vector3 _inputDirection = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (OldDirection != Vector3.zero)
        {
            float _decelValue = Mathf.Clamp((data.decel_k * OldDirection.magnitude) / data.decel_m, 0, OldDirection.magnitude);
            float _decel = Mathf.Round((OldDirection.magnitude - _decelValue * Time.deltaTime) * 10f) / 10f;

            if (_inputDirection == Vector3.zero && _decel < 4) _decel = 0;

            OldDirection = OldDirection.normalized * _decel;
        }

        float _acceleration = Mathf.Sqrt(Mathf.Pow(data.Acceleration_Z * _inputDirection.z, 2) + Mathf.Pow(data.Acceleration_X * _inputDirection.x, 2));

        _inputDirection = _inputDirection.normalized * _acceleration * Time.deltaTime;

        CurrentDirection = OldDirection + _inputDirection;

        CurrentDirection = CurrentDirection.normalized * Mathf.Clamp(CurrentDirection.magnitude, 0, data.SpeedMaxValue);

        SpeedTxt.text = ("Speed: " + CurrentDirection.magnitude.ToString("F2")).ToUpper();

        DroneCharaCtrl.Move(CurrentDirection * Time.deltaTime);
        OldDirection = CurrentDirection;

        mouseX += Input.GetAxis("Mouse X") * RotationHorSpeed;
        transform.rotation = Quaternion.Euler(0, mouseX, 0);

        //############ TILT ############################

        float _t = Mathf.Clamp01((CurrentDirection.magnitude - data.StartTilAtSpeed) / data.EndTilAtSpeed);

        float _TiltAngle = Mathf.Lerp(0, data.MaxAngleTilt, _t);

        Vector3 _Direction = transform.InverseTransformDirection(CurrentDirection);

        Vector3 _Vtilt = new Vector3(Mathf.Clamp01(_Direction.z), 0, -_Direction.x);

        TiltCamera.localRotation = Quaternion.Euler(_Vtilt.normalized * _TiltAngle);

        //############ END TILT ########################

        //############ CAMERA ########################

        mouseY += Input.GetAxis("Mouse Y") * CameraSpeed;

        mouseY = Mathf.Clamp(mouseY, MinAngle, MaxAngle);

        _Camera.localRotation = Quaternion.Euler(mouseY, 0, 0);

        //############ END CAMERA ########################
    }
}