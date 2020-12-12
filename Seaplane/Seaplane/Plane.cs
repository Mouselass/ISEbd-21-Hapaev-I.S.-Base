using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Seaplane
{
    public class Plane : Vehicle, IEquatable<Plane>
    {
        protected readonly int planeWidth = 130;

        protected readonly int planeHeight = 60;

        protected readonly char separator = ';';

        public Plane(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        public Plane(string info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }

        protected Plane(int maxSpeed, float weight, Color mainColor, int planeWidth, int planeHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.planeWidth = planeWidth;
            this.planeHeight = planeHeight;
        }

        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {

                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - planeWidth)
                    {
                        _startPosX += step;
                    }
                    break;

                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;

                case Direction.Up:
                    if (_startPosY + step > planeHeight / 2)
                    {
                        _startPosY -= step;
                    }
                    break;

                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - planeHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        public override void DrawTransport(Graphics g)
        {
            Brush plane = new SolidBrush(MainColor);

            PointF p1 = new PointF(_startPosX + 20, _startPosY + 10);
            PointF p2 = new PointF(_startPosX + 65, _startPosY + 10);
            PointF p3 = new PointF(_startPosX + 65, _startPosY + 15);
            PointF p4 = new PointF(_startPosX + 85, _startPosY + 15);
            PointF p5 = new PointF(_startPosX + 85, _startPosY + 10);
            PointF p6 = new PointF(_startPosX + 115, _startPosY + 15);
            PointF p7 = new PointF(_startPosX + 125, _startPosY);
            PointF p8 = new PointF(_startPosX + 130, _startPosY);
            PointF p9 = new PointF(_startPosX + 130, _startPosY + 35);
            PointF p10 = new PointF(_startPosX + 105, _startPosY + 40);
            PointF p11 = new PointF(_startPosX + 20, _startPosY + 40);
            PointF p12 = new PointF(_startPosX + 20, _startPosY + 10);

            PointF[] planeP = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 };
            g.FillPolygon(plane, planeP);

            PointF w1 = new PointF(_startPosX + 35, _startPosY + 2);
            PointF w2 = new PointF(_startPosX + 75, _startPosY + 22);
            PointF w3 = new PointF(_startPosX + 82, _startPosY + 17);
            PointF w4 = new PointF(_startPosX + 45, _startPosY);
            PointF w5 = new PointF(_startPosX + 35, _startPosY + 2);
            PointF[] wingP = { w1, w2, w3, w4, w5 };
            g.FillPolygon(plane, wingP);
        }

        public override string ToString()
        {
            return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor.Name}";
        }

        public bool Equals(Plane other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Plane planeObj))
            {
                return false;
            }
            else
            {
                return Equals(planeObj);
            }
        }
    }
}
