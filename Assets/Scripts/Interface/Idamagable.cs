using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public interface IDamagable 
{
    public void damage(float damageAmount, Vector2 attackDirection);

    public bool Hastakendamage { get; set; }
}
