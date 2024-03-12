using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class HandHapticArduinoManager : MonoBehaviour
{
    [SerializeField] private HandHapticDistanceCalculator handHapticDistanceCalculator;
    [SerializeField] private float _maxDistanceValue = 0.01f;

    [SerializeField] private List<float> fingerTipToInteractableDistanceList;

    [Header("Arduino Pin SetUp For Thumb")]
    [SerializeField] private const int _thumbArduinoVCCPin = 13;
    [SerializeField] private const int _thumbArduinoGNDPin = 12;
    [SerializeField] private const int _thumbArduinoPWMPin = 11;

    [Header("Arduino Pin SetUp For Index")]
    [SerializeField] private const int _indexArduinoVCCPin = 9;
    [SerializeField] private const int _indexArduinoGNDPin = 8;
    [SerializeField] private const int _indexArduinoPWMPin = 10;

    [Header("Arduino Pin SetUp For Middle")]
    [SerializeField] private const int _middleArduinoVCCPin = 7;
    [SerializeField] private const int _middleArduinoGNDPin = 6;
    [SerializeField] private const int _middleArduinoPWMPin = 5;

    [Header("Arduino Pin SetUp For Ring")]
    [SerializeField] private const int _ringArduinoVCCPin = 4;
    [SerializeField] private const int _ringArduinoGNDPin = 2;
    [SerializeField] private const int _ringArduinoPWMPin = 3;

    //[Header("Arduino Pin SetUp For Pinky")]
    //private const int _pinkyArduinoVCCPin = 8;
    //private const int _pinkyArduinoGNDPin = 12;
    //private const int _pinkyArduinoPWMPin = 16;

    void Start()
    {
        //Set PinMode
        //Set VCC pins
        UduinoManager.Instance.pinMode(_thumbArduinoVCCPin, PinMode.Output);
        UduinoManager.Instance.pinMode(_indexArduinoVCCPin, PinMode.Output);
        UduinoManager.Instance.pinMode(_middleArduinoVCCPin, PinMode.Output);
        UduinoManager.Instance.pinMode(_ringArduinoVCCPin, PinMode.Output);
        //UduinoManager.Instance.pinMode(_pinkyArduinoVCCPin, PinMode.Output);

        //Set GND pins
        UduinoManager.Instance.pinMode(_thumbArduinoGNDPin, PinMode.Output);
        UduinoManager.Instance.pinMode(_indexArduinoGNDPin, PinMode.Output);
        UduinoManager.Instance.pinMode(_middleArduinoGNDPin, PinMode.Output);
        UduinoManager.Instance.pinMode(_ringArduinoGNDPin, PinMode.Output);
        //UduinoManager.Instance.pinMode(_pinkyArduinoGNDPin, PinMode.Output);

        //Set PWM pins
        UduinoManager.Instance.pinMode(_thumbArduinoPWMPin, PinMode.Output);
        UduinoManager.Instance.pinMode(_indexArduinoPWMPin, PinMode.Output);
        UduinoManager.Instance.pinMode(_middleArduinoPWMPin, PinMode.Output);
        UduinoManager.Instance.pinMode(_ringArduinoPWMPin, PinMode.Output);
        //UduinoManager.Instance.pinMode(_pinkyArduinoPWMPin, PinMode.Output);

        //Set States.
        UduinoManager.Instance.digitalWrite(_thumbArduinoVCCPin, State.HIGH);
        UduinoManager.Instance.digitalWrite(_thumbArduinoGNDPin, State.LOW);

        UduinoManager.Instance.digitalWrite(_indexArduinoVCCPin, State.HIGH);
        UduinoManager.Instance.digitalWrite(_indexArduinoGNDPin, State.LOW);

        UduinoManager.Instance.digitalWrite(_middleArduinoVCCPin, State.HIGH);
        UduinoManager.Instance.digitalWrite(_middleArduinoGNDPin, State.LOW);

        UduinoManager.Instance.digitalWrite(_ringArduinoVCCPin, State.HIGH);
        UduinoManager.Instance.digitalWrite(_ringArduinoGNDPin, State.LOW);

        //UduinoManager.Instance.digitalWrite(_pinkyArduinoVCCPin, State.HIGH);
        //UduinoManager.Instance.digitalWrite(_pinkyArduinoGNDPin, State.LOW);

    }

    void Update()
    {
        fingerTipToInteractableDistanceList = handHapticDistanceCalculator.GetFingerTipToInteractableDistanceList();

        if (fingerTipToInteractableDistanceList.Count > 0)
        {
            UduinoManager.Instance.analogWrite(
                _thumbArduinoPWMPin,
                MapDistancceToPWMDistance(fingerTipToInteractableDistanceList[0])
            );

            UduinoManager.Instance.analogWrite(
                _indexArduinoPWMPin,
                MapDistancceToPWMDistance(fingerTipToInteractableDistanceList[1])
            );

            UduinoManager.Instance.analogWrite(
                _middleArduinoPWMPin,
                MapDistancceToPWMDistance(fingerTipToInteractableDistanceList[2])
            );

            UduinoManager.Instance.analogWrite(
                _ringArduinoPWMPin,
                MapDistancceToPWMDistance(fingerTipToInteractableDistanceList[3])
            );

            /*

            UduinoManager.Instance.analogWrite(
                _pinkyArduinoPWMPin,
                MapDistancceToPWMDistance(fingerTipToInteractableDistanceList[4])
            );

            */
        }
    }

    public int MapDistancceToPWMDistance(float distance)
    {
        if (distance > _maxDistanceValue)
        {
            return 0;
        }
        else
        {
            return 122;
        }
    }
}
