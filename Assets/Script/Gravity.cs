using System;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
     Rigidbody rb;
     const float G = 0.006674f;
     public static List<Gravity> planetList;
    [SerializeField] bool planet = false;
    [SerializeField]int orbitspeed = 1000;

          private void Awake()
     {
          rb = GetComponent<Rigidbody>();
          if (planetList == null)
          {
               planetList = new List<Gravity>();
          }
          planetList.Add(this);
          if (!planet)
          {
               rb.AddForce(Vector3.left * orbitspeed);
          }
     }
     private void FixedUpdate()
     {
          foreach (var planet in planetList)
          {
               if (planet!=this) 
                    Attract(planet);
          }
     }

     void Attract(Gravity other)
     {
          Rigidbody otherRb = other.rb;
          Vector3 direction = rb.position - otherRb.position;
          float distance = direction.magnitude;
          float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
          Vector3 finaForce = forceMagnitude * direction.normalized;
          otherRb.AddForce(finaForce);

     }
}
