using System;
using NBitcoin;
using System.Text;
using QBitNinja.Client;
using System.Threading.Tasks;


namespace blockchainfile
  
    class Program
    {
        static void Main(string[] args)
        {
          Network network = Network.TestNet;
          var treasurer = new BitcoinSecret("key")
          var alice = new BitcoinSecret("key");
          
          
          Console.WriteLine("treasurer key: " + treasurer.PrivateKey.GetWif(network));
          Console.WriteLine("Alice     key: " + alice.PrivateKey.GetWif(network));
          
          var scriptPubKey = PayToMultiSigTemplate
                .Instance
                .GenerateScriptPubKey(2, new[] { alice.PubKey, treasurer.PubKey });
          
          Console.WriteLine("PubKey script: " + scriptPubKey);
          
          var redeemScript = PayToMultiSigTemplate
            .Instance
            .GenerateScriptPubKey(2, new[] { bob.PubKey, alice.PubKey, treasurer.PubKey });

          var paymentScript = redeemScript.PaymentScript;
          Console.WriteLine("paymentScript: " + paymentScript);
          
          
          Console.WriteLine("multi-sig address: " + redeemScript.Hash.GetAddress(network));
          var client = new QBitNinjaClient(network);

            // Update
          var receiveTransactionId = uint256.Parse("yourid");
          var receiveTransactionResponse = client.GetTransaction(receiveTransactionId).Result;
          Console.WriteLine(receiveTransactionResponse.TransactionId);
         
          var receiveTransactionResponse = client.GetTransaction(receiveTransactionId).Result;

          Console.WriteLine(receiveTransactionResponse.TransactionId);
          Console.WriteLine(receiveTransactionResponse.Block.Confirmations);
           
          var receivedCoins = receiveTransactionResponse.ReceivedCoins;
          OutPoint outpointToSpend = null;
          ScriptCoin coinToSpend = null;
           
          foreach (var c in receivedCoins)
          {
                    try
                {
                    coinToSpend = new ScriptCoin(c.Outpoint, c.TxOut, redeemScript);
                    outpointToSpend = c.Outpoint;
                    break;
                }
                catch { }
           if (outpointToSpend == null)
                throw new Exception("TxOut doesn't contain any our ScriptPubKey");
                Console.WriteLine("outpoint #{0}");

          }
        }
    }
}


  
