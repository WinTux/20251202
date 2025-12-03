using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosVarios.Dibujables
{
    internal class DibujoReloj : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            DateTime tiempoActual = DateTime.Now;

            var centroReloj = new PointF(dirtyRect.Width / 2, dirtyRect.Height / 2);
            int radioCirculo = 100;

            canvas.StrokeColor = Colors.Tomato;
            canvas.StrokeSize = 6;

            // Dibujar el círculo del reloj
            canvas.DrawCircle(centroReloj, radioCirculo);
            canvas.DrawCircle(centroReloj, 5); // Centro del reloj

            canvas.StrokeSize = 4;

            var horero = GetManecillaHorero(tiempoActual,radioCirculo,centroReloj);
            canvas.DrawLine(centroReloj, horero);
            var minutero = GetManecillaMinutero(tiempoActual, radioCirculo, centroReloj);
            canvas.DrawLine(centroReloj, minutero);
            var segundero = GetManecillaSegundero(tiempoActual, radioCirculo, centroReloj);
            canvas.DrawLine(centroReloj, segundero);
        }

        private PointF GetManecillaSegundero(DateTime tActual, int radio, PointF centro)
        {
            int minutoActual = tActual.Second;
            var anguloGrad = minutoActual * 360 / 60;
            var anguloRad = (Math.PI / 180) * anguloGrad;
            var longitudManecilla = radio * 0.8;
            PointF extremoManecilla = new PointF(
                centro.X + (float)(longitudManecilla * Math.Sin(anguloRad)),
                centro.Y - (float)(longitudManecilla * Math.Cos(anguloRad))
            );
            return extremoManecilla;
        }

        private PointF GetManecillaMinutero(DateTime tActual, int radio, PointF centro)
        {
            int minutoActual = tActual.Minute;
            var anguloGrad = minutoActual * 360 / 60;
            var anguloRad = (Math.PI / 180) * anguloGrad;
            var longitudManecilla = radio * 0.8;
            PointF extremoManecilla = new PointF(
                centro.X + (float)(longitudManecilla * Math.Sin(anguloRad)),
                centro.Y - (float)(longitudManecilla * Math.Cos(anguloRad))
            );
            return extremoManecilla;
        }

        private PointF GetManecillaHorero(DateTime tActual, int radio, PointF centro)
        {
            int horaActual = tActual.Hour;
            if(horaActual >= 12) horaActual -= 12;
            var anguloGrad = horaActual * 360 / 12;
            var anguloRad = (Math.PI / 180) * anguloGrad;
            var longitudManecilla = radio * 0.5;
            PointF extremoManecilla = new PointF(
                centro.X + (float)(longitudManecilla * Math.Sin(anguloRad)),
                centro.Y - (float)(longitudManecilla * Math.Cos(anguloRad))
            );
            return extremoManecilla;
        }
    }
}
