using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniSpeedTest : MonoBehaviour
{
    public Animator ani;
    public void AniNaml()
    {
        ani.SetFloat("Speed", 1);
    }
    public void AniFast()
    {
        ani.SetFloat("Speed", 5);
    }
}
