using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public delegate float EasingFunction(float t);
public static class Easing
{

    public static EasingFunction Get(EaseEnum type)
    {
        switch (type)
        {
            case EaseEnum.Linear: return linear;
            case EaseEnum.InBack: return inBack;
            case EaseEnum.InBounce: return inBounce;
            case EaseEnum.InCirc: return inCirc;
            case EaseEnum.InCubic: return inCubic;
            case EaseEnum.InElastic: return inElastic;
            case EaseEnum.InExpo: return inExpo;
            case EaseEnum.InQuad: return inQuad;
            case EaseEnum.InQuart: return inQuart;
            case EaseEnum.InQuint: return inQuint;
            case EaseEnum.InSine: return inSine;
            case EaseEnum.OutBack: return outBack;
            case EaseEnum.OutBounce: return outBounce;
            case EaseEnum.OutCirc: return outCirc;
            case EaseEnum.OutCubic: return outCubic;
            case EaseEnum.OutElastic: return outElastic;
            case EaseEnum.OutExpo: return outExpo;
            case EaseEnum.OutQuad: return outQuad;
            case EaseEnum.OutQuart: return outQuart;
            case EaseEnum.OutQuint: return outQuint;
            case EaseEnum.OutSine: return outSine;
            case EaseEnum.InOutBack: return inOutBack;
            case EaseEnum.InOutBounce: return inOutBounce;
            case EaseEnum.InOutCirc: return inOutCirc;
            case EaseEnum.InOutCubic: return inOutCubic;
            case EaseEnum.InOutElastic: return inOutElastic;
            case EaseEnum.InOutExpo: return inOutExpo;
            case EaseEnum.InOutQuad: return inOutQuad;
            case EaseEnum.InOutQuart: return inOutQuart;
            case EaseEnum.InOutQuint: return inOutQuint;
            case EaseEnum.InOutSine: return inOutSine;
            default: return linear;
        }

        float linear(float t) => t;

        float inBack(float t) => t * t * t - t * Mathf.Sin(t * Mathf.PI);

        float outBack(float t) => 1f - inBack(1f - t);

        float inOutBack(float t) =>
            t < 0.5f
                ? 0.5f * inBack(2f * t)
                : 0.5f * outBack(2f * t - 1f) + 0.5f;

        float inBounce(float t) => 1f - outBounce(1f - t);

        float outBounce(float t) =>
            t < 4f / 11.0f ?
                (121f * t * t) / 16.0f :
            t < 8f / 11.0f ?
                (363f / 40.0f * t * t) - (99f / 10.0f * t) + 17f / 5.0f :
            t < 9f / 10.0f ?
                (4356f / 361.0f * t * t) - (35442f / 1805.0f * t) + 16061f / 1805.0f :
                (54f / 5.0f * t * t) - (513f / 25.0f * t) + 268f / 25.0f;

        float inOutBounce(float t) =>
            t < 0.5f
                ? 0.5f * inBounce(2f * t)
                : 0.5f * outBounce(2f * t - 1f) + 0.5f;

        float inCirc(float t) => 1f - Mathf.Sqrt(1f - (t * t));

        float outCirc(float t) => Mathf.Sqrt((2f - t) * t);

        float inOutCirc(float t) =>
            t < 0.5f
                ? 0.5f * (1 - Mathf.Sqrt(1f - 4f * (t * t)))
                : 0.5f * (Mathf.Sqrt(-((2f * t) - 3f) * ((2f * t) - 1f)) + 1f);

        float inCubic(float t) => t * t * t;

        float outCubic(float t) => inCubic(t - 1f) + 1f;

        float inOutCubic(float t) =>
            t < 0.5f
                ? 4f * t * t * t
                : 0.5f * inCubic(2f * t - 2f) + 1f;

        float inElastic(float t) => Mathf.Sin(13f * (Mathf.PI * 0.5f) * t) * Mathf.Pow(2f, 10f * (t - 1f));

        float outElastic(float t) => Mathf.Sin(-13f * (Mathf.PI * 0.5f) * (t + 1)) * Mathf.Pow(2f, -10f * t) + 1f;

        float inOutElastic(float t) =>
            t < 0.5f
                ? 0.5f * Mathf.Sin(13f * (Mathf.PI * 0.5f) * (2f * t)) * Mathf.Pow(2f, 10f * ((2f * t) - 1f))
                : 0.5f * (Mathf.Sin(-13f * (Mathf.PI * 0.5f) * ((2f * t - 1f) + 1f)) * Mathf.Pow(2f, -10f * (2f * t - 1f)) + 2f);

        float inExpo(float t) => Mathf.Approximately(0.0f, t) ? t : Mathf.Pow(2f, 10f * (t - 1f));

        float outExpo(float t) => Mathf.Approximately(1.0f, t) ? t : 1f - Mathf.Pow(2f, -10f * t);

        float inOutExpo(float v) =>
            Mathf.Approximately(0.0f, v) || Mathf.Approximately(1.0f, v)
                ? v
                : v < 0.5f
                    ? 0.5f * Mathf.Pow(2f, (20f * v) - 10f)
                    : -0.5f * Mathf.Pow(2f, (-20f * v) + 10f) + 1f;

        float inQuad(float t) => t * t;

        float outQuad(float t) => -t * (t - 2f);

        float inOutQuad(float t) =>
            t < 0.5f
                ? 2f * t * t
                : -2f * t * t + 4f * t - 1f;

        float inQuart(float t) => t * t * t * t;

        float outQuart(float t)
        {
            var u = t - 1f;
            return u * u * u * (1f - t) + 1f;
        }

        float inOutQuart(float t) =>
            t < 0.5f
                ? 8f * inQuart(t)
                : -8f * inQuart(t - 1f) + 1f;

        float inQuint(float t) => t * t * t * t * t;

        float outQuint(float t) => inQuint(t - 1f) + 1f;

        float inOutQuint(float t) =>
            t < 0.5f
                ? 16f * inQuint(t)
                : 0.5f * inQuint(2f * t - 2f) + 1f;

        float inSine(float t) => Mathf.Sin((t - 1f) * (Mathf.PI * 0.5f)) + 1f;

        float outSine(float t) => Mathf.Sin(t * (Mathf.PI * 0.5f));

        float inOutSine(float t) => 0.5f * (1f - Mathf.Cos(t * Mathf.PI));
    }
}
