using RevenueRecognitionSystem.Domain.DTOs.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Interfaces.Services
{
    public interface IContractService
    {
        void CreateContract(CreateContractDTO requestData);
        decimal PayForContract(PayForContractDTO request);
    }
}
