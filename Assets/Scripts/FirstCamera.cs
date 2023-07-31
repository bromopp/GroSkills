using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCamera : MonoBehaviour
{
    public HeroController Hero;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Hero.GetPosition();
        targetPosition.y = transform.position.y;
        targetPosition.z += -4;
        targetPosition.x += 6;
        transform.position = targetPosition ;
        
    }
}
