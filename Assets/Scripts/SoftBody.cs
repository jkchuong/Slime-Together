using System;
using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{
    #region Fields
    
        [SerializeField] private SpriteShapeController spriteShape;
        [SerializeField] private Transform[] points;
        private CircleCollider2D[] circleCollider2Ds;
        private const float SPLINE_OFFSET = 1f;

        #endregion

    #region MonoBehaviour Callbacks

        private void Awake()
        {
            circleCollider2Ds = new CircleCollider2D[points.Length - 1];
            for (int i = 0; i < points.Length - 1; i++)
            {
                circleCollider2Ds[i] = points[i].GetComponent<CircleCollider2D>();
            }
            UpdateVertices();
        }

        private void Update()
        {
            UpdateVertices();
        }

    #endregion

    #region privateMethods
    
        private void UpdateVertices()
        {
            for (int i = 0; i < points.Length - 1; i++)
            {
                Vector2 vertex = points[i].localPosition;

                Vector2 towardsCenter = (Vector2.zero - vertex).normalized;

                float colliderRadius = circleCollider2Ds[i].radius;
                try
                { 
                    spriteShape.spline.SetPosition(i, (vertex - towardsCenter * colliderRadius));
                }
                catch
                {
                    spriteShape.spline.SetPosition(i, (vertex - towardsCenter * (colliderRadius + SPLINE_OFFSET)));
                }

                Vector2 leftTangent = spriteShape.spline.GetLeftTangent(i);
                
                Vector2 newRightTangent = Vector2.Perpendicular(towardsCenter) * leftTangent.magnitude;
                Vector2 newLeftTangent = -newRightTangent;
                
                spriteShape.spline.SetRightTangent(i, newLeftTangent);
                spriteShape.spline.SetLeftTangent(i, newRightTangent);
            }
        }
    
    #endregion
}
