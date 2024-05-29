using ba_server.Models.Configuration;
using ba_server.Models.Requests;
using ba_server.Models.Responses;
using ba_server.Services.Interfaces;
using Microsoft.Extensions.Options;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace ba_server.Services;

public class UpsiContractService : IUpsiContractService
{
  private readonly BlockchainOptions _blockchain;

  public UpsiContractService(IOptions<BlockchainOptions> blockchainOptions)
  {
    _blockchain = blockchainOptions.Value;
  }

  public async Task<EmitInfectionEventResponse> EmitInfectionEventAsync(EmitInfectionEventRequest request)
  {
    var blockchainUrl = $"{_blockchain.Url}{INFURA_API_KEY}";
    var account = new Account(OPTIMISM_SEPOLIA_PRIVATE_KEY, _blockchain.ChainId);

    var web3 = new Web3(account, blockchainUrl);
    var contract = web3.Eth.GetContract(_blockchain.UpsiABI, _blockchain.UpsiContractAddress);
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
      new DateTimeOffset(request.TestTimestampUtc).ToUnixTimeSeconds().ToString(),
      // "2024-05-14T13:56:35.196Z",
      request.SignatureBls
      );

    return new EmitInfectionEventResponse { Text = "Status: " + receipt.Status + ", transaction" + receipt.TransactionHash};
  }
}