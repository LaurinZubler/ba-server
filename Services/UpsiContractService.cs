
using ba_server.Models.Requests;
using ba_server.Models.Responses;
using ba_server.Services.Interfaces;
using Nethereum.Hex.HexTypes;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace ba_server.Services;

public class UpsiContractService : IUpsiContractService
{

  public async Task<EmitInfectionEventResponse> EmitInfectionEventAsync(EmitInfectionEventRequest request)
  {
    var account = new Account(OPTIMISM_SEPOLIA_PRIVATE_KEY, 11155420);
    var url = $"https://optimism-sepolia.infura.io/v3/{INFURA_API_KEY}";



    var web3 = new Web3(account, url);

    var contract = web3.Eth.GetContract(ABI, UPSI_CONTRACT_ADDRESS);
    
    var emitInfectionEventFunction = contract.GetFunction("emitInfectionEvent");

    var transactionInput = emitInfectionEventFunction.CreateTransactionInput(
      account.Address,
      new HexBigInteger(50000), // Gas Limit
      new HexBigInteger(0) // Gas Value
    );


    var receipt = await emitInfectionEventFunction.SendTransactionAndWaitForReceiptAsync(
      transactionInput,
      null,
      request.Infection,
      request.Infectee,
      request.Tester,
      // new DateTimeOffset(request.TestTimestampUtc).ToUnixTimeSeconds().ToString(),
      "2024-05-14T13:56:35.196Z",
      request.SignatureBls
      );


    return new EmitInfectionEventResponse { Text = "Status: " + receipt.Status + ", transaction" + receipt.TransactionHash};
  }
}