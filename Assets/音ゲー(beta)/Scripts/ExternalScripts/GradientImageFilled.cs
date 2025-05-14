using UnityEngine;
using UnityEngine.UI;
public class GradientImageFilled : GradientImage
{
    [SerializeField, Range(0, 1f)]
    private float _fillAmount;
    public override void ModifyMesh(VertexHelper helper)
    {
        _vertexList.Clear();
        helper.GetUIVertexStream(_vertexList);

        CreateGradientMesh();
        var targetPos = Mathf.Lerp(_minMax[0], _minMax[1], _fillAmount);
        for (var index = 0; index < _vertexList.Count; index += 6)
        {
            var minMaxUV = new Vector2(_vertexList[index].uv0[_axisIndex], _vertexList[index].uv0[_axisIndex]);
            var minMaxPos = new Vector2(_vertexList[index].position[_axisIndex], _vertexList[index].position[_axisIndex]);
            for (var i = 1; i < 6; i++)
            {
                if (minMaxUV[0] > _vertexList[index + i].uv0[_axisIndex])
                    minMaxUV[0] = _vertexList[index + i].uv0[_axisIndex];
                if (minMaxUV[1] < _vertexList[index + i].uv0[_axisIndex])
                    minMaxUV[1] = _vertexList[index + i].uv0[_axisIndex];
                if (minMaxPos[0] > _vertexList[index + i].position[_axisIndex])
                    minMaxPos[0] = _vertexList[index + i].position[_axisIndex];
                if (minMaxPos[1] < _vertexList[index + i].position[_axisIndex])
                    minMaxPos[1] = _vertexList[index + i].position[_axisIndex];
            }
            for (var i = 0; i < 6; i++)
            {
                var vertex = _vertexList[index + i];
                if (!(_fillAmount < Mathf.InverseLerp(_minMax[0], _minMax[1], vertex.position[_axisIndex])))
                    continue;

                var pos = vertex.position;
                pos[_axisIndex] = targetPos;
                vertex.position = pos;
                var uv = vertex.uv0;
                uv[_axisIndex] = Mathf.Lerp(minMaxUV[0], minMaxUV[1], Mathf.InverseLerp(minMaxPos[0], minMaxPos[1], pos[_axisIndex]));
                vertex.uv0 = uv;
                _vertexList[index + i] = vertex;
            }
        }

        SetVertexColor();
        helper.Clear();
        helper.AddUIVertexTriangleStream(_vertexList);
    }
}
