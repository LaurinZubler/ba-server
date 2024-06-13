using ba_server.Models.Configuration;
using ba_server.Models.Requests;
using ba_server.Models.Responses;
using ba_server.Services.Interfaces;
using Microsoft.Extensions.Options;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace ba_server.Services;

public class UpsiContractService(IOptions<BlockchainOptions> blockchainOptions, IOptions<AzureOptions> azureOptions, ISecretsService secretsService)
  : IUpsiContractService
{
  private readonly BlockchainOptions _blockchain = blockchainOptions.Value;
  private readonly AzureOptions _azureOptions = azureOptions.Value;

  public async Task<EmitInfectionEventResponse> EmitInfectionEventAsync(EmitInfectionEventRequest request)
  {
    var infuraApiKey = await secretsService.Get(_azureOptions.InfuraApiKeyName);
    var privateKey = await secretsService.Get(_azureOptions.PrivateKeyName);

    var blockchainUrl = $"{_blockchain.Url}{infuraApiKey}";
    var account = new Account(privateKey, _blockchain.ChainId);
    var web3 = new Web3(account, blockchainUrl);
    var contract = web3.Eth.GetContract(_blockchain.UpsiABI, _blockchain.UpsiContractAddress);
    var emitInfectionEventFunction = contract.GetFunction(_blockchain.EmitInfectionEventFunctionName);

    var transactionInput = emitInfectionEventFunction.CreateTransactionInput(
      account.Address,
      new HexBigInteger(1000000), // Gas Limit
      new HexBigInteger(0) // Gas Value
    );

    long unixTimestamp = new DateTimeOffset(request.TestTime).ToUnixTimeSeconds();
    uint testTime = (uint)unixTimestamp;

    var receipt = await emitInfectionEventFunction.SendTransactionAndWaitForReceiptAsync(
      transactionInput,
      null, // Cancellation Token
      request.Infection,
      request.Infectee,
      request.Tester,
      testTime,
      request.Signature
    );

    return new EmitInfectionEventResponse { Status = receipt.Status.Value, TransactionHash = receipt.TransactionHash };
  }
}