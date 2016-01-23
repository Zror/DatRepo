using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class ProceduralWorldSettings : MonoBehaviour
{
    private const string spawnatTooltip =
        "A Spawn At rate is the mark that a certain value must surpass in order to spawn an object of it's class. These systems accrew value until they surpass the required spawn at point.";

    //These do not need to be the same distance. If they are not, their values will be solved for independantly to create unique curves.
    public float seed = 0;
    [Tooltip("Large jitter amounts will cause very random worlds. Low values are more deterministic. 0 will result in entirely predictible results")]
    [Range(0,1)]
    public float worldJitterAmount = 0.05f;

    [Header("Ground")]
    public AnimationCurve grassRate = AnimationCurve.EaseInOut(0,1,60,1);
    public AnimationCurve swampRate = AnimationCurve.EaseInOut(0, 1, 60, 1);
    public AnimationCurve dirtRate = AnimationCurve.EaseInOut(0, 1, 60, 1);

    [Header("Obsticles")]
    [Tooltip(spawnatTooltip)]
    public float towerSpawnAt;
    public AnimationCurve towerRate = AnimationCurve.EaseInOut(0, 1, 60, 1);

    [Tooltip(spawnatTooltip)]
    public float cloudSpawnAt;
    public AnimationCurve cloudRate = AnimationCurve.EaseInOut(0, 1, 60, 1);

    [Tooltip(spawnatTooltip)]
    public float stormCloudSpawnAt;
    public AnimationCurve stormCloudRate = AnimationCurve.EaseInOut(0, 1, 60, 1);

    [Header("Powerups and Loot")]
    [Tooltip(spawnatTooltip)]
    public float coinSpawnAt;
    public AnimationCurve coinRate = AnimationCurve.EaseInOut(0, 1, 60, 1);

    [Tooltip(spawnatTooltip)]
    public float haystackSpawnAt;
    public AnimationCurve haystackRate = AnimationCurve.EaseInOut(0, 1, 60, 1);

    [Tooltip(spawnatTooltip)]
    public float livestockSpawnAt;
    public AnimationCurve livestockRate = AnimationCurve.EaseInOut(0, 1, 60, 1);

    protected void Awake()
    {
        seed = Random.Range(0.0f, 10000.0f); //Calculate a random offset for this world. Different seeds will yield different results.
    }

    public float GetValueFromCurveAtPosition(AnimationCurve curve, float xPosition)
    {
        float xPos = xPosition + seed;
        xPos = xPos % curve[curve.length - 1].time;
        var result = curve.Evaluate(xPos);
        result += Random.Range(-worldJitterAmount, worldJitterAmount);
        result = Mathf.Clamp01(result);
        return result;
    }
}
