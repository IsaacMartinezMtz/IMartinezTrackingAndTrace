using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "RepartidorService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione RepartidorService.svc o RepartidorService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class RepartidorService : IRepartidorService
    {
        public Repartidor Add(ML.Repartidor repartidor)
        {
            ML.Repartidor repartidorA = BL.Repartidor.Add(repartidor);
            return new SLWCF.Repartidor
            {
                Correct = repartidorA.Correct,
                Object = repartidorA.Object,
                Objects = repartidorA.Objects

            };
        }
        public Repartidor Delete(ML.Repartidor repartidor)
        {
            ML.Repartidor repartidorD = BL.Repartidor.Delete(repartidor.IdRepartidor);
            return new SLWCF.Repartidor
            {
                Correct = repartidorD.Correct,
                Object = repartidorD.Object,
                Objects = repartidorD.Objects

            };
        }

        public Repartidor GetAll(ML.Repartidor repartidor)
        {
            ML.Repartidor repartidorG = BL.Repartidor.GetAll();
            return new SLWCF.Repartidor
            {
                Correct = repartidorG.Correct,
                Object = repartidorG.Object,
                Objects = repartidorG.Objects

            };
        }

        public Repartidor GetById(ML.Repartidor repartidor)
        {
            ML.Repartidor repartidorG = BL.Repartidor.GetById(repartidor.IdRepartidor);
            return new SLWCF.Repartidor
            {
                Correct = repartidorG.Correct,
                Object = repartidorG.Object,
                Objects = repartidorG.Objects

            };
        }

        public Repartidor Update(ML.Repartidor repartidor)
        {
            ML.Repartidor repartidorG = BL.Repartidor.Update(repartidor);
            return new SLWCF.Repartidor
            {
                Correct = repartidorG.Correct,
                Object = repartidorG.Object,
                Objects = repartidorG.Objects

            };
        }
    }
}
