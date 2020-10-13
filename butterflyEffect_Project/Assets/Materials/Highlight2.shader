Shader "Unlit/Outline2"
{
    Properties
    {
        _OutlineColor("OutlineColor", Color) = (1,0,0,0)
        _ScaleFactor("ScaleFactor ", Float) = 1.1
    }
    SubShader
    {
        Tags
        {
            "RenderPipeline" = "LightweightPipeline"
            "RenderType" = "Transparent"
            "Queue" = "Transparent+0"
        }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha

            Cull Front

            ZTest LEqual

            ZWrite Off

        }
    }
}
