using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    [SerializeField] TextMesh clockNumberPrefab;
    [SerializeField] float radius = 1f;
    TextMesh[] clockNumbers = new TextMesh[12];
    // Start is called before the first frame update
    void Start()
    {
        PositionClockNums();
    }
    /// <summary>
    /// Positions the 12 numbers of a clock using trig.
    /// </summary>
    private void PositionClockNums()
    {
        float angleRads = Mathf.PI / 2;
        for (int i = clockNumbers.Length-1; i >= 0; i--)
        {
            Vector3 clockNumPosition = new Vector3(Mathf.Cos(angleRads), Mathf.Sin(angleRads)) * radius;
            TextMesh newNumber = Instantiate(clockNumberPrefab, clockNumPosition, Quaternion.identity, this.transform);
            newNumber.text = (1+i).ToString();
            clockNumbers[i] = newNumber;
            angleRads += Mathf.PI / 6;
        }
    }
}
