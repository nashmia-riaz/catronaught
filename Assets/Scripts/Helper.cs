using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public delegate void basicFunction();
    public static IEnumerator waitBeforeExecution(float time, basicFunction toExecute)
    {
        float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        toExecute();
    }
}
