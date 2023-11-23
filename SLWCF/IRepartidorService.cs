using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IRepartidorService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IRepartidorService
    {
        [OperationContract]
        SLWCF.Repartidor Add(ML.Repartidor repartidor);
        [OperationContract]
        SLWCF.Repartidor Update(ML.Repartidor repartidor);
        [OperationContract]
        SLWCF.Repartidor Delete(ML.Repartidor repartidor);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Repartidor))]
        SLWCF.Repartidor GetAll(ML.Repartidor repartidor);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Repartidor))]
        SLWCF.Repartidor GetById(ML.Repartidor repartidor);


    }
}
